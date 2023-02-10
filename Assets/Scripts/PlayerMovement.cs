using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private const string Horizontal = "Horizontal";
    private const string Jump = "Jump";

    [SerializeField] private Player _player;
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;

    private Collider2D[] _colliders;
    private Rigidbody2D _rb2d;
    private SpriteRenderer _sprite;
    private Vector3 _direction;
    private bool IsGrounded = false;
    private float _radiusCheckGroundColliders = 0.05f;

    private void Awake()
    {
        _rb2d = GetComponent<Rigidbody2D>();
        _sprite = GetComponentInChildren<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        CheckGround();
    }

    private void Update()
    {
        if (IsGrounded) 
            _player.State = States.idle;       

        if (Input.GetButton(Horizontal))
            Run();

        if (IsGrounded && Input.GetButton(Jump))
            JumpUpward();
    }

    private void Run()
    {
        if (IsGrounded) 
            _player.State = States.run;

        _direction = transform.right * Input.GetAxis(Horizontal);
        transform.position = Vector3.MoveTowards(transform.position, transform.position + _direction, _speed * Time.deltaTime);
        _sprite.flipX = _direction.x < 0.0f;
    }

    private void JumpUpward()
    {
        _rb2d.AddForce(transform.up * _jumpForce, ForceMode2D.Impulse);
    }

    private void CheckGround()
    {
        _colliders = Physics2D.OverlapCircleAll(transform.position, _radiusCheckGroundColliders);
        IsGrounded = _colliders.Length > 1;

        if (IsGrounded == false)
            _player.State = States.jump;
    }
}