using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowProjectile : MonoBehaviour, IProjectile
{
    private float _damage;
    
    [Header("Move")]
    [SerializeField] private float _moveTime;
    [SerializeField] private float _moveDistance;

    [Header("Scale")]
    [SerializeField] private Vector3 _startScale;
    [SerializeField] private Vector3 _endScale;
    private float _currentScale;
    
    private float _currentTime;

    public void Init(float damage)
    {
        _damage = damage;
    }

    private IEnumerator Start() 
    {
        while (_currentTime < _moveTime)
        {
            yield return null;
            _currentTime += Time.deltaTime;

            if (_currentTime >= _moveTime)
                _currentTime = _moveTime;

            float time = _currentTime / _moveTime;
            transform.Translate(Vector3.up * 2.5f * Time.deltaTime);
            transform.localScale = Vector3.Lerp(_startScale, _endScale, time);
        }

        Destroy(gameObject);
    }
}

// 도트댐 구현 
