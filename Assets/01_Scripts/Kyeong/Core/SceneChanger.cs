using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SceneChanger : MonoBehaviour
{
    public static SceneChanger Instance;
    [SerializeField] private float _rotationTime;
    
    private Renderer _renderer;
    private float _value = 1f;

    private void Awake()
    {
        if (Instance != null)
            Debug.Log("Multiple SceneChanger is running");
        Instance = this;
    }

    private void Start()
    {
        _renderer = GetComponent<Renderer>();
        SceneChange(0, () =>
        {
            GameManager.Instance.UpdateState(GameState.RUNNING);
        });
    }

    public void SceneChange(int index, Action act = null)
    {
        StopAllCoroutines();
        StartCoroutine(SceneChangeCo(index, act));
    }

    [ContextMenu("adfkldjsklfjasklfadjlajs")]
    public void DissolveOnOff()
    {
        StartCoroutine(DissolveOnOffCo());
    }

    private IEnumerator DissolveOnOffCo()
    {
        StartCoroutine(SceneChangeCo(1));
        yield return new WaitForSeconds(_rotationTime + 1);
        StartCoroutine(SceneChangeCo(0));
    }

    private IEnumerator SceneChangeCo(int index, Action act = null)
    {
        DOTween.To(() => _value, x =>  _value = x, index, _rotationTime);
        while (_value != index)
        {
            _renderer.material.SetFloat("_DissolveFade", _value);
            yield return null;
        }
        act?.Invoke();
    }
}

// SceneChanger.Instance.SceneChange(1);
// 이런식으로 사용. 
