using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerNumBall : MonoBehaviour
{
    public GameObject playerFilled;
    
    private GameObject[] colorsList;
    private List<GameObject> colors;
    public int myNum;
    // Use this for initialization
    void Awake()
    {
        playerFilled.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D col)
    {

        GameObject playermanager = GameObject.Find("PlayerManager");
        playermanager.GetComponent<PlayerManager>().addOneToPlayerCount();
        GameObject.Find("background camera").GetComponent<SoundManager>().PlaySound(6);
        playerFilled.SetActive(true);
        playerFilled.GetComponent<PlayerNumPortals>().SetThisParent(this.gameObject);
        if (!playermanager.GetComponent<PlayerManager>().p5filled)
        {
            col.transform.position = new Vector3(0, 3.31f, 0);
            col.rigidbody.velocity = Vector2.zero;
            col.transform.rotation = Quaternion.identity;
        }
        else
        {
            col.gameObject.SetActive(false);
        }
        this.gameObject.SetActive(false);

    }

    void OnMouseDown()
    {
        //transform.GetComponentInParent<PlayerNumBall>().resetColor();
    }

   


}