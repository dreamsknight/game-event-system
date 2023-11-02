using Dream.GameEventSystem.Core;
using UnityEngine;

namespace Dream.GameEventSystem.GameEvents
{
    [CreateAssetMenu(fileName = "New String Event", menuName = "Game Events/String Event")]
    public class StringGameEvent : BaseGameEvent<string>
    {
    }
}