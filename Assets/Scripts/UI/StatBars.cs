using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatBars : MonoBehaviour
{

    public Slider speedSlider, hpSlider, shieldSlider, leftWeaponSlider, rightWeaponSlider;

    public Gradient speedColor;
    public Image fill,background;

    public void SetMaxSpeed(float speed)
    {
        speedSlider.maxValue = speed;
        speedSlider.value = speed;

        fill.color = speedColor.Evaluate(1f);
        background.color = speedColor.Evaluate(1f);

    }

    public void setSpeed(float speed)
    {
        speedSlider.value = speed;
        fill.color = speedColor.Evaluate(speedSlider.normalizedValue);
        background.color = speedColor.Evaluate(speedSlider.normalizedValue);
    }

    public void SetMaxHullHealth(float health)
    {
        hpSlider.maxValue = health;
        hpSlider.value = health;
    }

    public void setHullHealth(float health)
    {
        hpSlider.value = health;
    }

    public void SetMaxShield(float shield)
    {
        shieldSlider.maxValue = shield;
        shieldSlider.value = shield;
    }

    public void setShield(float shield)
    {
        shieldSlider.value = shield;
    }

    public void setLeftWeaponAmmo(float ammo)
    {
        leftWeaponSlider.value = ammo;
    }

    public void setRightWeaponAmmo(float ammo)
    {
        rightWeaponSlider.value = ammo;
    }

}
