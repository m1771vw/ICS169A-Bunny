using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerNumBall : MonoBehaviour
{
    private GameObject x_button;
    private GameObject[] colorsList;
    private List<GameObject> colors;
    // Use this for initialization
    void Start()
    {
        x_button = transform.GetChild(0).gameObject;
        x_button.SetActive(false);

        colors = new List<GameObject>();
        colorsList = GameObject.FindGameObjectsWithTag("ColorBall");
        for (int i =0; i< colorsList.Length;i++)
        {
            colors.Add(colorsList[i]);
        }


    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name.Contains("x"))
        {
            Debug.Log("x found");
            Physics2D.IgnoreCollision(GetComponent<Collider2D>(), col.gameObject.GetComponent<Collider2D>());
        }
        if (GetComponent<SpriteRenderer>().color==Color.white)
        {
            GetComponent<SpriteRenderer>().color = col.gameObject.GetComponent<SpriteRenderer>().color;
            x_button.SetActive(true);
            col.gameObject.SetActive(false);
            
        }
        else
        {
            col.gameObject.SetActive(false);
            bounceColorOut();
            GetComponent<SpriteRenderer>().color = col.gameObject.GetComponent<SpriteRenderer>().color;

        }
        //GetComponent<SpriteRenderer>().sprite = col.gameObject.GetComponent<SpriteRenderer>().sprite;
    }

    void OnMouseDown()
    {
        transform.GetComponentInParent<PlayerNumBall>().resetColor();
    }

    void bounceColorOut()
    {
        for (int i = 0; i < colorsList.Length; i++)
        {
            if (colors[i].GetComponent<SpriteRenderer>().color == GetComponent<SpriteRenderer>().color)
            {
                if (colors[i].activeSelf == false)
                {

                    colors[i].SetActive(true);

                    colors[i].transform.position += new Vector3(0, 1.5f, 0);
                    colors[i].GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                    colors[i].GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, 5f), ForceMode2D.Impulse);
                }
            }
        }
    }

    public void resetColor()
    {
        bounceColorOut();
        GetComponent<SpriteRenderer>().color = Color.white;
        x_button.SetActive(false);
    }

}