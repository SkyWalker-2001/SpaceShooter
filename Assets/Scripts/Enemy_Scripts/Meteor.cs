using UnityEngine;

public class Meteor : Enemy
{

    [SerializeField] protected float minSpeed;
    [SerializeField] protected float maxSpeed;

    [SerializeField] private float rotating_Speed;
    private float speed;

    void Start()
    {
        speed = Random.Range(minSpeed, maxSpeed);
        rb.velocity = Vector2.down * speed;
    }

    void Update()
    {
        transform.Rotate(0,0,rotating_Speed * Time.deltaTime);
    }

    public override void Hurt_Sequence()
    {
       // base.Hurt_Sequence();  Optional
    }

    public override void Death_Sequence()
    {
      //  base.Death_Sequence(); Optional
      Instantiate(explosion_Prefab, transform.position, transform.rotation);
      Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D otherCollider) {
        if(otherCollider.gameObject.CompareTag("Player"))
        {
            Player_State player_State = otherCollider.GetComponent<Player_State>();
            player_State.Player_TakeDamage(damage);
            Destroy(gameObject);
        }
    }

}
