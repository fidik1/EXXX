using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GirlBlock : MonoBehaviour
{
    [SerializeField] private Canvas _canvas;
    [SerializeField] private TMP_Text _text;
    [SerializeField] private GameObject[] _girl;
    [SerializeField] private Animator[] _girlAnimator;

    private bool _isSecret;

    private void Start()
    {
        _canvas.worldCamera = Camera.main;
        _girl[0].SetActive(!_isSecret);
        _girl[1].SetActive(_isSecret);
    }

    public void SetText(string text)
    {
        _text.text = text;
    }

    public void Kill()
    {
        foreach (Animator animator in _girlAnimator)
        {
            animator.SetTrigger("IsDead");
            _girl[0].GetComponent<BoxCollider>().enabled = false;
            _girl[1].GetComponent<BoxCollider>().enabled = false;
        }
    }

    public void Secret()
    {
        _isSecret = !_isSecret;
        _girl[0].SetActive(!_isSecret);
        _girl[1].SetActive(_isSecret);
    }
}
