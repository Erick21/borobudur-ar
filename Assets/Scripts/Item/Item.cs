using UnityEngine;

public class Item : MonoBehaviour
{
    public GameObject item;

    void Start()
    {
        Instantiate(item, transform.position, transform.rotation);
    }
}
