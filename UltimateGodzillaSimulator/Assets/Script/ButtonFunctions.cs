using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonFunctions : MonoBehaviour
{
    public void PlayButton(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitButton(){
        Application.Quit();
    }

    public void MenuButton(){
        SceneManager.LoadScene("MainMenu");
    }
}
