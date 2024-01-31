using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win_Condition : MonoBehaviour
{
    private float timer;
    [SerializeField] private float possibleWin_time;
    [SerializeField] private GameObject[] spawner;
    [SerializeField] private bool hasBoss;

    public bool canSpawnBoss = false;
    private void Start() {
        
    }

    private void Update() {
        if (End_Games_Manager.end_Games_Manager.gameOver == true)
            return;
        timer += Time.deltaTime;
        if(timer >= possibleWin_time)
        {

            if (hasBoss == false)
            {
                End_Games_Manager.end_Games_Manager.possibleWin = true;
                End_Games_Manager.end_Games_Manager.StartResolveSequence();
            }
            else
            {
                canSpawnBoss = true;
            }

            for (int i = 0; i < spawner.Length; i++)
            {
                spawner[i].SetActive(false);
            }

            
            gameObject.SetActive(false);

            //End_Games_Manager.end_Games_Manager.ResolveGame();
        }
    }
}
