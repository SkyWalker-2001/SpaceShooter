using UnityEngine;

public class Purple_Enemy : Enemy
{
    [SerializeField] private float speed;
    private float shootTime = 0;
    [SerializeField]private float shoot_Interval;
    [SerializeField] private Transform Left_Canon;
    [SerializeField] private Transform Right_Canon;
    [SerializeField] private GameObject bulletPrefabs;
    void Start()
    {
        rb.velocity = Vector2.down * speed;
    }

    // Update is called once per frame
    void Update()
    {
        shootTime += Time.deltaTime;
        if(shootTime >= shoot_Interval){
            Instantiate(bulletPrefabs, Left_Canon.position, Quaternion.identity);
            Instantiate(bulletPrefabs, Right_Canon.position, Quaternion.identity);
            shootTime = 0;
        }
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
        if(anim.GetCurrentAnimatorStateInfo(0).IsTag("Dmg"))
            return;
        anim.SetTrigger("Damage");
    }

    public override void Death_Sequence()
    {
        Instantiate(explosion_Prefab, transform.position,transform.rotation);
        Destroy(gameObject);
    }

    private void OnBecameInvisible() {
        Destroy(gameObject);
    }
}
