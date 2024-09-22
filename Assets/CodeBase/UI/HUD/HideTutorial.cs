using CodeBase.GamePlay.Player;
using CodeBase.Infrastructure.Factories;
using CodeBase.Services.InputService;
using UnityEngine;
using Zenject;

namespace CodeBase.UI.HUD
{
    public class HideTutorial : MonoBehaviour
    {
        [Inject] private IInputService _inputService;
        [Inject] private IGameFactory _gameFactory;

        private void Start()
        {
            _inputService.OnDrag += OnDrag;
        }

        private void OnDrag(float obj)
        {
            _gameFactory.Player.GetComponent<PlayerMovement>().SetStart();
            _gameFactory.Player.GetComponent<PlayerView>().SetPoor();
            gameObject.SetActive(false);
        }

        private void OnDisable()
        {
            _inputService.OnDrag -= OnDrag;
        }
    }
}
