 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Special_Bullet : MonoBehaviour
{
    [SerializeField] private float damage;
    [SerializeField] private float speed;
    [SerializeField] private float rotateSpeed;
    [SerializeField] private Rigidbody2D rb;

    [SerializeField] private GameObject mini_Bullet;
    [SerializeField] private Transform[] spawn_Point;

    private void Start()
    {
        rb.velocity = Vector2.down * speed;
        StartCoroutine(Explode());
    }

    private void Update()
    {
        transform.Rotate(0, 0, rotateSpeed * Time.deltaTime);
    }
    
    IEnumerator Explode()
    {
        float randomExplodeTime = Random.Range(1.5f, 2.5f);
        yield return new WaitForSeconds(randomExplodeTime);
        for(int i = 0; i < spawn_Point.Length; i++)
        {
            Instantiate(mini_Bullet, spawn_Point[i].position, spawn_Point[i].rotation);
        }
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<Player_State>().Player_TakeDamage(damage);
            Destroy(gameObject);
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
