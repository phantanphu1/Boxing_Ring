using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;


    [SerializeField] private GameObject UILevel;
    [SerializeField] private GameObject UIMain;
    [SerializeField] private GameObject UITime;

    [SerializeField] LevelTableObject _levelTableObject;
    [SerializeField] private Transform itemHolder;
    [SerializeField] private GameObject itemPrefabs;
    public LevelTable currentSelectedLevel;
    [SerializeField] private TextMeshProUGUI _txtTime;
    private float _countdownDuration = 3;
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(Instance);
        }
        Instance = this;
        DontDestroyOnLoad(this);
    }
    public void ActiveUIMain()
    {
        UILevel.SetActive(false);
        UIMain.SetActive(true);
        UITime.SetActive(false);
    }
    public void ActiveUILevel()
    {
        UILevel.SetActive(true);
        UIMain.SetActive(false);
        UITime.SetActive(false);
        ClearLevelItems();
        LoadLevel();
    }
    public void ActiveUITime()
    {
        UILevel.SetActive(false);
        UIMain.SetActive(false);
        UITime.SetActive(true);
    }
    private void LoadLevel()
    {
        foreach (var item in _levelTableObject._lsLevelTable)
        {
            GameObject obj = Instantiate(itemPrefabs, itemHolder);
            var tam = obj.GetComponent<UIItemLevel>();
            tam.SetItem(item);
        }
    }
    private void ClearLevelItems()
    {
        foreach (Transform child in itemHolder)
        {
            Destroy(child.gameObject);
        }
    }
    public IEnumerator LoadTime()
    {
        ActiveUITime();
        float _currentTime = _countdownDuration;
        while (_currentTime > 0)
        {
            _txtTime.text = Mathf.CeilToInt(_currentTime).ToString();
            yield return new WaitForSeconds(1f);
            _currentTime--;
        }

        if (_txtTime != null)
        {
            _txtTime.text = "Go";
        }
        SceneManager.LoadScene("GamePlay");
    }
}
