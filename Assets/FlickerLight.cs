using UnityEngine;

public class FlickerLight : MonoBehaviour
{
    private Light flickerLight;

    public float minIntensity = 0.5f;
    public float maxIntensity = 4f;
    public float flickerSpeed = 0.08f;

    private float timer;

    void Start()
    {
        flickerLight = GetComponent<Light>();
    }

    void Update()
    {
        if (flickerLight == null) return;

        timer -= Time.deltaTime;

        if (timer <= 0f)
        {
            flickerLight.intensity = Random.Range(minIntensity, maxIntensity);
            timer = flickerSpeed;
        }
    }
}