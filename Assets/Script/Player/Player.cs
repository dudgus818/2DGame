using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class Player : TopdownController
{
   
    public SpriteRenderer characterRenderer; // ĳ���͸� ��Ÿ���� SpriteRenderer
    public TextMeshProUGUI nameText; // ĳ���� �̸��� ǥ���ϴ� UI Text

    
    void Start()
    {
        OnChangeCharacter();
        
    }
    public void OnChangeCharacter()
    {
        // ���� ���� �� DataManager���� ���õ� ĳ���� ��ȣ�� ������
        int selectedCharacter = DataManager.instance.characterNum;

        // ���õ� ĳ���� ��ȣ�� �ش��ϴ� �̹����� �����ͼ� ĳ������ SpriteRenderer�� �Ҵ�
        if (selectedCharacter >= 0 && selectedCharacter < UIManager.instance.characterImages.Length)
        {
            characterRenderer.sprite = UIManager.instance.characterImages[selectedCharacter];
           GetComponent<Animator>().runtimeAnimatorController = UIManager.instance.anim[selectedCharacter];
        }
       
    }
    
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
