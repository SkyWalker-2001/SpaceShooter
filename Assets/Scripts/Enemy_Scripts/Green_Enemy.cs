using UnityEngine;

public class Green_Enemy : Enemy
{
    [SerializeField] private float speed;
  
    void Start()
    {
        rb.velocity = Vector2.down * speed;
    }

    private void OnTriggerEnter2D(Collider2D collider) {
        if(collider.CompareTag("Player")){
            collider.GetComponent<Player_State>().Player_TakeDamage(damage);
            Instantiate(explosion_Prefab, transform.position,transform.rotation);
            Destroy(gameObject);
        }
    }

    public override void Hurt_Sequence()
    {
        if(anim.GetCurrentAnimatorStateInfo(0).IsTag("Green_Dmg"))
            return;
        anim.SetTrigger("Damage");
    }

    public override void Death_Sequence()
    {
        base.Death_Sequence();
        Instantiate(explosion_Prefab, transform.position,transform.rotation);
        Destroy(gameObject);
    }

    private void OnBecameInvisible() {
        Destroy(gameObject);
    }
}
