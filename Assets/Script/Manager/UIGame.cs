using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIGame : MonoBehaviour
{
    public static UIGame Instance;

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
    private string _victory = "VICTORY";
    private string _defeat = "DEFEAT";

    public void GameOver(int score, int level)
    {
        UIDefeat.SetActive(true);
        UIBoard.SetActive(false);
        _txtTitle.text = _defeat;
        _txtScore.text = "Score: -" + score.ToString();
        _txtMoney.text = "Bonus: -" + score.ToString();
        _txtRank.text = "Level:" + level.ToString();

    }
    public void EnemyKnockedOut(int score, int level)
    {
        UIDefeat.SetActive(true);
        UIBoard.SetActive(false);
        _txtTitle.text = _victory;
        _txtScore.text = "Score: +" + score.ToString();
        _txtMoney.text = "Bonus: +" + score.ToString();
        _txtRank.text = "Level:" + level.ToString();

    }
    public void LoadSceneMenu()
    {
        SceneManager.LoadScene("Main");
    }

}
