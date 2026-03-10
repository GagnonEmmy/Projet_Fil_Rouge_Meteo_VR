using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class WeatherAPI : MonoBehaviour
{
    public string apiKey = "7a20392f65094d5b817213034261602";
    public string city = "Chicoutimi";

    public float celsiusTemp;
    public string conditionTemp;

    private void Start()
    {
        StartCoroutine(GetWeather());
    }

    public IEnumerator GetWeather()
    {
        string url = $"https://api.weatherapi.com/v1/current.json?key={apiKey}&q={city}";

        UnityWebRequest request = UnityWebRequest.Get(url);

        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success)
        {
            string json = request.downloadHandler.text;

            WeatherResponse data = JsonUtility.FromJson<WeatherResponse>(json);

            celsiusTemp = data.current.temp_c;
            conditionTemp = data.current.condition.text;

            Debug.Log($"Weather: {celsiusTemp}°C | {conditionTemp}");
        }
        else
        {
            Debug.LogError(request.error);
        }
    }
}

[System.Serializable]
public class WeatherResponse
{
    public Current current;
}

[System.Serializable]
public class Current
{
    public float temp_c;
    public Condition condition;
}

[System.Serializable]
public class Condition
{
    public string text;
}
