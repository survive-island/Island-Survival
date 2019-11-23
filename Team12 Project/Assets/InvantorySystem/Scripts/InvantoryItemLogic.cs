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

public enum LogicType
{
    Spawn,
    Other
}

[System.Serializable]
public class InvantoryItemLogic
{
    public LogicType logicType;
    public string name;

    public void UseItem(Transform tf, InvantoryObject invantoryObject)
    {
        switch (logicType)
        {
            case LogicType.Spawn:
                Object.Instantiate(invantoryObject.objectPrefab, tf.position + (tf.forward * 2), Quaternion.identity);
                break;
            case LogicType.Other:
                invantoryObject.objectPrefab.GetComponent<RuntimeInvantoryLogic>().Use(tf.gameObject);
                break;
            default:
                break;
        }
    }
}