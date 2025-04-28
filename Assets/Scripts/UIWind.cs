using UnityEngine;

public class UIWind : MonoBehaviour
{
    [SerializeField] private Wind _wind;
    [SerializeField] private Ship _ship;
    [SerializeField] private RectTransform _directionRectTransform;

    private void Update()
    {
        _directionRectTransform.rotation = Quaternion.Euler(0 ,0 ,_ship.Course.y - _wind.WindingAngle);
    }
}
