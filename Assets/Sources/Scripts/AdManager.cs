using GamePush;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdManager : MonoBehaviour
{

    private bool _isFullScreenAvailable = true;
    private float _time = 120;

    public void ShowInterstitialAd(Action onShowCallback = null, Action<bool> onCloseCallback = null)
    {
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
