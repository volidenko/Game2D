using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMaster2D : MonoBehaviour{
    public Text text;
    PlayerController2D plCon;

    // Start is called before the first frame update
    void Start(){
        plCon=GameObject.Find("Player").GetComponent<PlayerController2D>();
    }

    // Update is called once per frame
    void Update(){
        text.text=plCon.PlayerScore.ToString();
    }
}
