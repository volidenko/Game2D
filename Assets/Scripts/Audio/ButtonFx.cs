using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonFx : MonoBehaviour{
    public AudioSource myFx;
    public void HoverSound(){
        FindObjectOfType<AudioManager>().Play("WinSound");
    }

    public void ClickSound(){
        FindObjectOfType<AudioManager>().Play("Boom");
    }

    public void ExitSound(){
        FindObjectOfType<AudioManager>().Play("PlShoot");
    }
}
