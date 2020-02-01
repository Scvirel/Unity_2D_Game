using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D other)
    {
        if(other.tag == "PLayerHead" || other.tag =="PlayerBody")
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                SceneManager.LoadScene("Level2");
            }
        }
    }
}
