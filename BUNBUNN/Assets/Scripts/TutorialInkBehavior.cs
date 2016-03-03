using UnityEngine;
using System.Collections;

public class TutorialInkBehavior : MonoBehaviour {

    private GameObject tutorialManager;
    private float startTime = 10f;
    private float timer = 10f;
    private float growthInterval = .02f;
    void Start()
    {
        tutorialManager = GameObject.Find("Tutorial Manager");
        Destroy(gameObject, 2.0f);
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        //Debug.Log(decimal.Round((decimal)(startTime - timer.getTime()), 2));
        if (decimal.Round((decimal)(startTime - timer), 2) >= (decimal)growthInterval)
        {
            this.gameObject.transform.localScale += new Vector3(.5f, .5f, 0);
            growthInterval += .02f;
            if (decimal.Round((decimal)(startTime - timer), 2) > 1)
            {
                growthInterval = 9999;
            }
        }
    }

    void OnDestroy()
    {
        tutorialManager.GetComponent<TutorialManager>().ShowMenuButton();
    }
    
}
