using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CameraController : MonoBehaviour
{
    // for the camera to follow a sprite
    public Transform target;
    // variable for parallax scrolling
    public Transform farBackground, middleBackground;
    // variable for vertical camera control
    public float minHeight, maxHeight;
    private Vector2 lastPos;
    // Start is called before the first frame update
    void Start()
    {
        lastPos = transform.position;
    }
    // Update is called once per frame
    void Update()
    {
        // update camera's y position within limits
        transform.position = new Vector3(target.position.x,Mathf.Clamp(target.position.y, minHeight, maxHeight), transform.position.z);
        // create positions for parallax scrolling
        Vector2 amountToMove = new Vector2(transform.position.x - lastPos.x, transform.position.y - lastPos.y);
        farBackground.position += new Vector3(amountToMove.x,amountToMove.y,0f);
        middleBackground.position += new Vector3(amountToMove.x ,amountToMove.y,0f) * .5f;
        lastPos = transform.position;
    }
}
