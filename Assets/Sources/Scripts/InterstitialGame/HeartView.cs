using System;
using System.Numerics;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class HeartView : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private float _speed;
    [SerializeField] private RectTransform _rectTransform;
    [SerializeField] private ParticleSystem _particleSystem;
    //[SerializeField] private TMP_Text _valueText;

    //private IWallet _wallet;
    //private BigInteger _value;

    public RectTransform RectTransform => _rectTransform;

    //public object NumberFormatting { get; private set; }

    public event Action<HeartView> Exploded;

    //public void Init(IWallet wallet, BigInteger value)
    //{
    //    _value = value;
    //    _wallet = wallet;
    //    //_valueText.text = NumberFormatting.Format(_value);
    //}

    public void OnPointerClick(PointerEventData eventData)
    {
        //_wallet.Add(_value);
        _particleSystem.transform.parent = null;
        _particleSystem.Play();
        Exploded?.Invoke(this);
        Destroy(gameObject);
    }

    private void Update()
    {
        transform.Translate(UnityEngine.Vector3.up * _speed * Time.deltaTime);
    }
}
