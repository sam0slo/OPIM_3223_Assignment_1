using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{

    public bool hardMode;

    public Animator startButton;
    public Animator settingsButton;
    public Animator settingsPanel;

    void Start()
    {
        hardMode = false;
    }

    public void StartGame()
    {
        if (hardMode)
        {
            SceneManager.LoadScene("Main");
        }
        else
        {
            SceneManager.LoadScene("Main2");
        }
        
    }

    public void ToggleDifficulty()
    {
        if (hardMode)
        {
            hardMode = false;
        }
        else
        {
            hardMode = true;
        }
    }

    public void OpenSettings()
    {
        startButton.SetBool("isHidden", true);
        settingsButton.SetBool("isHidden", true);
        settingsPanel.SetBool("isHidden", false);
    }
    
    public void CloseSettings()
    {
        startButton.SetBool("isHidden", false);
        settingsButton.SetBool("isHidden", false);
        settingsPanel.SetBool("isHidden", true);
    }

}
