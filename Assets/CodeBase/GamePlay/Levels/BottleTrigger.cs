using CodeBase.GamePlay.Player;
using UnityEngine;

namespace CodeBase.GamePlay.Levels
{
    public class BottleTrigger : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent<TriggerHandler>(out var trigger))
            {
                trigger.Progress.RemoveMoney();
                Destroy(gameObject);
            }
        }
    }
}