using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EnemyUI : MonoBehaviour
{
    [SerializeField] Image HealthBar;
    [SerializeField] private TextMeshProUGUI _txtScore;
    public void UpdateScore(int score)
    {
        _txtScore.text = score.ToString();
    }
    public void UpdateHealth(float currentHealth, float maxHealth)
    {
        HealthBar.fillAmount = currentHealth / maxHealth;
    }
}
