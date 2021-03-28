using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class WinMenu : MonoBehaviour{
    public bool isWin=false;
    public GameObject winMenuUI;
    PlayerController2D plCon;

    // Start is called before the first frame update
    void Start(){
        plCon=GameObject.Find("Player").GetComponent<PlayerController2D>();
    }

    void Update(){
        if(isWin){
            WinScreen();
        }
    }

    void WinScreen(){
        winMenuUI.SetActive(true);
        Time.timeScale=0f;
    }

    public void LoadMenu(){
        SceneManager.LoadScene(0);
        isWin=false;
        Time.timeScale=1f;
    }

    public void Restart(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        isWin=false;
        Time.timeScale=1f;
    }

    public void NextLevel(){
        print("Win");
        HiScoreScr.d2CurScore=plCon.PlayerScore;
        SceneManager.LoadScene(5);
        isWin=false;
        Time.timeScale=1f;
        FindObjectType<AudioManager>().Play("Theme");
    }
}
  