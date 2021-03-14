using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour{
    float speed=10f;
    Vector3 direction;
    Vector3 lDirection;
    bool act=false;
    PlayerController2D plCon;
    // Start is called before the first frame update
    void Start(){
        plCon=GameObject.Find("Player").GetComponent<PlayerController2D>();
        direction=new Vector3(-1f, 0f, 0f);
        StartCoroutine("BulLife");
    }

    // Update is called once per frame
    void Update(){
        if(act==false){
            lDirection=direction;
            act=true;
        }
        transform.position=Vector3.MoveTowards(transform.position,transform.position+lDirection, speed*Time.deltaTime);
    }

    void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.name=="Player"){
            plCon.PlayerLives--;
            Destroy(this.gameObject);
        }
    }

    IEnumerator BulLife(){
        yield return new WaitForSeconds(4.0f);
        Destroy(this.gameObject);
        StopCoroutine("BulLife");
    }
}
