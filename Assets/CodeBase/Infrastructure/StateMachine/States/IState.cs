namespace CodeBase.Infrastructure.StateMachine.States
{
    public interface IState : IExitableState
    {
        void Enter();
    }
}