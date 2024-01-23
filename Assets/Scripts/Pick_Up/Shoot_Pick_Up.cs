using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot_Pick_Up : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Player_Shooting player = collision.GetComponent<Player_Shooting>();
            player.Increase_Update(1);
            Destroy(gameObject);
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
