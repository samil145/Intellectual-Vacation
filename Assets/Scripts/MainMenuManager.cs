using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    internal enum Categories
    {
        Astronomy = 2,
        History = 5,
        Mythology = 8
    }

    static internal Categories categories;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            PlayerPrefs.DeleteAll();
        }
    }

    public void ButtonTapped(int index)
    {
        switch (index)
        {
            case 1:
                categories = Categories.Astronomy;
                break;
            case 2:
                categories = Categories.History;
                break;
            case 3:
                categories = Categories.Mythology;
                break;
        }

        SceneManager.LoadScene(1);
    }
}
