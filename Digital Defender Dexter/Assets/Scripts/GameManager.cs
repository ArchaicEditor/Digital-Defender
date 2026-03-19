using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public float gameTime;
    public bool gameActive;

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

    private void Start()
    {
        gameActive = true;
    }

    private void Update()
    {
        if (gameActive)
        {
            gameTime += Time.deltaTime;
            UIController.Instance.UpdateTimer(gameTime);

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Pause();
            }
        }
        
    }

    public void GameOver()
    {
        gameActive=false;
        UIController.Instance.gameOverScreen.SetActive(true);
    }

    public void Restart()
    {
        SceneManager.LoadScene("Level 1");
    }

    public void Pause()
    {
        if (UIController.Instance.pauseScreen.activeSelf == false && UIController.Instance.gameOverScreen.activeSelf == false)
        {
            UIController.Instance.pauseScreen.SetActive(true);
            Time.timeScale = 0f;
        }
        else
        {
            UIController.Instance.pauseScreen.SetActive(false);
            Time.timeScale = 1f;
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

}
