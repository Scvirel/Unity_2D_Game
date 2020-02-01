using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Player : MonoBehaviour
{
    
    private int lives=5;
    private LivesBar _livesBar;
    public int Lives{ set { lives = value;} get { return lives; } }
    private Bullet bullet;
    public float speed;
    public Vector2 lastp;
    public bool IsGrounded=true,CanMove=true;
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private Animator animator;
    private BoxCollider2D pbc;
    public float timelefttoboost=5f;
    public bool Is_Boosted = false;

    private void Awake()
    {
        _livesBar = FindObjectOfType<LivesBar>();
        bullet = Resources.Load<Bullet>("Bullet");
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        pbc = GetComponent<BoxCollider2D>();
    }
    private void Shoot()
    {
        Vector3 position = transform.position;
        Bullet newb = Instantiate(bullet, position, bullet.transform.rotation) as Bullet;
        newb.tag = "PlayerBullet";
        newb.Direction = newb.transform.right * (sr.flipX ? -1.0f : 1.0f);
    }
    void FixedUpdate()
    {
        if (CanMove && Is_Boosted==false)
        {
            rb.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, rb.velocity.y);
        }
        else if(CanMove)
        {
            rb.velocity = new Vector2(Input.GetAxis("Horizontal") * speed * 3, rb.velocity.y);
        }
        if (Input.GetAxis("Horizontal") < 0)
        {
            sr.flipX = true;
        }
        else
        {
            sr.flipX = false;
        }
    }
    void Jump()
    {
        if(Is_Boosted==false)
        {
            rb.AddForce(transform.up * 5f, ForceMode2D.Impulse);
        }
        else
        {
            rb.AddForce(transform.up * 8f, ForceMode2D.Impulse);
        }
        animator.SetBool("IsJumping", true);
        IsGrounded = false;
    }
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
        if(Is_Boosted)
        {
            CalculetionEndTimeOfBoost();
        }
        
        if (Input.GetAxisRaw("Vertical") < 0)
        {
            animator.SetBool("IsCrouching", true);
        }

        else
        {
            animator.SetBool("IsCrouching", false);
        }
        if(Input.GetKeyDown(KeyCode.Space)&& IsGrounded)
        {
            Jump();
        }
        animator.SetFloat("Speed", Mathf.Abs(Input.GetAxis("Horizontal") * speed));
    }
    private void CalculetionEndTimeOfBoost()
    {
        timelefttoboost -= Time.deltaTime;
        if(timelefttoboost<0.0f)
        {
            timelefttoboost = 5f;
            Is_Boosted = false;
        }
    }
    public void Get_Damage()
    {
        Lives -= 1;
        _livesBar.Refresh();
        if (Lives<=0)
        {
            Death();
        }
    }
    public void Death()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
