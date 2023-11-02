using Dream.GameEventSystem.Core;
using UnityEngine;

namespace Dream.GameEventSystem.GameEvents
{
    [CreateAssetMenu(fileName = "New Void Event", menuName = "Game Events/Void Event")]
    public class VoidGameEvent : BaseGameEvent<Void>
    {
        public void Raise() => Raise(new Void());
    }
}