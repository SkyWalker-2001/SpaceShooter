using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Score_Display : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI score_TMP;
    [SerializeField] private TextMeshProUGUI high_Score_TMP;

    private void OnEnable()
    {
        int score = PlayerPrefs.GetInt("Score" + SceneManager.GetActiveScene().name, 0);
        score_TMP.text = "Score: " + score.ToString();

        int high_Score = PlayerPrefs.GetInt("High_Score" + SceneManager.GetActiveScene().name, 0);
        high_Score_TMP.text = "HighScore: " + high_Score.ToString();
    }
}
