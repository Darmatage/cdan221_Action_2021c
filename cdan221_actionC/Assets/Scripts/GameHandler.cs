using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameHandler : MonoBehaviour
{

    private GameObject player;
      public static int playerHealth;
    public int StartPlayerHealth = 100;
    public GameObject healthText;

    public static int gotTokens = 0;
    public bool isDefending = false;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        playerHealth = StartPlayerHealth;
        updateHealthDisplay();
    }

    public void playerGetHit(int damage)
    {
        if (isDefending == false)
        {
            playerHealth -= damage;
            updateHealthDisplay();
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

    public void updateHealthDisplay()
    {
        //Text healthTextTemp = healthText.GetComponent<Text>();
        //healthTextTemp.text = "PLAYER HEALTH: " + playerHealth;
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
        SceneManager.LoadScene("Level1");
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