using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class BlockSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _prefabBlock;
    [SerializeField] private GirlBlock _prefabGirl;
    [SerializeField] private Transform _parent;

    [SerializeField] private List<GameObject> _blocks;

    [SerializeField] private CameraController _cameraController;

    [SerializeField] private int _countX;
    [SerializeField] private int _countZ;

    [SerializeField] private bool _spawnOneLine;
    [SerializeField] private bool _spawnBlock;

    public List<GameObject> Blocks => _blocks;

    public void CreateBlocks()
    {
        if (_spawnOneLine)
        {
            SpawnX(_countX);
        }
        else
        {
            SpawnXZ(_countX, _countZ);
        }
        int index = _blocks.Count / 2;
        if (index % 2 == 1) index++;
        index += _countZ / 2;
        _cameraController.SetTarget(_countX, _countZ, _blocks[index].transform);
    }

    private void SpawnX(int countX)
    {
        foreach (GameObject block in _blocks)
        {
            Destroy(block);
        }
        _blocks.Clear();
        for (int i = 0; i < countX; i++)
        {
            Vector3 position = new(20 * i, -2, 0);
            if (_spawnBlock)
            {
                GameObject block = Instantiate(_prefabBlock, _parent);
                block.transform.position = position;
                _blocks.Add(block);
            }
            else
            {
                GirlBlock girlBlock = Instantiate(_prefabGirl, _parent);
                girlBlock.SetText(i.ToString());
                girlBlock.transform.position = position;
                _blocks.Add(girlBlock.gameObject);
            }
        }
    }

    private void SpawnXZ(int countX, int countZ)
    {
        foreach (GameObject block in _blocks)
        {
            Destroy(block);
        }
        _blocks.Clear();
        for (int i = 0; i < countX; i++)
        {
            for (int j = 0; j < countZ; j++)
            {
                Vector3 position = new(20 * i, -2, 20 * j);
                if (_spawnBlock)
                {
                    GameObject block = Instantiate(_prefabBlock, _parent);
                    block.transform.position = position;
                    _blocks.Add(block);
                }
                else
                {
                    GirlBlock girlBlock = Instantiate(_prefabGirl, _parent);
                    girlBlock.SetText($"{i}, {j}");
                    girlBlock.transform.position = position;
                    _blocks.Add(girlBlock.gameObject);
                }
            }
        }
    }

    public void Secret()
    {
        if (!_spawnBlock)
        {
            if (_blocks[0].GetComponent<GirlBlock>())
            {
                foreach (GameObject girl in _blocks)
                {
                    girl.GetComponent<GirlBlock>().Secret();
                }
            }
        }    
    }
}
