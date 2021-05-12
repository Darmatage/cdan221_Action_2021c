using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class PauseMenu : MonoBehaviour {

      public static bool GameisPaused = false;
      public GameObject pauseMenuUI;
      public AudioMixer mixer;
	  public AudioMixer sfxmixer;
      public static float volumeLevel = 1.0f;
	  public static float volumeLevel2 = 1.0f;
      private Slider sliderVolumeCtrl;
	  private Slider sliderVolumeCtrl2;

      void Awake (){
            SetLevel (volumeLevel);
            GameObject sliderTemp = GameObject.FindWithTag("PauseMenuSlider");
            if (sliderTemp != null){
                  sliderVolumeCtrl = sliderTemp.GetComponent<Slider>();
                  sliderVolumeCtrl.value = volumeLevel;
            }
			
			SetLevelSFX (volumeLevel2);
            GameObject sliderTemp2 = GameObject.FindWithTag("PauseMenuSlider2");
            if (sliderTemp2 != null){
                  sliderVolumeCtrl2 = sliderTemp2.GetComponent<Slider>();
                  sliderVolumeCtrl2.value = volumeLevel2;
            }
			
      }

      void Start (){
            pauseMenuUI.SetActive(false);
      }

      void Update (){
            if (Input.GetKeyDown(KeyCode.Escape)){
                  if (GameisPaused){
                        Resume();
                  }
                 else {
                        Pause();
                  }
            }
      }

      void Pause(){
            pauseMenuUI.SetActive(true);
            Time.timeScale = 0f;
            GameisPaused = true;
      }

      public void Resume(){
            pauseMenuUI.SetActive(false);
            Time.timeScale = 1f;
            GameisPaused = false;
      }

      public void Restart(){
            Time.timeScale = 1f;
            //restart the game:
            SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex);
            SceneManager.LoadScene ("MainMenu");
      }

      public void QuitGame() {
                #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
                #else
                Application.Quit();
                #endif
      }

      public void SetLevel (float sliderValue){
            mixer.SetFloat("MusicVolume", Mathf.Log10 (sliderValue) * 20);
            volumeLevel = sliderValue;
      }
	  
	  public void SetLevelSFX (float sliderValue){
            sfxmixer.SetFloat("SFXVolume", Mathf.Log10 (sliderValue) * 20);
            volumeLevel2 = sliderValue;
      }

}

