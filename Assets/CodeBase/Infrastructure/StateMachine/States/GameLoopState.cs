using CodeBase.Infrastructure.States;
using Zenject;

namespace CodeBase.Infrastructure.StateMachine.States
{
    public class GameLoopState: IState
    {
        private readonly IGameStateMachine _gameStateMachine;

        public GameLoopState(IGameStateMachine gameStateMachine)
        {
            _gameStateMachine = gameStateMachine;
        } 
        public void Exit()
        {
        }

        public void Enter()
        {
        }
        
        public class Factory : PlaceholderFactory<IGameStateMachine, GameLoopState> { }
    }
}