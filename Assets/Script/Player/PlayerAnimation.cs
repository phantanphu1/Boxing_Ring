using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField]
    private Animator _animator;
#if UNITY_EDITOR
    private void OnValidate()
    {
        _animator = GetComponent<Animator>();
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
    }
    public void HandleHeadPunch()
    {
        _animator.SetTrigger("HeadPunch");
        AudioManager.Instance.PunchMusic();
        //danh bang 2 tay vao dau
    }
    private void HandleKidneyPunchLeft()
    {
        _animator.SetTrigger("KidneyPunchLeft");
        // danh vao dau tay trai 1 cai
    }

    private void HandleKidneyPunchRight()
    {
        _animator.SetTrigger("KidneyPunchRight");
        // danh vao dau tay phai 1 cai

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
        if (index == 0)
        {
            HandleKidneyPunchLeft();
            AudioManager.Instance.PunchMusic();

        }
        else
        {
            HandleKidneyPunchRight();
            AudioManager.Instance.PunchMusic();

        }
    }
}
