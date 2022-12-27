﻿using System.Collections;
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
    public GameObject mine;
    public Transform minePoint;
    public float timeBetweenMines;
    private float mineCounter;
    private bool moveRight;
    [Header("Shooting")]
    public GameObject bullet;
    public Transform firePoint;
    public float timeBetweenShots;
    private float shotCounter;
    [Header("Hurt")]
    public float hurtTime;
    private float hurtCounter;
    public GameObject hitBox;
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
                // cool down timer
                shotCounter -= Time.deltaTime;
                // execute shot
                if(shotCounter <= 0)
                {
                    shotCounter = timeBetweenShots;
                    var newBullet = Instantiate(bullet, firePoint.position,firePoint.rotation);
                    newBullet.transform.localScale = theBoss.localScale;
                }
                break;
            case bossStates.hurt:
                if(hurtCounter > 0)
                {
                    // count down
                    hurtCounter -= Time.deltaTime;
                    // change state
                    if(hurtCounter <= 0)
                    {
                        currentState = bossStates.moving;
                        mineCounter = 0;
                    }
                }
                break;
            case bossStates.moving:
                if(moveRight)
                {
                    theBoss.position += new Vector3(moveSpeed * Time.deltaTime, 0f, 0f);
                    if(theBoss.position.x > rightPoint.position.x)
                    {
                        theBoss.localScale = Vector3.one;
                        moveRight = false;
                        EndMovement();
                    }
                }
                else
                {
                    theBoss.position -= new Vector3(moveSpeed * Time.deltaTime, 0f, 0f);
                    if(theBoss.position.x < leftPoint.position.x)
                    {
                        theBoss.localScale = new Vector3(-1f,1f,1f);
                        moveRight = true;
                        EndMovement();
                    }
                }
                mineCounter -= Time.deltaTime;
                if(mineCounter <= 0)
                {
                    mineCounter = timeBetweenMines;
                    Instantiate(mine,minePoint.position, minePoint.rotation);
                }
                break;
        }
        #if UNITY_EDITOR
        if(Input.GetKeyDown(KeyCode.H))
        {
            TakeHit();
        }
        #endif
    }
    public void TakeHit()
    {
        currentState = bossStates.hurt;
        hurtCounter = hurtTime;
        anim.SetTrigger("Hit");
        // remove existing mines
        BossTankMine[] mines = FindObjectsOfType<BossTankMine>();
        if(mines.Length > 0)
        {
            foreach (BossTankMine foundMine in mines)
            {
                foundMine.Explode();    
            }
        }
    }
    private void EndMovement()
    {
        currentState = bossStates.shooting;
        shotCounter = 0f;
        anim.SetTrigger("StopMoving");
        hitBox.SetActive(true);
    }
}
