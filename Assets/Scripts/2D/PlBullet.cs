using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlBullet : MonoBehaviour
{
    float speed=10f;
    Vector3 direction;
    Vector3 lDirection;
    GameObject pl;
    bool act=false;

    // Start is called before the first frame update
    void Start()
    {
        pl=GameObject.Find("Player");
        StartCoroutine("BulLife");
    }

    // Update is called once per frame
    void Update()
    {
        if(pl.transform.localScale.x==1)
            direction=new Vector3(1f, 0f, 0f);
        else
            direction=new Vector3(-1f, 0f, 0f);
        transform.Rotate(new Vector3(0,0,45)*Time.deltaTime*-25);
        if(act==false){
            lDirection=direction;
            act=true;
        }
        transform.position=Vector3.MoveTowards(transform.position,transform.position+lDirection, speed*Time.deltaTime);
    }
    void OnCollisionEnter2D(Collision2D collision){ //уничтожение пули при столкновении
        if(collision.gameObject.name=="Enemy"){
            print("destroy");
            Destroy(this.gameObject);
        }
    }
    IEnumerator BulLife() //уничтожение пули через 4с
    {
        yield return new WaitForSeconds(4.0f);
        Destroy(this.gameObject);
        StopCoroutine("BulLife");
    }
}
