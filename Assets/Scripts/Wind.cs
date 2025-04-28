using UnityEngine;

public class Wind : MonoBehaviour
{
    [SerializeField] float _force;
    [SerializeField] float _timeWindingInOneDirection;

    private float _windingAngle;
    private float _timeToChangeDirection;

    public Vector3 Direction => transform.forward;
    public float WindingAngle =>_windingAngle;
    public float Force => _force;

    private void Awake()
    {
        SetDirectionVector();
        _timeToChangeDirection = _timeWindingInOneDirection;
    }

    private void Update()
    {
        _timeToChangeDirection -= Time.deltaTime;

        if (_timeToChangeDirection <= 0 )
        {
            _timeToChangeDirection = _timeWindingInOneDirection;
            SetDirectionVector();
        }        
    }

    private void SetDirectionVector()
    {
        _windingAngle = Random.Range(0, 360);
        transform.rotation = Quaternion.Euler(new Vector3(0, _windingAngle, 0));
    }
}
