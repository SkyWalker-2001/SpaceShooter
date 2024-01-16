using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Player_State : MonoBehaviour
{

    [SerializeField] private float maxHealth;
    [SerializeField] private Image fill_Image;
    [SerializeField] private GameObject Explosion_Prefab;
    [SerializeField] private Animator player_Animator;

    private float health;
    private bool canPlaye_Anim = true;
    void Start()
    {
        health = maxHealth;
        fill_Image.fillAmount = health/maxHealth;
    }

    public void Player_TakeDamage(float damage){
        health -= damage;
        Instantiate(Explosion_Prefab, transform.position, transform.rotation);

        if(canPlaye_Anim){
            player_Animator.SetTrigger("Damage");
            StartCoroutine(AntiSpamAnimation());
        }

        fill_Image.fillAmount = health/maxHealth;

        if(health <= 0){

            Instantiate(Explosion_Prefab, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }

    private IEnumerator AntiSpamAnimation(){
        canPlaye_Anim = false;
        yield return new WaitForSeconds(.15f);
        canPlaye_Anim = true;
    }
}
