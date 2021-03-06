using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalcRob : MonoBehaviour{
    public float speed=2f;
    Vector3 direction;
    PlayerController2D plCon;
    public int price=3;
    int enemyLive=5;

    // Start is called before the first frame update
    void Start(){
        direction=new Vector3(-1f, 0f, 0f);
        plCon=GameObject.Find("Player").GetComponent<PlayerController2D>();
    }

    // Update is called once per frame
    void Update(){
        Run();
        if(enemyLive==0){
            Destroy(this.gameObject);
            plCon.PlayerScore+=price;
        }
    }

    public void Run(){
        transform.position=Vector3.MoveTowards(transform.position, transform.position+direction, speed*Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other){
        if (other.gameObject.name=="Left"){
            this.transform.localScale=new Vector3(-1f, 1f, 1f);
            direction=new Vector3(1f, 0f, 0f);
        }
        if (other.gameObject.name=="Right"){
            this.transform.localScale=new Vector3(1f, 1f, 1f);
            direction=new Vector3(-1f, 0f, 0f);
        }
    }
    
    void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.name=="Player"){
            plCon.PlayerLives--;
        }
        if(collision.gameObject.name=="PlBullet"){
            enemyLive--;
            print(enemyLive);
        }
    }
}
