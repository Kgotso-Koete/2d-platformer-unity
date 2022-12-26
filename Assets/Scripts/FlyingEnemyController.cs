﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class FlyingEnemyController : MonoBehaviour
{
    public Transform[] points;
    public float moveSpeed;
    private int currentPoint;
    public SpriteRenderer theSR;
    public float distanceToAttackPlayer, chaseSpeed;
    private Vector3 attackTarget;
    public float waitAfterAttack;
    private float attackCounter;
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < points.Length; i++)
        {
            points[i].parent = null;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if(attackCounter > 0)
        {
            attackCounter -= Time.deltaTime;
        }
        // move or attack player
        else
        {
            if( Vector3.Distance(transform.position, PlayerController.instance.transform.position) > distanceToAttackPlayer)
            {
                moveBetweenPoints();
                flipXWhenFlying();
            }
            else
            {
                AttackPlayer();
            }
        }
    }
    private void moveBetweenPoints()
    {
        attackTarget = Vector3.zero;
        transform.position = Vector3.MoveTowards(transform.position, points[currentPoint].position, moveSpeed * Time.deltaTime);
        if(Vector3.Distance(transform.position,points[currentPoint].position) < 0.5f)
        {
            currentPoint ++;
            if(currentPoint >= points.Length)
            {
                currentPoint = 0;
            }
        }
    }
    private void flipXWhenFlying()
    {
        if(transform.position.x < points[currentPoint].position.x)
        {
            theSR.flipX = true;
        }
        else if(transform.position.x > points[currentPoint].position.x)
        {
            theSR.flipX = false;
        }
    }
    private void AttackPlayer()
    {
        // attacking the player
        if(attackTarget == Vector3.zero)
        {
           attackTarget = PlayerController.instance.transform.position;
        }
        transform.position = Vector3.MoveTowards(transform.position,attackTarget, chaseSpeed * Time.deltaTime);
        // cool down period after attack
        if(Vector3.Distance(transform.position, attackTarget) <= 0.1f)
        {
            attackCounter = waitAfterAttack;
            attackTarget = Vector3.zero;
        }
    }
}
