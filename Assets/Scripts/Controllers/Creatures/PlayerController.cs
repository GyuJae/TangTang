using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Vector2 _moveDir = Vector2.zero;
    float _speed = 5f;
    
    void Start()
    {
        
    }

    void Update()
    {
        HandleInput();
        Move();
    }

    void HandleInput()
    {
        // 매 프레임마다 초기화
        _moveDir = Vector2.zero;
        
        if (Input.GetKey(KeyCode.W))
        {
            _moveDir += Vector2.up;
        } 
        else if (Input.GetKey(KeyCode.S))
        {
            _moveDir += Vector2.down;
        } 
        else if (Input.GetKey(KeyCode.A))
        {
            _moveDir += Vector2.left;
        } 
        else if (Input.GetKey(KeyCode.D))
        {
            _moveDir += Vector2.right;
        }
        
        // 대각선 이동 속도 균등화
        if (_moveDir.magnitude > 1)
            _moveDir.Normalize();
    }
    
    void Move()
    {
        transform.position += (Vector3)_moveDir * (_speed * Time.deltaTime);
    }
}
