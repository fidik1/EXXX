using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    [SerializeField] private BlockSpawner _blockSpawner;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            _blockSpawner.Secret();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            _blockSpawner.CreateBlocks();
        }
    }
}
