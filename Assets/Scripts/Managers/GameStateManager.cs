using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.LowLevel;

public enum GameState
{
    None,
    MainMenu,
    Playing,
    Paused
}

public class GameStateManager : MonoBehaviour
{
    ServiceHub serviceHub;
    [SerializeField] GameState currentState;

    private void Start()
    {
        serviceHub = ServiceHub.Instance;
        SetState(GameState.MainMenu);
    }

    private void OnStateChanged(GameState newState)
    {
        switch (newState)
        {
            case GameState.MainMenu:
                serviceHub.UIManager.ShowMainMenu();
                serviceHub.PlayerController.moveEnabled = false;
                serviceHub.PlayerController.spriteRenderer.enabled = false;
                break;

            case GameState.Playing:
                serviceHub.UIManager.ShowGameplay();
                serviceHub.PlayerController.moveEnabled = true;
                serviceHub.PlayerController.spriteRenderer.enabled = true;
                break;

            case GameState.Paused:
                serviceHub.UIManager.ShowPauseMenu();
                serviceHub.PlayerController.moveEnabled = false;
                serviceHub.PlayerController.spriteRenderer.enabled = true;
                break;

            default:
                Debug.Log($"Unknown game state: {newState}");
                break;
        }
    }

    public void SetState(GameState newState)
    {
        if (currentState == newState) return;
        currentState = newState;
        OnStateChanged(currentState);
    }

    //Unity buttons don't show SetState for some reason
    public void SetStateButton(int stateIndex)
    {
        switch (stateIndex)
        {
            case 0:
                SetState(GameState.MainMenu);
                break;
            case 1:
                SetState(GameState.Playing);
                break;
            case 2:
                SetState(GameState.Paused);
                break;
            default:
                Debug.Log($"Unknown game state: {stateIndex}");
                break;
        }
    }

    public void OnPause(InputAction.CallbackContext context)
    {
        if(context.performed) SetState(GameState.Paused);
    }
}