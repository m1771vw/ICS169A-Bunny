using UnityEngine;
using System.Collections;

public class ClickAndFling : MonoBehaviour
{
    private GameObject currentObject;
    private SpringJoint2D spring;

    /// <summary>
    /// We are connecting an object to the mouse though a spring joint that will allow it to take on the velocity and acceleration of the mouse
    /// </summary>
    void Start()
    {
        currentObject = this.gameObject;
    }
    /// <summary>
    /// when object is clicked on a spring is added to it
    /// then set the anchor to be the current mouse position
    /// SET ALL SPRING PROPS IN HERE
    /// </summary>
    void OnMouseDown()
    {
        spring = currentObject.AddComponent<SpringJoint2D>() as SpringJoint2D;
        //allows oject collision when attached not the collsion of the line drawn to be the spring
        currentObject.GetComponent<SpringJoint2D>().enableCollision = true;
        //distance from spring to object
        currentObject.GetComponent<SpringJoint2D>().distance = .00005f;

        spring = this.gameObject.GetComponent<SpringJoint2D>(); 

        spring.connectedAnchor = gameObject.transform.position;

        spring.enabled = true;
    }

    /// <summary>
    /// update cursor position
    /// alter anchors position tp current mouse
    /// </summary>
    void OnMouseDrag()
    {

        if (spring.enabled == true)
        {

            Vector2 cursorPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);//getting cursor position
        
            spring.connectedAnchor = cursorPosition;//the anchor get's cursor's position


        }
    }

    /// <summary>
    /// turn off spring and delete it
    /// </summary>
    void OnMouseUp()
    {

        spring.enabled = false;//disabling the spring component
        Destroy(spring);

    }

}