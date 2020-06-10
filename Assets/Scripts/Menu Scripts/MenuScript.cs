using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public string GotoGame;

    public static bool closing;
    public void PlayGame(){
        closing = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene ().buildIndex + 2);
    }

    public void MainMenu(){
        closing = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void MainMenu2(){
        closing = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
    }

    public void MainMenu3(){
        closing = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 3);
    }

    public void MainMenu4(){
        closing = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 4);
    }

    public void MainMenu5(){
        closing = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 5);
    }

    public void MainMenu6(){
        closing = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 6);
    }

    public void PlayTutorial(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Quit(){
        Application.Quit();
    }
}
