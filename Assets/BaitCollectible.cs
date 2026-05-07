using UnityEngine;
using System.Collections;

public class BaitCollectible : MonoBehaviour
{
    public GameObject warningText;
    public float displayTime = 3f;

    private bool used = false;

    private void OnTriggerEnter(Collider other)
    {
        if (used) return;

        if (other.GetComponent<CharacterController>() != null)
        {
            used = true;

            Debug.Log("Fake relic collected");

            if (GameManager.instance != null)
            {
                GameManager.instance.RemoveItem();
            }

            StartCoroutine(ShowWarning());
        }
    }

    private IEnumerator ShowWarning()
    {
        if (warningText != null)
            warningText.SetActive(true);

        yield return new WaitForSeconds(displayTime);

        if (warningText != null)
            warningText.SetActive(false);

        gameObject.SetActive(false);
    }
}