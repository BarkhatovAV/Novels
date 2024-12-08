using Agava.YandexGames;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GamePush;
using System;

public class StartGame : MonoBehaviour
{
    private bool _canShow;
    public event Action SDKReady;

    public bool CanShowAd { get; private set; }
    //#if YANDEX_GAMES && !UNITY_EDITOR
    //        private IEnumerator Start()
    //        {
    //            yield return YandexGamesSdk.Initialize();
    //        }
    //#endif

    // ����� ����������� �� ������� GP_Init.OnReady
    private void OnEnable()
    {
        GP_Init.OnReady += OnPluginReady;
    }

    // ����� ��������� ���������� ����� await GP_Init.Ready
    private async void Start()
    {
        await GP_Init.Ready;
        SDKReady?.Invoke();

        OnPluginReady();
    }

    // ����� ��������� ���������� ����� GP_Init.isReady
    private void CheckReady()
    {
        if (GP_Init.isReady)
        {
            OnPluginReady();
        }
    }

    private void OnPluginReady()
    {
        Debug.Log("Plugin ready");
    }
}
