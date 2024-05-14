using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEditor.Animations;

public class UIManager : MonoBehaviour
{
    public static UIManager instance; // �̱��� �ν��Ͻ�
    public InputField nameInputField;
    public Button joinButton;

    public AnimatorController[] anim;
    //ĳ���� �̹��� ��������
    public Sprite[] characterImages;
    private string playerName;
    public Image selectcharacter;
    // �̱��� ���� ����
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void ChoiceCharacter(int num)
    {
        selectcharacter.sprite = characterImages[num];
        DataManager.instance.characterNum = num; //ĳ���� ���õɶ� ����� ���õǾ����� �Ѿ��.
    }
    public void OnClickBtn()
    {
        
        // �Էµ� ���ڿ��� ���̸� Ȯ���ϰ�, ���ǿ� ���� ��ư�� Ȱ��ȭ �Ǵ� ��Ȱ��ȭ
        if (nameInputField.text.Length < 2 || nameInputField.text.Length > 10)
        {
            return;
        }
            
        DataManager.instance.userName = nameInputField.text;
          
        SceneManager.LoadScene(1);
       

    }
   

}
