using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonFx : MonoBehaviour{
    public AudioSource myFx;
    public AudioClip hoverFx;
    public AudioClip clickedFx;

    public void HoverSound(){
        myFx.PlayOneShot(hoverFx);
    }

    public void ClickSound(){
        myFx.PlayOneShot(clickedFx);
    }
}
