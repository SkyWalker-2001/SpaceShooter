using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor.SearchService;
using UnityEngine.SceneManagement;

public class End_Games_Manager : MonoBehaviour
{
    public static End_Games_Manager end_Games_Manager;

    private Panel_Controller panel_Controller;
    private TextMeshProUGUI scoreTextMeshPro;
    private Player_State player;
    private Rewarded_Ad rewardedAd;
    
    public bool gameOver;
    public bool possibleWin;

    public int Score;

    [HideInInspector]
    public string lvl_Unlock = "LevelUnlock";

    private void Awake() {

        if(end_Games_Manager == null){
            
            end_Games_Manager = this;
            DontDestroyOnLoad(gameObject);
        }
        else{
            Destroy(gameObject);
        }
    }

    private void Start() 
    {
        
    }

    public void StartResolveSequence()
    {
        StopCoroutine(nameof(ResolveSequence));
        StartCoroutine(ResolveSequence());
    }

    private IEnumerator ResolveSequence()
    {
        yield return new WaitForSeconds(2.5f);
        ResolveGame();
    }
    public void ResolveGame()
    {
        if(possibleWin == true && gameOver == false)
        {
            Win_Game();
        }
        else if(possibleWin == false && gameOver == true)
        {
            Ad_Lose_Game();
        }
        else if (possibleWin == true && gameOver == true)
        {
            Lose_Game();
        }
    }

    public void UpdateScore(int addScore)
    {
        Score += addScore;
        scoreTextMeshPro.text = "Score: " + Score.ToString();
    }

    public void Win_Game()
    {
        player.canTakeDamage = false;

        Set_Score();
        panel_Controller.Activate_Win_Screen_Panel();

        int next_Level = SceneManager.GetActiveScene().buildIndex + 1;
        if (next_Level > PlayerPrefs.GetInt(lvl_Unlock, 0))
        {
            PlayerPrefs.SetInt(lvl_Unlock, next_Level);
        }
    }

    public void Lose_Game(){
        Set_Score();
        panel_Controller.Activate_Lose_Screen_Panel();
    }

    public void Ad_Lose_Game()
    {
        Set_Score();
        if(rewardedAd.adNumber > 0)
        {
            rewardedAd.adNumber -= 1;
            panel_Controller.Activate_Ad_Lose_Screen_Panel();
        }
        else
        {
            panel_Controller.Activate_Lose_Screen_Panel();
        }
    }
    public void Set_Score()
    {
        PlayerPrefs.SetInt("Score" + SceneManager.GetActiveScene().name, Score);
        int highScore = PlayerPrefs.GetInt("High_Score" + SceneManager.GetActiveScene().name, 0);

        if(Score > highScore)
        {
            PlayerPrefs.SetInt("High_Score" + SceneManager.GetActiveScene().name, Score);
        }
        Score = 0;
    }

    public void RegisterPanelController(Panel_Controller pC){
        panel_Controller = pC;
    }

    public void Register_Score_Text(TextMeshProUGUI score_TMP)
    {
        scoreTextMeshPro = score_TMP;
    }

    public void RegisterPlayerState(Player_State player_State)
    {
        player = player_State;
    }

    public void RegisterRewardedAd(Rewarded_Ad ad)
    {
        rewardedAd = ad;
    }
}
