using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Eagle : MonoBehaviour
{
    public GameObject player;
    Rigidbody2D PlayerRb;
    private float speed = 2.0f;
    private SpriteRenderer _spriteRenderer;
    private Vector3 _direction;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void Start()
    {
        _direction = transform.right;
    }
    private void Update()
    {
        Move();
    }
    private void Move()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position + (transform.up * -0.5f) + transform.right*_direction.x, 0.2f);
        if (colliders.Length == 0)
        {
            _direction *= -1f;
            _spriteRenderer.flipX = !_spriteRenderer.flipX;
        }
        transform.position = Vector3.MoveTowards(transform.position, transform.position + _direction, speed * Time.deltaTime);
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "PlayerBullet")
        {
            Destroy(gameObject);
        }
        if(collision.tag=="PlayerBody")
        {
            PlayerRb = player.GetComponent<Rigidbody2D>();
            PlayerRb.velocity = Vector3.zero;
            PlayerRb.AddForce(new Vector2(0f, 5f), ForceMode2D.Impulse);
            Destroy(gameObject);
        }
        if (collision.tag == "PlayerHead")
        {
            player.GetComponent<Player>().Get_Damage();
            PlayerRb = player.GetComponent<Rigidbody2D>();
            player.GetComponent<Player>().CanMove = false;
            PlayerRb.velocity = Vector2.zero;
            if (player.transform.position.x < transform.position.x)
            {
                PlayerRb.AddForce(new Vector2(-5f, 3f), ForceMode2D.Impulse);
            }
            else if (player.transform.position.x > transform.position.x)
            {
                PlayerRb.AddForce(new Vector2(5f, 3f), ForceMode2D.Impulse);
            }
        }
    }
}
