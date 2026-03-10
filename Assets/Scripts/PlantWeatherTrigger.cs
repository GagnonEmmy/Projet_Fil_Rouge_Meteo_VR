using UnityEngine;

public class PlantWeatherTrigger : MonoBehaviour
{
    public WeatherAPI weatherAPI;

    public GameObject sunEffect;
    public GameObject rainEffect;
    public GameObject snowEffect;
    public GameObject cloudEffect;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Wand"))
        {
            SpawnWeather();
        }
    }

    void SpawnWeather()
    {
        string condition = weatherAPI.conditionTemp;

        if (condition.Contains("Sunny") || condition.Contains("Clear"))
            Instantiate(sunEffect, transform.position, Quaternion.identity);

        if (condition.Contains("Rain") || condition.Contains("Drizzle"))
            Instantiate(rainEffect, transform.position, Quaternion.identity);

        if (condition.Contains("Snow") || condition.Contains("Blizzard"))
            Instantiate(snowEffect, transform.position, Quaternion.identity);

        if (condition.Contains("Cloud"))
            Instantiate(cloudEffect, transform.position, Quaternion.identity);
    }
}
