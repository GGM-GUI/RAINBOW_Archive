using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class IntroUI : MonoBehaviour
{
    private UIDocument _uiDocument;
    private VisualElement _root;

    private Button _startBtn;
    private Button _exitBtn;

    private void Awake()
    {
        _uiDocument = GetComponent<UIDocument>();
    }

    private void OnEnable()
    {
        _root = _uiDocument.rootVisualElement;

        _startBtn = _root.Q<Button>("StartButton");
        _exitBtn = _root.Q<Button>("ExitButton");
        
        _startBtn.RegisterCallback<ClickEvent>(evt => SceneManager.LoadScene(1));
        _exitBtn.RegisterCallback<ClickEvent>(evt => Application.Quit());

        
    }
}
