using UnityEngine;
using System.Collections;

public class BombBehavior : MonoBehaviour
{
    private GameObject dataObject;
    private LocalMultiplayerGameData localData;
    public GameObject centerOfScreen;
    private Timer timer;
    private float startTime;
    private float growthInterval = .02f;
    public int inkToSpawn = 5;
    // Use this for initialization
    void Start()
    {
        dataObject = GameObject.Find("LocalMultiplayerGameData");
        localData = dataObject.GetComponent<LocalMultiplayerGameData>();
        dataObject = GameObject.Find("Timer");
        timer = dataObject.GetComponent<Timer>();
        startTime = timer.getTime();



    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(decimal.Round((decimal)(startTime - timer.getTime()), 2));
        if (decimal.Round((decimal)(startTime - timer.getTime()), 2) >= (decimal)growthInterval)
        {
            this.gameObject.transform.localScale += new Vector3(.015f, .015f, 0);
            growthInterval += .02f;
            if (decimal.Round((decimal)(startTime - timer.getTime()), 2) > 1)
            {
                growthInterval = 9999;
            }
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {

        if (localData != null)
        {
            if (col.gameObject.tag == "Player1" || col.gameObject.tag == "Player2" || col.gameObject.tag == "Player3" || col.gameObject.tag == "Player4" || col.gameObject.tag == "Player5")
            {
                for (int i = 0; i < inkToSpawn; i++)
                {
                    int rand = Random.Range(1,6);
                    GameObject node = Instantiate(localData.ink, GameObject.Find("CenterOfScreen").transform.position * rand, Quaternion.identity) as GameObject;
                }
                GameObject.Find("background camera").GetComponent<SoundManager>().PlaySound(1);
                Destroy(gameObject);
            }
        }
    }
}