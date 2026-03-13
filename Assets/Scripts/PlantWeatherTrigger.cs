using UnityEngine;

public class PlantWeatherTrigger : MonoBehaviour
{
    private bool activated = false;
    private GameObject currentEffect;

    public WeatherAPI weatherAPI;
    public WeatherUI weatherUI;

    public GameObject sunEffect;
    public GameObject rainEffect;
    public GameObject snowEffect;
    public GameObject cloudEffect;

    public Transform effectLocation;

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collision detected with: " + other.name);

        if (!activated)
        {
            if (other.GetComponentInParent<Transform>().CompareTag("Wand"))
            {
                SpawnWeather();
                weatherUI.ShowTemperature();
            }
            activated = true;
        }
        else
        {
            Destroy(currentEffect);
            weatherUI.HideTemperature();
            activated = false;
        }
    }

    void SpawnWeather()
    {
        string condition = weatherAPI.conditionTemp;

        if (condition.Contains("Sunny") || condition.Contains("Clear"))
            currentEffect = Instantiate(sunEffect, effectLocation.position, Quaternion.identity);

        if (condition.Contains("Rain") || condition.Contains("Drizzle"))
            currentEffect = Instantiate(rainEffect, effectLocation.position, Quaternion.identity);

        if (condition.Contains("Snow") || condition.Contains("Blizzard"))
            currentEffect = Instantiate(snowEffect, effectLocation.position, Quaternion.identity);

        if (condition.Contains("Cloudy") || condition.Contains("Cloud"))
            currentEffect = Instantiate(cloudEffect, effectLocation.position, Quaternion.identity);
    }
}
