using CodeBase.GamePlay.Player;
using UnityEngine;

namespace CodeBase.GamePlay.Levels
{
    public class ScoolTrigger : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent<TriggerHandler>(out var trigger))
            {
                trigger.Progress.AddMoney();
            }
        }
    }
}