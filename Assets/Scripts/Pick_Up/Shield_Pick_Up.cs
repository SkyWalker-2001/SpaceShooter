using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield_Pick_Up : MonoBehaviour
{
    [SerializeField] private AudioClip clipToPlay;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Player_Shield_Activator player_Shield_Activator = collision.GetComponent<Player_Shield_Activator>();
            player_Shield_Activator.Active_Shield();
            AudioSource.PlayClipAtPoint(clipToPlay, transform.position, 1f);
            Destroy(gameObject);
        }
        
    }
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
