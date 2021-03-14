using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2D : MonoBehaviour
{
    public int PlayerLives=5;
    public int MaxPlayerLives=5;
    float speed=5f;
    float jumpForse=15f;
    Rigidbody2D rb2;
    SpriteRenderer sprRen;
    public bool isGrounded;
    public GameObject bullet;
    public GameObject bulSpawn;
    public Transform rPoint;
    public HealthBarScript healthBar;

    // Start is called before the first frame update
    void Start()
    {
        rb2=GetComponent<Rigidbody2D>();
        sprRen=GetComponentInChildren<SpriteRenderer>();
        healthBar.SetMaxHealth(MaxPlayerLives);
    }

    void FixedUpdate()
    {
        CheckGround();
    }
    void Update()
    {
        if(Input.GetButtonDown("Fire1")) Shoot();
        if(Input.GetButton("Horizontal")) Run();
        if(Input.GetButtonDown("Jump")&&isGrounded) Jump(); //прыжок
        if(PlayerLives==0){
            PlayerLives=5;
            transform.position=rPoint.position;
        }
        print(PlayerLives);
        healthBar.SetHealth(PlayerLives);
    }
    
    public void Run(){
        Vector3 direction=transform.right*Input.GetAxis("Horizontal");
        transform.position=Vector3.MoveTowards(transform.position, transform.position+direction, speed*Time.deltaTime);
        if(direction.x<0f)
            this.transform.localScale=new Vector3(-1f, 1f, 1f);
        else
            this.transform.localScale=new Vector3(1f, 1f, 1f);

    }
    public void Jump(){
        rb2.AddForce(transform.up*jumpForse,ForceMode2D.Impulse);
    }
    void CheckGround(){
       Collider2D[] colliders=Physics2D.OverlapCircleAll(transform.position, 0.1f);
       isGrounded=colliders.Length>1;
    }
    void Shoot(){
        Vector3 position=bulSpawn.transform.position;
        Instantiate(bullet, position, bullet.transform.rotation);
    }
    void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.name=="FloorDown"){
            transform.position=rPoint.position;
        }
        if(collision.gameObject.name=="EndLevel"){
            transform.position=rPoint.position;
        }
    }
}
