using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TextData", menuName = "SO/TextData")]
public class DialogTextDataSO : ScriptableObject
{
    public List<TextData> textDataList;

    public List<string> FindTextList(string targetID)
    {
        List<string> temp = null;

        foreach (TextData td in textDataList)
        {
            if (td.id == targetID)
            {
                return td.textList;
            }
        }

        Debug.LogError("DialogTextDataSO : cant find this id textList");
        return temp;
    }

    public string FindNameText(string targetID)
    {
        string temp = "";

        foreach (TextData td in textDataList)
        {
            if (td.id == targetID)
            {
                return td.name;
            }
        }

        return temp;
    }
}

[System.Serializable]
public class TextData
{
    public string id; // �Ʒ� name�� text value ���� �������� ���� key ����

    public string name;
    [TextArea(3, 7)] public List<string> textList;
}
