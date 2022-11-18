using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;
    public float waitToRespawn;
    public int gemsCollected;
    public string levelToLoad;
    public float timeInLevel;
    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        timeInLevel = 0;
    }
    // Update is called once per frame
    void Update()
    {
        timeInLevel += Time.deltaTime;
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
    public void EndLevel()
    {
        StartCoroutine(EndLevelCo());
    }
    public IEnumerator EndLevelCo()
    {
        PlayerController.instance.stopInput = true;
        CameraController.instance.stopFollow = true;
        UIController.instance.levelCompleteText.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        UIController.instance.FadeToBlack();
        yield return new WaitForSeconds((1f / UIController.instance.fadeSpeed) + 0.25f);
        PlayerPrefs.SetInt(SceneManager.GetActiveScene().name + "_unlocked", 1);
        // record gems collected in level stats
        if(PlayerPrefs.HasKey(SceneManager.GetActiveScene().name + "_gems"))
        {
            if(gemsCollected > PlayerPrefs.GetInt(SceneManager.GetActiveScene().name + "_gems"))
            {
                PlayerPrefs.SetInt(SceneManager.GetActiveScene().name + "_gems",gemsCollected);
            }
        }
        else
        {
            PlayerPrefs.SetInt(SceneManager.GetActiveScene().name + "_gems",gemsCollected);
        }
        // record  time duration in level stats
        if(PlayerPrefs.HasKey(SceneManager.GetActiveScene().name + "_time"))
        {
            if(timeInLevel < PlayerPrefs.GetFloat(SceneManager.GetActiveScene().name + "_time"))
            {
                PlayerPrefs.SetFloat(SceneManager.GetActiveScene().name + "_time", timeInLevel);
            }
        }
        else
        {
            PlayerPrefs.SetFloat(SceneManager.GetActiveScene().name + "_time", timeInLevel);
        }
        // load next scene
        SceneManager.LoadScene(levelToLoad);
    }
}
