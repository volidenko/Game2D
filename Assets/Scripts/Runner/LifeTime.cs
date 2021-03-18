using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeTime : MonoBehaviour{
    // Start is called before the first frame update
    void Start(){
        StartCoroutine("LifeTimes");
        
    }

    // Update is called once per frame
    void Update(){
        
    }

    IEnumerator LifeTimes(){
        yield return new WaitForSeconds(4.0f);
        Destroy(this.gameObject);
    } 
}
