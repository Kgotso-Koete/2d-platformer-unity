using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerHealthController : MonoBehaviour
{
    public static PlayerHealthController instance;
    public int currentHealth,maxHealth;
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
