using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIItemLevel : MonoBehaviour
{
    [SerializeField] private Text _txtLevel;
    private LevelTable _myLevelData;
    private CanvasGroup _canvasGroup;

    [SerializeField] private Button _levelButton;
    private void Start()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
        ActiveLevel();

    }
    private void Update()
    {
    }
    public void SetItem(LevelTable levelTable)
    {
        _txtLevel.text = levelTable.LevelNumber.ToString();
        _myLevelData = levelTable;
        if (_levelButton != null)
        {
            _levelButton.onClick.RemoveAllListeners();
            _levelButton.onClick.AddListener(OnLevelSelected);
        }
        else
        {
            Debug.LogError("Button null");
        }
    }
    private void OnLevelSelected()
    {
        if (GameManager.Instance != null)
        {
            // Lưu toàn bộ đối tượng LevelTable của cấp độ này vào GameManager.Instance
            GameManager.Instance.currentSelectedLevel = _myLevelData;
            GameManager.Instance.StartCoroutine(GameManager.Instance.LoadTime());
            // SceneManager.LoadScene("GamePlay");
        }
        else
        {
            Debug.LogError("Error");
        }
    }
    public void ActiveLevel()
    {
        if (_myLevelData.active == true)
        {
            _canvasGroup.alpha = 1f;
            _canvasGroup.interactable = true;

        }
        else
        {
            _canvasGroup.alpha = 0.4f;
            _canvasGroup.interactable = false;
        }
    }
}
