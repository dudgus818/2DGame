using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TopdownController : MonoBehaviour
{
    // 다른 곳에서 evnt를 직접 Invoke 하는것을 막아준다
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
