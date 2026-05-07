using UnityEngine;

public class IntroStart : MonoBehaviour
{
    public GameObject introPanel;

    void Start()
    {
        Time.timeScale = 0f;
        introPanel.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            introPanel.SetActive(false);
            Time.timeScale = 1f;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }
}