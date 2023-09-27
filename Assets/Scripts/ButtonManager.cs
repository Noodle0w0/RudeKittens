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
        // ESC tuþuna basýldýðýnda PausePanel'i aç/kapat
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
        Time.timeScale = 0; // Oyun zamanýný durdur
        pausePanel.SetActive(true); // PausePanel'i görünür yap
        isPaused = true;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1; // Oyun zamanýný normale döndür
        pausePanel.SetActive(false); // PausePanel'i gizle
        isPaused = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
