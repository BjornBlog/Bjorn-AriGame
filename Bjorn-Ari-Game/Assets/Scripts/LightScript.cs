using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LightScript : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI batteryShowCount;
    public Slider batBar;
    private FirstPersonController PlayerScript;
    private Light light;
    private bool isOn = false;
    public int batteryCount = 1;
    public float batteryPercent = 100f;

    // Start is called before the first frame update
    void Start()
    {   
        PlayerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<FirstPersonController>();
        light = GetComponent<Light> ();
		light.enabled = false;
    }
    public bool EnableLight()
    {        
        if(batteryPercent > 0)
        {
            isOn = true;
            StartCoroutine(Startup());
            return true;
        }
        else if(batteryPercent !< 0 && batteryCount > 0)
        {
            batteryCount = batteryCount - 1;
            batteryPercent = 100f;
            isOn = true;
            StartCoroutine(Startup());
            return true;
        }
        else
        {
            //TellPlayerNoBatteries with bad sound ok
            return false;
        }

    }
    public bool DisableLight()
    {        
        isOn = false;
        light.enabled = false;
        return false;
    }
    private IEnumerator Startup()
    {
        print("Startup");
        light.enabled = true;
        yield return new WaitForSeconds(Random.Range(300, 700)/1000);
        light.enabled = false;
        yield return new WaitForSeconds(Random.Range(400, 1300)/1000);
        light.enabled = true;
        StartCoroutine(Flicker());
    }
    private IEnumerator Flicker()
    {
        while (isOn)
        {
            print("Flicker");
            yield return new WaitForSeconds(Random.Range(500, 700)/1000);
            light.enabled = false;
            yield return new WaitForSeconds(Random.Range(400, 800)/1000);
            light.enabled = true;
            yield return new WaitForSeconds(Random.Range(400, 1600)/1000);
        }
    }
    private IEnumerator BatteryDeath()
    {
        light.enabled = false;
        yield return new WaitForSeconds(Random.Range(300, 700)/1000);
        light.enabled = true;
        yield return new WaitForSeconds(Random.Range(400, 1300)/1000);
        light.enabled = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        batteryShowCount.text = batteryCount.ToString();
        batBar.value = batteryPercent;
        if(light.enabled && batteryPercent > 0)
        {
            batteryPercent = batteryPercent - 0.04f;
        }
        else if(light.enabled)
        {
            PlayerScript.isLightOn = false;
            isOn = false;
            StartCoroutine(BatteryDeath());
        }
    }
}
