using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class CheatWindow : EditorWindow
{
    private Vector3 _playerSpawnPos;
    // private 

    [MenuItem("Window/Cheat Window")]
    public static void ShowWindow() {
        EditorWindow.GetWindow(typeof(CheatWindow));
    }

    private void OnGUI() {
        GUILayout.Label("Charactor", EditorStyles.boldLabel);
        bool isOldWideMode = EditorGUIUtility.wideMode;
        EditorGUIUtility.wideMode = true;
        _playerSpawnPos = EditorGUILayout.Vector3Field("Player Position", _playerSpawnPos);
        EditorGUIUtility.wideMode = isOldWideMode;
        GUILayout.BeginHorizontal();
        GUILayout.FlexibleSpace();

        if(GUILayout.Button("Spawn", GUILayout.Width(100.0f), GUILayout.Height(30.0f))) {
            // Debug.LogFormat("다음 위치에 플레이어 생성 - {0}", _playerSpawnPos.ToString());

            // if(Application.isPlaying) {
            //     Object loadObj = Resources.Load("PT_Lowpoly_Medieval_Armors_Male_Moduar_Free_pack 1");
            //     if(null != loadObj) {
            //         GameObject instObj = Instantiate(loadObj, _playerSpawnPos, Quaternion.identity) as GameObject;
            //         if(null != instObj) {
            //             MyCamera[] allCams = FindObjectsOfType<MyCamera>();
            //             if(0 < allCams.Length) {
            //                 allCams[0]._targetObj = instObj;
            //             }
            //         }
            //     }
            // }

            CharactorManager.Instance.SpawnPlayer("PT_Lowpoly_Medieval_Armors_Male_Moduar_Free_pack 1", _playerSpawnPos, Quaternion.identity);
        }

        GUILayout.Space(10.0f);

        if(GUILayout.Button("Despawn", GUILayout.Width(100.0f), GUILayout.Height(30.0f))) {

            if(Application.isPlaying) {
                CharactorManager.Instance.DespawnPlayer();
            }
        }

        GUILayout.FlexibleSpace();
        GUILayout.EndHorizontal();

        EditorGUILayout.Separator();
        GUILayout.Label("Player Parts", EditorStyles.boldLabel);
        // _partType = (PartsControl.PartType)EditorGUILayout.EnumPopup("Part Type", _partType);


        // GUILayout.BeginHorizontal();
        // GUILayout.FlexibleSpace();
        // if(GUILayout.Button("Equip", GUILayout.Width(100.0f), GUILayout.Height(30.0f))) {
        //     if(Application.isPlaying && null != CharactorManager.Instance.Player) {
        //         PartsControl pCtrl = CharactorManager.Instance.Player.GetComponent<PartsControl>();
        //         if(null != pCtrl) {
        //             pCtrl.EquipPart(_partType, _partPath);
        //         }
        //     }
        // }

        // GUILayout.Space(10.0f);

        // if(GUILayout.Button("Unequip", GUILayout.Width(100.0f), GUILayout.Height(30.0f))) {
        //     if(Application.isPlaying && null != ) {

        //     }
        // }


    }
}
