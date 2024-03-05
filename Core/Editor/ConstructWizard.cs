using UnityEngine;
using UnityEditor;
using System.IO;

namespace UCF.Core.Editor
{
    public class ConstructWizard : EditorWindow
    {
        private string constructName;

        [MenuItem("UCF/Core/Create Construct")]
        static void Init()
        {
            ConstructWizard window = (ConstructWizard)EditorWindow.GetWindow(typeof(ConstructWizard));
            window.Show();
        }

        void OnGUI()
        {
            GUILayout.Label("Create Construct", EditorStyles.boldLabel);

            GUILayout.Space(10);

            GUILayout.Label("Enter Construct Name:");
            constructName = EditorGUILayout.TextField(constructName);

            GUILayout.Space(10);

            if (GUILayout.Button("Create"))
            {
                if (!string.IsNullOrEmpty(constructName))
                {
                    CreateConstructFolderStructure();
                    Close();
                }
                else
                {
                    Debug.LogError("Please enter a valid construct name.");
                }
            }
        }

        private void CreateConstructFolderStructure()
        {
            string constructsPath = "Assets/UnityConstructFramework/_Constructs";
            string constructFolderPath = Path.Combine(constructsPath, constructName);

            // Create the main construct folder
            if (!AssetDatabase.IsValidFolder(constructFolderPath))
            {
                AssetDatabase.CreateFolder(constructsPath, constructName);
            }

            // Create subfolders
            CreateSubfolder(constructFolderPath, "Code");
            CreateSubfolder(constructFolderPath, "Models");
            CreateSubfolder(constructFolderPath, "Materials");
            CreateSubfolder(constructFolderPath, "Shaders");
            CreateSubfolder(constructFolderPath, "Prefabs");
            CreateSubfolder(constructFolderPath, "Textures");
            CreateSubfolder(constructFolderPath, "Animations");
            CreateSubfolder(constructFolderPath, "Settings");
            CreateSubfolder(constructFolderPath, "Scenes");
            CreateSubfolder(constructFolderPath, "Tests");

            // Create Assembly Definition file
            CreateAssemblyDefinitionFile(constructFolderPath);

            // Refresh the AssetDatabase to reflect changes
            AssetDatabase.Refresh();
        }

        private void CreateSubfolder(string parentFolder, string folderName)
        {
            string subfolderPath = Path.Combine(parentFolder, folderName);
            if (!AssetDatabase.IsValidFolder(subfolderPath))
            {
                AssetDatabase.CreateFolder(parentFolder, folderName);
            }
        }

        private void CreateAssemblyDefinitionFile(string folderPath)
        {
            string asmdefFileName = $"{constructName}.asmdef";
            string asmdefFilePath = Path.Combine(folderPath, asmdefFileName);

            if (!File.Exists(asmdefFilePath))
            {
                using (StreamWriter writer = new StreamWriter(asmdefFilePath))
                {
                    writer.WriteLine("{");
                    writer.WriteLine("  \"name\": \"" + constructName + "\",");
                    writer.WriteLine("  \"rootNamespace\": \"TheSkywatchers.Constructs." + constructName + "\",");
                    writer.WriteLine("  \"references\": [],");
                    writer.WriteLine("  \"includePlatforms\": [],");
                    writer.WriteLine("  \"excludePlatforms\": [],");
                    writer.WriteLine("  \"allowUnsafeCode\": false,");
                    writer.WriteLine("  \"overrideReferences\": false,");
                    writer.WriteLine("  \"precompiledReferences\": [],");
                    writer.WriteLine("  \"autoReferenced\": true,");
                    writer.WriteLine("  \"defineConstraints\": [],");
                    writer.WriteLine("  \"versionDefines\": []");
                    writer.WriteLine("}");
                }
            }
        }
    }
}
