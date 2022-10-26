using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;
    public float waitToRespawn;
    public int GemsCollected;
    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
    }
    public void RespawnPlayer()
    {
        StartCoroutine(RespawnCo());
    }
    private IEnumerator RespawnCo()
    {
        // deactivate player and wait for some time
        PlayerController.instance.gameObject.SetActive(false);
        AudioManager.instance.PlaySFX(8);
        // wait for some time and fade the screen to and from black
        yield return new WaitForSeconds(waitToRespawn - (1f / UIController.instance.fadeSpeed));
        UIController.instance.FadeToBlack();
        yield return new WaitForSeconds((1f / UIController.instance.fadeSpeed) + 0.2f);
        UIController.instance.FadeFromBlack();
        // reactivate player
        PlayerController.instance.gameObject.SetActive(true);
        PlayerController.instance.transform.position = CheckpointController.instance.spawnPoint;
        PlayerHealthController.instance.currentHealth = PlayerHealthController.instance.maxHealth;
        UIController.instance.updateHealthDisplay();
    }
}
