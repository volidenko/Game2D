using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    float jumpForse=15f;
    Rigidbody2D rb2;
    public bool isGrounded;
    public GameObject bullet;
    public GameObject bulSpawn;
    public Transform rPoint;
    public HealthBarScript healthBar;


    // Start is called before the first frame update
    void Start()
    {
        rb2=GetComponent<Rigidbody2D>();
        SpriteRenderer=GetComponentInChildren<SpriteRenderer>();
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
        if(Input.GetButtonDown("Jump")&&isGrounded) Jump();
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
}
