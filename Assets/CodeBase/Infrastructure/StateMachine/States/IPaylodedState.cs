namespace CodeBase.Infrastructure.StateMachine.States
{
    public interface IPaylodedState<TPayload> : IExitableState
    {
        void Enter(TPayload payload);
    }
}