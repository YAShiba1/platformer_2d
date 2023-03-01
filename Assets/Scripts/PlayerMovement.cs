using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;

    private Animator _animator;
    private Rigidbody2D _rigidbody2D;

    private bool _isFacingRight = true;
    private bool _isGrounded;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        Move();
        Jump();
        Fall();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.GetComponent<Ground>())
        {
            _isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.GetComponent<Ground>())
        {
            _isGrounded = false;
        }
    }

    private void Move()
    {
        float inputHorizontal;

        inputHorizontal = Input.GetAxis("Horizontal");
        _rigidbody2D.velocity = new Vector2(inputHorizontal * _speed, _rigidbody2D.velocity.y);

        _animator.SetFloat("Speed", Mathf.Abs(inputHorizontal));

        if (_isFacingRight == false && inputHorizontal > 0)
        {
            Flip();
        }
        else if(_isFacingRight == true && inputHorizontal < 0)
        {
            Flip();
        }
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.W) && _isGrounded)
        {
            _rigidbody2D.AddForce(transform.up * _jumpForce, ForceMode2D.Impulse);
            _animator.SetBool("IsJumping", true);
        }
        else
        {
            _animator.SetBool("IsJumping", false);
        }
    }

    private void Fall()
    {
        if (_isGrounded == false && _rigidbody2D.velocity.y < 0)
        {
            _animator.SetBool("IsFalling", true);
        }
        else
        {
            _animator.SetBool("IsFalling", false);
        }
    }

    private void Flip()
    {
        _isFacingRight = !_isFacingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}
