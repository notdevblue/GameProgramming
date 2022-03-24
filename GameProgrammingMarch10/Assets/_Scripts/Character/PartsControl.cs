using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartsControl : MonoBehaviour
{
	// ÆÄÃ÷ Å¸ÀÔ
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

	// ÆÄÃ÷ ÀåÂø
	public void EquipPart(PartType InType, string InPath)
	{
		if (PartType.MAX == InType)
		{
			return;
		}

		UnequipPart(InType);

		Object loadObj = Resources.Load(CharacterManager.CutResourcePath(InPath));
		if (null != loadObj)
		{
			GameObject instObj = Instantiate(loadObj) as GameObject;
			if (null != instObj)
			{
				_parts[(int)InType] = instObj;
				RemappingBones(instObj);
				instObj.transform.parent = gameObject.transform;
			}
		}
	}

	// ÆÄÃ÷ ÀåÂø ÇØÁ¦
	public void UnequipPart(PartType InType)
	{
		if (PartType.MAX == InType || null == _parts[(int)InType])
		{
			return;
		}

		GameObject.Destroy(_parts[(int)InType]);
		_parts[(int)InType] = null;
	}

	// º» ¸®¸ÊÇÎ
	public void RemappingBones(GameObject InTargetObj)
	{
		var meshRenderer = gameObject.GetComponentInChildren<SkinnedMeshRenderer>();
		if (null == meshRenderer)
		{
			return;
		}

		Transform[] children = gameObject.transform.GetComponentsInChildren<Transform>(true);

		SkinnedMeshRenderer[] newRenderers = InTargetObj.GetComponentsInChildren<SkinnedMeshRenderer>();
		foreach (SkinnedMeshRenderer renderer in newRenderers)
		{
			Transform[] newBones = new Transform[renderer.bones.Length];
			for (int i = 0; i < renderer.bones.Length; i++)
			{
				newBones[i] = System.Array.Find<Transform>(children, c => c.name == renderer.bones[i].name);
			}
			renderer.bones = newBones;
			renderer.rootBone = meshRenderer.rootBone;
		}
	}
}
