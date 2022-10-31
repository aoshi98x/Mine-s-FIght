using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    Animator animPlayer;
    CharacterController ccPlayer;
    Transform trPlayer;
    EnemyAI killCond;
    public GameObject loseCanvas;
    public GameObject pausedCanvas;
    float velocity = 3.0f;
    public float life= 50.0f;
    public bool inRange = false;
    public bool isAtacking = false;
    public bool isWalk = false;
    public bool paused = false;
    public int score =0;
    public Text scoreText;
    public Text lifeText;
    public AudioSource fxPeak;
    public AudioSource fxPoints;
    AudioSource fxWalk;
    
    // Start is called before the first frame update
    void Start()
    {
        ccPlayer = GetComponent<CharacterController>();
        trPlayer = GetComponent<Transform>();
        animPlayer = GetComponent<Animator>();
        fxWalk = GetComponent <AudioSource>();
        lifeText.text = "Life: " + life;
        scoreText.text = "Score: " + score;
        
    }

    

    // Update is called once per frame
    void FixedUpdate()
    {
        killCond = GameObject.FindGameObjectWithTag("Enemy").GetComponent<EnemyAI>();
    }
    void Update()
    {
        
        Move();
        AnimationSwitch();
        Scanner();
        Paused();
        if (life <= 0.0f)
        {
            animPlayer.SetBool("isDead", true);
            animPlayer.SetBool("isATK", false);
            animPlayer.SetBool("isWalk", false);
            this.enabled=false;
            loseCanvas.SetActive(true);
        }
        if(Input.GetButtonDown("Jump"))
        {
            fxPeak.Play();
        }
        if(Input.GetButtonDown("Horizontal") || Input.GetButtonDown("Vertical"))
        {
            fxWalk.Play();
        }
        
    }
    public void Scanner()
    { 
        
        if (Input.GetButton("Jump"))
        {
            isAtacking = true;
        }
        else
        {
            isAtacking = false;
        }
        if (inRange && isAtacking)
        {
            killCond.kill = true;
        }
        else if (inRange && killCond.isAttack)
        {
            life = life - 0.8f;
            lifeText.text = "Life: " + life;
        }
        else
        {
            killCond.kill = false;
            inRange = false;
        }


    }
    public void Move()
    {
        float movH=Input.GetAxis("Horizontal");
        float movV=Input.GetAxis("Vertical");
        Vector3 movEntrada = new Vector3(movH, 0.0f, movV).normalized;
        ccPlayer.SimpleMove(movEntrada.normalized * velocity);
        if(movV > 0)
        {
            trPlayer.localRotation = Quaternion.Euler(0,-180,0);
        }
        else if(movV < 0)
        {
            trPlayer.localRotation = Quaternion.Euler(0,0,0);
        }
        else if(movH < 0)
        {
            trPlayer.localRotation = Quaternion.Euler(0,90,0);
        }
        else if(movH > 0)
        {
            trPlayer.localRotation = Quaternion.Euler(0,-90,0);
        }
        if(movH < 0 && movV > 0)
        {
            trPlayer.localRotation = Quaternion.Euler(0,135,0);
        }
        else if(movH < 0 && movV < 0)
        {
            trPlayer.localRotation = Quaternion.Euler(0,45,0);
        }
        else if(movH > 0 && movV < 0)
        {
            trPlayer.localRotation = Quaternion.Euler(0,-45,0);
        }
        else if(movH > 0 && movV > 0)
        {
            trPlayer.localRotation = Quaternion.Euler(0,-135,0);
        }
        
    }
    void AnimationSwitch()
    {
        float movH=Input.GetAxis("Horizontal");
        float movV=Input.GetAxis("Vertical");
        if(movH < 0 || movH > 0 || movV < 0 || movV > 0)
        {
            animPlayer.SetBool("isWalk", true);
        }
        else
        {
            animPlayer.SetBool("isWalk", false);
        }
        if(Input.GetButton("Jump"))
        {
            animPlayer.SetBool("isATK", true);
            animPlayer.SetBool("isWalk", false);
        }
        else if(Input.GetButtonUp("Jump"))
        {
            animPlayer.SetBool("isATK", false);
            fxPeak.Stop();
        }

    }
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            inRange = true;
        }
    }
    void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Points")
        {
            fxPoints.Play();
            score = score + 150;
            scoreText.text = "Score: " + score;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            inRange = false;
        }
    }
    
   void Paused()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            paused = !paused;
        }
        if(paused)
        {
            Time.timeScale = 0;
            pausedCanvas.SetActive(true);
        }
        else
        {
            Time.timeScale = 1;
            pausedCanvas.SetActive(false);
        }
    }
}
    
