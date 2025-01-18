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
            Debug.LogError("Кнопка 'Select Level' не найдена!");
        }

        if (levelSelectPanel != null) // Проверяем, что levelSelectPanel задан
        {
            foreach (LevelData level in levels)
            {
                if (level.button == null && level.sceneName != null && level.sceneName != "")
                {
                    string buttonName = level.sceneName.Replace("Level", "Button");
                    level.button = levelSelectPanel.transform.Find(buttonName)?.GetComponent<Button>();
                    if (level.button == null)
                        Debug.LogError($"Кнопка {buttonName} не найдена на панели выбора уровней.");
                    else
                    {
                        level.button.onClick.AddListener(() => StartLevel(level));
                    }
                }
            }
        }
        else
            Debug.LogError("Panel выбора уровней не задан в инспекторе!");
    }

    void OnSelectLevelButtonClick()
    {
        if (levelSelectPanel != null) // Проверяем еще раз перед активацией
        {
            levelSelectPanel.SetActive(true);
            gameObject.SetActive(false);
        }
    }

    public void StartLevel(LevelData level)
    {
        // ... (код загрузки сцены)
    }
}