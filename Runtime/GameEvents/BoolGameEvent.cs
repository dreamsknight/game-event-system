using Dream.GameEventSystem.Core;
using UnityEngine;

namespace Dream.GameEventSystem.GameEvents
{
    [CreateAssetMenu(fileName = "New Bool Event", menuName = "Game Events/Bool Event")]
    public class BoolGameEvent : BaseGameEvent<bool> { }
}