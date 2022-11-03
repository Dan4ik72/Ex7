using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Rigidbody2D))]
public class Movement : MonoBehaviour
{
    [SerializeField] private GroundChecker _groundChecker;

    [SerializeField] private float _runSpeed;
    [SerializeField] private float _jumpForce;

    private SpriteRenderer _spriteRenderer;
    private Rigidbody2D _rigidbody;

    private float _xPositionOffset;

    public bool IsRunning => _xPositionOffset != 0;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        float startXPosition = transform.position.x;

        if (Input.GetKey(KeyCode.D))
        {
            _spriteRenderer.flipX = false;

            transform.Translate(_runSpeed * Time.deltaTime, 0 , 0);
        }

        if (Input.GetKey(KeyCode.A))
        {
            _spriteRenderer.flipX = true;

            transform.Translate(_runSpeed * Time.deltaTime * -1, 0, 0);
        }

        if (Input.GetKeyDown(KeyCode.Space) && _groundChecker.IsOnGround)
        {
            Jump();
        }

        _xPositionOffset = startXPosition - transform.position.x;
    }

    private void Jump()
    {
        _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, _jumpForce);       
    }
}
