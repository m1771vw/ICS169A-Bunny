using UnityEngine;
using System.Collections;

public class CoinToss : MonoBehaviour {

    private Random rand = new Random();
    

	// Use this for initialization
	void Start () {
	
	}
	
	void chooseBackground()
    {
        //int number = rand(0, 2);
        float number = Random.value;
        if(number <= 0.5)
        {
            // choose western
            Debug.Log("Less than 5, trying to launch Western");
        }
        else
        {
            // choose feudal
            Debug.Log("Greater than 5, trying to launch Feudal");
        }
    }
}
