using UnityEngine;
using System.Collections;

public class PlayerControls : MonoBehaviour {
    public float speed = 4;
    float accelStartY;

    void Start()
    {
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

    void Move(Vector2 direction)
    {   
        Vector2 position = transform.position;

        position += direction * speed * Time.deltaTime;

        transform.position = position;
    }
}
