using UnityEngine;

public class SawBlade : MonoBehaviour
{
    [SerializeField] Transform _start;
    [SerializeField] Transform _end;
    [SerializeField] Transform _sawBladeSprite;

    private float _positionPercent;
    private int _direction = 1;

    private void Update()
    {
        _positionPercent += Time.deltaTime * _direction;
        _sawBladeSprite.position = Vector3.Lerp(_start.position, _end.position, _positionPercent);
        if (_positionPercent >= 1 && _direction == 1)
            _direction = -1;
        if (_positionPercent <= 0 && _direction == -1)
            _direction = 1;
    }
}
