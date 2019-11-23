/*
    This is adapted from: http://wiki.unity3d.com/index.php?title=CreateScriptableObjectAsset
*/
using System.IO;
using UnityEditor;
using UnityEngine;

public static class ScriptableObjectUtility
{
    /// <summary>
    //	This makes it easy to create, name and place unique new ScriptableObject asset files.
    /// </summary>
    public static T CreateAsset<T>() where T : ScriptableObject
    {
        T asset = ScriptableObject.CreateInstance<T>();

        string path = AssetDatabase.GetAssetPath(Selection.activeObject);
        if (path == "")
        {
            path = "Assets/InvantorySystem/Resources/InvantoryItems";
        }
        else if (Path.GetExtension(path) != "")
        {
            path = path.Replace(Path.GetFileName(AssetDatabase.GetAssetPath(Selection.activeObject)), "");
        }

        string assetPathAndName = AssetDatabase.GenerateUniqueAssetPath(path + "/" + typeof(T).ToString() + ".asset");

        AssetDatabase.CreateAsset(asset, assetPathAndName);

        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
        EditorUtility.FocusProjectWindow();

        return asset;
    }

    
}
public static class ScriptableObjectClasses{
    public static InvantoryObject CreateInvantoryAsset()
    {
        InvantoryObject io = ScriptableObjectUtility.CreateAsset<InvantoryObject>();
        io.itemLogic.name = io.name;
        return io;
    }
}