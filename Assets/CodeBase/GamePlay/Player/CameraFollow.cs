using UnityEngine;

namespace CodeBase.GamePlay.Player
{
    public class CameraFollow : MonoBehaviour
    {
        [SerializeField] private Transform player; // Игрок, за которым следует камера
        [SerializeField] private float followSpeed = 5f; // Скорость, с которой камера двигается за игроком
        [SerializeField] private float lateralOffsetLimit = 2f; // Лимит смещения по X

        private Vector3 _initialLocalPosition;

        private void Start()
        {
            // Сохраняем начальную локальную позицию камеры относительно игрока
            _initialLocalPosition = transform.localPosition;
        }

        private void LateUpdate()
        {
            // Получаем локальное смещение игрока по X относительно его начальной позиции
            float playerLocalX = player.localPosition.x;

            // Ограничиваем смещение камеры в пределах заданного лимита
            float clampedX = Mathf.Clamp(playerLocalX, -lateralOffsetLimit, lateralOffsetLimit);

            // Обновляем локальную позицию камеры только по X (остальные координаты остаются неизменными)
            Vector3 targetPosition = new Vector3(_initialLocalPosition.x + clampedX, _initialLocalPosition.y, _initialLocalPosition.z);
            transform.localPosition = Vector3.Lerp(transform.localPosition, targetPosition, followSpeed * Time.deltaTime);
        }
    }
}