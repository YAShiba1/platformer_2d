using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void SetSpeed(float speed)
    {
        _animator.SetFloat("Speed", Mathf.Abs(speed));
    }

    public void SetIsJumping(bool isJumping)
    {
        _animator.SetBool("IsJumping", isJumping);
    }

    public void SetIsFalling(bool isFalling)
    {
        _animator.SetBool("IsFalling", isFalling);
    }
}
