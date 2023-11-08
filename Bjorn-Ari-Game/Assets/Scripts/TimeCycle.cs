using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class TimeCycle : MonoBehaviour
{
    List<GameObject> Enemy;
    private GameObject pauseObject;
    private PauseScreen pauseSystem;
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
    public bool nightStart = true;
    [SerializeField]
    private float timeMultiplier;
    
    [SerializeField]
    private float startHour;

    [SerializeField]
    private TextMeshProUGUI timeText;

    [SerializeField]
    private Light sunLight;
    public float sunriseHour;
    public float sunsetHour;

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

    public DateTime currentTime;

    public TimeSpan sunriseTime;

    public TimeSpan sunsetTime;
    void Start()
    {
        currentTime = DateTime.Now.Date + TimeSpan.FromHours(startHour);
        sunriseTime = TimeSpan.FromHours(sunriseHour);
        sunsetTime = TimeSpan.FromHours(sunsetHour);
    }

    // Update is called once per frame
    void Awake()
    {
        pauseObject = GameObject.FindGameObjectWithTag ("Pause");
        pauseSystem = pauseObject.GetComponent<PauseScreen>();
    }
    void Update()
    {
        if (pauseSystem.GetIsPaused())
        { 
            return; 
        }
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
        if(sunsetTime >= currentTime.TimeOfDay && currentTime.TimeOfDay >= sunriseTime)
        {

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
            if(!nightStart)
            {
                
                nightStart = true;
            }
        }
        else
        {
            if(nightStart)
            {
                nightCount += 1;
                create(1);
                if(nightCount >= 3)
                {
                    create(2);
                    if(nightCount >= 6)
                    {
                        create(3);
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
    Vector3 GeneratedPosition()
    {
        int x, y, z;
        x = UnityEngine.Random.Range(-10, 10);
        y = UnityEngine.Random.Range(7, 10);
        z = UnityEngine.Random.Range(-10, 10);
        return new Vector3(x, y, z);
    }
    void create(int number)
    {
        // randomInt = Random.Range(0, enemy.Length);
        Instantiate(enemy1, GeneratedPosition(), Quaternion.identity);
    }
}
