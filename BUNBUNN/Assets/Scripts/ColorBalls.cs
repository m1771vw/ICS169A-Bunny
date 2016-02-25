using UnityEngine;
using System.Collections;

public class ColorBalls : MonoBehaviour {

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "colorBall")
        {
            Physics2D.IgnoreCollision(GetComponent<Collider2D>(), col.gameObject.GetComponent<Collider2D>());
        }
        //GetComponent<SpriteRenderer>().color = col.gameObject.GetComponent<SpriteRenderer>().color;
        //col.transform.position += new Vector3(2, 2, 0);
        //col.gameObject.SetActive(false);
        //GetComponent<SpriteRenderer>().sprite = col.gameObject.GetComponent<SpriteRenderer>().sprite;
    }
}
