using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProjectileScript : MonoBehaviour
{
    public GameObject projectileEmitter, laserType;
    public float laserForce;
    Animator anim;
    public KeyCode fireButton;
    public StatBars statBars;
    public Slider currentAmmoSlot;
    public string selectedGun;
    public float currentAmmo;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        if (selectedGun == "LeftGun")
        {
            statBars.leftWeaponSlider = currentAmmoSlot;
        }
        if (selectedGun == "RightGun")
        {
            statBars.rightWeaponSlider = currentAmmoSlot;
        }
    }

        // Update is called once per frame
        void Update()
    {
        if (Input.GetKeyDown(fireButton))
        {
            anim.SetTrigger("Shooting");
            GameObject projectileInstant;
            projectileInstant = Instantiate(laserType, projectileEmitter.transform.position, projectileEmitter.transform.rotation) as GameObject;
            projectileInstant.transform.Rotate(Vector3.left * 90);
            Rigidbody projectileRb;
            projectileRb = projectileInstant.GetComponent<Rigidbody>();
            projectileRb.AddForce(transform.up * laserForce);

                Destroy(projectileInstant, 5f);
        }
    }
}
