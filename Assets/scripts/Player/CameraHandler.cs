using UnityEngine;

public class CameraHandler : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private Vector3 cameraOffset = new Vector3(0f, 1.5f, 0f);
    [SerializeField] private float distance = 5f;
    [SerializeField] private float sensitivity = 0.15f;

    private float _yaw;
    private float _pitch = 15f;
    private ReadInput _input;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        if (target != null)
            _input = target.GetComponent<ReadInput>();
    }

    private void LateUpdate()
    {
        if (target == null || _input == null) return;

        _yaw += _input.LookInput.x * sensitivity;
        _pitch -= _input.LookInput.y * sensitivity;
        _pitch = Mathf.Clamp(_pitch, -25f, 65f);

        Quaternion rotation = Quaternion.Euler(_pitch, _yaw, 0f);
        Vector3 focusPoint = target.position + cameraOffset;

        transform.position = focusPoint - (rotation * Vector3.forward * distance);
        transform.LookAt(focusPoint);
    }
}