using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyCamera : MonoBehaviour{
    float speed = 2f;
    public Transform tar;
    // Start is called before the first frame update
    void Start(){
        
    }

    // Update is called once per frame
    void Update(){
        Vector3 position = tar.position;		
	    position.z = -10f;	
	    position.y = 1f;		
	    transform.position = Vector3.Lerp(position,position,speed*Time.deltaTime);
    }
}
