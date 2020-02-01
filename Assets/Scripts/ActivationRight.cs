using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivationRight : MonoBehaviour
{
    public Sprite sprite;
    public Animator animator;
    public SpriteRenderer srender;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.tag =="PlayerBody")
        {
            srender.sprite = sprite;
            animator.SetBool("MoveLeft", false);
            animator.SetBool("MoveRight", true);
        }
    }
}
