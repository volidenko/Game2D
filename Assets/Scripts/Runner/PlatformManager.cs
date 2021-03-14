using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : MonoBehaviour{
    [SerializeField]	
    private GameObject[] _platformPrefabs;	
    private float offset=0f;

    // Start is called before the first frame update
    void Start () {				
        for (int i = 0; i< _platformPrefabs.Length;i++){
            Instantiate(_platformPrefabs[i],new Vector3(0,0,offset),Quaternion.Euler(0,0,0));
            offset+=100f;
        }
    }

    public void RecyclePlatform(GameObject platform, float loffset){
        platform.transform.position= new Vector3(0,0,offset);		
        offset+=loffset;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
