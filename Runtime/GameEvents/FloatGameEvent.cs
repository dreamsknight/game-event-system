using Dream.GameEventSystem.Core;
using UnityEngine;

namespace Dream.GameEventSystem.GameEvents
{
    [CreateAssetMenu(fileName = "New Float Event", menuName = "Game Events/Float Event")]
    public class FloatGameEvent : BaseGameEvent<float>
    {
    }
}