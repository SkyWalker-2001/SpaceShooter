
using UnityEngine;
using UnityEngine.Pool;

public class Player_Shooting : MonoBehaviour
{

    [SerializeField] private Laser_Projectile laser_Bullet_Prefab;
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

    private ObjectPool<Laser_Projectile> pool;

    private float interval_Reset;

    private void Awake()
    {
        pool = new ObjectPool<Laser_Projectile>(CreatePoolObj, OnTake_ProjectileFormPool, OnReturnBulletFromPool, OnDestroyPoolObj, true, 10, 30);
    }

    void Start()
    {
        interval_Reset = shooting_Interval;
    }

    private void OnDestroyPoolObj(Laser_Projectile laser_Projectile)
    {
        Destroy(laser_Projectile.gameObject);
    }

    private Laser_Projectile CreatePoolObj()
    {
        Laser_Projectile projectile = Instantiate(laser_Bullet_Prefab, transform.position, transform.rotation);
        projectile.SetPool(pool);
        return projectile;
    }

    private void OnTake_ProjectileFormPool(Laser_Projectile laser_Projectile)
    {
        laser_Projectile.gameObject.SetActive(true);
    }
    
    private void OnReturnBulletFromPool(Laser_Projectile laser_Projectile)
    {
        laser_Projectile.gameObject.SetActive(false);
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
                //Instantiate(laser_Bullet_Prefab, Shooting_Point.position, Quaternion.identity);
                
                pool.Get().transform.position = Shooting_Point.position;
                break;

            case 1:
                //Instantiate(laser_Bullet_Prefab, left_Canon.position, Quaternion.identity);
                //Instantiate(laser_Bullet_Prefab, right_Canon.position, Quaternion.identity);
                
                pool.Get().transform.position = left_Canon.position;
                pool.Get().transform.position = right_Canon.position;

                break;
            case 2:
                //Instantiate(laser_Bullet_Prefab, Shooting_Point.position, Quaternion.identity);
                //Instantiate(laser_Bullet_Prefab, left_Canon.position, Quaternion.identity);
                //Instantiate(laser_Bullet_Prefab, right_Canon.position, Quaternion.identity);

                pool.Get().transform.position = Shooting_Point.position;
                pool.Get().transform.position = left_Canon.position;
                pool.Get().transform.position = right_Canon.position;

                break;
            case 3:
                //Instantiate(laser_Bullet_Prefab, Shooting_Point.position, Quaternion.identity);
                //Instantiate(laser_Bullet_Prefab, left_Canon.position, Quaternion.identity);
                //Instantiate(laser_Bullet_Prefab, secondLeft_Canon.position, Quaternion.identity);
                //Instantiate(laser_Bullet_Prefab, right_Canon.position, Quaternion.identity);
                //Instantiate(laser_Bullet_Prefab, secondRight_Canon.position, Quaternion.identity);

                pool.Get().transform.position = Shooting_Point.position;
                pool.Get().transform.position = left_Canon.position;
                pool.Get().transform.position = right_Canon.position;
                pool.Get().transform.position = secondLeft_Canon.position;
                pool.Get().transform.position = secondRight_Canon.position;

                break;
            case 4:
                //Instantiate(laser_Bullet_Prefab, Shooting_Point.position, Quaternion.identity);
                //Instantiate(laser_Bullet_Prefab, left_Canon.position, Quaternion.identity);
                //Instantiate(laser_Bullet_Prefab, secondLeft_Canon.position, Quaternion.identity);
                //Instantiate(laser_Bullet_Prefab, right_Canon.position, Quaternion.identity);
                //Instantiate(laser_Bullet_Prefab, secondRight_Canon.position, Quaternion.identity);

                pool.Get().transform.position = Shooting_Point.position;
                pool.Get().transform.position = left_Canon.position;
                pool.Get().transform.position = right_Canon.position;
                pool.Get().transform.position = secondLeft_Canon.position;
                pool.Get().transform.position = secondRight_Canon.position;

                Laser_Projectile laserL = pool.Get();
                laserL.transform.position = LeftRotation_Canon.position;
                laserL.transform.rotation = LeftRotation_Canon.rotation;
                laserL.SetDirectionAndSpeed();
                
                Laser_Projectile laserR = pool.Get();
                laserR.transform.position = RightRotation_Canon.position;
                laserR.transform.rotation = RightRotation_Canon.rotation;
                laserR.SetDirectionAndSpeed();

                //Instantiate(laser_Bullet_Prefab, LeftRotation_Canon.position, LeftRotation_Canon.rotation);
                //Instantiate(laser_Bullet_Prefab, RightRotation_Canon.position, RightRotation_Canon.rotation);
                break;
        }
    }
}
