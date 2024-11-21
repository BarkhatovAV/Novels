using Agava.YandexGames;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GamePush;

public class StartGame : MonoBehaviour
{
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
