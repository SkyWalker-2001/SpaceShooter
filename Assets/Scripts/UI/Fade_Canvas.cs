using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fade_canvas : MonoBehaviour
{
    public static Fade_canvas fader;

    [SerializeField] private CanvasGroup _canvasGroup;
    [SerializeField] private float changeValue;
    [SerializeField] private float wait_Time;
    [SerializeField] private bool fadeStarted = false;

    private void Awake()
    {
        if(fader == null)
        {
            fader = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        StartCoroutine(FadeIn());
    }

    public void FaderLoader_String(string level_name)
    {
        StartCoroutine(FadeOut_String(level_name));
    }   
    public void FaderLoader_Int(int level_number)
    {
        StartCoroutine(FadeOut_Int(level_number));
    }

    private IEnumerator FadeIn()
    {
        fadeStarted = false;
        while(_canvasGroup.alpha > 0)
        {
            _canvasGroup.alpha -= changeValue;
            yield return new WaitForSeconds(wait_Time); 
        }
    }

    private IEnumerator FadeOut_String(string level_Name)
    {
        if(fadeStarted)
            yield break;
        fadeStarted = true;
        while(_canvasGroup.alpha < 1)
        {
            _canvasGroup.alpha += changeValue;
            yield return new WaitForSeconds(wait_Time);
        }
        SceneManager.LoadScene(level_Name);
        yield return new WaitForSeconds(.1f);
        StartCoroutine(FadeIn());
    }  
    
    private IEnumerator FadeOut_Int(int level_Number)
    {
        if(fadeStarted)
            yield break;
        fadeStarted = true;
        while(_canvasGroup.alpha < 1)
        {
            _canvasGroup.alpha += changeValue;
            yield return new WaitForSeconds(wait_Time);
        }
        SceneManager.LoadScene(level_Number);
        yield return new WaitForSeconds(.1f);
        StartCoroutine(FadeIn());
    }
}
