using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeItem : MonoBehaviour
{
    public GameObject item;
    public GameObject player;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(tag=="Cherry" && (other.tag=="PlayerHead" || other.tag == "PlayerBody"))
        {
            player.GetComponent<Player>().Is_Boosted = true;
            player.GetComponent<Player>().timelefttoboost = 5f;
            Destroy(item);
        }
        if (tag == "Gem" && (other.tag == "PlayerHead" || other.tag == "PlayerBody"))
        {
            Destroy(item);
        }
           
    }
}
