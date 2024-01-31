using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Panel_Controller : MonoBehaviour
{
    [SerializeField] private CanvasGroup cGroup;
    [SerializeField] private GameObject Win_Screen;
    [SerializeField] private GameObject Lose_Screen;
    [SerializeField] private GameObject Ad_Lose_Screen;

    void Start()
    {
        End_Games_Manager.end_Games_Manager.RegisterPanelController(this);
    }

    public void Activate_Win_Screen_Panel(){
        cGroup.alpha = 1;
        Win_Screen.SetActive(true);
    }

    public void Activate_Lose_Screen_Panel(){
        cGroup.alpha = 1;
        Lose_Screen.SetActive(true);
    }

    public void Activate_Ad_Lose_Screen_Panel(){
        cGroup.alpha = 1;
        Ad_Lose_Screen.SetActive(true);
    }
    
    public void Deactivate_Ad_Lose_Screen(){
        cGroup.alpha = 0;
        Ad_Lose_Screen.SetActive(false);
    }
}
