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
    public GameObject center;
    public Transform target;
    public float rotateSpeedx, rotateSpeedy, rotateSpeedz;

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
        else if (inReverse == true && currentPathPercent >= 1f)
        {
            currentPathPercent = 0.0f;
            inReverse = false;
            currentWaypointArray = waypointArray;
        }
        //transform.LookAt(target);
        ///point objects at the center of the screen
        /*
        Vector3 vectorToTarget = center.transform.position - transform.position;
        float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, q, Time.deltaTime * rotateSpeed);
        */


        ///COIN transform.Rotate(Vector3.up * Time.deltaTime*rotateSpeed); 
        transform.Rotate(rotateSpeedx * Time.deltaTime, rotateSpeedy * Time.deltaTime, rotateSpeedz * Time.deltaTime);
    }

    void OnDrawGizmos()
    {
        //Visual in engine Not used in movement
        iTween.DrawPath(waypointArray);
    }
}