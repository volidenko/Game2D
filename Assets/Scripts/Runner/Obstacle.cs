using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour{
    private GameObject pl;
    public GameObject _dangerPref;
    // Start is called before the first frame update
    void Start(){
        pl=GameObject.Find("Player");
        StartCoroutine("LifeTime");
        Create();
    }

    // Update is called once per frame
    void Update(){
        
    }

    void Create(){
        Instantiate(_dangerPref, new Vector3(Random.Range(-5f,5f), transform.position.y, transform.position.z), Quaternion.Euler(0,0,0));
    }

    IEnumerator LifeTime(){
        yield return new WaitForSeconds(4.0f);
        Destroy(this.gameObject);
    }    
}
