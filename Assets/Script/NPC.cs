using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class NPC : MonoBehaviour
{
    public string npcName; // NPC�� �̸�

    void Start()
    {
        // NPC�� �̸��� UIManager�� ���
        ListUIManager.instance.AddNPC(GetInstanceID(), npcName);
    }
}
