using UnityEngine;

[RequireComponent(typeof(Player))]
[RequireComponent(typeof(Animator))]
public class PlayerEffects : MonoBehaviour
{
    public enum AnimationState
    {
        None,
        Idle,
        Running,
        Jumping
    }

    public SpriteRenderer Renderer;

    private Player _player;
    private Animator _animator;
    private AnimationState _currentAnimation;

    private void Awake()
    {
        _player = GetComponent<Player>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        HandleSpriteFlipping();
        HandleAnimation();
    }

    private void HandleSpriteFlipping()
    {
        if (_player.InputMoveX > 0)
        {
            Renderer.flipX = false;
        }
        else if (_player.InputMoveX < 0)
        {
            Renderer.flipX = true;
        }
    }

    private void HandleAnimation()
    {
        if (_player.IsGrounded)
        {
            if (_player.InputMoveX != 0)
            {
                SetAnimationState(AnimationState.Running);
            }
            else
            {
                SetAnimationState(AnimationState.Idle);
            }
        }
        else
        {
            SetAnimationState(AnimationState.Jumping);
        }
    }

    private void SetAnimationState(AnimationState newState)
    {
        if (_currentAnimation == newState)
            return;
        
        switch (newState)
        {
            case AnimationState.Idle:
                _animator.Play("Player_Idle");
                break;
            case AnimationState.Running:
                _animator.Play("Player_Run");
                break;
            case AnimationState.Jumping:
                _animator.Play("Player_Jump");
                break;
        }

        _currentAnimation = newState;
    }
}
