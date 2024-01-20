using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Button_Icon : MonoBehaviour
{
    [SerializeField] private Button[] lvl_Button;
    [SerializeField] private Sprite unlocked_Icon;
    [SerializeField] private Sprite locaked_Icone;
    [SerializeField] private int firstLevel_BuildIndex;

    private void Awake()
    {
        int unlocked_Lvl = PlayerPrefs.GetInt(End_Games_Manager.end_Games_Manager.lvl_Unlock, firstLevel_BuildIndex);

        for (int i = 0; i < lvl_Button.Length; i++)
        {
            if (i + firstLevel_BuildIndex <= unlocked_Lvl)
            {
                lvl_Button[i].interactable = true;
                lvl_Button[i].image.sprite = unlocked_Icon;
                TextMeshProUGUI text_Button = lvl_Button[i].GetComponentInChildren<TextMeshProUGUI>();
                text_Button.text = (i + 1).ToString();
                text_Button.enabled = true;
            }
            else
            {
                lvl_Button[i].interactable = false;
                lvl_Button[i].image.sprite= locaked_Icone;
                lvl_Button[i].GetComponentInChildren<TextMeshProUGUI>().enabled = false;
            }

           
        }
        
    }
}
