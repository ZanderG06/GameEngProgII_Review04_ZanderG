using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    Vector2 moveInput;
    Rigidbody2D rb;

    public bool moveEnabled;
    public SpriteRenderer spriteRenderer;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        moveEnabled = true;
    }

    private void Update()
    {
        HandlePlayerMovement();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    private void HandlePlayerMovement()
    {
        if (!moveEnabled) return;
        rb.MovePosition(rb.position + moveSpeed * Time.deltaTime * moveInput);
    }
}