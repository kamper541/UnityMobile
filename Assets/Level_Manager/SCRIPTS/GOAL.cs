using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GOAL : MonoBehaviour {

    public GameObject level_complete;

    public int unlock;

    void Start ()
    {
        Time.timeScale = 1;

        unlock = SceneManager.GetActiveScene().buildIndex + 1;

        level_complete.SetActive(false); 


    }

    void OnTriggerEnter(Collider target)
    {
        if (target.CompareTag("Player"))
        {
            //Debug.Log("level reach to:" + PlayerPrefs.GetInt("levelreached"));
            
            PlayerPrefs.SetInt("levelReached", 1);
            PlayerPrefs.Save();
            level_complete.SetActive(true);


        }
    }
}
