public abstract class BaseState 
{
    public Enemy enemy;
    public StateMachine stateMachine;
    public AudioManager audioManager;
    public abstract void Enter();
    public abstract void Perform();
    public abstract void Exit();
}

