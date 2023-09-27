using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ButtonManager : MonoBehaviour
{

    public GameObject pausePanel;

    private bool isPaused = false;

    void Start()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1f;
    }

    void Update()
    {
        // ESC tu�una bas�ld���nda PausePanel'i a�/kapat
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void PauseGame()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Time.timeScale = 0; // Oyun zaman�n� durdur
        pausePanel.SetActive(true); // PausePanel'i g�r�n�r yap
        isPaused = true;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1; // Oyun zaman�n� normale d�nd�r
        pausePanel.SetActive(false); // PausePanel'i gizle
        isPaused = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
