using UnityEngine;
using System.Collections;

public class PointsGainedBehaviour : MonoBehaviour {
    private float time, opacity;
    private GameObject scoreLocation;
    private Vector3 direction;
	// Use this for initialization
	void Start () {
        time = 1;
        opacity = 1;
        //scoreLocation = GameObject.Find("Score");
        //Vector3 pos = Camera.main.ViewportToWorldPoint(scoreLocation.transform.position);
        //direction = pos- transform.position;
        //direction.Normalize();
       // direction = -direction;
	}
	
	// Update is called once per frame
	void Update () {
        float xbar = 0;
        xbar = Mathf.Lerp(xbar, opacity, 1.0f);
        opacity -= Time.deltaTime;
        GetComponent<SpriteRenderer>().color = new Color(1f, 1f,1f, xbar);
        moveUp();
        time -= Time.deltaTime;
        if (time<0)
        {
            Destroy(this.gameObject);
        }
	}

    void moveUp()
    {
        GetComponent<Rigidbody2D>().AddForce(new Vector2(0.0f, 0.2f), ForceMode2D.Impulse);
    }
    void moveToScore()
    {
        GetComponent<Rigidbody2D>().AddForce(new Vector2(direction.x/2, direction.y/2), ForceMode2D.Impulse);
    }
}
