using System.Collections.Generic;
using CodeBase.GamePlay.Player;
using UnityEngine;

namespace CodeBase.GamePlay.Levels
{
    public class OpeningDoors : MonoBehaviour
    {
        [SerializeField] private List<Door> _doors;
        [SerializeField] private int _multiplier = 2;
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent<PlayerProgress>(out var playerProgress))
            {
                foreach (var door in _doors)
                {
                    door.Open();
                }
                playerProgress.SetMultiplier(_multiplier);
            }
        }
    }
}