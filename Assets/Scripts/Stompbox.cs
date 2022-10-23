using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Stompbox : MonoBehaviour
{
    public GameObject deathEffect;
    public GameObject collectible;
    [Range(0,100)] public float chanceToDrop;
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
        if(other.tag == "Enemy")
        {
            // defeat enemy
            other.transform.parent.gameObject.SetActive(false);
            // add animation effects
            Instantiate(deathEffect, other.transform.position, other.transform.rotation);
            PlayerController.instance.Bounce();
            // drop health pickup according to random number generator
            float dropSelect = Random.Range(0,100f);
            if(dropSelect <= chanceToDrop)
            {
                Instantiate(collectible,other.transform.position, other.transform.rotation);
            }
        }
    }
}
