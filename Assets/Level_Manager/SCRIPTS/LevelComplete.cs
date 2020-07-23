using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelComplete : MonoBehaviour {

    //public string Level= SceneManager.GetActiveScene().name;
    int LevelAmount = 50;
    private int currentLevel;

    private void Start()
    {
        CheckLevel();
        PlayerPrefs.SetInt("check" , 10);
    }

    void CheckLevel()
    {
        for (int i = 1; i <= LevelAmount; i++)
        {
            if (SceneManager.GetActiveScene().name == "Stage" + i)
            {
                currentLevel = i;
                SaveMyGame();
            }
        }
    }

    void SaveMyGame()
    {
        int NextLevel = currentLevel + 1;
        if(NextLevel <= LevelAmount)
        {
            PlayerPrefs.SetInt("Stage" + NextLevel.ToString(), 1);
        }
        
        Invoke("LoadNextLevel" , 2);
    }

    public void LoadNextLevel ()
	{
       // AdManager.Instance.bannerad.Destroy();

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}

}
