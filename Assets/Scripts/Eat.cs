using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Eat : MonoBehaviour
{
    public Slider slider;
    public int maxNumber;
    public int number;
    public int addNumber;
    public int removeNumber;
    public string tagName;
    public string tagName2;
    public string tagName3;

    void Start()
    {
        slider.wholeNumbers = true;
        slider.maxValue = maxNumber;
        slider.value = number;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == tagName)
        {
            number += addNumber;
            Destroy(other.gameObject);
            slider.value = number;
        }
        if ((other.gameObject.tag == "EnemyShipTag") || (other.gameObject.tag == "EnemyBulletTag"))
        {
            number -= removeNumber;
            Destroy(other.gameObject);
            slider.value = number;
        }
        else if (other.gameObject.tag == tagName3)
        {
            number -= removeNumber;
            Destroy(other.gameObject);
            slider.value = number;
        }

    }
}
