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

    // Start is called before the first frame update
    void Start(){
        pl=GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update(){
        dist=Vector3.Distance(pl.transform.position, transform.position);
        if(dist<=10 && actio==false){
            actio=true;
            Shoot();
        }
        if(enemyLive==0)
            Destroy(this.gameObject);
    }

    void Shoot(){
        Vector3 position=bulSpawn.transform.position;
        Instantiate(bullet, position, bullet.transform.rotation);
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
