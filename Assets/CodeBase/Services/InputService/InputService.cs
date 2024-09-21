using System;
using UnityEngine;

namespace CodeBase.Services.InputService
{
    public class InputService : IInputService
    {
        public event Action<float> OnDrag;

        private Vector2 _startMousePosition;
        private bool _isDragging = false;

        public void Update()
        {
            if (Input.GetMouseButton(0)) // Проверяем, зажата ли левая кнопка мыши
            {
                HandleMouse();
            }
            else
            {
                _isDragging = false;
            }
        }

        private void HandleMouse()
        {
            if (!_isDragging)
            {
                _startMousePosition = Input.mousePosition;
                _isDragging = true;
            }
            else
            {
                Vector2 currentMousePosition = Input.mousePosition;
                float deltaX = currentMousePosition.x - _startMousePosition.x;

                // Передаем смещение по X через событие
                OnDrag?.Invoke(deltaX);

                // Обновляем начальную точку
                _startMousePosition = currentMousePosition;
            }
        }
    }
}