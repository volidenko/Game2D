using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
public class MuteScript : MonoBehaviour{
    public bool isMute;
    Button button;
    public ColorBlock newC;
    ColorBlock old;

    void Start(){
        button=this.GetComponent<Button>();
        old=button.colors;
    }

    public void Mute(){
        isMute=!isMute;
        AudioListener.pause=isMute;
        if(isMute==false)
            button.colors=old;
        else
            button.colors=newC;
    }
}
