using System;
using UnityEngine;

namespace CodeBase.Services.InputService
{
    public class InputService : IInputService
    {
        public event Action<float> OnDrag;

        private Vector2 _startTouchPosition;
        private bool _isDragging = false;

        public void Update()
        {
            if (Input.touchCount > 0)
            {
                // Обработка касаний
                Touch touch = Input.GetTouch(0);
                HandleTouch(touch);
            }
            else if (Input.GetMouseButton(0)) // Проверяем, зажата ли левая кнопка мыши
            {
                HandleMouse();
            }
        }

        private void HandleTouch(Touch touch)
        {
            switch (touch.phase)
            {
                case TouchPhase.Began:
                    _startTouchPosition = touch.position;
                    _isDragging = true;
                    break;

                case TouchPhase.Moved:
                    if (_isDragging)
                    {
                        Vector2 currentTouchPosition = touch.position;
                        float deltaX = currentTouchPosition.x - _startTouchPosition.x;

                        // Передаем смещение по X через событие
                        OnDrag?.Invoke(deltaX);

                        // Обновляем начальную точку
                        _startTouchPosition = currentTouchPosition;
                    }
                    break;

                case TouchPhase.Ended:
                case TouchPhase.Canceled:
                    _isDragging = false;
                    break;
            }
        }

        private void HandleMouse()
        {
            if (!_isDragging)
            {
                _startTouchPosition = Input.mousePosition;
                _isDragging = true;
            }
            else
            {
                Vector2 currentMousePosition = Input.mousePosition;
                float deltaX = currentMousePosition.x - _startTouchPosition.x;

                // Передаем смещение по X через событие
                OnDrag?.Invoke(deltaX);

                // Обновляем начальную точку
                _startTouchPosition = currentMousePosition;
            }
        }
    }
}