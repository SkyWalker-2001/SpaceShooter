using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Laser_Projectile : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float speed;
    [SerializeField] private float damage;

    private ObjectPool<Laser_Projectile> reference_Pool;

    void OnEnable()
    {
        rb.velocity = Vector2.up * speed;
    }

    private void OnDisable()
    {
        transform.rotation = Quaternion.Euler(0, 0, 0);
    }

    public void SetPool(ObjectPool<Laser_Projectile> pool)
    {
        reference_Pool = pool;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        Enemy enemy = other.GetComponent<Enemy>();
        enemy.Take_Damage(damage);
        if (gameObject.activeSelf)
            reference_Pool.Release(this);
        //Destroy(gameObject);
    }

    public void SetDirectionAndSpeed()
    {
        rb.velocity = Vector2.up * speed;

    }

    private void OnBecameInvisible()
    {
        if(gameObject.activeSelf)
            reference_Pool.Release(this);
        //Destroy(gameObject);
    }
}
