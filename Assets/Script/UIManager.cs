using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEditor.Animations;

public class UIManager : MonoBehaviour
{
    public static UIManager instance; // 싱글톤 인스턴스
    public InputField nameInputField;
    public Button joinButton;

    public AnimatorController[] anim;
    //캐릭터 이미지 가져오기
    public Sprite[] characterImages;
    private string playerName;
    public Image selectcharacter;
    // 싱글톤 패턴 적용
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
        DataManager.instance.characterNum = num; //캐릭터 선택될때 몇번이 선택되었는지 넘어간다.
    }
    public void OnClickBtn()
    {
        
        // 입력된 문자열의 길이를 확인하고, 조건에 따라 버튼을 활성화 또는 비활성화
        if (nameInputField.text.Length < 2 || nameInputField.text.Length > 10)
        {
            return;
        }
            
        DataManager.instance.userName = nameInputField.text;
          
        SceneManager.LoadScene(1);
       

    }
   

}
