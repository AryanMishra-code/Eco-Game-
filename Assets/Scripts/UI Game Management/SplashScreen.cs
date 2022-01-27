using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashScreen : MonoBehaviour
{
    [SerializeField] float pauseTime = 5f;
    
    void Start()
    {
        StartCoroutine(LoadHomePage());
    }

    IEnumerator LoadHomePage()
    {
        yield return new WaitForSeconds(pauseTime);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}