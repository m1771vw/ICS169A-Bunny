using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    private Text timeTF;
    public bool isZero = false;
    private Image timeBar;
    private Image backBar;
    private RectTransform canvas;
    private float maxTime;
    private float curTime;

    public void Start()
    {


        timeTF = gameObject.GetComponent<Text>();
        maxTime = (float.Parse(timeTF.text));
        InvokeRepeating("ReduceTime", 1, 1);
        canvas = GameObject.Find("Canvas").GetComponent<RectTransform>();

        GameObject timeFront = new GameObject("timeBar");
        timeBar = timeFront.AddComponent<Image>();
        timeBar.rectTransform.SetParent(canvas.transform, false);
        timeBar.color = Color.green;

        GameObject timeBack = new GameObject("timeBarBack");
        backBar = timeBack.AddComponent<Image>();
        backBar.rectTransform.SetParent(canvas.transform, false);
        backBar.color = new Color(0.0f, 0.0f, 0.0f);
    }

    public void Update()
    {
        curTime = (float.Parse(timeTF.text));
        float percent = curTime / maxTime;

        if ((percent > 0.3) && (percent < 0.6))
        {
            timeBar.color = Color.yellow;
        }
        else if (percent < 0.3)
        {
            timeBar.color = Color.red;
        }

        float target, xbar = 0.0f;
        target = Screen.width * percent;
        xbar = Mathf.Lerp(xbar, percent, 1.75f);
        xbar = Mathf.Lerp(xbar, percent, 2.0f);

        timeBar.rectTransform.offsetMin = Vector2.zero;
        timeBar.rectTransform.offsetMax = Vector2.zero;
        timeBar.rectTransform.anchorMin = new Vector2(0.0f, 0.84f);
        timeBar.rectTransform.anchorMax = new Vector2(xbar, 0.85f);

        backBar.rectTransform.offsetMin = Vector2.zero;
        backBar.rectTransform.offsetMax = Vector2.zero;
        backBar.rectTransform.anchorMin = new Vector2(xbar, 0.84f);
        backBar.rectTransform.anchorMax = new Vector2(1.0f, 0.85f);
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

    public int getTime()
    {
        return System.Int32.Parse(timeTF.text);
    }
}
