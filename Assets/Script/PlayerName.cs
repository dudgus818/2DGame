using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class PlayerName : MonoBehaviour
{
    TextMeshProUGUI nameText;

    private void Start()
    {

        PullName();

        


    }
   public void PullName()
    {
        nameText = GetComponent<TextMeshProUGUI>();
        nameText.text = DataManager.instance.userName; // DataManager���� �÷��̾��� �̸��� ������ UI�� ǥ��
    }
    
}
