using UnityEngine;

namespace CodeBase.GamePlay.Player
{
    public class FVXTimer : MonoBehaviour
    {
        private void Start()
        {
            Destroy(gameObject,1.5f);
        }
    }
}