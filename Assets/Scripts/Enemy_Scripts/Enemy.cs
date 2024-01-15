using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] protected float health;
    [SerializeField] protected Rigidbody2D rb;

    void Start()
    {
        
    }

    public void Take_Damage( float dmg ){
        health -= dmg;
        Hurt_Sequence();

        if(health <= 0){
            Death_Sequence();
        }
    }

    public virtual void Hurt_Sequence(){

    }

    public virtual void Death_Sequence(){

    }
}
