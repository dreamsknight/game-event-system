using Dream.GameEventSystem.Core;
using Dream.GameEventSystem.GameEvents;
using Dream.GameEventSystem.UnityEvents;
using UnityEngine;

namespace Dream.GameEventSystem.Listeners
{
    public class GameObjectGameEventListener : BaseGameEventListener<GameObject, GameObjectGameEvent, GameObjectUnityEvent> { }
}