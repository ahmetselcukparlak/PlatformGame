using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarBehaviour : MonoBehaviour
{
    private Slider Slider;
    public Color Low;
    public Color High;
    public Vector3 Offset;

    private void Awake()
    {
        Slider = GetComponent<Slider>();
    }
    public void SetHealth(float health, float maxHealth)
    {
        Slider.gameObject.SetActive(health < maxHealth);
        Slider.value = health / 100;
        Slider.maxValue = maxHealth / 100;

        Slider.fillRect.GetComponentInChildren<Image>().color = Color.Lerp(Low, High, Slider.normalizedValue);
    }
}
