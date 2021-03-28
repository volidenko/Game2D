using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class PauseMenuScript : MonoBehaviour{
    public static bool gameIsPaused=false;
    public GameObject pauseMenuUI;
    PlayerController2D plCon;
    public Text text;
    public Text hStext;
    // Start is called before the first frame update
    void Start(){
        plCon=GameObject.Find("Player").GetComponent<PlayerController2D>();
    }

    // Update is called once per frame
    void Update(){
        if(Input.GetKeyDown(KeyCode.Escape)){
            if(gameIsPaused){
               Resume();
            }
            else{
               Pause();
            }
        }
        text.text="Score "+plCon.PlayerScore.ToString();
        hStext.text="Hi-score "+plCon.HiScoreScr.ToString();
    }
    public void Resume(){
        pauseMenuUI.SetActive(false);
        Time.timeScale=1f;
        gameIsPaused=false;
        FindObjectType<AudioManager>().Play("Theme");
    }

    void Pause(){
        pauseMenuUI.SetActive(true);
        Time.timeScale=0f;
        gameIsPaused=true;
    }

    public void LoadMenu(){
        SceneManager.LoadScene(0);
        Time.timeScale=1f;
        // gameIsPaused=false;
    }

    public void QuitGame(){
        print("uiyhu7yh");
        Application.Quit();
    }
}
