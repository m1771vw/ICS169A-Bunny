using UnityEngine;
using System.Collections;

public class CoinToss : MonoBehaviour {

    private Random rand = new Random();
    

	// Use this for initialization
	void Start () {
        chooseBackground();
	}
	
	void chooseBackground()
    {
        //int number = rand(0, 2);
        float number = Random.value;
        if(number <= 0.5)
        {
            // choose feudal
            Debug.Log(" than 5, trying to launch Western");
            GameObject.Find("western").GetComponent<SpriteRenderer>().sprite = GameObject.Find("feudal").GetComponent<SpriteRenderer>().sprite;
            GameObject.Find("background camera").GetComponent<SoundManager>().PlaySound(9);
            // GameObject.Find("backgroundcamera").GetComponent<AudioSource>().clip.Equals
        }
        else
        {
            GameObject.Find("background camera").GetComponent<SoundManager>().PlaySound(8);
            
        }

    }
}
