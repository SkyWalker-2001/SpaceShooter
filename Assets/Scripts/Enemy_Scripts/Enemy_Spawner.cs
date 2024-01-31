using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Spawner : MonoBehaviour
{
    private Camera mainCam;
    private float maxLeft;
    private float maxRight;
    private float yPos;

    [Header("Enemy Prefabs")]
    [SerializeField] private GameObject[] enemys_Prefabs;
    private float enemyTimer;
    [Space(15)]
    [SerializeField]private float enemySpawnTime;

    [Header("Boss")]
    [SerializeField] private GameObject bossPrefab;
    [SerializeField] private Win_Condition winCondition;

    void Start()
    {
        mainCam = Camera.main;

        StartCoroutine(SetBoundaries());
    }

    private void Update() {
        Spawn_Enemy();
    }

    private void Spawn_Enemy(){
        enemyTimer += Time.deltaTime;
        if(enemyTimer >= enemySpawnTime){
            int randomPick = Random.Range(0,enemys_Prefabs.Length);
            Instantiate(enemys_Prefabs[randomPick], new Vector3(Random.Range(maxLeft, maxRight),yPos,0), Quaternion.identity);
            enemyTimer = 0;
        }
    }
    
    private IEnumerator SetBoundaries(){
        yield return new WaitForSeconds(0.2f);

        maxLeft = mainCam.ViewportToWorldPoint(new Vector2(0.15f,0)).x;
        maxRight = mainCam.ViewportToWorldPoint(new Vector2(0.85f,0)).x;

        yPos = mainCam.ViewportToWorldPoint(new Vector2(0,1.1f)).y;
    }

    private void OnBecameInvisible() {
        Destroy(gameObject);
    }
    private void OnDisable()
    {
        if (winCondition.canSpawnBoss == false) 
            return;

        if(bossPrefab != null)
        {
            Vector2 spawnPos = mainCam.ViewportToWorldPoint(new Vector2(0.5f, 1.2f));
            Instantiate(bossPrefab, spawnPos, Quaternion.identity);
        }
    }
}
