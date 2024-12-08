using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


    public class ButtonHoverHandler : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        private bool isHovered;
        public event Action OnHover;

        // Срабатывает, когда указатель входит в область кнопки
        public void OnPointerEnter(PointerEventData eventData)
        {
            OnHover?.Invoke();
            isHovered = true;
            Debug.Log("Кнопка в фокусе");
        }

        // Срабатывает, когда указатель выходит из области кнопки
        public void OnPointerExit(PointerEventData eventData)
        {
            isHovered = false;
            Debug.Log("Кнопка больше не в фокусе");
        }

        // Опционально: проверка состояния
        public bool IsHovered()
        {
            return isHovered;
        }
    }

