using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System;

public class OfferPanel : MonoBehaviour
{
    [SerializeField] private Button _noAd;
    [SerializeField] private Button _rewardButton;
    [SerializeField] private AdManager _adManager;
    [SerializeField] private Canvas _canvas;
    [SerializeField] private Reader _reader;

    public  Action _rewarded;
    private bool _isRewarded;

    private void OnEnable()
    {
        _noAd.onClick.AddListener(NoADClicked);
        _rewardButton.onClick.AddListener(RewardButton);
    }
    private void OnDisable()
    {
        _noAd.onClick.RemoveListener(NoADClicked);
        _rewardButton.onClick.RemoveListener(RewardButton);
    }

    private void RewardButton()
    {
        _isRewarded = false;
        Action rewarded = () =>
        {
            if (_isRewarded)
                return;
            _reader.ShowBest();
            _canvas.enabled = false;
            _isRewarded = true;
        };

        _adManager.ShowRewardAd(onRewardedCallback: rewarded, onCloseCallback: rewarded);
    }

    private void NoADClicked()
    {
        _reader.Next(true);
        _canvas.enabled = false;
    }

    public void Show()
    {
        _noAd.gameObject.SetActive(false);
        _canvas.enabled = true;
        StartCoroutine(ShowButton());

        IEnumerator ShowButton()
        {
            yield return new WaitForSeconds(4);
            _noAd.gameObject.SetActive(true);
        }

    }
}
