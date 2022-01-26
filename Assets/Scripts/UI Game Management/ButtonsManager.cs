using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonsManager : MonoBehaviour
{
    // HOME PAGE:
    [SerializeField] int sceneIndex;
    [SerializeField] GameObject controlsPanel;
    [SerializeField] GameObject homePagePanel;
    
    public void LoadMainGameLevel()
    {
        SceneManager.LoadScene(sceneIndex);
    }
    
    public void ShowControlsPanel()
    {
        homePagePanel.SetActive(false);
        controlsPanel.SetActive(true);
    }
    public void ExitControls()
    {
        controlsPanel.SetActive(false);
        homePagePanel.SetActive(true);
    }
    
    // COMMON: 
    public void ExitApplication()
    {
        Debug.Log("Quit Application!");
        Application.Quit();
    }
}