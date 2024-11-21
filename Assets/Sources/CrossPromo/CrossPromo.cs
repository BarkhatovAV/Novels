using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class CrossPromo : MonoBehaviour
{
    [SerializeField] private Button _enterButton;
    [SerializeField] private Button _exitButton;
    [SerializeField] private GameObject _gameObject;

    private void OnEnable()
    {
        _enterButton.onClick.AddListener(OnEnter);
        _exitButton.onClick.AddListener(OnExit);
        StartCoroutine(Loop());

        IEnumerator Loop()
        {
            while(true)
            {
                yield return new WaitForSeconds(80);
                _enterButton.gameObject.transform.DOScale(1.1f, 0.7f).SetLoops(6, LoopType.Yoyo).SetEase(Ease.InOutBack);
            }
        }
    }

    private void OnDisable()
    {
        _enterButton.onClick.RemoveListener(OnEnter);
        _exitButton.onClick.RemoveListener(OnExit);
    }

    private void OnEnter()
    {
        _gameObject.SetActive(true);
    }

    private void OnExit()
    {
        _gameObject.SetActive(false);
    }
}
