using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CrossButton : MonoBehaviour
{
    [SerializeField] private string _url;
    [SerializeField] private Button _button;

    private void OnEnable()
    {
        _button.onClick.AddListener(OnClicked);
    }

    private void DisEnable()
    {
        _button.onClick.RemoveListener(OnClicked);
    }

    private void OnClicked()
    {
        Application.OpenURL(_url);
    }
}
