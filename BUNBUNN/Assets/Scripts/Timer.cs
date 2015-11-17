using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Timer : MonoBehaviour {
    private Text timeTF;
    public bool isZero = false;

    public void Start()
    {
        timeTF = gameObject.GetComponent<Text>();
        InvokeRepeating("ReduceTime", 1, 1);
    }

    public void ReduceTime()
    {

        if (timeTF.text == "0")
        {
            isZero = true;
        }

        timeTF.text = (int.Parse(timeTF.text) - 1).ToString();
    }

    public bool getIsZero()
    {
        return isZero;
    }
}
