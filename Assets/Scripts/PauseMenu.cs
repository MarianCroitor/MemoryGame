using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public bool PauseGame;
    public GameObject PauseGameMenu;

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (PauseGame)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        } 
    }

        public void Resume()
        {
            PauseGameMenu.SetActive(false);
            Time.timeScale = 1f;
            PauseGame = false;
        }
        public void Pause()
        {
            PauseGameMenu.SetActive(true);
            Time.timeScale = 0f;
            PauseGame = true;
        }
        public void LoadMenu()
        {
            Time.timeScale = 1f;
            PauseGame = false;
            SceneManager.LoadScene("_Menu");
        }
    }


