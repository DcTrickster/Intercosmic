using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipStats : MonoBehaviour
{
    public int hullHealth, shieldHealth, maxHullHealth, maxShieldHealth;
    public float speed = 6f;
    public float minSpeed = 0, mediumSpeed = 10, maxSpeed = 20;
    public float weaponOneCharge = 100, weaponTwoCharge = 100;

}
