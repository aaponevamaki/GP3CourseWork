using UnityEngine;

public class Sphere : MonoBehaviour
{
    private Vector3 _direction;
    private Vector3 _initialPos;

    private float _distance;

    public Transform _leftWall;
    public Transform _rightWall;
    public Transform _ground;

    private float _sine;
    private float _sineDirection = 1f;

    void Start()
    {
        _initialPos = transform.position;
        _direction = transform.right;
        _distance = _rightWall.position.x - _leftWall.position.x;
    }
    void Update()
    {
        transform.position += _direction * _distance * Time.deltaTime;

        _sine = Mathf.Sin(Time.time * Mathf.PI) * (_initialPos.y - _ground.position.y);
        transform.position = new Vector3(transform.position.x, _ground.position.y + _sine * _sineDirection, 0f);

        if (Vector3.Dot(_rightWall.position - transform.position, Vector3.right) < 0)
        {
            _direction = -transform.right;
        }
        
        if (Vector3.Dot(_leftWall.position - transform.position, Vector3.right) > 0)
        {
            _direction = transform.right;
        }
        
        if (Vector3.Dot(_ground.position - transform.position, Vector3.up) > 0)
        {
            _sineDirection *= -1f;
        }
    }
}
