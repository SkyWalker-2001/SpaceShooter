using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Special_Attack : Boss_BaseState
{
    [SerializeField] private float speed;
    [SerializeField] private float waitTime;
    [SerializeField] private GameObject specialBullet;
    [SerializeField] private Transform shootingPoints;

    private Vector2 targetPoint;

    protected override void Start()
    {
        targetPoint = mainCam.ViewportToWorldPoint(new Vector2(0.5f,0.9f));
    }

    public override void RunState()
    {
        StartCoroutine(RunSpecial_State());
    }

    public override void StopState()
    {
        base.StopState();
    }

    IEnumerator RunSpecial_State()
    {
        while(Vector2.Distance(transform.position, targetPoint) > 0.01f)
        {
            transform.position = Vector2.MoveTowards(transform.position, targetPoint, speed * Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }
        Instantiate(specialBullet, shootingPoints.position, Quaternion.identity);
        yield return new WaitForSeconds(waitTime);
        boss_Controller.ChangeState(Boss_State.fire);
    }
}
