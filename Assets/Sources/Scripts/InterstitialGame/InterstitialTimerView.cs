using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InterstitialTimerView : MonoBehaviour
{
    [SerializeField] private InterstitialTimeController _interstitialTimeController;
    [SerializeField] private TMP_Text _timer;
    [SerializeField] private HeartSpawner _spawner;
    [SerializeField] private Image _image;

    private void OnEnable()
    {
        _interstitialTimeController.Tick += OnTick;
        _interstitialTimeController.CountdownTimerStarted += OnCountdownStarted;
        _interstitialTimeController.Stopped += OnStopped;
    }

    private void OnDisable()
    {
        _interstitialTimeController.Tick -= OnTick;
        _interstitialTimeController.CountdownTimerStarted -= OnCountdownStarted;
        _interstitialTimeController.Stopped -= OnStopped;
    }

    private void OnTick(float value)
    {
        _timer.text = ((int)value).ToString();
    }

    private void OnStopped()
    {
        _image.gameObject.SetActive(false);
        _spawner.StopSpawn();
    }

    private void OnCountdownStarted()
    {
        _image.gameObject.SetActive(true);
        _spawner.StartSpawn();
    }
}
