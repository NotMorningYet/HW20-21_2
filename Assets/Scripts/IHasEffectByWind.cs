using UnityEngine;

public interface IHasEffectByWind
{
    public Vector3 EffectDirection { get; }
    public float CalculateForce(Vector3 wind, float windForce);
}
