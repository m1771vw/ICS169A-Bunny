using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
public class PlayerManager : MonoBehaviour {

    private RectTransform UI;
    private GameObject whitePlayer, bluePlayer, redPlayer, yellowPlayer, grayPlayer, addButtonInstance, subButtonInstance;
    private int inputNum = 2;
    public int startingY;
    //location on screen
    public int locationY = Screen.height/4;

    private List<GameObject> listOfInputFields;
    //just stores the prefabs. use the game object variables above. 
    public GameObject inputField, addButton, subButton;
    
	// Use this for initialization
	void Start () 
    {
        UI = GameObject.Find("MenuUI").GetComponent<RectTransform>();
        listOfInputFields = new List<GameObject>();
        whitePlayer = GameObject.Find("whitePlayer");
        bluePlayer = GameObject.Find("bluePlayer");
        redPlayer = GameObject.Find("redPlayer");
        yellowPlayer = GameObject.Find("yellowPlayer");
        grayPlayer = GameObject.Find("grayPlayer");
        addButtonInstance = GameObject.Find("AddButton");
        subButtonInstance = GameObject.Find("SubButton");
        SetupInputFields();




	}

    private void SetupInputFields()
    {


        //instantiate all inputfields
        //whitePlayer = Instantiate(inputField, new Vector3(0, locationY, 0), Quaternion.identity) as GameObject;
        //whitePlayer.transform.SetParent(UI, false);
        //whitePlayer.GetComponent<InputField>().placeholder.GetComponent<Text>().text = "Player: White";


        //redPlayer = Instantiate(inputField, new Vector3(0, locationY - 20, 0), Quaternion.identity) as GameObject;
        //redPlayer.transform.SetParent(UI, false);
        //redPlayer.GetComponent<InputField>().placeholder.GetComponent<Text>().text = "Player: Red";

        //yellowPlayer = Instantiate(inputField, new Vector3(0, locationY - 60, 0), Quaternion.identity) as GameObject;
        //yellowPlayer.transform.SetParent(UI, false);
        //yellowPlayer.GetComponent<InputField>().placeholder.GetComponent<Text>().text = "Player: Yellow";

        //bluePlayer = Instantiate(inputField, new Vector3(0, locationY - 100, 0), Quaternion.identity) as GameObject;
        //bluePlayer.transform.SetParent(UI, false);
        //bluePlayer.GetComponent<InputField>().placeholder.GetComponent<Text>().text = "Player: Blue";

        //grayPlayer = Instantiate(inputField, new Vector3(0, locationY - 140, 0), Quaternion.identity) as GameObject;
        //grayPlayer.transform.SetParent(UI, false);
        //grayPlayer.GetComponent<InputField>().placeholder.GetComponent<Text>().text = "Player: Gray";


        //disable to hide
        yellowPlayer.SetActive(false); 
        bluePlayer.SetActive(false);
        grayPlayer.SetActive(false);

        //add to list of input fields for iteration later
        listOfInputFields.Add(whitePlayer);
        listOfInputFields.Add(redPlayer);
        listOfInputFields.Add(yellowPlayer);
        listOfInputFields.Add(bluePlayer);
        listOfInputFields.Add(grayPlayer);

        

        addButtonInstance.GetComponent<Button>().onClick.AddListener(addButtonClick);


        subButtonInstance.GetComponent<Button>().onClick.AddListener(subButtonClick);
        subButtonInstance.SetActive(false);

        Button nextButton = GameObject.Find("Next Button").GetComponent<Button>();
        nextButton.GetComponent<Button>().onClick.AddListener(NextButtonClick);
    } 

    public void addButtonClick()
    {
        subButtonInstance.SetActive(true);
        if (inputNum<5)
        {
            inputNum++;
        }
        
        for (int i =0; i< inputNum; i++)
        {
            listOfInputFields[i].SetActive(true);
        }

        if (inputNum >=5)
        {
            addButtonInstance.SetActive(false);
        }

        
        //addButton.transform.position = new Vector3(addButton.transform.position.x, addButton.transform.position.y + 40 * inputNum, 0);

    }

    public void subButtonClick()
    {
        addButtonInstance.SetActive(true);
        if (inputNum>2)
        {
            inputNum--;
        }
        
        for (int i = 4; i >= inputNum; i--)
        {
            listOfInputFields[i].SetActive(false);
        }


        
        if (inputNum<=2)
        {
            subButtonInstance.SetActive(false);
        }

    }

    public void NextButtonClick()
    {
        LocalMultiplayerGameData data = GameObject.Find("LocalMultiplayerGameData").GetComponent<LocalMultiplayerGameData>();
        data.numberOfPlayers = inputNum;
        Debug.Log(data.numberOfPlayers);
    }
}
