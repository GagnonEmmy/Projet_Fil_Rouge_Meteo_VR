using UnityEngine;
using UnityEngine.UI;

public class WeatherUI : MonoBehaviour
{
    public WeatherAPI weatherAPI;

    public GameObject window;
    public Text temperatureText;

    public void ShowTemperature()
    {
        window.SetActive(true);

        temperatureText.text = weatherAPI.celsiusTemp + " °C";
    }

    public void HideTemperature()
    {
        window.SetActive(false);
    }
}
