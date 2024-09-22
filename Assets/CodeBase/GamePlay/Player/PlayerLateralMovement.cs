using CodeBase.Services.InputService;
using UnityEngine;
using Zenject;

namespace CodeBase.GamePlay.Player
{
    public class PlayerLateralMovement : MonoBehaviour
    {
        [SerializeField] private Transform leftPoint;
        [SerializeField] private Transform rightPoint;
        [SerializeField] private float moveSpeed = 5f;
        [SerializeField] private float rotationAngle = 30f;
        [SerializeField] private float dragSensitivity = 0.02f;

        private IInputService _inputService;
        private Vector3 _targetPosition;
        private float _minX, _maxX;

        [Inject]
        public void Construct(IInputService inputService)
        {
            _inputService = inputService;
        }

        private void Start()
        {
            _inputService.OnDrag += OnDrag;

            _minX = leftPoint.localPosition.x;
            _maxX = rightPoint.localPosition.x;

            _targetPosition = transform.localPosition;
        }

        private void Update()
        {
            _inputService.Update();

            transform.localPosition =
                Vector3.Lerp(transform.localPosition, _targetPosition, moveSpeed * Time.deltaTime);

            if (Mathf.Abs(transform.localPosition.x - _targetPosition.x) < 0.5f)
            {
                transform.localRotation = Quaternion.Euler(0, 0, 0);
            }
        }

        private void OnDrag(float deltaX)
        {
            float newX = Mathf.Clamp(_targetPosition.x + deltaX * dragSensitivity, _minX, _maxX);

            _targetPosition = new Vector3(newX, transform.localPosition.y, transform.localPosition.z);

            if (deltaX > 0)
            {
                transform.localRotation = Quaternion.Euler(0, rotationAngle, 0);
            }
            else if (deltaX < 0)
            {
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