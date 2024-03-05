using UnityEngine;

namespace UCF.Core.Common
{
    public static class UCFUtilities
    {
        public static bool Contains(this LayerMask mask, int layer)
        {
            return mask == (mask | (1 << layer));
        }
    }
}