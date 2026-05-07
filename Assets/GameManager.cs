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

    private void EndLevel()
    {
        float time = Time.time - startTime;

        if (endCanvas != null)
            endCanvas.SetActive(true);

        if (endText != null)
            endText.text = "You escaped Blackridge Chapel!\n" +
                          "Relics Collected: " + collectedItems + "/" + totalItems + "\n" +
                          "Time: " + time.ToString("F1") + " seconds";

        Time.timeScale = 0f;
    }

    private void UpdateText()
    {
        if (statsText != null)
            statsText.text = "Relics: " + collectedItems + "/" + totalItems;
    }
}