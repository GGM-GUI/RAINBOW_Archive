using UnityEngine;

public class FlyingProjectile : MonoBehaviour, IProjectile
{
    [SerializeField] private float _speed;
    private float _damage;

    public void Init(float damage)
    {
        _damage = damage;
    }

    private void Update()
    {
        transform.Translate(Vector3.up * (_speed * Time.deltaTime));
    }

    private void OnCollisionEnter(Collision collision)
    {
        //공격
        Destroy(gameObject);
    }
}
