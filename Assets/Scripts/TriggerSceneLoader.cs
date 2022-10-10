using Cinemachine;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Collider))]
public class TriggerSceneLoader : MonoBehaviour
{
    #region Fields
    [SerializeField, TagField] private string loadingActivatorTag;
    [SerializeField] private int sceneBuildIndex;
    #endregion

    #region Methods
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag(loadingActivatorTag))
            SceneManager.LoadScene(sceneBuildIndex);
    }
    #endregion
}