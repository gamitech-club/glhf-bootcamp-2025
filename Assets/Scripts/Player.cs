using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public LayerMask GroundLayers;
    public float MaxSpeed = 8f;
    public float Acceleration = 30f;
    public float Deceleration = 30f;
    public float TurnSpeed = 40f;
    public float JumpForce = 7f;

    private Rigidbody2D _rb;
    private bool _isGrounded;

    // Audio
    [SerializeField] private AudioSource _sfxWalk;
    [SerializeField] private AudioSource _sfxJump;

    // Input
    private InputAction _moveAction;
    private InputAction _jumpAction;
    private int _inputMoveX;

    public int InputMoveX => _inputMoveX;
    public bool IsGrounded => _isGrounded;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        // "Move" itu nama action yang didefinisikan di Input Actions asset
        _moveAction = InputSystem.actions.FindAction("Move");
        _jumpAction = InputSystem.actions.FindAction("Jump");
    }

    // Update is called once per frame
    private void Update()
    {
        GatherInput();
        CheckGround();
    }

    private void FixedUpdate()
    {
        Movement();
    }

    private void CheckGround()
    {
        bool grounded = Physics2D.OverlapBox(transform.position, new Vector2(.7f, .03f), 0, GroundLayers);
        _isGrounded = grounded;
    }

    private void GatherInput()
    {
        Vector2 moveInput = _moveAction.ReadValue<Vector2>();
        _inputMoveX = Mathf.RoundToInt(moveInput.x);

        if (_jumpAction.triggered && _isGrounded)
        {
            Jump();
        }
    }

    private void Movement()
    {
        float targetVelocityX = _inputMoveX * MaxSpeed;
        float currSpeed;

        if (_inputMoveX != 0)
        {
            if (Mathf.Sign(targetVelocityX) != Mathf.Sign(_rb.linearVelocityX))
            {
                // Jika sedang berbalik arah, pake TurnSpeed
                currSpeed = TurnSpeed;
            }
            else
            {
                // Jika sedang mempercepat, pake Acceleration speed
                currSpeed = Acceleration;
            }
        }
        else
        {
            // Jika tidak ada input, gunakan kecepatan deselerasi
            currSpeed = Deceleration;
        }

        float smoothedVelocityX = Mathf.MoveTowards(_rb.linearVelocityX, targetVelocityX, currSpeed * Time.fixedDeltaTime);
        _rb.linearVelocityX = smoothedVelocityX;
    }

    private void Jump()
    {
        _rb.linearVelocityY = JumpForce;
        PlayJumpSFX();
    }

    private void PlayJumpSFX()
    {
        _sfxJump.Play();
    }

    // Dipanggil dari Animation Event di walk animation
    public void PlayWalkSFX()
    {
        _sfxWalk.Play();
    }
}
