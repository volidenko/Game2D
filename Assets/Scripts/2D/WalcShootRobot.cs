using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalcShootRobot : MonoBehaviour{
    public float speed=2f;
    Vector3 direction;
    PlayerController2D plCon;
    public int price=4;
    public GameObject bullet;
    public GameObject bulSpawn;
    int enemyLive=5;
    float dist;
    bool actio=false;
    private GameObject pl;

    // Start is called before the first frame update
    void Start(){
        pl=GameObject.Find("Player");
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
        dist=Vector3.Distance(pl.transform.position, transform.position);
        if(dist<=5 && actio==false){
            actio=true;
            Shoot();
        }
    }

    public void Run(){
        transform.position=Vector3.MoveTowards(transform.position, transform.position+direction, speed*Time.deltaTime);
    }

    void Shoot(){
        Vector3 position=bulSpawn.transform.position;
        Instantiate(bullet, position, bullet.transform.rotation);
        StartCoroutine("Charge");
    }

    void OnTriggerEnter2D(Collider2D other){
        if (other.gameObject.name=="Left"){
            this.transform.localScale=new Vector3(-1f, 1f, 1f);
            direction=new Vector3(1f, 0f, 0f);
            print("check");
        }
        if (other.gameObject.name=="Right"){
            print("check");
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

        IEnumerator Charge(){
        yield return new WaitForSeconds(1.0f);
        actio=false;
        StopCoroutine("Charge");
    }
}
