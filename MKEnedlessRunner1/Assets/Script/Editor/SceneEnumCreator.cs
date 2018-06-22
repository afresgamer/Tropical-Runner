using UnityEditor;
using UnityEngine;
using System.Collections.Generic;

public class SceneEnumCreator : EditorWindow {

    //このWindowの本体
    static SceneEnumCreator window;
    //Enumを作るスクリプト
    private MonoScript AttachScript;
    //Scene名
    static List<SceneAsset> sceneList = new List<SceneAsset>();
    private SceneAsset[] sceneAssets = null;
    int count = 0;
    static List<string> sceneNameList = new List<string>();
    private static string sceneName = "";
    const string SceneEnumName = "Scenes";
 
    [MenuItem("Tools/SceneName")]
    private static void WindowCreate()
    {
        // Windowを表示
        window =  GetWindow<SceneEnumCreator>("SceneName");
        window.maxSize = window.minSize = new Vector2(320, 320);
        window.Show();
    }

    private void OnGUI()
    {
        EditorGUILayout.LabelField("Enumを作るためのスクリプトをアタッチして");
        AttachScript = EditorGUILayout.ObjectField(AttachScript, typeof(MonoScript), true) as MonoScript;
        
        count = EditorGUILayout.IntField("Scene数を入力して下さい", count);
        
        if (count > 0)
        {
            if (GUILayout.Button("ボタンを押すとScene数を設定できます"))
            {
                sceneAssets = new SceneAsset[count];
            }
            if(sceneAssets != null)
            {
                if (sceneAssets.Length > 0)
                {
                    EditorGUILayout.LabelField("Sceneオブジェクトをアタッチして下さい");
                    for (int i = 0; i < count; i++)
                    {
                        sceneAssets[i] = EditorGUILayout.ObjectField(sceneAssets[i], typeof(SceneAsset), true) as SceneAsset;
                    }
                    if (sceneAssets != null)
                    {
                        EditorGUILayout.LabelField("ボタンを押すとScene名を保存します。");
                        if (GUILayout.Button("SceneName Saveing"))
                        {
                            foreach (var sceneAsset in sceneAssets)
                            {
                                sceneList.Add(sceneAsset);
                            }
                        }
                    }
                }
            }
        }

        EditorGUILayout.LabelField("ボタンを押すとEnumを生成します");
        bool isCreate = GUILayout.Button("Scece Writing");

        if (isCreate && AttachScript != null && sceneList != null)
        {
            foreach(var scene in sceneList)
            {
                sceneNameList.Add(scene.name);
            }
            //記述します
            string AttachPath = AssetDatabase.GetAssetPath(AttachScript);
            EnumCreate(SceneEnumName, AttachScript.name, AttachPath, sceneNameList, true);

            Debug.Log(AttachScript.name + "保存しました");
            //Window閉じます
            window.Close();
        }
        else if(isCreate && (AttachScript == null || sceneList == null))
        { Debug.LogWarning("情報が不足しています"); }
    }

    /// <summary>
    /// Enumにするための関数
    /// </summary>
    /// <param name="enumName"></param>
    /// <param name="ScriptName"></param>
    /// <param name="path"></param>
    /// <param name="sceneList"></param>
    /// <param name="isSingleton"></param>
    public static void EnumCreate(string enumName, string ScriptName , string path, List<string> sceneList , bool isSingleton)
    {
        //コード全文をリセット
        sceneName = "";

        //名前空間やクラス名を記述(ここでシングルトンクラスかどうかで処理を分ける)
        if (!isSingleton)
        {
            sceneName += "using UnityEngine;\n";
            sceneName += "using System.Collections.Generic;\n";
            sceneName += "\n";
            sceneName += "public class " + ScriptName + ": MonoBehaviour {\n";
        }
        else
        {
            sceneName += "using UnityEngine;\n";
            sceneName += "using System.Collections.Generic;\n";
            sceneName += "\n";
            sceneName += "public class " + ScriptName + ": SingletonMonoBehaviour<" + ScriptName + ">{\n";
        }
        

        //enum名を設定
        sceneName += "      public enum " + enumName + " { ";
        
        if(sceneList.Count > 0)
        {
            for (int i = 0; i < sceneList.Count; i++)
            {
                if (i == sceneList.Count - 1) sceneName += sceneList[i];
                else { sceneName += sceneList[i] + " , "; }
            }
            sceneName += "  }\n";
        }
        else { sceneName += "}\n"; }

        //全ての記述を閉じる
        sceneName += "}\n";

        //記述する
        System.IO.File.WriteAllText(path, sceneName, System.Text.Encoding.UTF8);
        AssetDatabase.Refresh(ImportAssetOptions.ImportRecursive);
        //リストの初期化
        sceneNameList.Clear();
    }
}
