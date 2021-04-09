using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour{
    public Animator transition;
    public float transitionTime=1f;

    // Start is called before the first frame update

    public void D2Game(){
        StartCoroutine(LoadLevel(1));
        //SceneManager.LoadScene(1);
    }

    public void Runner(){
        StartCoroutine(LoadLevel(5));
        //SceneManager.LoadScene(5);
    }

    public void HiScore(){
        StartCoroutine(LoadLevel(4));
    }

    public void QuitGame(){
        Application.Quit();
    }

    IEnumerator LoadLevel(int LevelIndex){
        //transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(LevelIndex);
    }
}
