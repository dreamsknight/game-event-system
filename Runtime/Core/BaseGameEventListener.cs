using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Events;

namespace Dream.GameEventSystem.Core
{
    public abstract class BaseGameEventListener<T, E, UER> : MonoBehaviour, IGameEventListener<T>
        where E : BaseGameEvent<T> where UER : UnityEvent<T>
    {
        private enum EventRegisterFunctions
        {
            EnableDisable,
            StartDestroy
        }

        [SerializeField] private E gameEvent;
        [SerializeField] private UER unityEventResponse;

        [EnumToggleButtons] [SerializeField]
        private EventRegisterFunctions eventRegisterFunctions = EventRegisterFunctions.EnableDisable;

        public E GameEvent
        {
            get => gameEvent;
            set => gameEvent = value;
        }

        private void Start()
        {
            if (eventRegisterFunctions != EventRegisterFunctions.StartDestroy)
            {
                return;
            }

            RegisterToGameEvent();
        }

        private void OnDestroy()
        {
            if (eventRegisterFunctions != EventRegisterFunctions.StartDestroy)
            {
                return;
            }

            UnregisterFromGameEvent();
        }

        private void OnEnable()
        {
            if (eventRegisterFunctions != EventRegisterFunctions.EnableDisable)
            {
                return;
            }

            RegisterToGameEvent();
        }

        private void OnDisable()
        {
            if (eventRegisterFunctions != EventRegisterFunctions.EnableDisable)
            {
                return;
            }

            UnregisterFromGameEvent();
        }

        public void RegisterToGameEvent()
        {
            if (GameEvent != null)
            {
                GameEvent.RegisterListener(this);
            }
        }

        public void UnregisterFromGameEvent()
        {
            if (GameEvent != null)
            {
                GameEvent.UnregisterListener(this);
            }
        }


        public void OnEventRaised(T item)
        {
            if (unityEventResponse != null)
            {
                unityEventResponse.Invoke(item);
            }
        }
    }
}