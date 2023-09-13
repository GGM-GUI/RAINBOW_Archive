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
    public string id; // 아래 name과 text value 들을 가져오기 위한 key 역할

    public string name;
    [TextArea(3, 7)] public List<string> textList;
}
