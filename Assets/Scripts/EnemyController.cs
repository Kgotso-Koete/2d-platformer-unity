using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EnemyController : MonoBehaviour
{
    public float moveSpeed;
    public Transform leftPoint,rightPoint;
    private bool movingRight;
    private Rigidbody2D theRB;
    public SpriteRenderer theSR;
    private Animator anim; 
    public float moveTime, waitTime;
    private float moveCount, waitCount;
    // Start is called before the first frame update
    void Start()
    {
        // initialize Unity components
        theRB = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        // initialize variables
        leftPoint.parent = null;
        rightPoint.parent = null;
        movingRight = true;
        moveCount = moveTime;
    }
    // Update is called once per frame
    void Update()
    {
        // move code
        if(moveCount > 0)
        {
            // update moveCount at same rate as framerate
            moveCount -= Time.deltaTime;
            // move the character
            MoveCharacter();
            // refill waitCount if moveCount is counted down to 0
            if(moveCount <=0)
            {
                waitCount = Random.Range(waitTime * 0.75f, waitTime * 1.25f);
            }
            // transition from idle to active animation
            anim.SetBool("isMoving",true);
        }
        // wait code
        else if(waitCount > 0)
        {
            waitCount -= Time.deltaTime;
            theRB.velocity = new Vector2(0f,theRB.velocity.y);
            // refill moveCount if waitCount is counted down to 0
            if(waitCount <= 0)
            {
                moveCount = Random.Range(moveTime * 0.75f, waitTime * 0.75f);
            }
            // transition from active to idle animation
            anim.SetBool("isMoving",false);
        }
    }
    private void MoveCharacter()
    {
        if(movingRight)
        {
            theRB.velocity = new Vector2(moveSpeed, theRB.velocity.y);
            theSR.flipX = true;
            if(transform.position.x > rightPoint.position.x)
            {
                movingRight = false;
            }
        }
        else
        {
            theRB.velocity = new Vector2(-moveSpeed, theRB.velocity.y);
            theSR.flipX = false;
            if(transform.position.x < leftPoint.position.x)
            {
                movingRight = true;
            }
        }
    }
}
