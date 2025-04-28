using UnityEngine;

public class Sail : MonoBehaviour, IRotatable, IHasEffectByWind
{
    [SerializeField] private HandleRotator _handleRotator;
    [SerializeField] private Wind _wind;
    [SerializeField] private Ship _ship;
    [SerializeField] private Transform _sailTransform;

    private float _angleRotation = 0f;
    private float _maxRotateAngle = 90f;    
    private float _noWindSailScaleZ = 0.1f;
    private float _maxWindSailScaleZ = 0.6f;
    private float _minWindWhenSailMax = 5f;
    private float _sailExtensionCoef = 0.2f;
    private IMovableByEternalForce _moverByEternalForce;

    public float MaxRotateAngle => _maxRotateAngle;
    public Vector3 RotationAxis => Vector3.up;
    public Vector3 EffectDirection { get; set; }

    public void Initialize(IMovableByEternalForce moverByEternalForce)
    {
        _handleRotator.Initialize(this);
        _moverByEternalForce = moverByEternalForce;
        _sailTransform.localScale = new Vector3(_sailTransform.localScale.x, _sailTransform.localScale.y, _noWindSailScaleZ);
    }

    public void SetRotation(Vector3 rotation)
    {
        _angleRotation = rotation.y;
        transform.localRotation = Quaternion.AngleAxis(_angleRotation, RotationAxis);
    }

    public float CalculateForce(Vector3 windDirection, float windForce)
    {
        {
            float cosinus = Vector3.Dot(windDirection, transform.forward);
            EffectDirection = windDirection;
            float force = windForce * Mathf.Clamp(cosinus, 0, 1);

            ChangeSailSize(force);

            return force;
        }
    }
    
    private void ChangeSailSize(float force)
    {
        float scaleZ = _noWindSailScaleZ + force/_minWindWhenSailMax * _sailExtensionCoef;
        scaleZ = Mathf.Clamp(scaleZ, _noWindSailScaleZ, _maxWindSailScaleZ);
        _sailTransform.localScale = new Vector3(_sailTransform.localScale.x, _sailTransform.localScale.y, scaleZ);
    }

    private void FixedUpdate()
    {
        _moverByEternalForce.ApplyForce(EffectDirection, CalculateForce(_wind.Direction, _wind.Force));
    }
}


