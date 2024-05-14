using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class ChangeName : MonoBehaviour
{
    public static ChangeName instance; // 게임 씬에서 사용될 UI 매니저의 싱글톤 인스턴스
    public InputField nameInputField;
    public Button changeNameButton; // 닉네임 변경 버튼

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // 닉네임 변경 버튼 클릭 시 호출될 함수
    public void OnChangeNameButtonClick()
    {
        string newName = nameInputField.text;
        if (string.IsNullOrEmpty(newName))
        {
            Debug.Log("이름을 입력하세요.");
            return;
        }

        DataManager.instance.userName = nameInputField.text;
        Debug.Log("닉네임이 변경되었습니다: " + newName);
    }

}

