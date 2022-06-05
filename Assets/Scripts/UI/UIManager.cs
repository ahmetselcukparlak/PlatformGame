using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; set; }
    [SerializeField] private GameObject GamePanel;
    [SerializeField] private GameObject GameFailPanel;
    [SerializeField] private GameObject GameMenuPanel;

    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        GameMenuPanel.SetActive(true);
        GameFailPanel.SetActive(false);
        GamePanel.SetActive(false);
        CharacterService.Instance.gameObject.SetActive(false);
    }

    public void GameFail()
    {
        GamePanel.SetActive(false);
        GameFailPanel.SetActive(true);
    }

    public void OnStartGame()
    {
        GameMenuPanel.SetActive(false);
        GamePanel.SetActive(true);
        CharacterService.Instance.gameObject.SetActive(true);
    }
    public void OnRestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void OnAboutGame()
    {

    }
    public void OnQuitGame()
    {
        Application.Quit();
    }
}
