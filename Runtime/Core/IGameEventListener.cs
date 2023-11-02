namespace Dream.GameEventSystem.Core
{
    public interface IGameEventListener<T>
    {
        void RegisterToGameEvent();
        void UnregisterFromGameEvent();
        void OnEventRaised(T item);
    } 
}