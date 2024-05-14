using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : TopdownController
{
    // ��������� �ѹ� ���� �� �ѹ��� ȣ��ȴ�
    public void OnMove(InputValue value)
    {
        Vector2 direction = value.Get<Vector2>();
        CallMoveEvent(direction);
    }
    // ���콺�� ������ ������ ȣ��
    public void OnLook(InputValue value)
    {
        // ������ �ξ��� mouse�� ��ġ�� �޾ƿ´�
        // �̶� �� ��ġ�� Screen ��ġ�Ƿ� �����ؾ� �Ѵ�
        Vector2 mousePosition = value.Get<Vector2>();
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        Vector2 direction = mousePosition - (Vector2)transform.position;
        CallLookEvent(direction);
    }
}
