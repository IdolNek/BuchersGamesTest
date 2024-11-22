using UnityEngine;

namespace CodeBase.GamePlay.Player
{
    public class TriggerHandler: MonoBehaviour
    {
        [SerializeField] private PlayerProgress _playerProgress;

        public PlayerProgress Progress => _playerProgress;
    }
}