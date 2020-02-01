using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Froggy : MonoBehaviour
{
    private Rigidbody2D PlayerRb;
    private float timerun=0.0F;
    private float antime;
    private Bullet bullet;
    public GameObject _player;
    private SpriteRenderer sprite_Renderer_B;
    private SpriteRenderer sprite_Renderer_F;
    private Animator animator;
    private AnimatorClipInfo[] m_AnimatorClipInfo;
    private void Awake()
    {
        animator = gameObject.GetComponent<Animator>();
        bullet = Resources.Load<Bullet>("Bullet");
        sprite_Renderer_F = gameObject.GetComponent<SpriteRenderer>();
        animator = gameObject.GetComponent<Animator>();
        m_AnimatorClipInfo = animator.GetCurrentAnimatorClipInfo(0);
        antime = m_AnimatorClipInfo[0].clip.length;
    }
    private bool CheckTime()
    {
        return timerun >= antime;
    }
    private void Update()
    {
        timerun += Time.deltaTime;
        if(CheckTime())
        {
            Vector3 position = transform.position;
            position.y += 0.1f;
            Bullet newb = Instantiate(bullet, position, bullet.transform.rotation) as Bullet;
            sprite_Renderer_B = newb.GetComponent<SpriteRenderer>();
            sprite_Renderer_B.color = new Color(27,190,0);
            newb.tag = "EnemyBullet";
            newb._player = _player; 
            newb.Direction = newb.transform.right * (sprite_Renderer_F.flipX ? 1.0f : -1.0f);
            timerun = 0;
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "PlayerBullet")
        {
            Destroy(gameObject);
        }
        if (collision.tag == "PlayerBody")
        {
            PlayerRb = _player.GetComponent<Rigidbody2D>();
            PlayerRb.velocity = Vector3.zero;
            PlayerRb.AddForce(new Vector2(0f, 5f), ForceMode2D.Impulse);
            Destroy(gameObject);
        }
        if (collision.tag == "PlayerHead")
        {
            _player.GetComponent<Player>().Get_Damage();
            PlayerRb = _player.GetComponent<Rigidbody2D>();
            _player.GetComponent<Player>().CanMove = false;
            PlayerRb.velocity = Vector2.zero;
            if (_player.transform.position.x < transform.position.x)
            {
                PlayerRb.AddForce(new Vector2(-5f, 3f), ForceMode2D.Impulse);
            }
            else if (_player.transform.position.x > transform.position.x)
            {
                PlayerRb.AddForce(new Vector2(5f, 3f), ForceMode2D.Impulse);
            }
        }
    }
}
