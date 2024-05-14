using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Movement : MonoBehaviour
{
    private TopdownController _characterController;
    private Rigidbody2D _rigidbody;
    private SpriteRenderer _characterSprite;
    private Animator _animator;
    private Vector2 _direction;
    [SerializeField] [Range(10, 1000)] private float _speed;
    //UIManager uIManager;
    private bool _isMovementEnabled = true; // 캐릭터의 움직임이 활성화되었는지 여부

    private void Awake()
    {
        _characterController = GetComponent<TopdownController>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _characterSprite = GetComponentInChildren<SpriteRenderer>();
        _animator = GetComponentInChildren<Animator>();

        // 이벤트 등록
        _characterController.OnMoveEvent += Move;
        _characterController.OnLookEvent += Look;

     
    }

    private void FixedUpdate()
    {
        if (_isMovementEnabled)
        {
            ApplyMovement();
            UpdateAnimation();
        }
    }

    private void Look(Vector2 direction)
    {
        // 2D Sprite를 뒤집어 마우스 방향을 바라보게 만든다
        _characterSprite.flipX = DataManager.instance.characterNum == 0 ? direction.x < 0 : direction.x > 0;
    }

    private void Move(Vector2 direction)
    {
        // 이동 방향 등록
        _direction = direction;
    }

    private void ApplyMovement()
    {
        // rigidbody를 이용한 캐릭터 이동
        _rigidbody.velocity = _direction * _speed;
    }

    private void UpdateAnimation()
    {
        // 이동 속도에 따라 애니메이션 재생
        float movementSpeed = _rigidbody.velocity.magnitude;
        _animator.SetFloat("walk", movementSpeed);

        // 이동 속도가 0이 아니면서 walk 애니메이션이 비활성화된 경우
        if (movementSpeed > 0 && !_animator.GetCurrentAnimatorStateInfo(0).IsName("walk"))
        {
            _animator.SetBool("isWalk", true);
        }
        // 이동 속도가 0이면서 walk 애니메이션이 활성화된 경우
        else if (movementSpeed == 0 && _animator.GetCurrentAnimatorStateInfo(0).IsName("walk"))
        {
            _animator.SetBool("isWalk", false);
        }
    }

   
}
