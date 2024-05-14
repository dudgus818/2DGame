using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;
public class TimeController : MonoBehaviour
{
    public TMP_Text timeText; // UI 텍스트 요소

    void Start()
    {
        // 매 프레임마다 UpdateClock 함수를 호출하여 시간을 업데이트합니다.
        InvokeRepeating("UpdateClock", 0f, 1f);
    }

    void UpdateClock()
    {
        // 현재 시간을 문자열로 변환하여 UI에 표시합니다.
        timeText.text = DateTime.Now.ToString("HH:mm:ss");
    }
}
