using UnityEngine;

public class MoverBySailWind : IMovableByEternalForce
{
    private Ship _ship;
    private Rigidbody _rigidBodyToInteract;
    
    public MoverBySailWind(Ship ship)
    {
        _ship = ship;
        _rigidBodyToInteract = ship.RigidBodyToInteract;
    }

    public void ApplyForce(Vector3 forceDirection, float forceValue)
    {
        _rigidBodyToInteract.AddForce(CalculateForce(forceDirection, forceValue), ForceMode.Force);
    }

    private Vector3 CalculateForce(Vector3 forceDirection, float forceValue)
    {
        float cosinus = Vector3.Dot(forceDirection, _ship.Direction);
        return forceValue * Mathf.Clamp(cosinus, 0, 1) * _ship.Direction;
    }
}

