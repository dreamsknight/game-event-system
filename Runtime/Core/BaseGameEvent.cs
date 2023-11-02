using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Dream.GameEventSystem.Core
{
    public abstract class BaseGameEvent<T> : SerializedScriptableObject
    {
        [ShowInInspector,ReadOnly] private readonly List<IGameEventListener<T>> eventListeners = new List<IGameEventListener<T>>();

        [SerializeField][TextArea]
        private string description;
        [SerializeField]
        protected T debugValue;
        public void Raise(T gameEvent)
        {
            for (int i = eventListeners.Count-1; i >= 0; i--)
            {
                eventListeners[i].OnEventRaised(gameEvent);
            }
        }    
        public void RegisterListener(IGameEventListener<T> listener)
        {
            if (!eventListeners.Contains(listener))
            {
                eventListeners.Add(listener);
            }
        
        }

        public void UnregisterListener(IGameEventListener<T> listener)
        {
            if (eventListeners.Contains(listener))
            {
                eventListeners.Remove(listener);
            }   
        }
        
        [Button("Fire Event (Debug)",ButtonSizes.Large), GUIColor(0, 1, 0)]
        private void DebugFireEvent()
        {
            Raise(debugValue);
        }
    }
}