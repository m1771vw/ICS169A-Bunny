using UnityEngine;
using System.Collections;

public class CoinToss : MonoBehaviour {

    private Random rand = new Random();


	// Use this for initialization
	void Start () {
	
	}
	
	void chooseBackground()
    {
        int number = rand.Next(0, 2);
        if(number == 0)
        { 
            // choose western
        }
        else
        {
            // choose feudal
        }
    }
}
