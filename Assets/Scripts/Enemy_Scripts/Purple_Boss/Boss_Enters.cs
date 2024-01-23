using System.Collections;
using UnityEngine;

public class Boss_Enters : Boss_BaseState
{
    private Vector2 enter_Point;
    [SerializeField] private float speed;

    protected override void Start()
    {
        base.Start();
        enter_Point = mainCam.ViewportToWorldPoint(new Vector2(0.5f,0.7f));
    }

    public override void RunState()
    {
        StartCoroutine(RunEnterState());
    }

    public override void StopState()
    {
        base.StopState();
    }
    IEnumerator RunEnterState()
    {
        while (Vector2.Distance(transform.position, enter_Point) > 0.01f)
        {
            transform.position = Vector2.MoveTowards(transform.position, enter_Point, speed * Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }
        boss_Controller.ChangeState(Boss_State.fire);
    }
}
