using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] GameObject aboutSection;
    [SerializeField] GameObject levelSelection;
    public void PlayGame(int level)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + level);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void AboutSection()
    {
        levelSelection.SetActive(false);
        aboutSection.SetActive(true);
    }

    public void LevelSelection()
    {
        levelSelection.SetActive(true);
        aboutSection.SetActive(false);
    }
}
