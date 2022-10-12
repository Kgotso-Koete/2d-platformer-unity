using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerHealth : MonoBehaviour
{
    public int currentHealth,maxHealth;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }
    // Update is called once per frame
    void Update()
    {
    }
    public void DealDamage()
    {
        currentHealth -= 1;
        if(currentHealth <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}
