using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Stats : Enemy
{
    [SerializeField] private Boss_Controller boss_Controller;

    public override void Hurt_Sequence()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsTag("Dmg"))
            return;
        anim.SetTrigger("Damage");
    }

    public override void Death_Sequence()
    {
        base.Death_Sequence();
        boss_Controller.ChangeState(Boss_State.death);
        Instantiate(explosion_Prefab, transform.position, Quaternion.Euler(0, 0, Random.Range(0,360)));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<Player_State>().Player_TakeDamage(damage);
        }
    }
}
