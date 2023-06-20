using UnityEngine;
using UnityEngine.SceneManagement;

public class GameUI : MonoBehaviour
{
    [SerializeField] DirectionalButton[] directionalButtons;
    [SerializeField] GameObject menuButton;
    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject gameOverMenu;

    public void HandleGameOver() {
        foreach (DirectionalButton dbtn in directionalButtons) {
            dbtn.gameObject.SetActive(false);
            menuButton.SetActive(false);
        }
        gameOverMenu.SetActive(true);
    }

    public void PauseButtonPressed() {
        foreach(DirectionalButton dbtn in directionalButtons) {
            dbtn.gameObject.SetActive(false);
            menuButton.SetActive(false);
        }
        pauseMenu.SetActive(true);
    }

    public void ResumePressed() {
        foreach (DirectionalButton dbtn in directionalButtons) {
            dbtn.gameObject.SetActive(true);
            menuButton.SetActive(true);
        }
        pauseMenu.SetActive(false);

    }

    public void RestartPressed() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void QuitPressed() {
        Application.Quit();
    }


}
