using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
public class MenuManager : MonoBehaviour
{

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PlayGame()
    {
        StartCoroutine(PlayGameWithDelay());
    }
    IEnumerator PlayGameWithDelay()
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(1);
    }
    public void QuitGame()
    {
        Application.Quit();
    }

}
