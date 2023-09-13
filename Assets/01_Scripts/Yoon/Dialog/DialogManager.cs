using System.Collections.Generic;
using UnityEngine;

public class DialogManager : MonoBehaviour
{
    public static DialogManager Instance = null;

    [SerializeField] private DialogTextDataSO textData;
    [SerializeField] private DialogSystem _dialogSystem;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(Instance);
        }
    }

    public void DialogPanelOn(string targetID)
    {
        if (_dialogSystem.IsOnTextPanel) return;

        Debug.Log($"DialogPanelOn / id is {targetID}");

        string name = textData.FindNameText(targetID);
        List<string> textList = textData.FindTextList(targetID);
        
        _dialogSystem.SetTextData(name, textList);
        _dialogSystem.ActivateTextPanel();
    }

    public void DialogPanelOff()
    {
        _dialogSystem.DeactivateTextPanel();
    }
}
