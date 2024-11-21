using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FavoriteButtonTemplate : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    [SerializeField] private Button _button;

    private int _number;

    public Action<int> Clicked;

    private void OnEnable()
    {
        _button.onClick.AddListener(FavoriteClick);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(FavoriteClick);
    }

    public void Init(int number)
    {
        _number = number;
        _text.text = number.ToString();
    }

    private void FavoriteClick()
    {
        Clicked?.Invoke(_number);
    }
}
