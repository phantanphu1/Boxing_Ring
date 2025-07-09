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
    [SerializeField] private int countEnemy;
    [SerializeField] private int teamEnemy = 0;
    private int _level;
    private void Start()
    {

        if (GameManager.Instance.currentSelectedLevel != null)
        {
            LevelTable data = GameManager.Instance.currentSelectedLevel;
            _minDamage = data.MinDamageEnemy;
            _maxDamage = data.MaxDamageEnemy;
            _maxHealth = data.HealthEnemy;
            _level = data.LevelNumber;
            teamEnemy = data.TeamEnemy;
        }
        countEnemy = 1;
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
        player.SetActiveLevel();
        UIGame.Instance.EnemyKnockedOut(scorePlayer, _level);

    }

    public void TakeDamage(float damage)
    {
        if (_isEnemy) return;
        _currentHealth -= damage;
        _currentHealth = Mathf.Max(0, _currentHealth);
        UpdateHealth();
        if (_currentHealth <= 0)
        {
            _animator.SetTrigger("KnockedOut");
            if (countEnemy < teamEnemy)
            {
                Invoke("ActiveEnemy", 5f);
                return;
            }
            _isEnemy = true;
            _enemyController.CancelEnemyAttacks();
            playerAnimation.HandleVictory();
            Invoke("Die", 7f);
        }
    }
    private void ActiveEnemy()
    {
        _animator.SetTrigger("Comback");
        Debug.LogWarning($"countEnemy:{countEnemy} tearmEnemy:{teamEnemy}");
        countEnemy++;
        _currentHealth = _maxHealth;
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
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("HeadPlayer"))
        {
            float damage = UnityEngine.Random.Range(_minDamage, _maxDamage);
            int score = UnityEngine.Random.Range(1, 2);
            player.TakeDamage(damage);
            AddScore(score);
        }
    }
    public void HandleAnimationVictory()
    {
        _animator.SetTrigger("Victory");
    }
}
