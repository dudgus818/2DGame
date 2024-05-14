using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class Player : TopdownController
{
   
    public SpriteRenderer characterRenderer; // 캐릭터를 나타내는 SpriteRenderer
    public TextMeshProUGUI nameText; // 캐릭터 이름을 표시하는 UI Text

    
    void Start()
    {
        OnChangeCharacter();
        
    }
    public void OnChangeCharacter()
    {
        // 게임 시작 시 DataManager에서 선택된 캐릭터 번호를 가져옴
        int selectedCharacter = DataManager.instance.characterNum;

        // 선택된 캐릭터 번호에 해당하는 이미지를 가져와서 캐릭터의 SpriteRenderer에 할당
        if (selectedCharacter >= 0 && selectedCharacter < UIManager.instance.characterImages.Length)
        {
            characterRenderer.sprite = UIManager.instance.characterImages[selectedCharacter];
           GetComponent<Animator>().runtimeAnimatorController = UIManager.instance.anim[selectedCharacter];
        }
       
    }
    
    // 눌렀을경우 한번 뗐을 때 한번이 호출된다
    public void OnMove(InputValue value)
    {
        Vector2 direction = value.Get<Vector2>();
        CallMoveEvent(direction);
    }
    // 마우스가 움직일 때마다 호출
    public void OnLook(InputValue value)
    {
        // 설정해 두었던 mouse의 위치를 받아온다
        // 이때 이 위치를 Screen 위치므로 주의해야 한다
        Vector2 mousePosition = value.Get<Vector2>();
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        Vector2 direction = mousePosition - (Vector2)transform.position;
        CallLookEvent(direction);
    }
}
