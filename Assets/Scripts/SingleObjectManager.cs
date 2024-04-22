using UnityEngine;
using UnityEngine.UI;

public class SingleObjectManager : MonoBehaviour
{

    void Start()
    {
        GameObject deleteButton = GameObject.FindWithTag("DeleteButton");
        
        DeleteButton deleteButtonScript = deleteButton.GetComponent<DeleteButton>();
        if (deleteButtonScript != null)
        {
            deleteButtonScript.SetObjectToDelete(gameObject);
        }
        else
        {
            Debug.LogError("Delete button script not found!");
        }
    }
}