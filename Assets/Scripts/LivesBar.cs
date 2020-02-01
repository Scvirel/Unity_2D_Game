using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivesBar : MonoBehaviour
{
    private Transform[] hearts = new Transform[5];

    public GameObject _player;



    private void Awake()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            hearts[i] = transform.GetChild(i);
        }
    }
    public void Refresh()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < _player.GetComponent<Player>().Lives)
            {
                hearts[i].gameObject.SetActive(true);
            }
            else
            {
                hearts[i].gameObject.SetActive(false);
            }
        }
    }
}
