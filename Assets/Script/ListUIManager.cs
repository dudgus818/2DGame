using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ListUIManager : MonoBehaviour
{
    public static ListUIManager instance; // 싱글톤 인스턴스

    public GameObject attendanceUI; // 참석 인원 UI
    public TMP_Text attendanceListText; // 참석 인원 목록 텍스트

    private Dictionary<int, string> npcNames = new Dictionary<int, string>(); // NPC의 ID와 이름을 저장하는 딕셔너리

    void Awake()
    {
        // UIManager의 싱글톤 인스턴스 설정
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

    // NPC를 참석 인원 목록에 추가하는 함수
    public void AddNPC(int npcID, string npcName)
    {
        if (!npcNames.ContainsKey(npcID))
        {
            npcNames.Add(npcID, npcName);
            UpdateAttendanceListUI();
        }
    }

    // 참석 인원 목록 UI를 업데이트하는 함수
    private void UpdateAttendanceListUI()
    {
        attendanceListText.text = "List\n";

        // NPC 이름들 추가
        foreach (var kvp in npcNames)
        {
            attendanceListText.text += kvp.Value + "\n";
        }

        // 플레이어 이름 추가
        string playerName = DataManager.instance.userName;
        if (!string.IsNullOrEmpty(playerName))
        {
            attendanceListText.text += playerName + " (Player)\n";
        }
    }
}
