using System.Collections;
using System.Collections.Generic;
using UCF.Core.ScriptableObjects;
using UnityEditor;
using UnityEngine;

namespace UCF.Core.Editor
{
    public static class UCFEditorFunctions
    {
        public static UCFSettings GetSettings()
        {
            // Find UCFSettings asset in the project
            string[] guids = AssetDatabase.FindAssets("t:UCFSettings"); // Search for assets of type UCFSettings
            string settingsPath = null;

            // Check if UCFSettings is found
            if (guids.Length > 0)
            {
                settingsPath = AssetDatabase.GUIDToAssetPath(guids[0]); // Get the path of the first found instance
            }
            else
            {
                Debug.LogError("UCFSettings not found. Please create UCFSettings asset.");
                return null;
            }

            // Access UCFSettings asset
            UCFSettings settings = AssetDatabase.LoadAssetAtPath<UCFSettings>(settingsPath);

            // Check if UCFSettings asset is loaded successfully
            if (settings == null)
            {
                Debug.LogError("UCFSettings asset found, but failed to load.");
                return null;
            }

            return settings;
        }
    }
}
