using UnityEngine;

public class Collectible : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger touched by: " + other.name);

        GameManager gm = FindObjectOfType<GameManager>();

        if (gm != null)
        {
            gm.CollectItem();
        }

        Destroy(gameObject);
    }
}