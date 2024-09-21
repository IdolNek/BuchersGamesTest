using ButchersGames;
using CodeBase.GamePlay.Player;
using CodeBase.UI.HUD;
using UnityEngine;
using Zenject;

namespace CodeBase.Infrastructure.Factories
{
    public class GameFactory : IGameFactory
    {
        private readonly DiContainer _container;
        private readonly HUDRoot.Factory _hudFactory;
        private readonly LevelManager.Factory _levelManagerFactory;
        
        private Player _player;

        public GameFactory(DiContainer container, HUDRoot.Factory hudFactory, LevelManager.Factory levelManagerFactory)
        {
            _container = container;
            _hudFactory = hudFactory;
            _levelManagerFactory = levelManagerFactory;
        }

        public IHUDRoot CreateHUD() => _hudFactory.Create();
        
        public LevelManager CreateLevelManager() => _levelManagerFactory.Create();
        public void CreatePlayer(Vector3 position)
        {
           var player = _container.InstantiatePrefabResource(InfrastructureAssetPath.Player, position, Quaternion.identity, null);
           _player = player.GetComponent<Player>();
        }

        public void Cleanup()
        {
            
        }
    }
}