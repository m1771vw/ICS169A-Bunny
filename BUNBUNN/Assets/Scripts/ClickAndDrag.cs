using UnityEngine;
using System.Collections;

public class ClickAndDrag : MonoBehaviour
{
    private Vector2 screenPoint;
    private Vector2 offset;
    // Use this for initialization
    void Start()
    {

    }
    void OnMouseDown()
    {
        screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
    }

    void OnMouseDrag()
    {
        Vector2 cursorPoint = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 cursorPosition;
        cursorPosition.x = Camera.main.ScreenToWorldPoint(cursorPoint).x + offset.x;
        cursorPosition.y = Camera.main.ScreenToWorldPoint(cursorPoint).y + offset.y;
        transform.position = cursorPosition;
    }
    // Update is called once per frame
    void Update()
    {

    }
}
