using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Shooting : MonoBehaviour
{

    [SerializeField] private GameObject laser_Bullet_Prefab;
    [SerializeField] private Transform Shooting_Point;

    [SerializeField] private float shooting_Interval;

    private float interval_Reset;
 
    void Start()
    {
        interval_Reset = shooting_Interval;
    }

    // Update is called once per frame
    void Update()
    {
        shooting_Interval -= Time.deltaTime;
        if(shooting_Interval <= 0){

            Shoot();

            shooting_Interval = interval_Reset;
        }
    }

    private void Shoot(){
        Instantiate(laser_Bullet_Prefab, Shooting_Point.position, Quaternion.identity);
    }
}
