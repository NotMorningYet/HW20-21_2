using UnityEngine;

public interface IRotatable
{
    public float MaxRotateAngle { get; }
    public Vector3 RotationAxis { get; }
    
    public void SetRotation(Vector3 rotation);
}
