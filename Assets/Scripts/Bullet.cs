using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float speed=10.0f;
    private Vector3 direction;
    private SpriteRenderer sprite;
    public Vector3 Direction { set { direction = value; } }
    public GameObject _player;

    private void Start()
    {
        Destroy(gameObject, 1.5f);
    }
    private void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, speed * Time.deltaTime);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (tag == "PlayerBullet" && (other.gameObject.tag == "PlayerHead" || other.gameObject.tag == "PlayerBody")) return;
        if (tag == "EnemyBullet" && (other.gameObject.tag == "PlayerHead" || other.gameObject.tag == "PlayerBody"))
        {
            _player.GetComponent<Player>().Get_Damage();
        }
        Destroy(gameObject);
    }
}
