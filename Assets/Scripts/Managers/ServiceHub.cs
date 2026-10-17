using UnityEngine;

public class ServiceHub : MonoBehaviour
{
    public static ServiceHub Instance { get; private set; }

    [Header("System References")]
    [SerializeField] UIManager uiManager;
    [SerializeField] PlayerController playerController;

    public UIManager UIManager => uiManager;
    public PlayerController PlayerController => playerController;

    private void Awake()
    {
        if (Instance != null && Instance != this) Destroy(this);
        else Instance = this;
    }
}