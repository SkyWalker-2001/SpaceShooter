using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Fire : Boss_BaseState
{
    [SerializeField] private float speed;
    [SerializeField] private float shoot_Rate;
    [SerializeField] private GameObject bullet_Prefab;
    [Header("Shooting Points")]
    [SerializeField] private Transform[] shootPoint;

    public override void RunState()
    {
        StartCoroutine(RunFire_State());
    }

    public override void StopState()
    {
        base.StopState();
    }

    IEnumerator RunFire_State()
    {
        float shootTime = 0f;
        float fireStateTimer = 0f;
        float fireStateExitTime = Random.Range(5f, 10f);
        Vector2 targetPosition = new Vector2(Random.Range(maxLeft, maxRight), Random.Range(maxDown, maxUp));
        while(fireStateTimer <= fireStateExitTime)
        {
            if (Vector2.Distance(transform.position, targetPosition) > 0.01f)
            {
                transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
            }
            else
            {
                targetPosition = new Vector2(Random.Range(maxLeft, maxRight), Random.Range(maxDown, maxUp));
            }
            shootTime += Time.deltaTime;
            if(shootTime >= shoot_Rate)
            {
                for(int i = 0; i < shootPoint.Length; i++)
                {
                    Instantiate(bullet_Prefab, shootPoint[i].position, Quaternion.identity);
                }
                shootTime = 0f;
            }
            yield return new WaitForEndOfFrame();
            fireStateTimer += Time.deltaTime;
        }

        int randomPick = Random.Range(0, 2);
        if (randomPick == 0)
        {
            boss_Controller.ChangeState(Boss_State.fire);
        }
        else
        {
            boss_Controller.ChangeState(Boss_State.special);
        }
    }
}
