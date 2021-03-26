using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.SceneManagement;

public class ShowHS : MonoBehaviour{
    public Text plat;
    public Text pac;
    public Text run;

    // Start is called before the first frame update
    void Start(){
        plat.text=HiScoreScr.d2HiScore.ToString();
        pac.text=HiScoreScr.d3HiScore.ToString();
        run.text=HiScoreScr.RunHiScore.ToString();
    }

    // Update is called once per frame
    void Update(){
        if(Input.GetKeyDown(KeyCode.Escape))
        SceneManager.LoadScene(0);
    }
}
