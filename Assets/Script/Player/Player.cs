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
    [SerializeField] private float _minDamage = 5;
    [SerializeField] private float _maxDamage = 20;
    [SerializeField] private int levelPlayer;
    [SerializeField] LevelTableObject _levelTableObject;
    private int _level;
    private void Start()
    {
        _txtScore.text = _score.ToString();
        _currentHealth = _maxHealth;
        if (GameManager.Instance.currentSelectedLevel != null)
        {
            LevelTable data = GameManager.Instance.currentSelectedLevel;
            _minDamage = data.MinDamagePlayer;
            _maxDamage = data.MaxDamagePlayer;
            _maxHealth = data.HealthPlayer;
            _level = data.LevelNumber;
        }
    }
    public void Die()
    {
        UIGame.Instance.GameOver(_score, _level);
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
        Debug.LogWarning($"score:{score}");
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
            float damage = UnityEngine.Random.Range(_minDamage, _maxDamage);
            int score = UnityEngine.Random.Range(1, 4);
            enemy.TakeDamage(damage);
            AddScore(score);
            if (enemy.ReturnHealthEnemy() <= 0)
            {
                _playerAnimation.HandleVictory();
                SetActiveLevel();

            }
        }
    }
    void SetActiveLevel()
    {
        foreach (var item in _levelTableObject._lsLevelTable)
        {
            if (item.LevelNumber == _level + 1)
            {
                item.active = true;
            }
        }
    }
}
