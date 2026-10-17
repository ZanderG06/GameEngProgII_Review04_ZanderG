using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject mainMenuUI;
    [SerializeField] GameObject pauseMenuUI;
    [SerializeField] GameObject gameplayUI;

    private void DisableAll()
    {
        mainMenuUI.SetActive(false);
        pauseMenuUI.SetActive(false);
        gameplayUI.SetActive(false);
    }

    public void ShowMainMenu()
    {
        DisableAll();
        mainMenuUI.SetActive(true);
    }

    public void ShowPauseMenu()
    {
        DisableAll();
        pauseMenuUI.SetActive(true);
    }

    public void ShowGameplay()
    {
        DisableAll();
        gameplayUI.SetActive(true);
    }

    public void OnQuit()
    {
        Application.Quit();
    }
}