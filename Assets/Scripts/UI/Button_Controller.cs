using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button_Controller : MonoBehaviour
{
    public void LoadLevelByString(string level_String)
    {
        SceneManager.LoadScene(level_String);
    }

    public void LoadLevelByInt(string level_Int)
    {
        SceneManager.LoadScene(level_Int);
    }

    public void Reset_Level()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
