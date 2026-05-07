using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int totalItems = 5;
    public int collectedItems = 0;

    public TMP_Text statsText;
    public TMP_Text endText;
    public GameObject endCanvas;

    public GameObject[] relics;

    private float startTime;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        startTime = Time.time;

        if (endCanvas != null)
            endCanvas.SetActive(false);

        UpdateText();
    }

    public void CollectItem()
    {
        collectedItems++;
        UpdateText();

        if (collectedItems >= totalItems)
            EndLevel();
    }

    public void RemoveItem()
    {
        if (collectedItems > 0)
        {
            collectedItems--;
            UpdateText();
        }
    }

    public void RespawnRelics()
    {
        foreach (GameObject relic in relics)
        {
            if (relic != null)
                relic.SetActive(true);
        }
    }

    private void EndLevel()
    {
        float time = Time.time - startTime;

        if (endCanvas != null)
            endCanvas.SetActive(true);

        if (endText != null)
        {
            endText.text =
                "You escaped Blackridge Chapel!\n" +
                "Relics Collected: " + collectedItems + "/" + totalItems + "\n" +
                "Time: " + time.ToString("F1") + " seconds";
        }

        Time.timeScale = 0f;
    }

    public void UpdateText()
    {
        if (statsText != null)
            statsText.text = "Relics: " + collectedItems + "/" + totalItems;
    }
}