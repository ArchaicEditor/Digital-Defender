using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }

    }

    public void GameOver()
    {
        UIController.Instance.gameOverScreen.SetActive(true);
    }

    public void Restart()
    {
        SceneManager.LoadScene("Level 1");
    }
}
