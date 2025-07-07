using System.Collections;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(Instance);
        }
        Instance = this;
        DontDestroyOnLoad(this);
    }
    public GameObject UIDefeat;
    public GameObject UIBoard;
    [SerializeField] private TextMeshProUGUI _txtScore;
    [SerializeField] private TextMeshProUGUI _txtRank;
    [SerializeField] private TextMeshProUGUI _txtMoney;
    [SerializeField] private TextMeshProUGUI _txtTitle;
    [SerializeField] private float _delayAfterDeath = 1f;
    private string _victory = "VICTORY";
    private string _defeat = "DEFEAT";

    public void GameOver(int score)
    {
        UIDefeat.SetActive(true);
        UIBoard.SetActive(false);
        _txtTitle.text = _defeat;
        _txtScore.text = "Score: -" + score.ToString();
        _txtMoney.text = "Bonus: -" + score.ToString();
        _txtRank.text = "Level 1";

    }
    public void EnemyKnockedOut(int score)
    {
        UIDefeat.SetActive(true);
        UIBoard.SetActive(false);
        _txtTitle.text = _victory;
        _txtScore.text = "Score: +" + score.ToString();
        _txtMoney.text = "Bonus: +" + score.ToString();
        _txtRank.text = "Level 1";
    }

}
