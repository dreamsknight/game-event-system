using Dream.GameEventSystem.Core;
using UnityEngine;

namespace Dream.GameEventSystem.GameEvents
{
    [CreateAssetMenu(fileName = "New GameObject Event", menuName = "Game Events/GameObject Event")]
    public class GameObjectGameEvent : BaseGameEvent<GameObject>
    {
    }
}