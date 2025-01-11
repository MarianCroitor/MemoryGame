using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuButton : MonoBehaviour
{
    public GameObject levelSelectPanel;
    public Button selectLevelButton;

    [System.Serializable]
    public class LevelData
    {
        public string sceneName;
        public Button button;
    }

    public LevelData[] levels;

    void Start()
    {
        if (selectLevelButton != null)
        {
            selectLevelButton.onClick.AddListener(OnSelectLevelButtonClick);
        }
        else
        {
            Debug.LogError("������ 'Select Level' �� �������!");
        }

        if (levelSelectPanel != null) // ���������, ��� levelSelectPanel �����
        {
            foreach (LevelData level in levels)
            {
                if (level.button == null && level.sceneName != null && level.sceneName != "")
                {
                    string buttonName = level.sceneName.Replace("Level", "Button");
                    level.button = levelSelectPanel.transform.Find(buttonName)?.GetComponent<Button>();
                    if (level.button == null)
                        Debug.LogError($"������ {buttonName} �� ������� �� ������ ������ �������.");
                    else
                    {
                        level.button.onClick.AddListener(() => StartLevel(level));
                    }
                }
            }
        }
        else
            Debug.LogError("Panel ������ ������� �� ����� � ����������!");
    }

    void OnSelectLevelButtonClick()
    {
        if (levelSelectPanel != null) // ��������� ��� ��� ����� ����������
        {
            levelSelectPanel.SetActive(true);
            gameObject.SetActive(false);
        }
    }

    public void StartLevel(LevelData level)
    {
        // ... (��� �������� �����)
    }
}