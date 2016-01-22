using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Customize_Switch : MonoBehaviour {

    // William Test Code
    public Button RightArrow;
    
    public Button LeftArrow;
    public Image Character1;
    public Image Character2;
    public Image Character3;

    
    // Use this for initialization
    void Start () {
        //RightArrow = RightArrow.GetComponent<Button>();
        //LeftArrow = LeftArrow.GetComponent<Button>();

        
        
    }
	
	public void RightArrowPressed()
	{
        // Change image
        //Application.LoadLevel("Calibration");
        Debug.Log("Hello!");
        Character1.enabled = false;
        Debug.Log(Character2.enabled);
        Character2.enabled = true;
    }
}
