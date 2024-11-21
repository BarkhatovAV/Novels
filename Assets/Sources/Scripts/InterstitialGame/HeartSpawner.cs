using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HeartSpawner : MonoBehaviour
{
    [SerializeField] private HeartView _heartPrefab;
    [SerializeField] private float _spawnInterval = 1f;
    [SerializeField] private Transform _container;
    [SerializeField] private int _multiplier;
    [SerializeField] private TMP_Text _counter;
    [SerializeField] private int _maxSpawn;
    [SerializeField] private RectTransform _canvasRect;
    [SerializeField] private AudioSource _audioSource;

    private List<HeartView> _heartViews = new List<HeartView>();

    private int _currentExplodeHeart;
    private float _spawnTimer = 0f;

    public void StartSpawn()
    {
        _currentExplodeHeart = 0;
        _spawnTimer = _spawnInterval;
        enabled = true;
        UpdateView();
    }

    public void StopSpawn()
    {
        foreach (var heart in _heartViews)
        {
            if (heart != null)
            {
                heart.Exploded -= OnExploded;
                Destroy(heart.gameObject);
            }
        }

        enabled = false;
    }

    private void Update()
    {
        _spawnTimer += Time.deltaTime;

        if (_spawnTimer >= _spawnInterval)
        {
            SpawnHeart();
            _spawnTimer = 0f;
        }
    }

    private void SpawnHeart()
    {
        if (_currentExplodeHeart > _maxSpawn)
            return;

        float screenWidth = _canvasRect.sizeDelta.x / 2;
        float randomX = Random.Range(-screenWidth, screenWidth);
        Vector3 spawnPosition = new Vector3(randomX, 0f, 0f);
        HeartView newHeart = Instantiate(_heartPrefab, _container);
        //newHeart.Init(_wallet, _clickStrategy.Force * _multiplier);
        _heartViews.Add(newHeart);
        newHeart.Exploded += OnExploded;
        RectTransform heartRectTransform = newHeart.RectTransform;
        Vector3 offset = new Vector3(heartRectTransform.sizeDelta.x / 3, 0, 0);
        heartRectTransform.anchoredPosition = spawnPosition + (spawnPosition.x > 0 ? -offset : offset);
    }

    private void OnExploded(HeartView view)
    {
        _audioSource.Play();
        view.Exploded -= OnExploded;
        _heartViews.Remove(view);
        _currentExplodeHeart++;
        _counter.text = _currentExplodeHeart.ToString();
        UpdateView();
    }

    private void UpdateView()
    {
        _counter.text = _currentExplodeHeart + "/" + _maxSpawn;
    }
}
