using UnityEngine;
using UnityEngine.InputSystem;
public class WalkerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private InputAction moveAction;

    [Header("Movement")]
    [SerializeField] private float moveSpeed = 6f;


    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        //InputSystem.actions -> covers the entire user interactions
        moveAction = InputSystem.actions.FindAction("Move");
       
    }

    private float moveInput;
    void Update()
    {
        // move on horizontal axis
        moveInput = moveAction.ReadValue<Vector2>().x;

        //if we move
        if (moveInput != 0f)
        {
            //
            spriteRenderer.flipX = moveInput > 0f;
        }
       
    }
    void FixedUpdate()
    {
        // its gonna move it move it
        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);
    }
}
