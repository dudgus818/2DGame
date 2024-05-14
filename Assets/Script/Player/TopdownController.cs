using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TopdownController : MonoBehaviour
{
    // �ٸ� ������ evnt�� ���� Invoke �ϴ°��� �����ش�
    public event Action<Vector2> OnMoveEvent;
    public event Action<Vector2> OnLookEvent;

    public void CallMoveEvent(Vector2 direction)
    {
        OnMoveEvent?.Invoke(direction);
    }
    public void CallLookEvent(Vector2 direction)
    {
        OnLookEvent?.Invoke(direction);
    }
}