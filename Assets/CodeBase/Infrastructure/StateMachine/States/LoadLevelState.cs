using ButchersGames;
using CodeBase.Infrastructure.Factories;
using CodeBase.Infrastructure.States;
using CodeBase.UI.HUD;
using Zenject;

namespace CodeBase.Infrastructure.StateMachine.States
{
    public class LoadLevelState : IPaylodedState<string>
    {
        private readonly IGameStateMachine _gameStateMachine;
        private readonly ISceneLoader _sceneLoader;
        private readonly ILoadingCurtain _loadingCurtain;
        private readonly IGameFactory _gameFactory;
        
        private LevelManager _levelManager;
        private IHUDRoot _hUDRoot;

        public LoadLevelState(IGameStateMachine gameStateMachine, ISceneLoader sceneLoader, ILoadingCurtain loadingCurtain, IGameFactory gameFactory)
        {
            _gameStateMachine = gameStateMachine;
            _sceneLoader = sceneLoader;
            _loadingCurtain = loadingCurtain;
            _gameFactory = gameFactory;
        }

        public void Enter(string sceneName)
        {
            _loadingCurtain.Show();
            _sceneLoader.Load(sceneName, OnLoaded);
        }

        public void Exit()
        {
            _loadingCurtain.Hide();
        }

        private void OnLoaded()
        {
            _levelManager = _gameFactory.CreateLevelManager();
            _hUDRoot = _gameFactory.CreateHUD();
            _levelManager.NextLevel();

            _gameFactory.CreatePlayer(_levelManager.Levels[_levelManager.CurrentLevelIndex].PlayerSpawnPoint.position);
            
            if (_levelManager.CurrentLevelIndex == 0)
            {
                _hUDRoot.StartTutorial();
            }
            
            _gameStateMachine.Enter<GameLoopState>();
        }

        public class Factory : PlaceholderFactory<IGameStateMachine, LoadLevelState>
        {
        }
    }
}