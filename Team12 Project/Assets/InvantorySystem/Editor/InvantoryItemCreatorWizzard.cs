/*
Copyright 2016 Frederic Babord

Licensed under the Apache License, Version 2.0 (the "License");
you may not use this file except in compliance with the License.
You may obtain a copy of the License at

    http://www.apache.org/licenses/LICENSE-2.0

Unless required by applicable law or agreed to in writing, software
distributed under the License is distributed on an "AS IS" BASIS,
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
See the License for the specific language governing permissions and
limitations under the License.

*/
using UnityEngine;
using UnityEditor;
using Object = UnityEngine.Object;

public class InvantoryItemCreatorWizzard : ScriptableWizard
{

    public Sprite objectImage = null;
    public GameObject objectToPrefab = null;
    public InvantoryItemLogic itemLogic = new InvantoryItemLogic();
    public string objectTooltip;

    [MenuItem("Tools/Freddie Babord/Invantory System/Create New Invantory Asset")]
    static void CreateWindow()
    {
        // Creates the wizard for display
        ScriptableWizard.DisplayWizard("Create An Invantory Object",
            typeof(InvantoryItemCreatorWizzard),
            "Create!");
    }

    void OnWizardUpdate()
    {
        helpString = "Creates an Invantory Asset, Its Prefab from the Scene and links everything together";
        if (!objectImage || !objectToPrefab || itemLogic.name == "")
        {
            errorString = "Please assign an object from the scene, an object image or name the object!";
            isValid = false;
        }
        else {
            errorString = "";
            isValid = true;
        }
    }

    void OnWizardCreate()
    {
        InvantoryObject io = ScriptableObjectClasses.CreateInvantoryAsset();
        io.objectImage = objectImage;
        io.objectTooltip = objectTooltip;
        objectToPrefab.name = itemLogic.name;
        AssetDatabase.RenameAsset("Assets/InvantorySystem/Resources/InvantoryItems/InvantoryObject.asset",
            itemLogic.name);
        if (!objectToPrefab.GetComponent<CollectableObject>())
        {
            var co = objectToPrefab.AddComponent<CollectableObject>();
            co.objectRefrence = io;
            co.quantity = 1;
        }
        else
            objectToPrefab.GetComponent<CollectableObject>().objectRefrence = io;
        var cols = objectToPrefab.GetComponents<SphereCollider>();
        bool hasTriggerCollider = false;
        for (var i = 0; i < cols.Length; i++)
        {
            if (cols[i].isTrigger)
            {
                hasTriggerCollider = true;
            }
        }
        if(!hasTriggerCollider)
        {
            var co = objectToPrefab.AddComponent<SphereCollider>();
            co.isTrigger = true;
        }

        GameObject igo = CreatePrefab(objectToPrefab);
        Selection.activeObject = igo;
        io.objectPrefab = Resources.Load<GameObject>("InvantoryPrefabs/" + objectToPrefab.name);
        io.itemLogic = itemLogic;

        io.name = itemLogic.name;

        Vector3 pos = objectToPrefab.transform.position;
        Quaternion rot = objectToPrefab.transform.rotation;
        DestroyImmediate(objectToPrefab);
        GameObject go = (GameObject)PrefabUtility.InstantiatePrefab(igo);
        go.transform.position = pos;
        go.transform.rotation = rot;
        Selection.activeObject = go;
        EditorGUIUtility.PingObject(go);

    }


    static GameObject CreatePrefab(GameObject existingObject)
    {
        GameObject obj = existingObject ? existingObject : Selection.activeGameObject;
        string name = obj.name;

        Object prefab = PrefabUtility.CreateEmptyPrefab("Assets/InvantorySystem/Resources/InvantoryPrefabs/" + name + ".prefab");
        GameObject pf = PrefabUtility.ReplacePrefab(obj, prefab);
        AssetDatabase.Refresh();
        return pf;
    }
}
