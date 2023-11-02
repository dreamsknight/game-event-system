using Dream.GameEventSystem.Core;
using UnityEngine;

namespace Dream.GameEventSystem.GameEvents
{
    [CreateAssetMenu(fileName = "New Transform Event", menuName = "Game Events/Transform Event")]
    public class TransformGameEvent : BaseGameEvent<Transform>
    {
    }
}