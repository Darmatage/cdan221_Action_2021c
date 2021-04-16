using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameHandler : MonoBehaviour
{

    private GameObject player;
    public static int playerHealth;
    public int StartPlayerHealth = 100;
    public GameObject healthText;

    public int gotOrbs = 0;
    public GameObject orbsText;

    public bool isDefending = false;

    public static int MaxHealth = 100;
    public static int CurrentHealth = 100;
    private string sceneName;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        playerHealth = StartPlayerHealth;
        updateStatsDisplay();
    }

    public void playerGetOrbs(int newOrbs)
    {
        gotOrbs += newOrbs;
        updateStatsDisplay();
    }

    public void playerGetHit(int damage)
    {
        if (isDefending == false)
        {
            playerHealth -= damage;
            updateStatsDisplay();
            player.GetComponent<PlayerHurt>().playerHit();
        }

        if (playerHealth >= 100)
        {
            playerHealth = 100;
        }

        if (playerHealth <= 0)
        {
            playerHealth = 0;
            playerDies();
        }
    }
    public void TakeDamage(int damage)
    {
        CurrentHealth -= damage;
        UpdateHealth();
        sceneName = SceneManager.GetActiveScene().name;
        if (CurrentHealth >= MaxHealth) { CurrentHealth = MaxHealth; }
        if ((CurrentHealth <= 0) && (sceneName != "EndLose"))
        {
            SceneManager.LoadScene("EndLose");
        }
    }

    public void UpdateHealth()
    {
		updateStatsDisplay();
        //Text healthTextB = healthText.GetComponent<Text>();
		//healthTextB.text = "Current Health: " + CurrentHealth + "\n Max Health: " + MaxHealth;
    }
    public void updateStatsDisplay()
    {
        Text healthTextTemp = healthText.GetComponent<Text>();
        healthTextTemp.text = "HEALTH: " + playerHealth;

        Text orbsTextTemp = orbsText.GetComponent<Text>();
        orbsTextTemp.text = "ORBS: " + gotOrbs;
    }

    public void playerDies()
    {
        player.GetComponent<PlayerHurt>().playerDead();
        StartCoroutine(DeathPause());
    }

    IEnumerator DeathPause()
    {
        player.GetComponent<PlayerMove>().isAlive = false;
        player.GetComponent<PlayerJump>().isAlive = false;
        yield return new WaitForSeconds(1.0f);
        SceneManager.LoadScene("LoseScreen");
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Level_1");
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("StartScreen");
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
                Application.Quit();
#endif
    }

    public void Credits()
    {
        SceneManager.LoadScene("Credits");
    }
}