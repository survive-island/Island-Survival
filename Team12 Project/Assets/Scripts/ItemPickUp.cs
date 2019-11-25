using UnityEngine;

public class ItemPickUp : MonoBehaviour
{
    void PickUp()
    {
        Debug.Log("Picking up item.");
        Destroy(gameObject);
    }
}
