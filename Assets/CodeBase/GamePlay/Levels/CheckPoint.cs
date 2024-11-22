using System.Collections.Generic;
using CodeBase.GamePlay.Player;
using UnityEngine;

namespace CodeBase.GamePlay.Levels
{
    public class CheckPoint : MonoBehaviour
    {
        [SerializeField] private List<Flag> _flags;
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent<TriggerHandler>(out var playerTrigger))
            {
                foreach (var flag in _flags)
                {
                    flag.Rotate();
                }
            }
        }
    }
}