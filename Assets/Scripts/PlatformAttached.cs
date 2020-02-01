﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformAttached : MonoBehaviour
{
    public GameObject player;
    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject ==  player)
        {
            player.transform.parent = transform;
        }
    }
    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject == player)
        {
            player.transform.parent = null;
        }
    }
}
