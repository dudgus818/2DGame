using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class ChangeName : MonoBehaviour
{
    public static ChangeName instance; // ���� ������ ���� UI �Ŵ����� �̱��� �ν��Ͻ�
    public InputField nameInputField;
    public Button changeNameButton; // �г��� ���� ��ư

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

    // �г��� ���� ��ư Ŭ�� �� ȣ��� �Լ�
    public void OnChangeNameButtonClick()
    {
        string newName = nameInputField.text;
        if (string.IsNullOrEmpty(newName))
        {
            Debug.Log("�̸��� �Է��ϼ���.");
            return;
        }

        DataManager.instance.userName = nameInputField.text;
        Debug.Log("�г����� ����Ǿ����ϴ�: " + newName);
    }

}

