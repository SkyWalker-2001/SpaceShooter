using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score_Registration : MonoBehaviour
{
    private void Start()
    {
        TextMeshProUGUI textForResistration = GetComponent<TextMeshProUGUI>();
        End_Games_Manager.end_Games_Manager.Register_Score_Text(textForResistration);
        textForResistration.text = "Score: 0";
    }
}
