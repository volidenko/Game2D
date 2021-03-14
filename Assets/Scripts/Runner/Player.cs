using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour{
    private CharacterController _controller;
    [SerializeField]
    private float _speed=5f;
    [SerializeField]
    private float _jumpHeight=20f;
    [SerializeField]
    private float _gravity=1f;
    private float _yVelocity=0f;
    public int playerScore=0;
    public int playerLive=5;
    public GameObject Obs_pref;
    public Text textLive;
    public Text textScore;

    // Start is called before the first frame update
    void Start(){
        _controller=GetComponent<CharacterController>();
        StartCoroutine("CreateObs");
    }

    // Update is called once per frame
    void Update(){
        if(this.transform.position.z%20==0){
        }
        Vector3 direction = new Vector3(0,0,1);		
        Vector3 velocity = direction*_speed;		
	    if(_controller.isGrounded==true){
            if(Input.GetButtonDown("Jump")){				
	            _yVelocity = _jumpHeight;			
	        }		
        }
        else{				
            _yVelocity-=_gravity;
            }		 
        velocity.y=_yVelocity;		
        _controller.Move(velocity*Time.deltaTime);	
	    if(Input.GetAxis("Horizontal")!=0){			
	        Vector3 Ldirection = transform.right*Input.GetAxis("Horizontal");
            transform.position=Vector3.MoveTowards(transform.position, transform.position+Ldirection, _speed*Time.deltaTime);
            transform.position=new Vector3(Mathf.Clamp(transform.position.x, -5.5f,5.5f), transform.position.y, transform.position.z);
        }
        textLive.text=playerLive.ToString();
        textScore.text=playerScore.ToString();
    }

    IEnumerator CreateObs(){
        while(true){
            yield return new WaitForSeconds(4.0f);
            Instantiate(Obs_pref,new Vector3(0,transform.position.y, transform.position.z+20),Quaternion.Euler(0,0,0));
        }    
    }

        void OnCollisionEnter(Collision col){
    }

        void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag=="Respawn") 
            playerScore++;
        if (other.gameObject.tag=="Enemy") 
            playerLive--;
        print("ok");
    }
}
