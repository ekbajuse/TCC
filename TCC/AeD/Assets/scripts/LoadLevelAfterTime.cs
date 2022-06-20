using UnityEngine;
using UnityEngine.SceneManagement;
public class LoadLevelAfterTime : MonoBehaviour
{
    [SerializeField]
    private float delayBeforeLoading = 3f;
    [SerializeField]
    private string sceneNameToLoad;

    private float timeElaspsed;

    private void Update()
    {
        Debug.Log(timeElaspsed); 
        timeElaspsed += Time.deltaTime;
        if (timeElaspsed > delayBeforeLoading)
        {

            SceneManager.LoadScene(sceneNameToLoad);

        }
    }
}