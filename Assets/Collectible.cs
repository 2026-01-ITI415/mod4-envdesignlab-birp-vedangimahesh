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
            Camera cam = Camera.main;
            if (cam != null)
            {
                player = cam.transform;
                Debug.Log("Using Main Camera as player reference");
            }
            else
            {
                Debug.LogError("No Player or Camera found!");
            }
        }
        else
        {
            player = p.transform;
            Debug.Log("Player found: " + p.name);
        }
    }

    void Update()
    {
        if (player == null || collected) return;

        Vector3 playerFlat = new Vector3(player.position.x, 0, player.position.z);
        Vector3 relicFlat  = new Vector3(transform.position.x, 0, transform.position.z);

        float distance = Vector3.Distance(playerFlat, relicFlat);

        Debug.Log(gameObject.name + " distance: " + distance);

        if (distance <= collectDistance)
        {
            collected = true;
            Debug.Log("✅ Collected: " + gameObject.name);

            if (GameManager.instance != null)
            {
                GameManager.instance.CollectItem();
            }
            else
            {
                Debug.LogError("❌ GameManager instance is NULL!");
            }

            Destroy(gameObject);
        }
    }
}