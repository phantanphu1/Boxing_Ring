using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField]
    private Animator _animator;
    [SerializeField]
    private Player _player;
#if UNITY_EDITOR
    private void OnValidate()
    {
        _animator = GetComponent<Animator>();
        _player = GetComponent<Player>();
    }
#endif


    void Start()
    {

        if (_animator == null)
        {
            // throw new Exception();
            Debug.LogError("k co animator");
            return;
        }
        if (_player == null)
        {
            Debug.LogError("k co _player");
            return;
        }
    }
    public void HandleHeadPunch()
    {
        _animator.SetTrigger("HeadPunch");
        //danh bang 2 tay vao dau
        _player.TakeDamge(15);
    }
    private void HandleKidneyPunchLeft()
    {
        _animator.SetTrigger("KidneyPunchLeft");
        // danh vao dau tay trai 1 cai
        _player.TakeDamge(10);

    }

    private void HandleKidneyPunchRight()
    {
        _animator.SetTrigger("KidneyPunchRight");
        // danh vao dau tay phai 1 cai
        _player.TakeDamge(10);

    }
    public void HandleKnockedOut()
    {
        _animator.SetTrigger("KnockedOut");
        // nga nguoi xuong san

    }
    public void HandleStomachPunch()
    {
        _animator.SetTrigger("StomachPunch");
        // buoc len dam tay trai duoi cam
        _player.TakeDamge(20);

    }
    public void HandleStomachHit()
    {
        _animator.SetTrigger("StomachHit");
        // cui dau ne don
    }
    public void HandleVictory()
    {
        _animator.SetTrigger("Victory");
    }
    public void RandomPunch()
    {

        int index = UnityEngine.Random.Range(0, 2);
        Debug.Log($"index:{index}");
        if (index == 0)
        {
            HandleKidneyPunchLeft();
        }
        else
        {
            HandleKidneyPunchRight();
        }
    }
}
