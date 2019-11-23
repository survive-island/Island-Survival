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

    
This is adapted from: http://wiki.unity3d.com/index.php?title=CreateScriptableObjectAsset to fit the intantory system

*/

using UnityEngine;

[CreateAssetMenu(menuName = "Invantory Object")]
public class InvantoryObject : ScriptableObject
{
    

    public GameObject objectPrefab;
    public Sprite objectImage;
    public int quantity = 0;
    public InvantoryItemLogic itemLogic;
    public string objectTooltip;

}