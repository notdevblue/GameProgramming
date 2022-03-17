using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartsControl : MonoBehaviour
{
    public enum PartType
    {
        HEAD,
        BODY,
        HANDS,
        LEGS,
        FOOTS,
        MAX
    }

    private GameObject[] _parts = new GameObject[(int)PartType.MAX];

    public void EquipPart(PartType partType, string path) {
        if(partType == PartType.MAX) {
            return;
        }

        UnequipPart(partType);

        const string prefix = "Assets/Resources";
        const string postfix = ".prefab";

        if(path.StartsWith(prefix)) {
            path = path.Substring(prefix.Length);
        }

        if(path.EndsWith(postfix)) {
            path = path.Substring(0, path.Length - postfix.Length);
        }

        Object loadObj = Resources.Load(path);
        if(null != loadObj) {
            GameObject instObj = Instantiate(loadObj) as GameObject;

            if(null == instObj) {
                _parts[(int)partType] = instObj;
                RemappingBones(instObj);
                instObj.transform.parent = gameObject.transform;
            }
        }
    }

    public void UnequipPart(PartType partType) {
        if(partType == PartType.MAX || _parts[(int)partType] == null) {
            return;
        }

        GameObject.Destroy(_parts[(int)partType]);
    }

    public void RemappingBones(GameObject target) {
        var meshRenderer = gameObject.GetComponentInChildren<SkinnedMeshRenderer>();
        if(meshRenderer == null) {
            return;
        }

        Transform[] children = gameObject.transform.GetComponentsInChildren<Transform>(true);

        SkinnedMeshRenderer[] newRenderers = target.GetComponentsInChildren<SkinnedMeshRenderer>();
        foreach(var renderer in newRenderers) {
            Transform[] newBones = new Transform[renderer.bones.Length];
            for (int i = 0; i < renderer.bones.Length; ++i) {
                newBones[i] = System.Array.Find<Transform>(children, c => c.name == renderer.bones[i].name);
            }

            renderer.bones = newBones;
            renderer.rootBone = meshRenderer.rootBone;
        }
    }
}
