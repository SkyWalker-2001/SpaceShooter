using UnityEngine;

public class Meteor : Enemy
{

    [SerializeField] protected float minSpeed;
    [SerializeField] protected float maxSpeed;

    private float speed;

    void Start()
    {
        speed = Random.Range(minSpeed, maxSpeed);
        rb.velocity = Vector2.down * speed;
    }

    void Update()
    {
        
    }

    public override void Hurt_Sequence()
    {
       // base.Hurt_Sequence();  Optional
    }

    public override void Death_Sequence()
    {
      //  base.Death_Sequence(); Optional
    }

}
