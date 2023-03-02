using UnityEngine;

[RequireComponent(typeof(PlayerMovement), typeof(PlayerAnimation))]
public class Player : MonoBehaviour 
{
    private PlayerMovement _playerMovement;
    private PlayerAnimation _playerAnimation;

    private void Start()
    {
        _playerMovement = GetComponent<PlayerMovement>();
        _playerAnimation = GetComponent<PlayerAnimation>();
    }

    private void Update()
    {
        float inputHorizontal = Input.GetAxis("Horizontal");

        _playerAnimation.SetSpeed(inputHorizontal);
        _playerAnimation.SetIsJumping(_playerMovement.IsGrounded() == false);
        _playerAnimation.SetIsFalling(_playerMovement.IsGrounded() == false && _playerMovement.GetRigidbody2D().velocity.y < 0);
    }
}
