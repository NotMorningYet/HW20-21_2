using UnityEngine;

public class Ship : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private float _waterResistance;
    [SerializeField] private Sail _sail;

    private IMovableByEternalForce _moverByEternalForce;

    public Rigidbody RigidBodyToInteract => _rigidbody;
    public Vector3 Course {  get; private set; }
    public Vector3 Direction => transform.forward;

    private void Awake()
    {
        _rigidbody.drag = _waterResistance;
        _moverByEternalForce = new MoverBySailWind(this);
        _sail.Initialize(_moverByEternalForce);
    }

    public void WheelRotate(float angleRotation)
    {
        Course = new Vector3(0, angleRotation, 0);
        transform.rotation = Quaternion.Euler(Course);         
    }
}
