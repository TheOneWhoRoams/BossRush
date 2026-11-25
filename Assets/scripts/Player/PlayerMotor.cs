using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(ReadInput))]
[RequireComponent(typeof(PlayerStateMachine))]
public class PlayerMotor : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform cameraTransform;

    [Header("Movement")]
    [SerializeField] private float moveSpeed = 6f;
    [SerializeField] private float rotationSpeed = 12f;

    [Header("Jump & Gravity")]
    [SerializeField] private float jumpHeight = 1.5f;
    [SerializeField] private float horizontalJumpForce = 7f;
    [SerializeField] private float gravity = -20f;

    private CharacterController _controller;
    private ReadInput _input;
    private PlayerStateMachine _stateMachine;

    private Vector3 _airVelocity;
    private float _verticalVelocity;

    private void Awake()
    {
        _controller = GetComponent<CharacterController>();
        _input = GetComponent<ReadInput>();
        _stateMachine = GetComponent<PlayerStateMachine>();

        if (cameraTransform == null && Camera.main != null)
            cameraTransform = Camera.main.transform;
    }

    private void OnEnable() => _input.OnJumpPressed += HandleJump;
    private void OnDisable() => _input.OnJumpPressed -= HandleJump;

    private void Update()
    {
        HandleGravity();

        if (_stateMachine.CurrentState == PlayerState.Airborne)
        {
            Vector3 finalVelocity = _airVelocity;
            finalVelocity.y = _verticalVelocity;
            _controller.Move(finalVelocity * Time.deltaTime);

            if (_controller.isGrounded && _verticalVelocity <= 0f)
            {
                _airVelocity = Vector3.zero;
                _stateMachine.SetState(PlayerState.Idle);
            }
            return;
        }

        if (_stateMachine.CanMoveXZ)
            HandleGroundMovement();
    }

    private void HandleGroundMovement()
    {
        Vector3 moveDir = GetCameraRelativeMoveDir();

        if (moveDir.sqrMagnitude > 0.01f)
        {
            _stateMachine.SetState(PlayerState.Moving);
            Quaternion targetRot = Quaternion.LookRotation(moveDir);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRot, rotationSpeed * Time.deltaTime);
        }
        else
        {
            _stateMachine.SetState(PlayerState.Idle);
        }

        Vector3 finalVelocity = moveDir * moveSpeed;
        finalVelocity.y = _verticalVelocity;
        _controller.Move(finalVelocity * Time.deltaTime);
    }

    private void HandleGravity()
    {
        if (_controller.isGrounded && _verticalVelocity < 0f)
            _verticalVelocity = -2f;

        _verticalVelocity += gravity * Time.deltaTime;
    }

    private void HandleJump()
    {
        if (!_stateMachine.CanJump || !_controller.isGrounded) return;

        Vector3 moveDir = GetCameraRelativeMoveDir();
        _airVelocity = moveDir * horizontalJumpForce;
        _verticalVelocity = Mathf.Sqrt(jumpHeight * -2f * gravity);

        _stateMachine.SetState(PlayerState.Airborne);
    }

    private Vector3 GetCameraRelativeMoveDir()
    {
        Vector2 moveInput = _input.MoveInput;
        Vector3 camForward = cameraTransform.forward;
        Vector3 camRight = cameraTransform.right;
        camForward.y = 0f;
        camRight.y = 0f;

        Vector3 dir = camForward.normalized * moveInput.y + camRight.normalized * moveInput.x;
        return Vector3.ClampMagnitude(dir, 1f);
    }
}