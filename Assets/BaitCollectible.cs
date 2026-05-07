using UnityEngine;
using System.Collections;

public class BaitCollectible : MonoBehaviour
{
    public GameObject warningText;
    public float displayTime = 3f;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Bait collected");

        if (other.GetComponent<CharacterController>() != null)
        {
            StartCoroutine(ShowWarning());
        }
    }

    private IEnumerator ShowWarning()
    {
        if (warningText != null)
        {
            warningText.SetActive(true);
        }

        yield return new WaitForSeconds(displayTime);

        if (warningText != null)
        {
            warningText.SetActive(false);
        }

        Destroy(gameObject);
    }
}
