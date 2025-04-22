using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoaderOnCollision : MonoBehaviour
{
    [Tooltip("Duvarlara verdiğiniz Tag")]
    public string wallTag = "Wall";

    [Tooltip("Yüklenecek sahnenin adı ya da build index'i")]
    public string sceneToLoad;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(wallTag))
        {
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}
