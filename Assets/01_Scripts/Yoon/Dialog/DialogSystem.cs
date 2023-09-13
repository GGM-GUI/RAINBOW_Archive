using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using TMPro;

public class DialogSystem : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI nameText; // 이름
    [SerializeField] private TextMeshProUGUI realText; // 본문

    [SerializeField] private GameObject playerHpUI;

    private bool isOnTextPanel;
    public bool IsOnTextPanel => isOnTextPanel;

    private string nameTextData = "";
    private List<string> realTextData = null;
    private int realTextDataLengh;

    private bool isRoopStart;
    public bool IsRoopStart => isRoopStart;

    public void SetTextData(string name, List<string> textData)
    {
        nameTextData = name;
        realTextData = textData;
        realTextDataLengh = textData.Count;
    }

    public void ActivateTextPanel()
    {
        isOnTextPanel = true;
        playerHpUI.SetActive(false);
        gameObject.SetActive(true);

        StartCoroutine(TextRoop());
    }

    private IEnumerator TextRoop()
    {
        isRoopStart = true;
        nameText.text = nameTextData;

        for (int i = 0; i <  realTextDataLengh; i++)
        {
            realText.text = realTextData[i];
            yield return new WaitForEndOfFrame();
            yield return new SpaceKeyWating(this);
        }

        DeactivateTextPanel();
        isRoopStart = false;
    }

    public void DeactivateTextPanel()
    {
        gameObject.SetActive(false);
        playerHpUI.SetActive(true);
        isOnTextPanel = false;
    }
}

public class SpaceKeyWating : CustomYieldInstruction
{
    DialogSystem _dialogSystem;

    public SpaceKeyWating(DialogSystem dialogSystem)
    {
        _dialogSystem = dialogSystem;
    }

    public override bool keepWaiting => !Input.GetKeyDown(KeyCode.Space) && _dialogSystem.IsRoopStart;
}