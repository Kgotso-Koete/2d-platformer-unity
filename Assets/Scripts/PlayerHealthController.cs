using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerHealthController : MonoBehaviour
{
    public static PlayerHealthController instance;
    public int currentHealth,maxHealth;
    public float invincibleLength;
    private float invincibleCounter;
    // initialize singleton to instantiated object
    private void Awake()
    {
        instance = this;
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
                gameObject.SetActive(false);
            }
            else{
                invincibleCounter = invincibleLength;
            }
            // update health UI
            UIController.instance.updateHealthDisplay();
        }
    }
}
