using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCursor : MonoBehaviour
{
    private Camera cam;

    void Start() {
        cam = Camera.main;
    }
    // Update is called once per frame
    void Update()
    {
        Vector2 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        Vector2 newPos = new Vector2(Input.mousePosition.x - 32, Input.mousePosition.y - 32);
        gameObject.transform.position = newPos;
        //Destroy this game object if escape is pressed.
    }
}
