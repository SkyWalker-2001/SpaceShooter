using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Player_State : MonoBehaviour
{

    [SerializeField] private float maxHealth;
    [SerializeField] private Image fill_Image;
    [SerializeField] private GameObject Explosion_Prefab;
    [SerializeField] private Animator player_Animator;
    [SerializeField] private Shield shield;

    private Player_Shooting player_Shooting;

    private float health;
    private bool canPlaye_Anim = true;

    public bool canTakeDamage = true;

    void OnEnable()
    {
        health = maxHealth;
        fill_Image.fillAmount = health/maxHealth;
        End_Games_Manager.end_Games_Manager.gameOver = false;

        StartCoroutine(Damage_Protection());
    }

    private void Start()
    {
        player_Shooting = GetComponent<Player_Shooting>();

        End_Games_Manager.end_Games_Manager.RegisterPlayerState(this);
        
        End_Games_Manager.end_Games_Manager.possibleWin = false;
    }

    IEnumerator Damage_Protection()
    {
        canTakeDamage = false;
        yield return new WaitForSeconds(1.5f);
        canTakeDamage = true;
    }

    public void Player_TakeDamage(float damage)
    {
        if (canTakeDamage == false)
            return;

        if (shield.protection)
            return;

        health -= damage;
        Instantiate(Explosion_Prefab, transform.position, transform.rotation);

        player_Shooting.Decrease_Update(1);
        if(canPlaye_Anim){
            player_Animator.SetTrigger("Damage");
            StartCoroutine(AntiSpamAnimation());
        }

        fill_Image.fillAmount = health/maxHealth;

        if(health <= 0){

            End_Games_Manager.end_Games_Manager.gameOver = true;
            End_Games_Manager.end_Games_Manager.StartResolveSequence();
            Instantiate(Explosion_Prefab, transform.position, transform.rotation);
            //Destroy(gameObject);
            gameObject.SetActive(false);
        }
    }

    public void Add_Health(int healAmount)
    {
        health += healAmount;
        if (health > maxHealth)
            health = maxHealth;
        fill_Image.fillAmount = health / maxHealth;
    }

    private IEnumerator AntiSpamAnimation(){
        canPlaye_Anim = false;
        yield return new WaitForSeconds(.15f);
        canPlaye_Anim = true;
    }
}
