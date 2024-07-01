using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveNextLevel : MonoBehaviour
{
    public int nextSceneLoad;

    // Start is called before the first frame update
    void Start()
    {
        nextSceneLoad = SceneManager.GetActiveScene().buildIndex + 1;
    }

    public void BackButtonTapped()
    {
        SceneManager.LoadScene(1);
    }

    public void ButtonTapped()
    {
        SceneManager.LoadScene(nextSceneLoad);

        if (MainMenuManager.categories == MainMenuManager.Categories.Astronomy && nextSceneLoad > PlayerPrefs.GetInt("levelAt1"))
        {
            PlayerPrefs.SetInt("levelAt1", nextSceneLoad);
        }
        else if (MainMenuManager.categories == MainMenuManager.Categories.History && nextSceneLoad > PlayerPrefs.GetInt("levelAt2"))
        {
            PlayerPrefs.SetInt("levelAt2", nextSceneLoad);
        }
        else if (MainMenuManager.categories == MainMenuManager.Categories.Mythology && nextSceneLoad > PlayerPrefs.GetInt("levelAt3"))
        {
            PlayerPrefs.SetInt("levelAt3", nextSceneLoad);
        }
    }
}
