using UnityEngine;

public class Collectible : MonoBehaviour
{
    public float collectDistance = 8f;
    private Transform player;
    private bool collected = false;

    void Start()
    {
        GameObject p = GameObject.FindGameObjectWithTag("Player");

        if (p == null)
        {
            if (Camera.main != null)
            {
                player = Camera.main.transform;
                Debug.Log("Using camera for: " + gameObject.name);
            }
        }
        else
        {
            player = p.transform;
            Debug.Log("Player found for: " + gameObject.name);
        }
    }

    void Update()
    {
        if (player == null || collected) return;

        Vector3 playerFlat = new Vector3(player.position.x, 0, player.position.z);
        Vector3 relicFlat = new Vector3(transform.position.x, 0, transform.position.z);
        float distance = Vector3.Distance(playerFlat, relicFlat);

        if (distance <= collectDistance)
        {
            collected = true;
            Debug.Log("✅ COLLECTED: " + gameObject.name);

            if (GameManager.instance != null)
                GameManager.instance.CollectItem();

            Destroy(gameObject);
        }
    }
}