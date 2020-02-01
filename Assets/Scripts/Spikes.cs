using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    private Rigidbody2D _plyerRigitBody;
    public GameObject _player;

    private void Awake()
    {
        _plyerRigitBody = _player.GetComponent<Rigidbody2D>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag =="PlayerBody" || other.tag == "PlayerHead")
        {
            _player.GetComponent<Player>().Get_Damage();
            _plyerRigitBody.velocity = Vector3.zero;
            _plyerRigitBody.AddForce(new Vector2(0f, 5f), ForceMode2D.Impulse);
        }
        
    }
}
