using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Checkpoint : MonoBehaviour
{
    public SpriteRenderer theSR;
    public Sprite cpOn,cpOff;
    // Start is called before the first frame update
    void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            // first deactivate all checkpoints
            CheckpointController.instance.DeactivateCheckpoints();
            theSR.sprite = cpOn;
        }
    }
    public void ResetCheckpoint()
    {
        theSR.sprite = cpOff;
    }
}
