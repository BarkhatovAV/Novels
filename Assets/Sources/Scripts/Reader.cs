using System.Collections.Generic;
using System.IO;
using UnityEngine;
using TMPro;
//using Agava.YandexMetrica;
using GamePush;
public class Reader : MonoBehaviour
{
    [SerializeField] private TextAsset textFile;
    [SerializeField] private TMP_Text _text;
    [SerializeField] private AdManager _adManager;
    [SerializeField] private FavoritesPanel _favoritesPanel;
    [SerializeField] private Canvas _jokePanel;
    [SerializeField] private OfferPanel _offerCanvas;


    private string[] _data;
    private int _currentIndex = 0;
    private int _metricaIndex = 0;
    private int _intervalOffer = 30;

    public int CurrentIndex => _currentIndex;

    void Start()
    {
        if (Screen.width < Screen.height)
            _text.fontSizeMax = 60;

        _data = textFile.text.Split(';');
        if (PlayerPrefs.HasKey("Index"))
            _currentIndex =  PlayerPrefs.GetInt("Index");
        else
            _currentIndex = 0;
        UpdateText();
    }

    public void Open(int number)
    {
        _text.text = _data[number];
    }
    public void Next()
    {
        Next(false, false);
    }

    public void Back()
    {

        //if (_currentIndex != 0 && _currentIndex % _intervalOffer == 0)
        //{

        //    _offerCanvas.Show();
        //    return;
        //}

        if (_currentIndex != 0)
            _currentIndex-- ;



        PlayerPrefs.SetInt("Index", _currentIndex);
        _favoritesPanel.Close();
        //_adManager.ShowInterstitialAd();
        UpdateText();
        //_metricaIndex++;
//#if YANDEX_GAMES && !UNITY_EDITOR
//        YandexMetrica.Send("Next" + _metricaIndex);
//        Debug.Log("Next" + _metricaIndex);
//#endif
        
    }

    public void Next(bool skip1 = false, bool isBest = false)
    {
        if(skip1)
            _currentIndex++;

        //if (_currentIndex != 0 && _currentIndex % _intervalOffer == 0)
        //{
            
        //    _offerCanvas.Show();
        //    return;
        //}

        if (isBest)
            _currentIndex--;

        if (_currentIndex >= _data.Length - 1)
            _currentIndex = 0;
        else
            _currentIndex++;


        PlayerPrefs.SetInt("Index", _currentIndex);
        _favoritesPanel.Close();
        _adManager.ShowInterstitialAd();
        UpdateText();
        _metricaIndex++;
        GP_Analytics.Goal("Next", _metricaIndex);
//#if YANDEX_GAMES && !UNITY_EDITOR
//        YandexMetrica.Send("Next" + _metricaIndex);
//        Debug.Log("Next" + _metricaIndex);
//#endif

    }

    private void UpdateText()
    {
        _text.text = _data[_currentIndex];
    }

    internal void ShowBest()
    {
        _currentIndex++;
        Next(isBest: true);
    }
}
