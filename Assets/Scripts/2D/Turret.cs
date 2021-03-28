using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour{
    public GameObject bullet;
    public GameObject bulSpawn;
    private GameObject pl;
    float dist;
    bool actio=false;
    int enemyLive=10;
    public int price=2;
    PlayerController2D plCon;

    // Start is called before the first frame update
    void Start(){
        pl=GameObject.Find("Player");
        plCon=GameObject.Find("Player").GetComponent<PlayerController2D>();
    }

    // Update is called once per frame
    void Update(){
        dist=Vector3.Distance(pl.transform.position, transform.position);
        if(dist<=10 && actio==false){
            actio=true;
            Shoot();
        }
        if(enemyLive==0){
            FindObjectType<AudioManager>().Play("Boom");
            Destroy(this.gameObject);
            plCon.PlayerScore+=price;
        }
    }

    void Shoot(){
        Vector3 position=bulSpawn.transform.position;
        Instantiate(bullet, position, bullet.transform.rotation);
        FindObjectType<AudioManager>().Play("EnShoot");
        StartCoroutine("Charge");
    }

    void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.tag=="PlBullet"){
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
