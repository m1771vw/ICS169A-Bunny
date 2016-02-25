using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    private float timeTF;
    private Text timeStart;
    public bool isZero = false;
    private Image timeBar;
    private Image backBar;
    private RectTransform canvas;
    public float maxTime;
    private float curTime;
    private Image timerPie;

    public void Start()
    {

        timerPie = GameObject.Find("TimerPie").GetComponent<Image>();
        timeStart = GameObject.Find("Timer").GetComponent<Text>();

        //InvokeRepeating("ReduceTime", 1, 1);


        //canvas = GameObject.Find("Canvas").GetComponent<RectTransform>();

        //GameObject timeFront = new GameObject("timeBar");
        //timeBar = timeFront.AddComponent<Image>();
        //timeBar.rectTransform.SetParent(canvas.transform, false);
        //timeBar.color = Color.green;

        //GameObject timeBack = new GameObject("timeBarBack");
        //backBar = timeBack.AddComponent<Image>();
        //backBar.rectTransform.SetParent(canvas.transform, false);
        //backBar.color = new Color(0.0f, 0.0f, 0.0f);
    }

    public void setMaxTime(float number)
    {
        maxTime = number;
        timeStart = timerPie.GetComponent<Text>();

    }
    public void setStartTime(float number)
    {
        timeTF = number;
        maxTime = number;
        curTime = number;

        timeStart.text = ((int)timeTF).ToString();
    }

    public void Update()
    {
        if (curTime>0)
        {
            //current time minus the time that has passed since the last update call in Timer
            curTime -= Time.deltaTime;

            //this is for the GameManager class. When the current time <= 0, it'll set it manually to 0.0f for the GameManager class
            if (curTime <= 0.0f)
            {
                isZero = true;
                curTime = 0.0f;
            }
            float percent = curTime / maxTime;
            timerPie.fillAmount = percent;
            if ((percent > 0.3) && (percent < 0.6))
            {
                //timeBar.color = Color.yellow;
                timerPie.color = Color.yellow;
            }
            else if (percent < 0.3)
            {

                // timeBar.color = Color.red;
                timerPie.color = Color.red;
            }

            //float target, xbar = 0.0f;
            //target = Screen.width * percent;
            //xbar = Mathf.Lerp(xbar, percent, 1.75f);
            //xbar = Mathf.Lerp(xbar, percent, 2.0f);

            //timeBar.rectTransform.offsetMin = Vector2.zero;
            //timeBar.rectTransform.offsetMax = Vector2.zero;
            //timeBar.rectTransform.anchorMin = new Vector2(0.0f, 0.85f);
            //timeBar.rectTransform.anchorMax = new Vector2(xbar, 0.86f);

            //backBar.rectTransform.offsetMin = Vector2.zero;
            //backBar.rectTransform.offsetMax = Vector2.zero;
            //backBar.rectTransform.anchorMin = new Vector2(xbar, 0.85f);
            //backBar.rectTransform.anchorMax = new Vector2(1.0f, 0.86f);

            if (curTime < (maxTime / 2))
            {

                float newTime = Mathf.Floor(curTime * 100.0f + 0.5f) / 100;

                // Debug.Log(newTime);
                timeStart.text = newTime.ToString("F2");
            }
            else
            {
                if (curTime != 0)
                {
                    timeStart.text = ((int)curTime).ToString();
                }
            }
        }
        

        
    }

    //public void ReduceTime()
    //{

    //    if (curTime <= -0.5f)
    //    {
    //        isZero = true;
    //    }

    //    timeTF.text = (int.Parse(timeTF.text) - 1).ToString();
    //}

    public bool getIsZero()
    {
        return isZero;
    }

    public float getTime()
    {
        return curTime;
    }
}
