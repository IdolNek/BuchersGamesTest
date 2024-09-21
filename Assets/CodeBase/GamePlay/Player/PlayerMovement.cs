using System.Collections;
using System.Collections.Generic;
using CodeBase.GamePlay.Levels;
using CodeBase.Services.InputService;
using UnityEngine;
using Zenject;

namespace CodeBase.GamePlay.Player
{
    public class PlayerMovement : MonoBehaviour
    {
        public float speed = 5f; // Скорость движения вперед
        public float rotationSpeed = 180f; // Скорость поворота
        private int _currentPointIndex = 0; // Текущая точка, к которой движется игрок

        private List<PivotPoint> _pivotPoints; // Список точек, по которым будет двигаться игрок

        public void Initialize(List<PivotPoint> pivotPoints)
        {
            _pivotPoints = pivotPoints;
        }

        private void Update()
        {
            if (_pivotPoints == null || _pivotPoints.Count == 0 || _currentPointIndex >= _pivotPoints.Count)
                return;

            MoveTowardsPoint();
        }

        private void MoveTowardsPoint()
        {
            // Берем текущую точку назначения
            Transform targetPoint = _pivotPoints[_currentPointIndex].transform;

            // Двигаем игрока к точке
            Vector3 direction = (targetPoint.position - transform.position).normalized;
            transform.position += direction * speed * Time.deltaTime;

            // Вращаем игрока в сторону точки
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

            // Проверяем, достиг ли игрок точки
            if (Vector3.Distance(transform.position, targetPoint.position) < 0.1f)
            {
                _currentPointIndex++; // Переходим к следующей точке

                // Если достигли последней точки, вызываем событие завершения игры
                if (_currentPointIndex >= _pivotPoints.Count)
                {
                    OnGameEnd();
                }
            }
        }

        private void OnGameEnd()
        {
            Debug.Log("Game Over: All points reached");
            // Здесь можно вызвать событие окончания игры
        }
    }
}