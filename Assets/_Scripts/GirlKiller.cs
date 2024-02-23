using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GirlKiller : MonoBehaviour
{
    [SerializeField] private BlockSpawner _blockSpawner;
    [SerializeField] private Projectile _prefabProjectile;

    private int _currentGirl;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _currentGirl < _blockSpawner.Blocks.Count)
        {
            SpawnProjectile();
        }
    }

    private void SpawnProjectile()
    {
        Projectile projectile = Instantiate(_prefabProjectile, new(transform.position.x, transform.position.y * 2, transform.position.z), Quaternion.identity);
        projectile.SetTarget(_blockSpawner.Blocks[_currentGirl].transform);
        _currentGirl++;
    }
}
