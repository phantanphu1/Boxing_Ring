using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Player : MonoBehaviour, IDamageable
{
    private int _score = 0;
    private float _currentHealth;
    private float _maxHealth = 100f;
    [SerializeField] private PlayerAnimation _playerAnimation;
    private bool _isDie = false;
    [SerializeField]
    private Enemy enemy;
    [SerializeField] EnemyController _enemyController;
    [SerializeField] private float _minDamage = 5;
    [SerializeField] private float _maxDamage = 20;
    [SerializeField] private int levelPlayer;
    [SerializeField] LevelTableObject _levelTableObject;
    private int countPlayer;
    private int teamPlayer;
    private int _level;
    [SerializeField] private PlayerUI playerUI;
    private PlayerSpawner playerSpawner;
    private void Awake()
    {

    }
    private void Start()
    {
        playerSpawner = FindObjectOfType<PlayerSpawner>();
        playerUI = FindObjectOfType<PlayerUI>();
        _playerAnimation = FindObjectOfType<PlayerAnimation>();
        enemy = FindObjectOfType<Enemy>();
        _enemyController = FindObjectOfType<EnemyController>();
        if (GameManager.Instance.currentSelectedLevel != null)
        {
            LevelTable data = GameManager.Instance.currentSelectedLevel;
            _minDamage = data.MinDamagePlayer;
            _maxDamage = data.MaxDamagePlayer;
            _maxHealth = data.HealthPlayer;
            _level = data.LevelNumber;
            teamPlayer = data.TeamPlayer;
        }
        countPlayer = 1;
        playerUI.UpdateScore(_score);
        _currentHealth = _maxHealth;
    }
    public void Die()
    {
        this.gameObject.SetActive(false);
        enemy.gameObject.SetActive(false);
        UIGame.Instance.GameOver(_score, _level);
    }
    public void TakeDamage(float damage)
    {
        if (_isDie) return;
        _currentHealth -= damage;
        _currentHealth = Mathf.Max(0, _currentHealth);
        playerUI.UpdateHealth(_currentHealth, _maxHealth);

        if (_currentHealth <= 0)
        {
            _playerAnimation.HandleKnockedOut();
            _isDie = true;

            if (countPlayer < teamPlayer)
            {
                Invoke("ActivePlayer", 5f);
                return;
            }
            // _isDie = true;
            _enemyController.CancelEnemyAttacks();
            enemy.HandleAnimationVictory();
            Invoke("Die", 7f);
        }
    }
    private void ActivePlayer()
    {
        _isDie = false;
        this.gameObject.SetActive(false);
        playerSpawner.SpwanNewPlayer();
        countPlayer++;
        _currentHealth = _maxHealth;
        playerUI.UpdateHealth(_currentHealth, _maxHealth);

    }
    public void AddScore(int score)
    {
        _score += score;
        playerUI.UpdateScore(_score);
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
        }
    }
    public void SetActiveLevel()
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
