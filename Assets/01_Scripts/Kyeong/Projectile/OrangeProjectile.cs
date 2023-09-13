using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrangeProjectile : MonoBehaviour, IProjectile
{
    private float _damage;
    [SerializeField] private float _moveTime;
    private float _currentTime = 0;
    
    [SerializeField] private float _radius;
    [SerializeField] private float _distance;
    [SerializeField] private LayerMask _enemyLayer;
    
    public void Init(float damage)
    {
        _damage = damage;
    }

    private IEnumerator Start()
    {
        Vector2 startPos = transform.position;
        Vector2 endPos = startPos + Vector2.up * 5;
        
        while (_currentTime < 1)
        {
            yield return null;
            _currentTime += Time.deltaTime;

            if (_currentTime >= _moveTime)
                _currentTime = _moveTime;

            float time = _currentTime / _moveTime;
            time = 1 - Mathf.Pow(1 - time, 5);
            transform.position = Vector2.Lerp(startPos, endPos, time);
        }

        yield return new WaitForSeconds(3f);
        
        Boom();
    }

    private void Boom()
    {
        RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, _radius, Vector2.up, _enemyLayer);
        if (hits.Length < 0)
            return;

        foreach (var hit in hits)
        {
            // 대충 아래처럼 해서 데미지 주도록 개발 해야함. 
            // hit.transform.GetComponent<>()
        }
    }
}

// 에셋이랑 파티클 추가해줘야함. 
// 끝나면 삭제 되도록 
