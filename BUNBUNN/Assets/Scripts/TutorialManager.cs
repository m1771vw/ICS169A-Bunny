using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TutorialManager : MonoBehaviour {
    public GameObject carrot, trash1, trash2, trash3, bomb, portal, TutorialText, menuButton;
    private GameObject portalObject;
	// Use this for initialization
	void Start () {
        Instantiate(carrot, Vector3.zero, Quaternion.identity);
        menuButton.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void SpawnTrashTutorial()
    {
        portalObject = Instantiate(portal, new Vector3(0, 2.8f, 0), Quaternion.identity) as GameObject;
        
        Instantiate(trash1, new Vector3(-5, -2, 0), Quaternion.identity);
        Instantiate(trash2, new Vector3(0, -2, 0), Quaternion.identity);
        Instantiate(trash3, new Vector3(5, -2, 0), Quaternion.identity);
        
        GameObject node = Instantiate(trash1, new Vector3(-5, 0, 0), Quaternion.identity) as GameObject;
        node.GetComponent<SpriteRenderer>().color = Color.blue;
        
        GameObject node2 = Instantiate(trash2, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
        node2.GetComponent<SpriteRenderer>().color = Color.red;
        
        GameObject node3 = Instantiate(trash3, new Vector3(5, 0, 0), Quaternion.identity) as GameObject;
        node3.GetComponent<SpriteRenderer>().color = Color.green;

        ChangeTutorialText("Drag the trash to the portal. Brightly colored trash is from other players.");
    }

    public void SpawnBombTutorial()
    {
        Instantiate(bomb, new Vector3(0, 0, 0), Quaternion.identity);
        ChangeTutorialText("Bombs hinder you. Drag to portal to see effect");

    }
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void ChangeTutorialText(string newString)
    {
        TutorialText.GetComponent<Text>().text = newString;
    }

    public void ShowMenuButton()
    {
        Destroy(portalObject);
        menuButton.SetActive(true);
    }
    
}
