using System.Collections.Generic;
using UCF.Core.Data;
using UnityEngine;
using UnityEngine.Events;

namespace UCF.Core.Common
{
    public class UCFBehaviour : MonoBehaviour
    {
        private List<UnityEventBase> eventListeners = new List<UnityEventBase>();

        protected void SetLink(EventLink eventLink)
        {
            eventListeners.Add(eventLink.UnityEvent);
            eventLink.UnityEvent.AddListener(new UnityAction(eventLink.Action));
        }

        protected void SetLink<T>(EventLink<T> eventLink)
        {
            eventListeners.Add(eventLink.UnityEvent);
            eventLink.UnityEvent.AddListener(new UnityAction<T>(eventLink.Action));
        }

        protected void SetLink<T1,T2>(EventLink<T1, T2> eventLink)
        {
            eventListeners.Add(eventLink.UnityEvent);
            eventLink.UnityEvent.AddListener(new UnityAction<T1, T2>(eventLink.Action));
        }

        protected void SetLink<T1, T2, T3>(EventLink<T1, T2, T3> eventLink)
        {
            eventListeners.Add(eventLink.UnityEvent);
            eventLink.UnityEvent.AddListener(new UnityAction<T1, T2, T3>(eventLink.Action));
        }

        protected void SetLinks<T>(params EventLink<T>[] eventLinks)
        {
            foreach (var eventLink in eventLinks)
            {
                SetLink(eventLink);
            }
        }

        protected void SetLinks(params EventLink[] eventLinks)
        {
            foreach (var eventLink in eventLinks)
            {
                SetLink(eventLink);
            }
        }

        private void OnEnable()
        {
            foreach (var listener in eventListeners)
            {
                if (listener != null)
                {
                    (listener as UnityEvent)?.RemoveAllListeners();
                }
            }
        }

        private void OnDisable()
        {
            foreach (var listener in eventListeners)
            {
                if (listener != null)
                {
                    (listener as UnityEvent)?.RemoveAllListeners();
                }
            }
        }
    }
}
