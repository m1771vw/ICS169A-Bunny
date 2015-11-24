using UnityEngine;
using System.Collections;

public class PlayerControls : MonoBehaviour {
    public float speed = 4;
    float accelStartY;
    private GameObject dataObject;
    private LocalMultiplayerGameData localData;
    public int playerHitPenalty = 20;
    void Start()
    {
        dataObject = GameObject.Find("LocalMultiplayerGameData");
        localData = dataObject.GetComponent<LocalMultiplayerGameData>();
        accelStartY = Input.acceleration.y;
    }

    void Update()
    {
        float x = Input.acceleration.x;
        float y = Input.acceleration.y - accelStartY;

        Vector2 direction = new Vector2(x, y);
        
        
        if(direction.sqrMagnitude > 1)
        {
            direction.Normalize();
        }

        Move(direction);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player1" || col.gameObject.tag == "Player2" ||
            col.gameObject.tag == "Player3" || col.gameObject.tag == "Player4" ||
            col.gameObject.tag == "Player5")
        {
            localData.playerData[localData.currentPlayer].score -= playerHitPenalty;
        }
    }

    void Move(Vector2 direction)
    {   
        Vector2 position = transform.position;

        position += direction * speed * Time.deltaTime;

        transform.position = position;
    }
}
