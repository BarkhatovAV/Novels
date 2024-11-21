using GameAnalyticsSDK;
using System;
using System.Collections;
using UnityEngine;

public class InterstitialTimeController : MonoBehaviour
{
    [SerializeField] private AdManager _adManager;
    [SerializeField] private Canvas _canvas;
    
    private float _currentTime;
    private bool _isCountdownTimerStarted = false;
    private Coroutine _coroutineTimer;
    private float _interCooldown = 90;
    private float _countdownTimer = 5;

    public event Action Started;
    public event Action Stopped;
    public event Action<float> Tick;
    public event Action CountdownTimerStarted;



    //private IEnumerator Start()
    //{
    //    //GameAnalytics.Initialize();

    //    //while(GameAnalytics.IsRemoteConfigsReady() == false)
    //    //{
    //    //    yield return new WaitForSeconds(1);
    //    //}

    //    //Debug.Log($"CONFIG CONTENT = {GameAnalytics.GetRemoteConfigsContentAsString()}");

    //    //string conf = GameAnalytics.GetRemoteConfigsValueAsString("Ad");

    //    //if (conf == "On")
    //    //    StartTimer();
    //}

    public void StartTimer()
    {
        if (_coroutineTimer != null)
            return;

        _coroutineTimer = StartCoroutine(TimerTick());
    }

    public void StopTimer()
    {
        if (_coroutineTimer == null)
            return;

        StopCoroutine(_coroutineTimer);
    }

    private IEnumerator TimerTick()
    {
        _currentTime = _interCooldown;
        _isCountdownTimerStarted = false;
        Started?.Invoke();

        while (_currentTime > 0)
        {
            _currentTime -= Time.deltaTime;
            Tick?.Invoke(_currentTime);

            if (_currentTime <= _countdownTimer && _isCountdownTimerStarted == false)
            {
                _canvas.enabled = true;
                _isCountdownTimerStarted = true;
                CountdownTimerStarted?.Invoke();
            }

            yield return null;
        }

        _coroutineTimer = null;
        Stopped?.Invoke();
        _canvas.enabled = false;
        ShowInter();
    }

    private void ShowInter()
    {
        _adManager.ShowInterstitialAd(null, OnCloseCallback);

        void OnCloseCallback(bool isClosed)
        {
            StartTimer();
        }
    }
}
