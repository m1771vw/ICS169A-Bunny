using UnityEngine;
using System.Collections;

public class Touchv2 : MonoBehaviour {
private Vector2 leftFingerPos;
private Vector2 leftFingerLastPos;
private Vector2 leftFingerMovedBy;
 
public float slideMagnitudeX = 0.0f;
public float slideMagnitudeY = 0.0f; 
void Update()
    {
        if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                leftFingerPos = Vector2.zero;
                leftFingerLastPos = Vector2.zero;
                leftFingerMovedBy = Vector2.zero;

                slideMagnitudeX = 0;
                slideMagnitudeY = 0;

                // record start position
                leftFingerPos = touch.position;

            }

            else if (touch.phase == TouchPhase.Moved)
            {
                leftFingerMovedBy = touch.position - leftFingerPos; // or Touch.deltaPosition : Vector2
                                                                    // The position delta since last change.
                leftFingerLastPos = leftFingerPos;
                leftFingerPos = touch.position;

                // slide horz
                slideMagnitudeX = leftFingerMovedBy.x / Screen.width;

                // slide vert
                slideMagnitudeY = leftFingerMovedBy.y / Screen.height;

            }

            else if (touch.phase == TouchPhase.Stationary)
            {
                leftFingerLastPos = leftFingerPos;
                leftFingerPos = touch.position;

                slideMagnitudeX = 0.0f;
                slideMagnitudeY = 0.0f;
            }

            else if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)
            {
                slideMagnitudeX = 0.0f;
                slideMagnitudeY = 0.0f;
                Destroy(this.gameObject);
            }
        }
    }
}
