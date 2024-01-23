using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield_Pick_Up : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player_Shield_Activator player_Shield_Activator = collision.GetComponent<Player_Shield_Activator>();
        player_Shield_Activator.Active_Shield();
        Destroy(gameObject);
    }
}
