using GamePush;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VNCreator;
public class Metrica : MonoBehaviour
{
    [SerializeField] private VNCreator_DisplayUI _displayUI;
    private int _nextClickCounter;

    private void OnEnable()
    {
        _displayUI.NextDowned += OnNextDown;
    }

    private void OnDisable()
    {
        _displayUI.NextDowned -= OnNextDown;
    }

    private void OnNextDown()
    {
        _nextClickCounter++;
        GP_Analytics.Goal("Next", _nextClickCounter.ToString());
    }
}
