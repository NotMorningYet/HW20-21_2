using UnityEngine;

public class HandleRotator : MonoBehaviour
{
    [SerializeField] private KeyCode _rotateRightKey;
    [SerializeField] private KeyCode _rotateLeftKey;
    [SerializeField] private float _sensibility = 15f;

    private IRotatable _rotatableObject;
    private float _currentAngle;
    private const float _turnAround = 360;

    public void Initialize (IRotatable rotatableObject)
    {
        _rotatableObject = rotatableObject;
    }

    private void Update()
    {
        HandleInput();
        ApplyRotation();
    }

    private void HandleInput()
    {
        float rotationInput = 0f;

        if (Input.GetKey(_rotateLeftKey)) rotationInput -= 1f;
        if (Input.GetKey(_rotateRightKey)) rotationInput += 1f;

        _currentAngle += rotationInput * _sensibility * Time.deltaTime;
        _currentAngle = Mathf.Clamp(_currentAngle,
                                  -_rotatableObject.MaxRotateAngle,
                                  _rotatableObject.MaxRotateAngle);

        if (_currentAngle == _turnAround | _currentAngle == -_turnAround)
            ResetAngle();        
    }

    private void ApplyRotation()
    {
        Vector3 rotation = _rotatableObject.RotationAxis * _currentAngle;
        _rotatableObject.SetRotation(rotation);
    }

    private void ResetAngle()
    {
        _currentAngle = 0;
    }
}