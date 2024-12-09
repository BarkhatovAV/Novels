using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GamePush;
using VNCreator;
using GameAnalyticsSDK;


public class AdManagerNovels : MonoBehaviour
{
    [SerializeField] private List<ButtonHoverHandler> _buttonHoverHandlers;
    [SerializeField] private StartGame _startGame;

    private void OnEnable()
    {
        foreach (ButtonHoverHandler item in _buttonHoverHandlers)
        {
            item.OnHover += OnHovered;
        }
        _startGame.SDKReady += OnReady;
    }

    private void OnDisable()
    {
        foreach (ButtonHoverHandler item in _buttonHoverHandlers)
        {
            item.OnHover -= OnHovered;
        }
        _startGame.SDKReady -= OnReady;
    }

    private void OnHovered()
    {
        ShowInterstitialAd();
    }

    private bool _isFullScreenAvailable = true;
    private float _time = 120;
    private bool _canShow = false;

    private void Start()
    {
        if (GP_Init.isReady)
        {
            OnReady();
        }
    }

    private void OnReady()
    {
        Debug.Log("_______VARIABLES: GET STRING " + GP_Variables.GetString("Ad"));
        string conf = GP_Variables.GetString("Ad");
        //GameAnalytics.Initialize();

        //while (GameAnalytics.IsRemoteConfigsReady() == false)
        //{
        //    yield return new WaitForSeconds(1);
        //}

        //Debug.Log($"CONFIG CONTENT = {GameAnalytics.GetRemoteConfigsContentAsString()}");

        //string conf = GameAnalytics.GetRemoteConfigsValueAsString("Ad");

        if (conf == "On")
            _canShow = true;
    }

    public void ShowInterstitialAd(Action onShowCallback = null, Action<bool> onCloseCallback = null)
    {
        if (_canShow == false)
            return;

        if (_isFullScreenAvailable == false)
        {
            onShowCallback?.Invoke();
            onCloseCallback?.Invoke(true);
            return;
        }



        //#if YANDEX_GAMES && !UNITY_EDITOR
        //        if (YandexGamesSdk.IsInitialized)
        //            Agava.YandexGames.InterstitialAd.Show(onShowCallback, onCloseCallback);
        //#endif
        GP_Ads.ShowFullscreen(onShowCallback, onCloseCallback);


#if !UNITY_WEBGL || UNITY_EDITOR
        onShowCallback?.Invoke();
        onCloseCallback?.Invoke(true);
#endif
    }

    public void ShowRewardAd(Action onOpenCallback = null, Action onRewardedCallback = null, Action onCloseCallback = null)
    {

        //#if YANDEX_GAMES && !UNITY_EDITOR
        //        Agava.YandexGames.VideoAd.Show(onOpenCallback, onRewardedCallback, onCloseCallback);
        //#endif




#if !UNITY_WEBGL || UNITY_EDITOR
        onOpenCallback?.Invoke();
        onCloseCallback?.Invoke();
#endif

    }
}

