using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingDeath : MonoBehaviour
{
    public GameObject _player;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "PlayerBody")
        {
            _player.GetComponent<Player>().Death();
        }
    }
}
