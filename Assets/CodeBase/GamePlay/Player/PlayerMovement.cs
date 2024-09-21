using System.Collections;
using CodeBase.Services.InputService;
using UnityEngine;
using Zenject;

namespace CodeBase.GamePlay.Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float forwardSpeed = 5f; // Скорость движения вперед
        [SerializeField] private float moveSpeed = 10f; // Скорость горизонтального движения
        [SerializeField] private float laneLimit = 2f;
        [SerializeField] private float turnSpeed = 2f; 
        
        private IInputService _inputService;
        private Vector3 _targetPosition;
        private float _initialX;

        [Inject]
        private void Construct(IInputService inputService)
        {
            _inputService = inputService;
        }

        private void Start()
        {
            _initialX = transform.position.x;
            _targetPosition = transform.position; // Инициализируем начальную позицию
            _inputService.OnDrag += HandleDrag;
        }

        private void Update()
        {
            _inputService.Update();

            // Движение вперед
            transform.Translate(Vector3.forward * forwardSpeed * Time.deltaTime);

            // Обновляем позицию по X
            Vector3 currentPosition = transform.position;
            currentPosition.x = Mathf.Lerp(currentPosition.x, _targetPosition.x, moveSpeed * Time.deltaTime);
            transform.position = currentPosition;
        }

        private void HandleDrag(float deltaX)
        {
            float minX = _initialX - laneLimit; // Минимальная граница
            float maxX = _initialX + laneLimit; // Максимальная граница

            // Измените только x-координату на основе deltaX
            float newX = Mathf.Clamp(transform.position.x + deltaX * 0.1f, minX, maxX);
            _targetPosition = new Vector3(newX, transform.position.y, transform.position.z);

            Debug.Log($"Current X: {transform.position.x}, New target X: {newX}");
        }
        
        public void TurnTowards(float angle)
        {
            Quaternion targetRotation = Quaternion.Euler(0, angle, 0) * transform.rotation;

            // Обновляем начальную позицию после поворота
            _initialX = transform.position.x;

            StartCoroutine(RotateToTarget(targetRotation));
        }
        
        private IEnumerator RotateToTarget(Quaternion targetRotation)
        {
            float elapsedTime = 0f;
            float duration = 0.5f; // Задайте длительность поворота

            while (elapsedTime < duration)
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, (elapsedTime / duration));
                elapsedTime += Time.deltaTime;
                yield return null; // Ждем следующего кадра
            }

            transform.rotation = targetRotation;
        }

        public void SetTurnPosition(Vector3 position)
        {
            Debug.Log("Setting turn position: " + position);
            _targetPosition = position;
        }

        private void OnDestroy()
        {
            if (_inputService != null)
            {
                _inputService.OnDrag -= HandleDrag;
            }
        }
    }
}