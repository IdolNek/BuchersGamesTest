using System.Collections;
using CodeBase.GamePlay.Player;
using UnityEngine;

namespace CodeBase.GamePlay.Levels
{
    public class CorridorTurn: MonoBehaviour
    {
        [SerializeField] private float turnSpeed = 2f; // Скорость поворота игрока
        [SerializeField] private float turnRadius = 1f; // Радиус поворота для игрока
        [SerializeField] private bool turnLeft; // true - поворот налево, false - направо

        private PlayerMovement _playerMovement;
        private bool _isTurning = false;

        private void OnTriggerEnter(Collider other)
        {
            Debug.Log("asdf");
            if (other.gameObject.TryGetComponent<PlayerMovement>(out PlayerMovement player)) // Убедитесь, что тег игрока установлен
            {
                Debug.Log("Player found");
                _playerMovement = player;
                if (player != null && !_isTurning)
                {
                    StartCoroutine(TurnCoroutine());
                }
            }
        }

        private IEnumerator TurnCoroutine()
        {
            _isTurning = true;

            // Определяем угол поворота (90 градусов)
            float turnAngle = turnLeft ? -90f : 90f;

            // Вызываем метод поворота у игрока
            _playerMovement.TurnTowards(turnAngle); // Передаем угол поворота

            // Устанавливаем новую позицию игрока после поворота
            Vector3 turnPosition = new Vector3(transform.position.x + (turnLeft ? -turnRadius : turnRadius), transform.position.y, transform.position.z);
            _playerMovement.SetTurnPosition(turnPosition);

            yield return new WaitForSeconds(turnSpeed); // Задержка для завершения поворота

            _isTurning = false;
        }
    }
}