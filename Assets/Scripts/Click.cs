using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class Click : MonoBehaviour
{
    private Button _button;
    void Start()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        switch (_button.name)
        {
            case "StartButton": { SceneManager.LoadScene("Level1"); } break;
            case "ExitButton": { Application.Quit(); }break;
        }
        
    }
}