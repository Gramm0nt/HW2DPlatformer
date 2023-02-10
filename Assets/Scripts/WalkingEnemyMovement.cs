using UnityEngine;

public class WalkingEnemyMovement : MonoBehaviour
{
    private float _speed = 4f;
    private Vector3 _direction;
    private Vector3 _overlapCirclePosition;
    private SpriteRenderer _sprite;
    private Collider2D[] _colliders;
    private float _overlapCircleRadius = -0.3f;
    private float _multiplierOverlapTransformUp = 0.1f;
    private float _multiplierOverlapTransformRight = 0.75f;

    private void Awake()
    {
        _sprite = GetComponentInChildren<SpriteRenderer>();
    }

    private void Start()
    {
        _direction = transform.right;
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        _overlapCirclePosition = transform.position + transform.up * _multiplierOverlapTransformUp
            + transform.right * _direction.x * _multiplierOverlapTransformRight;
        _colliders = Physics2D.OverlapCircleAll(_overlapCirclePosition, _overlapCircleRadius);

        if (_colliders.Length > 0 && _colliders[0].gameObject != Player.Instance.gameObject)
            _direction *= -1f;

        transform.position = Vector3.MoveTowards(transform.position, transform.position + _direction, _speed * Time.deltaTime);
        _sprite.flipX = _direction.x > 0.0f;
    }
}