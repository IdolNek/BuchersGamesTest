using UnityEngine;
using Zenject;

namespace CodeBase.UI.HUD
{
    public class HUDRoot : MonoBehaviour, IHUDRoot
    {
        [SerializeField] private GameObject _tutorial;

        public void StartTutorial() => _tutorial.SetActive(true);

        public class Factory : PlaceholderFactory<HUDRoot>
        {
        }
    }
}