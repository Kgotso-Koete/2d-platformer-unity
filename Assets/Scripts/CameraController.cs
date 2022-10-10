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
    private float lastXPos;
    // Start is called before the first frame update
    void Start()
    {
        lastXPos = transform.position.x;
    }
    // Update is called once per frame
    void Update()
    {
        //transform.position = new Vector3(target.position.x,target.position.y,transform.position.z);
        // update camera's y position within limits
        //float clampedY = Mathf.Clamp(transform.position.y, minHeight, maxHeight);
        //transform.position = new Vector3(transform.position.x, clampedY,transform.position.z);
        transform.position = new Vector3(target.position.x,Mathf.Clamp(target.position.y, minHeight, maxHeight), transform.position.z); 
        // create positions for parallax scrolling
        float amountToMoveX = transform.position.x - lastXPos;
        farBackground.position += new Vector3(amountToMoveX,0f,0f);
        middleBackground.position += new Vector3(amountToMoveX * .5f,0f,0f);
        lastXPos = transform.position.x;
    }
}
