using UnityEngine.Events;

namespace UCF.Core.Common
{
    public static class UCFEvents
    {
        public static UnityEvent TestEvent1 = new UnityEvent();
        public static UnityEvent<int> TestEvent2 = new UnityEvent<int>();
        public static UnityEvent<int,string> TestEvent3 = new UnityEvent<int, string>();
        public static UnityEvent<int, string, bool> TestEvent4 = new UnityEvent<int, string, bool>();
    }
}
