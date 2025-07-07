using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Player : MonoBehaviour, IDamageable
{
    [SerializeField] private TextMeshProUGUI _txtScore;
    private int _score = 0;
    private float _currentHealth;
    private float _maxHealth = 100f;
    [SerializeField] Image HealthBar;
    [SerializeField] private PlayerAnimation _playerAnimation;
    private bool _isDie = false;
    [SerializeField]
    private Enemy enemy;
    [SerializeField] EnemyController _enemyController;
    private void Start()
    {
        _txtScore.text = _score.ToString();
        _currentHealth = _maxHealth;
    }
    public void Die()
    {
        GameManager.Instance.GameOver(_score);
    }
    public void TakeDamage(float damage)
    {
        if (_isDie) return;
        _currentHealth -= damage;
        _currentHealth = Mathf.Max(0, _currentHealth);
        if (_currentHealth <= 0)
        {
            _playerAnimation.HandleKnockedOut();
            _isDie = true;
            _enemyController.CancelEnemyAttacks();
            Invoke("Die", 8f);

        }
        UpdateHealth();

    }
    public float ReturnHealthPlayer()
    {
        return _currentHealth;
    }

    public void AddScore(int score)
    {
        _score += score;
        _txtScore.text = _score.ToString();
    }

    private void UpdateHealth()
    {
        HealthBar.fillAmount = _currentHealth / _maxHealth;
    }
    public int ReturnScore()
    {
        return _score;
    }
    public bool IsPlayer()
    {
        return _isDie;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("HeadEnemy"))
        {
            float damage = UnityEngine.Random.Range(10, 30);
            int score = UnityEngine.Random.Range(1, 4);
            enemy.TakeDamage(damage);
            AddScore(score);
            if (enemy.ReturnHealthEnemy() <= 0)
            {
                _playerAnimation.HandleVictory();

            }
        }
    }
}
