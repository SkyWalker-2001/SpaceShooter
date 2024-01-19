using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button_Controller : MonoBehaviour
{
    public void LoadLevelByString(string level_String)
    {
        Fade_canvas.fader.FaderLoader_String(level_String);
    }

    public void LoadLevelByInt(int level_Int)
    {
        Fade_canvas.fader.FaderLoader_Int(level_Int);
    }

    public void Reset_Level()
    {
        Fade_canvas.fader.FaderLoader_Int(SceneManager.GetActiveScene().buildIndex);
    }
}
