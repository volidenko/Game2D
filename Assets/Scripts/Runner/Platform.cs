using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour{
    private PlatformManager _platformManager;
    public float lOffset;

    private void OnEnable(){
        _platformManager=GameObject.FindObjectOfType<PlatformManager>();
    }

    // Start is called before the first frame update
    void Start(){
        
    }

    // Update is called once per frame
    void Update(){
        
    }

    private void OnBecameInvisible(){
        _platformManager.RecyclePlatform(this.gameObject, lOffset);
    }
}
