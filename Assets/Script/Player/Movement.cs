using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Movement : MonoBehaviour
{
    TopdownController _characterController;
    Rigidbody2D _rigidbody;
    SpriteRenderer _characterSprite;
    Vector2 _direction;
    [SerializeField] [Range(10, 1000)] float _speed;
    void Awake()
    {
        _characterController = gameObject.GetComponent<TopdownController>();
        _rigidbody = gameObject.GetComponent<Rigidbody2D>();
        _characterSprite = gameObject.GetComponentInChildren<SpriteRenderer>();
    }
    private void Start()
    {
        // �̺�Ʈ ���
        _characterController.OnMoveEvent += Move;
        _characterController.OnLookEvent += Look;
    }
    void FixedUpdate()
    {
        ApplayMovement();
    }
    private void Look(Vector2 direction)
    {
        // 2D Sprite�� ������ ���콺 ������ �ٶ󺸰� �����
        _characterSprite.flipX = (direction.x < 0);
    }
    void Move(Vector2 direction)
    {
        // �̵� ���� ���
        _direction = direction;
    }
    void ApplayMovement()
    {
        // rigidbody�� �̿��� ĳ���� �̵�
        _rigidbody.velocity = _direction * _speed;
    }
}
