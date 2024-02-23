using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private GameObject _prefabKill;

    private Transform _target;

    public void SetTarget(Transform target)
    {
        _target = target;
    }

    private void Update()
    {
        Vector3 direction = (_target.position + new Vector3(0, 18, 0) - transform.position).normalized;
        _rb.velocity = direction * _speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Girl"))
        {
            other.GetComponentInParent<GirlBlock>().Kill();
            Instantiate(_prefabKill, transform.position + new Vector3(0, 2, 0), Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
