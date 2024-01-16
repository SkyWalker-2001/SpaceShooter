using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win_Condition : MonoBehaviour
{
    private float timer;
    [SerializeField] private float possibleWin_time;
    [SerializeField] private GameObject[] spawner;

    private void Start() {
        
    }

    private void Update() {
        timer += Time.deltaTime;
        if(timer >= possibleWin_time){
            for(int i = 0; i < spawner.Length; i++){
                spawner[i].SetActive(false);
            }
        }
    }
}
