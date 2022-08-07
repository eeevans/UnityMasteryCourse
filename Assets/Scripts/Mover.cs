using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] Transform _start;
    [SerializeField] Transform _end;
    [SerializeField] Transform _sprite;
    [SerializeField] float _speedFactor = 2f;

    private float _positionPercent;
    private int _direction = 1;

    private void Update()
    {
        var distance = Vector3.Distance(_start.position, _end.position);
        var speedOverDistance = _speedFactor / distance;
        _positionPercent += Time.deltaTime * _direction * speedOverDistance;
        _sprite.position = Vector3.Lerp(_start.position, _end.position, _positionPercent);
        if (_positionPercent >= 1 && _direction == 1)
            _direction = -1;
        if (_positionPercent <= 0 && _direction == -1)
            _direction = 1;
    }
}
