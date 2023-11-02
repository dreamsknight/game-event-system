using System.IO;
using UnityEditor;
using UnityEngine;

namespace Dream.GameEventSystem.Core
{
    public class GameEventScriptGenerator : EditorWindow
    {
        private string typeName = "";
        
        [MenuItem("Tools/Game Event Script Generator")]
        public static void ShowWindow()
        {
            GetWindow<GameEventScriptGenerator>("Game Event Script Generator");
        }

        void OnGUI()
        {
            GUILayout.Label("Create New Game Event Scripts", EditorStyles.boldLabel);
            typeName = EditorGUILayout.TextField("Type Name", typeName);

            if (GUILayout.Button("Generate Game Event Scripts"))
            {
                GenerateEventScripts(CapitalizeFirstLetter(typeName));
            }
        }

        private void GenerateEventScripts(string typeName)
        {
            var cSharpTypeName = MapToCSharpType(typeName);

            var folderPath = "Assets/DreamGameEventSystem/";
            var gameEventsFolder = folderPath + "GameEvents/";
            var unityEventsFolder = folderPath + "UnityEvents/";
            var listenersFolder = folderPath + "Listeners/";

            // Paths for the generated scripts
            var gameEventFilePath = gameEventsFolder + typeName + "GameEvent.cs";
            var unityEventFilePath = unityEventsFolder + typeName + "UnityEvent.cs";
            var listenerFilePath = listenersFolder + typeName + "GameEventListener.cs";

            // Check if any of the files already exist
            if (File.Exists(gameEventFilePath) || File.Exists(unityEventFilePath) || File.Exists(listenerFilePath))
            {
                EditorUtility.DisplayDialog("Error", $"Files for {typeName} already exist! Generation aborted.", "OK");
                return; // Exit without generating scripts
            }

            CreateDirectoryIfNotExists(gameEventsFolder);
            CreateDirectoryIfNotExists(unityEventsFolder);
            CreateDirectoryIfNotExists(listenersFolder);

            File.WriteAllText(gameEventFilePath, GenerateGameEventScript(typeName, cSharpTypeName));
            File.WriteAllText(unityEventFilePath, GenerateUnityEventScript(typeName, cSharpTypeName));
            File.WriteAllText(listenerFilePath, GenerateEventListenerScript(typeName, cSharpTypeName));

            AssetDatabase.Refresh();
            EditorUtility.DisplayDialog("Success", "Event scripts generated for type: " + typeName, "OK");
        }


        private static string MapToCSharpType(string typeName)
        {
            switch (typeName)
            {
                case "Int": return "int";
                case "Float": return "float";
                case "String": return "string";
                case "Bool" : return "bool";
                // Add more predefined mappings as needed
                default: return typeName; // For custom class names
            }
        }

        private static void CreateDirectoryIfNotExists(string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }
        private string CapitalizeFirstLetter(string input)
        {
            if (string.IsNullOrEmpty(input))
                return input;

            return char.ToUpper(input[0]) + input.Substring(1);
        }      
        
        private static string GenerateGameEventScript(string typeName, string cSharpTypeName)
        {
            return
                $@"using UnityEngine;

namespace DreamGameEventSystem
{{
    [CreateAssetMenu(fileName = ""New {typeName} Event"", menuName = ""Game Events/{typeName} Event"")]
    public class {typeName}GameEvent : BaseGameEvent<{cSharpTypeName}> {{}}
}}";
        }

        private static string GenerateUnityEventScript(string typeName, string cSharpTypeName)
        {
            return
                $@"using UnityEngine.Events;

namespace DreamGameEventSystem
{{
    [System.Serializable]
    public class {typeName}UnityEvent : UnityEvent<{cSharpTypeName}> {{ }}
}}";
        }

        private static string GenerateEventListenerScript(string typeName, string cSharpTypeName)
        {
            return
                

                $@"namespace DreamGameEventSystem
{{
    public class {typeName}GameEventListener : BaseGameEventListener<{cSharpTypeName}, {typeName}GameEvent, {typeName}UnityEvent> {{ }}
}}";
        }

    }
}