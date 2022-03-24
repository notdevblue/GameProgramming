using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager
{
	private static CharacterManager _instance = null;
	private GameObject _player = null;

	// 생성자
	private CharacterManager() { }
	// 인스턴스 얻기
	public static CharacterManager Instance
	{
		get
		{
			if (null == _instance) { _instance = new CharacterManager(); }
			return _instance;
		}
	}

	// 플레이어 얻기
	public GameObject Player { get { return _player; } }

	// 플레이어 스폰처리
	public void SpawnPlayer(string InPath, Vector3 InPos, Quaternion InRot)
	{
		if (null != _player)
		{
			return;
		}

		Object loadObj = Resources.Load(CutResourcePath(InPath));
		Debug.Log(loadObj);
		if (null != loadObj)
		{
			_player = Object.Instantiate(loadObj, InPos, InRot) as GameObject;
			if (null != _player)
			{
				MyCamera[] allCams = Object.FindObjectsOfType<MyCamera>();
				if (0 < allCams.Length)
				{
					allCams[0].TargetObj = _player;
				}

				_player.AddComponent<PartsControl>();
			}
			else
			{
				Debug.Log("A");
			}
		}
		else
		{
         Debug.Log(CutResourcePath(InPath));
      }
	}

	// 디스폰 플레이어
	public void DespawnPlayer()
	{
		if (null == _player)
		{
			return;
		}

		GameObject.Destroy(_player);
		_player = null;

		MyCamera[] allCams = Object.FindObjectsOfType<MyCamera>();
		if (0 < allCams.Length)
		{
			allCams[0].TargetObj = null;
		}
	}

	static public string CutResourcePath(string InPath)
   {
      const string prefix = "Assets/Resources/";
      const string postfix = ".prefab";
      if (true == InPath.StartsWith(prefix))
      {
         InPath = InPath.Substring(prefix.Length);
      }
      if (true == InPath.EndsWith(postfix))
      {
         InPath = InPath.Substring(0, InPath.Length - postfix.Length);
      }

      return InPath;
   }
}
