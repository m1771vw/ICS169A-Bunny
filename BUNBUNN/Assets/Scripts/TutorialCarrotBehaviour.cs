using UnityEngine;
using System.Collections;

public class TutorialCarrotBehaviour : MonoBehaviour {
    private float growthInterval = .02f;
    private float startTime = 10f;
    private float timer = 10f;
    public GameObject confetti;
    private GameObject tutorialManager;
    // Sound Code
    private GameObject dataObject;
    private SoundManager sound;
   
	// Use this for initialization
	void Start () {
        tutorialManager = GameObject.Find("Tutorial Manager");
        // Sound
        dataObject = GameObject.Find("background camera");
        sound = dataObject.GetComponent<SoundManager>();
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

    void OnMouseDown()
    {
        
        Instantiate(confetti, transform.position, Quaternion.identity);
        sound.PlaySound(2);
        Destroy(this.gameObject);
    }
    void OnDestroy()
    {
        tutorialManager.GetComponent<TutorialManager>().SpawnTrashTutorial();
    }
}
