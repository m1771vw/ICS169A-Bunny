using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class setRoundText : MonoBehaviour {

	// Use this for initialization
	void Start () {
        int roundCount = GameObject.Find("LocalMultiplayerGameData").GetComponent<LocalMultiplayerGameData>().currentRound;
        if(roundCount == 2)
        {
            GameObject.Find("one").GetComponent<Image>().sprite =
                GameObject.Find("two").GetComponent<Image>().sprite;
        }
        else if (roundCount == 3)
        {
            GameObject.Find("one").GetComponent<Image>().sprite =
                GameObject.Find("three").GetComponent<Image>().sprite;
        }
        
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
