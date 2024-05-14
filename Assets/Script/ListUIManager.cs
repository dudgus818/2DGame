using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ListUIManager : MonoBehaviour
{
    public static ListUIManager instance; // �̱��� �ν��Ͻ�

    public GameObject attendanceUI; // ���� �ο� UI
    public TMP_Text attendanceListText; // ���� �ο� ��� �ؽ�Ʈ

    private Dictionary<int, string> npcNames = new Dictionary<int, string>(); // NPC�� ID�� �̸��� �����ϴ� ��ųʸ�

    void Awake()
    {
        // UIManager�� �̱��� �ν��Ͻ� ����
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

    // NPC�� ���� �ο� ��Ͽ� �߰��ϴ� �Լ�
    public void AddNPC(int npcID, string npcName)
    {
        if (!npcNames.ContainsKey(npcID))
        {
            npcNames.Add(npcID, npcName);
            UpdateAttendanceListUI();
        }
    }

    // ���� �ο� ��� UI�� ������Ʈ�ϴ� �Լ�
    private void UpdateAttendanceListUI()
    {
        attendanceListText.text = "List\n";

        // NPC �̸��� �߰�
        foreach (var kvp in npcNames)
        {
            attendanceListText.text += kvp.Value + "\n";
        }

        // �÷��̾� �̸� �߰�
        string playerName = DataManager.instance.userName;
        if (!string.IsNullOrEmpty(playerName))
        {
            attendanceListText.text += playerName + " (Player)\n";
        }
    }
}
