using Dream.GameEventSystem.Core;
using UnityEngine;

namespace Dream.GameEventSystem.GameEvents
{
    [CreateAssetMenu(fileName = "New Int Event", menuName = "Game Events/Int Event")]
    public class IntGameEvent : BaseGameEvent<int>
    {
    }
}