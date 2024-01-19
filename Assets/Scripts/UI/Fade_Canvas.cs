using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Fade_canvas : MonoBehaviour
{
    public static Fade_canvas fader;

    [SerializeField] private CanvasGroup _canvasGroup;
    [SerializeField] private GameObject loading_Screen;
    [SerializeField] private Image loading_Bar;
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
        loading_Screen.SetActive(false);

        fadeStarted = false;
        while(_canvasGroup.alpha > 0)
        {
            if(fadeStarted)
                yield break;
            _canvasGroup.alpha -= changeValue;
            yield return new WaitForSeconds(wait_Time); 
        }
    }

    private IEnumerator FadeOut_String(string level_Name)
    {
        // Until fade in disappear player controles is on hold 
        //if (_canvasGroup.alpha != 0)
        //    yield break;

        if(fadeStarted)
            yield break;
        fadeStarted = true;
        while(_canvasGroup.alpha < 1)
        {
            _canvasGroup.alpha += changeValue;
            yield return new WaitForSeconds(wait_Time);
        }
        //SceneManager.LoadScene(level_Name);

        // --------------------------------------------------------------IMP------------------------------------------ //

        // 0 --- 0.9 --- 1

        // https://www.udemy.com/course/unitymobilecourse/learn/lecture/37102592#content

        AsyncOperation ao = SceneManager.LoadSceneAsync(level_Name);
        ao.allowSceneActivation = false;
        loading_Screen.SetActive(true);
        loading_Bar.fillAmount = 0;

        while (ao.isDone == false)
        {
            loading_Bar.fillAmount = ao.progress / 0.9f;

            if(ao.progress == 0.9f)
            {
                ao.allowSceneActivation = true;
            }
            yield return null;
        }


        // ---------------------------------------------------------------------------------------------------------- //

        // yield return new WaitForSeconds(.1f);
        StartCoroutine(FadeIn());
    }  
    
    private IEnumerator FadeOut_Int(int level_Index)
    {
        if(fadeStarted)
            yield break;
        fadeStarted = true;
        while(_canvasGroup.alpha < 1)
        {
            _canvasGroup.alpha += changeValue;
            yield return new WaitForSeconds(wait_Time);
        }
        //SceneManager.LoadScene(level_Number);

        AsyncOperation ao = SceneManager.LoadSceneAsync(level_Index);
        ao.allowSceneActivation = false;
        loading_Screen.SetActive(true);
        loading_Bar.fillAmount = 0;

        while (ao.isDone == false)
        {
            loading_Bar.fillAmount = ao.progress / 0.9f;

            if (ao.progress == 0.9f)
            {
                ao.allowSceneActivation = true;
            }
            yield return null;
        }

        //yield return new WaitForSeconds(.1f);
        StartCoroutine(FadeIn());
    }
}
