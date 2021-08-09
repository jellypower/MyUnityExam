using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public HealthPoint healthPoints;

    [HideInInspector] public Player character;

    public Image meterImage;

    public Text hpText;

    float maxHealthPoints;

    void Start()
    {
        maxHealthPoints = character.maxHealthPoints;
        Debug.Log(character);
    }

    // Update is called once per frame
    void Update()
    {
        if(character != null)
        {
            meterImage.fillAmount = healthPoints.value / maxHealthPoints;

            hpText.text = "HP: " + (meterImage.fillAmount * 100);
        }
    }
}
