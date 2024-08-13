using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    public float timeSpeed = 1f;
    public Text valueText;
    public AudioSource audio;

    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    void Update()
    {
        valueText.text = Time.timeScale.ToString();

        if (Input.GetKey(KeyCode.E))
        {
            Time.timeScale--;
            audio.Play();
        }
        if (Input.GetKey(KeyCode.Q))
        {
            Time.timeScale++;
        }
    }
}
