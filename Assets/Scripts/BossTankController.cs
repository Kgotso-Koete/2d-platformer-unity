using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BossTankController : MonoBehaviour
{
    public enum bossStates {shooting, hurt, moving};
    public bossStates currentState;
    public Transform theBoss;
    public Animator anim;
    [Header("Movement")]
    public float moveSpeed;
    public Transform leftPoint, rightPoint;
    private bool moveRight;
    [Header("Shooting")]
    public GameObject bullet;
    public Transform firePoint;
    public float timeBetweenShots;
    private float shotCounter;
    [Header("Hurt")]
    public float hurtTime;
    private float hurtCounter;
    // Start is called before the first frame update
    void Start()
    {
        currentState = bossStates.shooting;
    }
    // Update is called once per frame
    void Update()
    {
        switch(currentState)
        {
            case bossStates.shooting:
                break;
            case bossStates.hurt:
                break;
            case bossStates.moving:
                break;
        }
    }
}
