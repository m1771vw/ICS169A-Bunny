using UnityEngine;
using System.Collections;

public class PortalPathing : MonoBehaviour
{
    public Transform[] waypointArray;
    public Transform[] waypointArrayReverse;
    Transform[] currentWaypointArray;
    public float percentsPerSecond = 0.10f; // %2 of the path moved per second
    public float currentPathPercent = 1.0f; //min 0, max 1
    public bool inReverse = false;
    public Vector3 center;
    public Transform target;

    /// <summary>
    /// set current array we are going to flip back and forth from the reverse array to the normal path array so the object patrols
    /// </summary>
    void Awake()
    {
        currentWaypointArray = waypointArray;
    }

    void Update()
    {
        currentPathPercent += percentsPerSecond * Time.deltaTime;
        iTween.PutOnPath(gameObject, currentWaypointArray, currentPathPercent);
        //check path if its gone to far send it the opposite direction in an array of reverse elements
        if (inReverse == false && currentPathPercent >= 1.0f)
        {
            currentPathPercent = 0.0f;
            inReverse = true;
            currentWaypointArray = waypointArrayReverse;
        }
        else if(inReverse == true && currentPathPercent >= 1f)
        {
            currentPathPercent = 0.0f;
            inReverse = false;
            currentWaypointArray = waypointArray;
        }
        //transform.LookAt(target);
        ///point objects at the center of the screen
        Vector3 dir = center - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    void OnDrawGizmos()
    {
        //Visual in engine Not used in movement
        iTween.DrawPath(waypointArray);
    }
}