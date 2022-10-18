using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CheckpointController : MonoBehaviour
{
    public static CheckpointController instance;
    // identify all checkpoints in the level
    private Checkpoint[] checkpoints;
    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        checkpoints = FindObjectsOfType<Checkpoint>();
    }
    // Update is called once per frame
    void Update()
    {
    }
    public void DeactivateCheckpoints()
    {
        for (int i = 0; i < checkpoints.Length; i++)
        {
            checkpoints[i].ResetCheckpoint();
        }
    }
}
