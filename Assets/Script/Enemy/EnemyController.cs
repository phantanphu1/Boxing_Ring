using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private float _startDelay = 0.5f;
    [SerializeField] private float _nextDelay = 7f;
    void Start()
    {
        InvokeRepeating("HandleRandomSttack", _startDelay, _nextDelay);
    }
    private void HandleRandomSttack()
    {
        int index = UnityEngine.Random.Range(0, 3);
        if (index == 0)
        {
            _animator.SetTrigger("KidneyPunchLeft");
        }
        else if (index == 1)
        {
            _animator.SetTrigger("KidneyPunchRight");
        }
        else
        {
            _animator.SetTrigger("HeadPunch");
        }

    }
    public void CancelEnemyAttacks()
    {
        CancelInvoke("HandleRandomSttack");
    }
}
