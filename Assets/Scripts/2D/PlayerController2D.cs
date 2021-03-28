using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2D : MonoBehaviour{
    public int PlayerLives=5;
    public int PlayerScore=0;
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
    bool isDeath;
    Animator anim;
    LoseMenu loseMenu;
    WinMenu winMenu;
    bool isStep;
    // Start is called before the first frame update
    void Start(){
        if(SceneManager.GetActiveScene().buildIndex==1){
            HiScoreScr.d2CurScore=PlayerScore;
            //print("dfd");
        }
        else{
            PlayerScore=HiScoreScr.d2CurScore;
            print(HiScoreScr.d2CurScore);
            //print("dgfg");
        }
        rb2=GetComponent<Rigidbody2D>();
        sprRen=GetComponentInChildren<SpriteRenderer>();
        anim=gameObject.transform.GetChild(0).GetComponent<Animator>();
        loseMenu=GameObject.Find("LoseMenuCanvas").GetComponent<LoseMenu>();
        winMenu=GameObject.Find("WinMenuCanvas").GetComponent<WinMenu>();
        //healthBar.SetMaxHealth(MaxPlayerLives);
    }

    void FixedUpdate(){
        CheckGround();
    }

    void Update(){
        anim.SetFloat("Speed", Mathf.Abs(Input.GetAxis("Horizontal")));
        if(Input.GetButtonDown("Fire1")) Shoot();
        if(Input.GetButton("Horizontal")){
            Run();
            if(isStep==false){
                FindObjectOfType<AudioManager>().Play("Step");
                isStep=true;
                StartCoroutine("StepByStep");
                //print("cfsvgd");
            }
        }
        if(Input.GetButtonDown("Jump")&&isGrounded) Jump(); //прыжок
        if(PlayerLives==0&&isDeath==false){
            isDeath=true;
            anim.SetBool("isDeath", isDeath); 
            FindObjectOfType<AudioManager>().Play("Lose");
            StartCoroutine("AfterAnim");
            speed=0f;
            // PlayerLives=5;
            // transform.position=rPoint.position;
        }
        //print(PlayerLives);
        //healthBar.SetHealth(PlayerLives);
        if(PlayerScore>HiScoreScr.d2HiScore)
            HiScoreScr.d2HiScore=PlayerScore;
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
        FindObjectOfType<AudioManager>().Play("PlShoot");
    }
    
    void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.name=="FloorDown"){
            FindObjectOfType<AudioManager>().Play("Lose");
            if(loseMenu.isLose==false)
                loseMenu.isLose=true;
            transform.position=rPoint.position;
        }
        if(collision.gameObject.name=="EndLevel"){
             if(winMenu.isWin==false)
                winMenu.isWin=true;
            transform.position=rPoint.position;
        }
        if(collision.gameObject.name=="Obstacle"){
            PlayerLives--;
        }
    }

    IEnumerator AfterAnim(){
        yield return new WaitForSeconds(2f);
        FindObjectOfType<AudioManager>().Play("Boom");
        if(loseMenu.isLose==false)
            loseMenu.isLose=true;
    }

    IEnumerator StepByStep(){
        yield return new WaitForSeconds(0.4f);
        isStep=false;
    }
}
