using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Animator _animator;
    private int _sumTouch = 0;
    [SerializeField] private float _timeDelay = 0.3f;
    private float _lastTapTime = 0f; // Thời điểm của lần chạm gần nhất
    private bool _canProcessSingleTap = false;
    private bool _isDoubleTapping = false;
    [SerializeField]
    private PlayerAnimation _playerAnimation;
    [SerializeField] Player player;
    [SerializeField] Enemy enemy;
    private void Awake()
    {
        _animator = GetComponent<Animator>();

    }
    private void Update()
    {
        if (player.IsPlayer() || enemy.IsEnemy()) return;
        if (Input.GetMouseButtonDown(0))
        {
            float timeSinceLastTap = Time.time - _lastTapTime;

            if (timeSinceLastTap < _timeDelay)
            {
                _sumTouch++;
                if (_sumTouch == 2)
                {
                    _playerAnimation.HandleHeadPunch();
                    _sumTouch = 0;
                    _lastTapTime = 0f;
                    _canProcessSingleTap = false;
                    _isDoubleTapping = true;
                }
            }
            else
            {
                _sumTouch = 1;
                _lastTapTime = Time.time;
                _canProcessSingleTap = true;
                _isDoubleTapping = false;
            }
        }
        else if (Input.GetMouseButtonUp(0))
        {
            if (_isDoubleTapping)
            {
                _isDoubleTapping = false;
                return;
            }
        }

        if (_sumTouch == 1 && _canProcessSingleTap && (Time.time - _lastTapTime >= _timeDelay))
        {
            _playerAnimation.RandomPunch();
            _sumTouch = 0;
            _lastTapTime = 0f;
            _canProcessSingleTap = false;
        }
    }
    private void HandleTouch(Touch touch)
    {
        if (touch.phase == TouchPhase.Began)
        {
            if (Time.time - _lastTapTime < _timeDelay)
            {
                _sumTouch++;
            }
            else
            {
                _sumTouch = 1;
            }
            _lastTapTime = Time.time;
        }
        else if (touch.phase == TouchPhase.Ended)
        {
            if (_sumTouch == 1)
            {
                Debug.LogWarning("cham 1 lan");
            }
            else if (_sumTouch == 2)
            {
                Debug.LogWarning("cham 2 lan");
                _sumTouch = 0;
            }
        }
    }


}
