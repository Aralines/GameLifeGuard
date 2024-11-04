using UnityEngine;
using UnityEngine.Rendering;

public class Menu : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;

    public void PauseMenu()
    {
        pauseControl(true);
    }

    public void Resume()
    {
        pauseControl(false);
    }
    
    private void pauseControl(bool pause)
    {
        Time.timeScale = pause ? 0 : 1;
        pauseMenu.SetActive(pause);
    }
}