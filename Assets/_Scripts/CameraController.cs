using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera _camera;
    [SerializeField] private float _blockWidth;

    private CinemachineTransposer _transposer;

    private void Start()
    {
        _transposer = _camera.GetCinemachineComponent<CinemachineTransposer>();
    }

    public void SetTarget(int countX, int countZ, Transform target)
    {
        _transposer.m_FollowOffset = new(0, 15 * ((countZ + countX) / 2), -_blockWidth * ((countZ + countX) / 2));
        _camera.Follow = target;
        _camera.LookAt = target;
    }
}
