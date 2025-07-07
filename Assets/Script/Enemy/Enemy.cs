using System.Collections;
using TMPro;
using TMPro.EditorUtilities;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour, IDamageable
{
    private int _score = 0;
    private float _currentHealth;
    private float _maxHealth = 100f;
    [SerializeField] Image HealthBar;
    [SerializeField] private TextMeshProUGUI _txtScore;
    private float _minDamage = 5;
    private float _maxDamage = 20;
    [SerializeField]
    private Player player;
    [SerializeField] private PlayerAnimation playerAnimation;
    private bool _isEnemy = false;
    private Animator _animator;
    [SerializeField] EnemyController _enemyController;

    private void Start()
    {
        _txtScore.text = _score.ToString();
        _currentHealth = _maxHealth;
        _animator = GetComponent<Animator>();
    }
    public void AddScore(int score)
    {
        _score += score;
        _txtScore.text = _score.ToString();
    }

    public void Die()
    {
        int scorePlayer = player.ReturnScore();
        GameManager.Instance.EnemyKnockedOut(scorePlayer);

    }

    public void TakeDamage(float damage)
    {
        if (_isEnemy) return;
        _currentHealth -= damage;
        _currentHealth = Mathf.Max(0, _currentHealth);
        if (_currentHealth <= 0)
        {
            _isEnemy = true;
            _animator.SetTrigger("KnockedOut");
            _enemyController.CancelEnemyAttacks();
            Invoke("Die", 8f);
        }
        UpdateHealth();
    }
    private void UpdateHealth()
    {

        HealthBar.fillAmount = _currentHealth / _maxHealth;
    }
    public bool IsEnemy()
    {
        return _isEnemy;
    }
    public float ReturnHealthEnemy()
    {
        return _currentHealth;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("HeadPlayer"))
        {
            float damage = UnityEngine.Random.Range(_minDamage, _maxDamage);
            int score = UnityEngine.Random.Range(1, 4);
            player.TakeDamage(damage);
            AddScore(score);
            if (player.ReturnHealthPlayer() <= 0)
            {
                _animator.SetTrigger("Victory");
            }
        }
    }
}
