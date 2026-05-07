using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int totalItems = 5;
    public int collectedItems = 0;

    public TMP_Text statsText;
    public GameObject endCanvas;

    private float startTime;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        startTime = Time.time;

        if(endCanvas != null)
            endCanvas.SetActive(false);

        UpdateText();
    }

    public void CollectItem()
    {
        collectedItems++;

        UpdateText();

        if (collectedItems >= totalItems)
        {
            EndLevel();
        }
    }

    void EndLevel()
    {
        float time = Time.time - startTime;

        if(endCanvas != null)
            endCanvas.SetActive(true);

        if(statsText != null)
        {
            statsText.text =
                "You escaped the haunted grounds.\n" +
                "Relics Collected: " + collectedItems + "/" + totalItems + "\n" +
                "Time: " + time.ToString("F1") + " seconds";
        }

        Time.timeScale = 0f;
    }

    void UpdateText()
    {
        if(statsText != null)
        {
            statsText.text =
                "Relics: " + collectedItems + "/" + totalItems;
        }
    }
}