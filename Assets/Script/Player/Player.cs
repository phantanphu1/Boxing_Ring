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
    private PlayerAnimation _playerAnimation;
    private bool _isDie = false;
    private void Start()
    {
        _txtScore.text = _score.ToString();
        _currentHealth = _maxHealth;
        _playerAnimation = FindObjectOfType<PlayerAnimation>();
    }
    public void Die()
    {
        if (_isDie) return;
        _isDie = true;
        _playerAnimation.HandleKnockedOut();
    }
    private void Update()
    {
        if (!_isDie)
        {
            UpdateHealth();
        }
    }

    public void TakeDamge(float damge)
    {
        if (_isDie) return;
        _currentHealth -= damge;
        if (_currentHealth <= 0)
        {
            Die();
        }
    }

    public void UpdateScore(int score)
    {
        _score += score;
        _txtScore.text = _score.ToString();
    }
    private void GameOver()
    {

    }
    private void WinGame()
    {

    }
    private void UpdateHealth()
    {
        HealthBar.fillAmount = _currentHealth / _maxHealth;
    }
}
