using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerHealthController : MonoBehaviour
{
    public static PlayerHealthController instance;
    public int currentHealth,maxHealth;
    public float invincibleLength;
    private float invincibleCounter;
    private SpriteRenderer theSR;
    // initialize singleton to instantiated object
    private void Awake()
    {
        instance = this;
        theSR = GetComponent<SpriteRenderer>();
    }
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }
    // Update is called once per frame
    void Update()
    {
        if(invincibleCounter > 0){
            // decrease by 1 every second by deducting time to between frames each update (60 updates per second for 60 frames per second)
            invincibleCounter -= Time.deltaTime;
            // reverse player image transparency when invincibility runs out
            if(invincibleCounter <= 0)
            {
                theSR.color = new Color(theSR.color.r,theSR.color.g,theSR.color.b,1);
            }
        }
    }
    public void DealDamage()
    {
        if(invincibleCounter <= 0){
            // decrease health
            currentHealth -= 1;
            // check if health is depleted
            if(currentHealth <= 0)
            {
                currentHealth = 0;
                LevelManager.instance.RespawnPlayer();
            }
            else{
                invincibleCounter = invincibleLength;
                // make the player transparent
                theSR.color = new Color(theSR.color.r,theSR.color.g,theSR.color.b,.5f);
                PlayerController.instance.KnockBack();
            }
            // update health UI
            UIController.instance.updateHealthDisplay();
        }
    }
}
