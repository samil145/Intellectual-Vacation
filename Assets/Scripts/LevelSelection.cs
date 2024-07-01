using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelection : MonoBehaviour
{
    [SerializeField]
    Button[] levelButtons;

    int levelAt;

    internal int levelAt1, levelAt2, levelAt3;

    // Start is called before the first frame update
    void Start()
    {
        //levelAt = PlayerPrefs.GetInt("levelAt", (int)MainMenuManager.categories);

        levelAt1 = PlayerPrefs.GetInt("levelAt1", 2);
        levelAt2 = PlayerPrefs.GetInt("levelAt2", 5);
        levelAt3 = PlayerPrefs.GetInt("levelAt3", 8);

        for (int i = 0; i < levelButtons.Length; i++)
        {
            if (MainMenuManager.categories == MainMenuManager.Categories.Astronomy)
            {
                if (i + (int)MainMenuManager.categories > levelAt1)
                {
                    levelButtons[i].interactable = false;
                }
            }
            else if (MainMenuManager.categories == MainMenuManager.Categories.History)
            {
                if (i + (int)MainMenuManager.categories > levelAt2)
                {
                    levelButtons[i].interactable = false;
                }
            }
            else if (MainMenuManager.categories == MainMenuManager.Categories.Mythology)
            {
                if (i + (int)MainMenuManager.categories > levelAt3)
                {
                    levelButtons[i].interactable = false;
                }
            }
        }
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            PlayerPrefs.DeleteAll();
        }
    }

    public void openLevel(int levelID)
    {
        SceneManager.LoadScene(levelID+(int)MainMenuManager.categories - 1);
    }

    public void BackButtonTapped()
    {
        SceneManager.LoadScene(0);
    }
}
