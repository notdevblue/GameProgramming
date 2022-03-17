using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharactorManager
{
    private static CharactorManager _instance = null;
    private GameObject _player = null;

    private CharactorManager() { }
    public static CharactorManager Instance {
        get {
            if(_instance == null)
                _instance = new CharactorManager();
            
            return _instance;
        }
    }

    public void SpawnPlayer(string path, Vector3 pos, Quaternion rot) {
        if(_player != null) {
            return;
        }

        _player = Object.Instantiate(Resources.Load(path), pos, rot) as GameObject;
        MyCamera[] allCams = Object.FindObjectsOfType<MyCamera>();
        if (allCams.Length > 0) {
            allCams[0]._targetObj = _player;
        }

        _player.AddComponent<PartsControl>();
    }

    public void DespawnPlayer() {
        if(_player == null) {
            return;
        }

        GameObject.Destroy(_player);
        _player = null;

        MyCamera[] allCams = Object.FindObjectsOfType<MyCamera>();
        if(allCams.Length > 0) {
            allCams[0]._targetObj = null;
        }
    }
}
