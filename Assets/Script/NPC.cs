using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class NPC : MonoBehaviour
{
    public string npcName; // NPC의 이름

    void Start()
    {
        // NPC의 이름을 UIManager에 등록
        ListUIManager.instance.AddNPC(GetInstanceID(), npcName);
    }
}
