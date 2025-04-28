using UnityEngine;

public class Wheel : MonoBehaviour, IRotatable
{
    [SerializeField] private HandleRotator _handleRotator;
    [SerializeField] private Ship _ship;
    private float _angleRotation = 0f;
    private float _maxRotateAngle = 360f;

    public float MaxRotateAngle => _maxRotateAngle;
    public Vector3 RotationAxis => Vector3.forward;

    private void Awake()
    {
        _handleRotator.Initialize(this);
    }

    private void Update()
    {
        SetShipRotation();
    }

    public void SetRotation(Vector3 rotation)
    {
        _angleRotation = rotation.z;
        transform.localRotation = Quaternion.AngleAxis(_angleRotation, RotationAxis);
    }

    private void SetShipRotation()
    {
        _ship.WheelRotate(-_angleRotation);
    }
}
