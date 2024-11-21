using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FavoritesPanel : MonoBehaviour
{
    [SerializeField] private FavoriteButtonTemplate _favoriteButtonTemplate;
    [SerializeField] private Transform _container;
    [SerializeField] private GameObject _panel;
    [SerializeField] private Reader _reader;
    [SerializeField] private Button _openButton;
    [SerializeField] private Button _like;

    private Favorites _favorites;
    private List<FavoriteButtonTemplate> _buttons = new List<FavoriteButtonTemplate>();
    private bool _isOpened = false;

    private void OnEnable()
    {
        _openButton.onClick.AddListener(OpenClicked);
        _like.onClick.AddListener(LikeClicked);
    }

    private void Start()
    {
        _favorites = new Favorites();
        _favorites.Load();
    }

    private void Show()
    {
        _isOpened = true;
        _panel.SetActive(true);
        foreach (int item in _favorites.Numbers)
        {
            FavoriteButtonTemplate button = Instantiate(_favoriteButtonTemplate, _container);
            _buttons.Add(button);
            button.Init(item);
            button.Clicked += OnClicked;
        }
    }

    internal void Close()
    {
        _isOpened = false;
        _panel.SetActive(false);
        foreach (FavoriteButtonTemplate item in _buttons)
        {
            Destroy(item.gameObject);
        }
        _buttons.Clear();
    }

    private void OnDisable()
    {
        foreach (var item in _buttons)
        {
            item.Clicked += OnClicked;
        }
        _openButton.onClick.RemoveListener(OpenClicked);
        _like.onClick.RemoveListener(LikeClicked);
    }

    private void OpenClicked()
    {
        if (_isOpened)
            Close();
        else
            Show();
    }

    private void LikeClicked()
    {
        _favorites.Add(_reader.CurrentIndex);
    }

    private void OnClicked(int number)
    {
        _reader.Open(number);
        _panel.SetActive(false);
    }
}
