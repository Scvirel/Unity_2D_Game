using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnGround : MonoBehaviour
{
    public GameObject player;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "PlayerHead")
        {
                player.GetComponent<Player>().CanMove = false;
        }
        if (collision.collider.tag == "PlayerBody")
        {
            player.GetComponent<Player>().IsGrounded = true;
            player.GetComponent<Player>().CanMove = true;
            player.GetComponent<Animator>().SetBool("IsJumping", false);
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.tag == "PlayerHead")
        {
            if (player.GetComponent<Player>().IsGrounded == false)
            {
                player.GetComponent<Player>().CanMove = false;
            }
            else
            {
                player.GetComponent<Player>().CanMove = true;
            }
        }
        if (collision.collider.tag == "PlayerBody")
        {
            player.GetComponent<Player>().IsGrounded = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "PlayerBody")
        {
            player.GetComponent<Player>().IsGrounded = false;
        }
        if (collision.collider.tag == "PlayerHead")
        {
            player.GetComponent<Player>().CanMove = true;
        }
    }

}
