using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


    public class ButtonHoverHandler : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        private bool isHovered;
        public event Action OnHover;

        // �����������, ����� ��������� ������ � ������� ������
        public void OnPointerEnter(PointerEventData eventData)
        {
            OnHover?.Invoke();
            isHovered = true;
            Debug.Log("������ � ������");
        }

        // �����������, ����� ��������� ������� �� ������� ������
        public void OnPointerExit(PointerEventData eventData)
        {
            isHovered = false;
            Debug.Log("������ ������ �� � ������");
        }

        // �����������: �������� ���������
        public bool IsHovered()
        {
            return isHovered;
        }
    }

