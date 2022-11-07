using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class LSCameraController : MonoBehaviour
{
    public Vector2 minPos, maxPos;
    public Transform target;
    // Start is called before the first frame update
    void Start()
    {
    }
    // Update is called once per frame
    void LateUpdate()
    {
        // move camera in LateUpdate lifecycle hook after player moved in Update lifecycle hook
        float xPos = Mathf.Clamp(target.position.x, minPos.x, maxPos.x);
        float yPos = Mathf.Clamp(target.position.y, minPos.y, maxPos.y);
        transform.position = new Vector3(xPos, yPos, transform.position.z);
    }
}
