using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EnterPortalStart : MonoBehaviour
{
    public string scene;
    //public Button BackButton;
    //public GameObject Back;
    // Use this for initialization
    void Start()
    {
        //BackButton.enabled = false;
        //Back.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] thingyToFind = GameObject.FindGameObjectsWithTag("trash");
        int thingyCount = thingyToFind.Length;
        Debug.Log(thingyCount);
        if (thingyCount == 0)
        {
            Application.LoadLevel("scene");
            //Back.SetActive(true);
            //BackButton.enabled = true;
        }
    }


}
