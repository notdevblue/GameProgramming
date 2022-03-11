using UnityEngine;

public static class Define
{
    private static Transform _player = null;
    public static Transform Player {
        get {
            if(_player == null) {
                _player = GameObject.FindGameObjectWithTag("Player").transform;
            }
            return _player;
        }
    }
}