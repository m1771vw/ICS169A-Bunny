using UnityEngine;
using System.Collections;

public class TutorialTrashBehavior : MonoBehaviour {
    private GameObject tutorialManager;
    private float startTime = 10f;
    private float timer = 10f;
    private float growthInterval = .02f;
    void Start()
    {
        tutorialManager = GameObject.Find("Tutorial Manager");
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        //Debug.Log(decimal.Round((decimal)(startTime - timer.getTime()), 2));
        if (decimal.Round((decimal)(startTime - timer), 2) >= (decimal)growthInterval)
        {
            this.gameObject.transform.localScale += new Vector3(.015f, .015f, 0);
            growthInterval += .02f;
            if (decimal.Round((decimal)(startTime - timer), 2) > 1)
            {
                growthInterval = 9999;
            }
        }
    }

    void OnDestroy()
    {
        GameObject[] listOfTutorialTrash = GameObject.FindGameObjectsWithTag("trash");
        GameObject.Find("background camera").GetComponent<SoundManager>().PlaySound(0);
        //for (int i = 0; i < listOfTutorialTrash.Length;i++ )
        //{
        //    Debug.Log(listOfTutorialTrash[i].name);
        //}
        if (listOfTutorialTrash.Length==0)
        {
            tutorialManager.GetComponent<TutorialManager>().SpawnBombTutorial();
        }
    }


}
