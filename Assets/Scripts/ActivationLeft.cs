using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivationLeft : MonoBehaviour
{
    public GameObject platform;
    public SpriteRenderer sr;
    public Sprite sprite;
    public Animator animator;

    private void OnTriggerEnter2D(Collider2D colider)
    {
        if (colider.tag == "PlayerBody")
        {
            sr.sprite = sprite;
            animator.SetBool("MoveRight", false);
            animator.SetBool("MoveLeft", true);
        }
    }
}
