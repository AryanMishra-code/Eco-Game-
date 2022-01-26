using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadAsyncOperation : MonoBehaviour
{
    [SerializeField] Image progressBar;

    void Start()
    {
        StartCoroutine(LoadScene());
    }

    IEnumerator LoadScene()
    {
        yield return new WaitForSeconds(7.5f);
        AsyncOperation gameLevel = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
        while (gameLevel.progress < 1)
        {
            progressBar.fillAmount = gameLevel.progress;
            yield return new WaitForEndOfFrame();
        }
    }
}