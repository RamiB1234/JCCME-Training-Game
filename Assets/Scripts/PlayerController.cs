using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rbody;
    float axisH = 0.0f;
    public float speed = 3.0f;
    public int health = 10;
    public GameObject healthBar;
    public GameObject groundChecker;

    public AudioSource jumpSFX;
    public AudioSource hitSFX;

    public float jump = 9.0f;
    public LayerMask groundLayer;
    bool gonnaJump = false;
    bool onGround = false;
    bool isVulnerable = true;

    private Animator animator;

    public static PlayerController Instance;

    enum State
    {
        playing,
        gameComplete,
        gameOver,
    }

    State gameState = State.playing;

    void Awake()
    {
        Instance = this;
        animator = gameObject.GetComponent<Animator>();
    }

    void Start()
    {
        // Set max health:
        healthBar.GetComponent<Slider>().maxValue = health;
        healthBar.GetComponent<Slider>().value = health;

        rbody = GetComponent<Rigidbody2D>();
        gameState = State.playing;
    }

    void Update()
    {
        if (gameState != State.playing)
        {
            return;
        }

        healthBar.GetComponent<Slider>().value = health;

        axisH = Input.GetAxisRaw("Horizontal");
        if (axisH > 0.0f)
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
        else if (axisH < 0.0f)
        {
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        }

        if(axisH !=0 && onGround)
        {
            animator.SetBool("IsRunning", true);
        }
        else
        {
            animator.SetBool("IsRunning", false);
        }

        if(onGround==false)
        {
            animator.SetBool("IsJumping", true);
        }
        else
        {
            animator.SetBool("IsJumping", false);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }

    void FixedUpdate()
    {
        if (gameState != State.playing)
        {
            return;
        }

        onGround = Physics2D.Linecast(transform.position,
            groundChecker.transform.position, groundLayer);

        if (onGround || axisH != 0)
        {
            rbody.velocity = new Vector2(speed * axisH, rbody.velocity.y);
        }

        if (onGround && gonnaJump)
        {
            Vector2 jumpPw = new Vector2(0, jump);
            rbody.AddForce(jumpPw, ForceMode2D.Impulse);
            gonnaJump = false;
            jumpSFX.Play();
        }
    }

    void Jump()
    {
        gonnaJump = true;
    }

    public void Goal()
    {
        gameState = State.gameComplete;
        GameStop();
    }

    public void GameOver()
    {
        gameState = State.gameOver;
        GameStop();
        GetComponent<CapsuleCollider2D>().enabled = false;
        rbody.AddForce(new Vector2(0, 5), ForceMode2D.Impulse);
    }

    void GameStop()
    {
        Rigidbody2D rbody = GetComponent<Rigidbody2D>();
        rbody.velocity = new Vector2(0, 0);
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if(col.transform.tag == "Needle" && isVulnerable)
        {
            health -= 2;
            StartCoroutine(PlayHitEffect());
        }

        if (col.transform.tag == "SpikeyEnemy" && isVulnerable)
        {
            health -= 4;
            StartCoroutine(PlayHitEffect());
        }
    }

    IEnumerator PlayHitEffect()
    {
        isVulnerable = false;
        hitSFX.Play();

        for (int i=0; i<8;i++)
        {
            gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
            yield return new WaitForSeconds(0.05f);
            gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
            yield return new WaitForSeconds(0.05f);
        }

        isVulnerable = true;
    }
}