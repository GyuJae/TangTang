using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Vector2 _moveDir = Vector2.zero;
    float _speed = 5f;
    
    void Start()
    {
        Managers.Game.OnMoveDirChanged -= HandleOnMoveDirChanged;
        Managers.Game.OnMoveDirChanged += HandleOnMoveDirChanged;
        
    }

    void HandleOnMoveDirChanged(Vector2 dir)
    {
        _moveDir = dir;
    }

    void Update()
    {
        transform.Translate(_moveDir * Time.deltaTime * _speed);
    }
}
