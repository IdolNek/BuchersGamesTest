using CodeBase.GamePlay.Player;
using UnityEngine;

namespace CodeBase.GamePlay.Levels
{
    public class MoneyTrigger : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent<PlayerProgress>(out var playerProgress))
            {
                playerProgress.AddMoney();
                Destroy(gameObject);
            }
        }
    }
}