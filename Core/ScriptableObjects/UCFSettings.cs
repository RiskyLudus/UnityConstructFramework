using UnityEngine;

namespace UCF.Core.ScriptableObjects
{
    [CreateAssetMenu(fileName = "Data", menuName = "UCF/Create Settings", order = 1)]
    public class UCFSettings : ScriptableObject
    {
        public string RootNamespace = "UCF";
        public string PathToUCF = "Assets/UnityConstructFramework";
        public string PathToConstructs = "Assets/UnityConstructFramework/_Constructs";
    }
}
