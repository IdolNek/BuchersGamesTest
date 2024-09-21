using CodeBase.Services.InputService;
using UnityEngine;
using Zenject;

namespace CodeBase.GamePlay.Player
{
    public class PlayerLateralMovement : MonoBehaviour
    {
        [SerializeField] private Transform leftPoint; // Левый крайний предел
        [SerializeField] private Transform rightPoint; // Правый крайний предел
        [SerializeField] private float moveSpeed = 5f; // Скорость движения
        [SerializeField] private float rotationAngle = 30f; // Угол наклона при движении

        private IInputService _inputService;
        private Vector3 _targetPosition;
        private bool _isMovingLeft;

        [Inject]
        public void Construct(IInputService inputService)
        {
            _inputService = inputService;
        }

        private void Start()
        {
            _inputService.OnDrag += OnDrag;
            _targetPosition = transform.localPosition;
        }

        private void Update()
        {
            _inputService.Update();
            // Плавное перемещение к целевой позиции с учётом локальных координат
            transform.localPosition = Vector3.Lerp(transform.localPosition, _targetPosition, moveSpeed * Time.deltaTime);
        }

        private void OnDrag(float deltaX)
        {
            if (deltaX > 0) // Движение вправо
            {
                _isMovingLeft = false;
                _targetPosition = rightPoint.localPosition;
                transform.localRotation = Quaternion.Euler(0, rotationAngle, 0);
            }
            else if (deltaX < 0) // Движение влево
            {
                _isMovingLeft = true;
                _targetPosition = leftPoint.localPosition;
                transform.localRotation = Quaternion.Euler(0, -rotationAngle, 0);
            }
        }

        private void OnDestroy()
        {
            if (_inputService != null)
            {
                _inputService.OnDrag -= OnDrag;
            }
        }
    }
}