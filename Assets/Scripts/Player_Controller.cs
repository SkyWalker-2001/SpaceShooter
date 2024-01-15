using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;
using TouchPhase = UnityEngine.InputSystem.TouchPhase;


public class Player_Controller : MonoBehaviour
{

    private Camera mainCam;
    private Vector3 offSet;

    void Start()
    {
        mainCam = Camera.main;
    }


    private void OnEnable() {
        EnhancedTouchSupport.Enable();
    }

    private void OnDisable() {
        EnhancedTouchSupport.Disable();
    }

    void Update()
    {
        if(Touch.fingers[0].isActive){
            
            Touch myTouch = Touch.activeTouches[0];
            Vector3 touchPos = myTouch.screenPosition;
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

        }
    }
}
