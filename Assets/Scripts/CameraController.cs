using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CameraController : MonoBehaviour
{
    // for the camera to follow a sprite
    public Transform target;
    // objects for parallax scrolling
    public Transform farBackground, middleBackground;
    private float lastXPos;
    // Start is called before the first frame update
    void Start()
    {
        lastXPos = transform.position.x;
    }
    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(target.position.x,transform.position.y,transform.position.z);
        // create positions for parallax scrolling
        float amountToMoveX = transform.position.x - lastXPos;
        farBackground.position += new Vector3(amountToMoveX,0f,0f);
        middleBackground.position += new Vector3(amountToMoveX * .5f,0f,0f);
        lastXPos = transform.position.x;
    }
}
