using UnityEngine;

public class DeleteButton : MonoBehaviour
{
    private GameObject objectToDelete;

    public void SetObjectToDelete(GameObject objectToDelete)
    {
        this.objectToDelete = objectToDelete;
    }

    public void DeleteObject()
    {
        if (objectToDelete != null)
        {
            Destroy(objectToDelete);
            objectToDelete = null;
        }
    }
}