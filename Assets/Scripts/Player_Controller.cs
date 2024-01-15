
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;
using TouchPhase = UnityEngine.InputSystem.TouchPhase;


public class Player_Controller : MonoBehaviour
{

    private Camera mainCam;
    private Vector3 offSet;

    private float maxLeft;
    private float maxRight;

    private float maxUp;
    private float maxDown;

    void Start()
    {
        mainCam = Camera.main;

        StartCoroutine(SetBoundaries());

    }


    private void OnEnable() {
        EnhancedTouchSupport.Enable();
    }

    private void OnDisable() {
        EnhancedTouchSupport.Disable();
    }

    void Update()
    {

        // if(Touch.activeTouches.Count > 0){
        //     if(Touch.activeTouches[0].finger.index == 0){

        //     }
        // }

        if(Touch.fingers[0].isActive){
            
            Touch myTouch = Touch.activeTouches[0];
            Vector3 touchPos = myTouch.screenPosition;


#if UNITY_EDITOR
        
        if(touchPos.x == Mathf.Infinity){
            return;
        }

#endif

            touchPos = mainCam.ScreenToWorldPoint(touchPos);

            if(Touch.activeTouches[0].phase == TouchPhase.Began){
                offSet = touchPos - transform.position;
            }
            if(Touch.activeTouches[0].phase == TouchPhase.Moved){
                transform.position = new Vector3(touchPos.x - offSet.x, touchPos.y - offSet.y,0);
            }
            if(Touch.activeTouches[0].phase == TouchPhase.Stationary){
                transform.position = new Vector3(touchPos.x - offSet.x, touchPos.y - offSet.y,0);
            }

            transform.position = new Vector3(Mathf.Clamp(transform.position.x,maxLeft,maxRight),Mathf.Clamp(transform.position.y, maxDown,maxUp),0);
        }
    }

    private IEnumerator SetBoundaries(){
        yield return new WaitForSeconds(0.2f);

        maxLeft = mainCam.ViewportToWorldPoint(new Vector2(0.15f,0)).x;
        maxRight = mainCam.ViewportToWorldPoint(new Vector2(0.85f,0)).x;

        maxDown = mainCam.ViewportToWorldPoint(new Vector2(0, 0.07f)).y;
        maxUp = mainCam.ViewportToWorldPoint(new Vector2(0,0.9f)).y;
    }
}
