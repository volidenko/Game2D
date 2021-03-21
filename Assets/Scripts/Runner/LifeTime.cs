using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeTime : MonoBehaviour{
    Vector3 direction=new Vector3(0,0,-1);
    float _speed=5f;
    float _startPos;
    Animator animator;
    // Start is called before the first frame update
    void Start(){
        StartCoroutine("LifeTimes");
        _startPos=transform.position.x;
        animator=GetComponent<Animator>();
        animator.SetFloat("Speed", _speed);
    }

    // Update is called once per frame
    void Update(){
        transform.position=Vector3.MoveTowards(transform.position, transform.position+direction, _speed*Time.deltaTime);
        if(this.gameObject.name=="Danger(Clone)")
            transform.position=new Vector3(Mathf.Clamp(Mathf.Lerp(-5.5f,5.5f, Mathf.PingPong(_startPos+Time.time, 1)),-5.5f, 5.5f), transform.position.y, transform.position.z);
    }

    IEnumerator LifeTimes(){
        yield return new WaitForSeconds(4.0f);
        Destroy(this.gameObject);
    } 
}
