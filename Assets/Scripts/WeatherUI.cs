using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WeatherUI : MonoBehaviour
{
    public WeatherAPI weatherAPI;

    public GameObject window;
    public TextMeshProUGUI temperatureText;
    public TextMeshProUGUI conditionText;

    public void ShowTemperature()
    {
        window.SetActive(true);
        temperatureText.text = weatherAPI.celsiusTemp + " °C";
        conditionText.text = GetConditionLabel(weatherAPI.conditionTemp);
    }

    public void HideTemperature()
    {
        window.SetActive(false);
    }

    private string GetConditionLabel(string code)
    {
        if (code.Contains("Sunny") || code.Contains("Clear"))
            return "Ensoleillé";

        if (code.Contains("Rain") || code.Contains("Drizzle"))
            return "Pluie";

        if (code.Contains("Snow") || code.Contains("Blizzard"))
            return "Neige";

        if (code.Contains("Cloudy") || code.Contains("Cloud"))
            return "Nuageux";

        return "Nuageux";
    }
}
