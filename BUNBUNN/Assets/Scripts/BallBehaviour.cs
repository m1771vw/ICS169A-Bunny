using UnityEngine;
using System.Collections;

public class BallBehaviour : MonoBehaviour
{
    private GameObject x_button;
    private GameObject[] listOfBalls;
    // Use this for initialization
    void Start()
    {
        listOfBalls = new GameObject[4];
        listOfBalls = GameObject.FindGameObjectsWithTag("PlayerNumBall");
        x_button = gameObject.transform.GetChild(0).gameObject;
        x_button.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnCollisionEnter2D(Collision2D col)
    {
        GetComponent<SpriteRenderer>().sprite = col.gameObject.GetComponent<SpriteRenderer>().sprite;
        x_button.SetActive(true);
        for (int i = 0; i < 4; i++)
        {
            Debug.Log(listOfBalls[i].name);
            if (!listOfBalls[i].activeSelf)
            {
                listOfBalls[i].transform.position += new Vector3(1, 1, 0);
                listOfBalls[i].SetActive(true);
                listOfBalls[i].GetComponent<Rigidbody2D>().AddForce(new Vector2(2f, 2f), ForceMode2D.Impulse);
            }

        }
        col.gameObject.SetActive(false);

    }
}
