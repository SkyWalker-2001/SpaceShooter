using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

[CreateAssetMenu(menuName = "PowerUp_Spawner", fileName = "Spawenr")]

public class Scriptable_Obj : ScriptableObject
{
    public int spawnThreshold;
    public GameObject[] power_Up;

    public void Spawn_PowerUp(Vector3 spawn_Pos)
    {
        int randomChance = Random.Range(0, 100);
        if ( randomChance > spawnThreshold )
        {
            int random_PowerUp = Random.Range(0, power_Up.Length);
            Instantiate(power_Up[random_PowerUp], spawn_Pos, Quaternion.identity);
        }
       
    }
}
