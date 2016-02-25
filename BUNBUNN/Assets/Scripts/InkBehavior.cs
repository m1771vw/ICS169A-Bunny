using UnityEngine;
using System.Collections;

public class InkBehavior : MonoBehaviour
{
    private GameObject dataObject;
    private LocalMultiplayerGameData localData;
    private Timer timer;
    private float startTime;
    private float growthInterval = .02f;
    public int lifeTime = 3;
    // Use this for initialization
    void Start()
    {
        dataObject = GameObject.Find("LocalMultiplayerGameData");
        localData = dataObject.GetComponent<LocalMultiplayerGameData>();
        dataObject = GameObject.Find("Timer");
        timer = dataObject.GetComponent<Timer>();
        startTime = timer.getTime();
    }
    void Awake()
    {
        Destroy(gameObject, lifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(decimal.Round((decimal)(startTime - timer.getTime()), 2));
        if (decimal.Round((decimal)(startTime - timer.getTime()), 2) >= (decimal)growthInterval)
        {
            this.gameObject.transform.localScale += new Vector3(1f, 1f, 0);
            growthInterval += .02f;
            if (decimal.Round((decimal)(startTime - timer.getTime()), 2) > 1)
            {
                growthInterval = 9999;
            }
        }

    }
}
