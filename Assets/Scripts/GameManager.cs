using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField]
    GameObject endGamePanel;
    [SerializeField]
    GameObject pauseGamePanel;
    [SerializeField]
    GameObject inGamePanel;
    [SerializeField]
    GameObject scoreText;
    AudioSource aud;
    [SerializeField]
    AudioClip gameOverClip;
    private void Awake()
    {
        Instance = this;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        aud = GetComponent<AudioSource>();
        InGamePanel();
    }

    // Update is called once per frame
    void Update()
    {

    }
    IEnumerator BackMenuWithDelay()
    {
        Time.timeScale = 1f;
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(0);
    }
    public void BackMenu()
    {
        StartCoroutine(BackMenuWithDelay());
    }
    public void PauseGame()
    {
        PauseGamePanel();
        Time.timeScale = 0f;
    }
    public void ContinueGame()
    {
        InGamePanel();
        Time.timeScale = 1f;
    }
    IEnumerator RePlayGameWithDelay()
    {
        Time.timeScale = 1f;
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(1);
    }
    public void ReplayGame()
    {
        StartCoroutine(RePlayGameWithDelay());
    }
    void InGamePanel()
    {
        inGamePanel.SetActive(true);
        pauseGamePanel.SetActive(false);
        endGamePanel.SetActive(false);
    }
    void PauseGamePanel()
    {
        inGamePanel.SetActive(false);
        pauseGamePanel.SetActive(true);
        endGamePanel.SetActive(false);
    }
    IEnumerator EndGameWithDelay()
    {
        yield return new WaitForSeconds(0.4f);
        aud.PlayOneShot(gameOverClip);
        yield return new WaitForSeconds(1.5f);
        Time.timeScale = 0f;
        PlayerController.instance.HighScore();
        inGamePanel.SetActive(false);
        pauseGamePanel.SetActive(false);
        endGamePanel.SetActive(true);
    }
    public void EndGamePanel()
    {
        StartCoroutine(EndGameWithDelay());
    }
}
