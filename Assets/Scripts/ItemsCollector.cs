using Cinemachine;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class ItemsCollector :  MonoBehaviour
{
    #region Fields
    [SerializeField, TagField] private string collectableItemsTag;
    private int _numberOfCollectedItems;
    #endregion

    #region Methods
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag(collectableItemsTag))
        {
            Collect(other.gameObject);
            Debug.Log("Total items collected: " + _numberOfCollectedItems);
        }
    }

    private void Collect(GameObject itemGameObject)
    {
        itemGameObject.SetActive(false);
        _numberOfCollectedItems++;
    }
    #endregion
}