using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;
public class TimeController : MonoBehaviour
{
    public TMP_Text timeText; // UI �ؽ�Ʈ ���

    void Start()
    {
        // �� �����Ӹ��� UpdateClock �Լ��� ȣ���Ͽ� �ð��� ������Ʈ�մϴ�.
        InvokeRepeating("UpdateClock", 0f, 1f);
    }

    void UpdateClock()
    {
        // ���� �ð��� ���ڿ��� ��ȯ�Ͽ� UI�� ǥ���մϴ�.
        timeText.text = DateTime.Now.ToString("HH:mm:ss");
    }
}
