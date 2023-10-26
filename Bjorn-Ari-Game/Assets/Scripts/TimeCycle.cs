using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class TimeCycle : MonoBehaviour
{
    public Vector3 origin1 = Vector3.zero;
    public float radius1 = 10;
    public Vector3 origin2 = Vector3.zero;
    public float radius2 = 10;
    public Vector3 origin3 = Vector3.zero;
    public float radius3 = 10;
    [SerializeField]
    private GameObject enemy1;
    [SerializeField]
    private GameObject enemy2;
    [SerializeField]
    private GameObject enemy3;
    private int nightCount = 0;
    private bool nightStart = true;
    [SerializeField]
    private float timeMultiplier;
    
    [SerializeField]
    private float startHour;

    [SerializeField]
    private TextMeshProUGUI timeText;

    [SerializeField]
    private Light sunLight;

    [SerializeField]
    private float sunriseHour;

    [SerializeField]
    private float sunsetHour;

    [SerializeField]
    private Color dayAmbientLight;

    [SerializeField]
    private Color nightAmbientLight;

    [SerializeField]
    private AnimationCurve lightChangeCurve;

    [SerializeField]
    private float maxSunLightIntensity;

    [SerializeField]
    private Light moonLight;

    [SerializeField]
    private float maxMoonLightIntensity;

    private DateTime currentTime;

    private TimeSpan sunriseTime;

    private TimeSpan sunsetTime;
    void Start()
    {
        currentTime = DateTime.Now.Date + TimeSpan.FromHours(startHour);
        sunriseTime = TimeSpan.FromHours(sunriseHour);
        sunsetTime = TimeSpan.FromHours(sunsetHour);
    }

    // Update is called once per frame
    void Update()
    {
        UpdateTimeOfDay();
        RotateSun();
        UpdateLightSettings();
    }

    private void UpdateTimeOfDay()
    {
        currentTime = currentTime.AddSeconds(Time.deltaTime * timeMultiplier);
        if (timeText != null)
        { 
            timeText.text = currentTime.ToString("HH:mm");
        }
    }

    private void RotateSun()
    {
        float sunLightRotation;

        if (currentTime.TimeOfDay > sunriseTime && currentTime.TimeOfDay < sunsetTime)
        {
            TimeSpan sunriseToSunsetDuration = CalculateTimeDifference(sunriseTime, sunsetTime);
            TimeSpan timeSinceSunrise = CalculateTimeDifference(sunriseTime, currentTime.TimeOfDay);

            double percentage = timeSinceSunrise.TotalMinutes / sunriseToSunsetDuration.TotalMinutes;

            sunLightRotation = Mathf.Lerp(90, 270, (float)percentage);
            nightStart = true;
        }
        else
        {
            if(nightStart)
            {
                nightCount += 1;
                Vector3 randomPosition1 = origin1 + UnityEngine.Random.insideUnitSphere * radius1;
                Instantiate(enemy1, randomPosition1, Quaternion.identity);
                if(nightCount >= 3)
                {
                    Vector3 randomPosition2 = origin2 + UnityEngine.Random.insideUnitSphere * radius2;
                    Instantiate(enemy2, randomPosition2, Quaternion.identity);
                    if(nightCount >= 6)
                    {
                        Vector3 randomPosition3 = origin3 + UnityEngine.Random.insideUnitSphere * radius3;
                        Instantiate(enemy3, randomPosition3, Quaternion.identity);
                    }
                }
                nightStart = false;
            }
            TimeSpan sunsetToSunriseDuration = CalculateTimeDifference(sunsetTime, sunriseTime);
            TimeSpan timeSinceSunset = CalculateTimeDifference(sunsetTime, currentTime.TimeOfDay);

             double percentage = timeSinceSunset.TotalMinutes / sunsetToSunriseDuration.TotalMinutes;

             sunLightRotation = Mathf.Lerp(-90, 90, (float)percentage);
        }
        sunLight.transform.rotation = Quaternion.AngleAxis(sunLightRotation, Vector3.right);
    }

    private void UpdateLightSettings()
    {
        float dotProduct = Vector3.Dot(sunLight.transform.forward, Vector3.down);
        sunLight.intensity = Mathf.Lerp(0, maxSunLightIntensity, lightChangeCurve.Evaluate(dotProduct));
        moonLight.intensity = Mathf.Lerp(maxMoonLightIntensity, 0, lightChangeCurve.Evaluate(dotProduct));
        RenderSettings.ambientLight = Color.Lerp(nightAmbientLight, dayAmbientLight, lightChangeCurve.Evaluate(dotProduct));
    }
    private TimeSpan CalculateTimeDifference(TimeSpan fromTime, TimeSpan toTime)
    {
        TimeSpan difference = toTime - fromTime;

        if (difference.TotalSeconds < 0)
        {
            difference += TimeSpan.FromHours(24);
        }

        return difference;
    }
}
