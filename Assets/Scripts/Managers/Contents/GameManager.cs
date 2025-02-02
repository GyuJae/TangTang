
using System;
using UnityEngine;

public class GameManager
{
    private Vector2 _moveDir;
    public Vector2 MoveDir
    {
        get { return _moveDir; }
        set
        {
            _moveDir = value;
            OnMoveDirChanged?.Invoke(value);
        }
    }
    
    public event Action<Vector2> OnMoveDirChanged;
}