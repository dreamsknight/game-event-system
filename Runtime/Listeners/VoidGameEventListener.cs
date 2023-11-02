using Dream.GameEventSystem.Core;
using Dream.GameEventSystem.GameEvents;
using Dream.GameEventSystem.UnityEvents;
using Void = Dream.GameEventSystem.Core.Void;

namespace Dream.GameEventSystem.Listeners
{
    public class VoidGameEventListener : BaseGameEventListener<Core.Void, VoidGameEvent, VoidUnityEvent> { }
}