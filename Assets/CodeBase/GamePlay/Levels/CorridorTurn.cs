using System.Collections;
using CodeBase.GamePlay.Player;
using UnityEngine;
using UnityEngine.Serialization;

namespace CodeBase.GamePlay.Levels
{
    public class CorridorTurn: MonoBehaviour
    {
        [SerializeField] private bool turnRight; // true - поворот налево, false - направо

        private void OnTriggerEnter(Collider other)
        {
            // if (other.gameObject.TryGetComponent<PlayerRotation>(out PlayerRotation player))
            // {
            //     Debug.Log("Player found");
            //     if (player != null)
            //     {
            //         player.RotatePlayer(turnRight);
            //     }
            // }
        }

    }
}