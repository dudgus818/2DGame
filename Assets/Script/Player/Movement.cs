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
    private bool _isMovementEnabled = true; // ĳ������ �������� Ȱ��ȭ�Ǿ����� ����

    private void Awake()
    {
        _characterController = GetComponent<TopdownController>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _characterSprite = GetComponentInChildren<SpriteRenderer>();
        _animator = GetComponentInChildren<Animator>();

        // �̺�Ʈ ���
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
        // 2D Sprite�� ������ ���콺 ������ �ٶ󺸰� �����
        _characterSprite.flipX = DataManager.instance.characterNum == 0 ? direction.x < 0 : direction.x > 0;
    }

    private void Move(Vector2 direction)
    {
        // �̵� ���� ���
        _direction = direction;
    }

    private void ApplyMovement()
    {
        // rigidbody�� �̿��� ĳ���� �̵�
        _rigidbody.velocity = _direction * _speed;
    }

    private void UpdateAnimation()
    {
        // �̵� �ӵ��� ���� �ִϸ��̼� ���
        float movementSpeed = _rigidbody.velocity.magnitude;
        _animator.SetFloat("walk", movementSpeed);

        // �̵� �ӵ��� 0�� �ƴϸ鼭 walk �ִϸ��̼��� ��Ȱ��ȭ�� ���
        if (movementSpeed > 0 && !_animator.GetCurrentAnimatorStateInfo(0).IsName("walk"))
        {
            _animator.SetBool("isWalk", true);
        }
        // �̵� �ӵ��� 0�̸鼭 walk �ִϸ��̼��� Ȱ��ȭ�� ���
        else if (movementSpeed == 0 && _animator.GetCurrentAnimatorStateInfo(0).IsName("walk"))
        {
            _animator.SetBool("isWalk", false);
        }
    }

   
}
