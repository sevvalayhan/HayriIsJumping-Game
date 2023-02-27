using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class EnergySlider : MonoBehaviour
{
    public Slider slider;
   


    void Start()
    {
        slider.value = slider.maxValue;
        slider.minValue = 0;

    }

    // Update is called once per frame
    void Update()
    {
    }
    public void DownGrade(int value)
    {
        if (slider.value >= slider.minValue)
        {
            slider.value -= value;
        }

    }
    public void UpGrade(int value)
    {
        if (slider.value >= slider.minValue)
        {
            slider.value += value;
        }
    }



}
