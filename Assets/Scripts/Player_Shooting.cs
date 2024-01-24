using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Shooting : MonoBehaviour
{

    [SerializeField] private GameObject laser_Bullet_Prefab;
    [SerializeField] private float shooting_Interval;

    [Header("Basic Attack")]
    [SerializeField] private Transform Shooting_Point;

    [Header("Upgrade Points")]
    [SerializeField] private Transform left_Canon;
    [SerializeField] private Transform right_Canon;
    [SerializeField] private Transform secondLeft_Canon;
    [SerializeField] private Transform secondRight_Canon;

    [Header("Upgrade Rotation Points")]
    [SerializeField] private Transform LeftRotation_Canon;
    [SerializeField] private Transform RightRotation_Canon;

    [SerializeField] private AudioSource audioSource;

    private int upgrade_Level = 0;

    private float interval_Reset;
 
    void Start()
    {
        interval_Reset = shooting_Interval;
    }

    void Update()
    {
        shooting_Interval -= Time.deltaTime;
        if(shooting_Interval <= 0){

            Shoot();

            shooting_Interval = interval_Reset;
        }
    }

    public void Increase_Update(int increase_Amount)
    {
        upgrade_Level += increase_Amount;
        if(upgrade_Level > 4)
        {
            upgrade_Level = 4;
        }
    }

    public void Decrease_Update(int decrease_Amount)
    {
        upgrade_Level -= decrease_Amount;
        if(upgrade_Level < 0)
        {
            upgrade_Level = 0;
        }
    }

    private void Shoot(){
        
        switch(upgrade_Level)
        {
            case 0:
                Instantiate(laser_Bullet_Prefab, Shooting_Point.position, Quaternion.identity);
                break;

            case 1:
                Instantiate(laser_Bullet_Prefab, left_Canon.position, Quaternion.identity);
                Instantiate(laser_Bullet_Prefab, right_Canon.position, Quaternion.identity);
                break;
            case 2:
                Instantiate(laser_Bullet_Prefab, Shooting_Point.position, Quaternion.identity);
                Instantiate(laser_Bullet_Prefab, left_Canon.position, Quaternion.identity);
                Instantiate(laser_Bullet_Prefab, right_Canon.position, Quaternion.identity);
                break;
            case 3:
                Instantiate(laser_Bullet_Prefab, Shooting_Point.position, Quaternion.identity);
                Instantiate(laser_Bullet_Prefab, left_Canon.position, Quaternion.identity);
                Instantiate(laser_Bullet_Prefab, secondLeft_Canon.position, Quaternion.identity);
                Instantiate(laser_Bullet_Prefab, right_Canon.position, Quaternion.identity);
                Instantiate(laser_Bullet_Prefab, secondRight_Canon.position, Quaternion.identity);
                break;
            case 4:
                Instantiate(laser_Bullet_Prefab, Shooting_Point.position, Quaternion.identity);
                Instantiate(laser_Bullet_Prefab, left_Canon.position, Quaternion.identity);
                Instantiate(laser_Bullet_Prefab, secondLeft_Canon.position, Quaternion.identity);
                Instantiate(laser_Bullet_Prefab, right_Canon.position, Quaternion.identity);
                Instantiate(laser_Bullet_Prefab, secondRight_Canon.position, Quaternion.identity);

                Instantiate(laser_Bullet_Prefab, LeftRotation_Canon.position, LeftRotation_Canon.rotation);
                Instantiate(laser_Bullet_Prefab, RightRotation_Canon.position, RightRotation_Canon.rotation);
                break;
        }
    }
}
