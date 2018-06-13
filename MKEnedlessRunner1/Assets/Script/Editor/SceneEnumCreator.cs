using UnityEditor;
using UnityEngine;

public class SceneEnumCreator : EditorWindow {
    
    [MenuItem("Window/SceneName")]
    public static void WindowCreate()
    {
        // Windowを表示
        var window =  GetWindow<SceneEnumCreator>("SceneName");
        window.minSize = new Vector2(320, 320);
    }

    private void OnGUI()
    {
        EditorGUILayout.LabelField("Scene");
        //アタッチ出来るUI作成
        EditorGUILayout.ObjectField(null, typeof(UnityEngine.SceneManagement.Scene), false);
    }
}
