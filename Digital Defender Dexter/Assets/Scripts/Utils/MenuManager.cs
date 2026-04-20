using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{

    public GameObject startMenu;
    public GameObject levelSelect;
    public void LevelSelect()
    {
        startMenu.SetActive(false);
        levelSelect.SetActive(true);
        
    }
    public void Level1()
    {
        SceneManager.LoadScene("Level 1");
    }

    public void Level2()
    {
        SceneManager.LoadScene("Level 2");
    }

    public void Level3()
    {
        SceneManager.LoadScene("Level 3");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
