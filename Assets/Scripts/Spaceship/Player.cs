using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : ShipStats
{

    public StatBars statBars;
    private bool fpCamOn, tpCamOn;
    private bool camChange;
    public bool gotHit;
    public float timeLastHit, chargeInitialTime;
    public GameObject firstPersonCamera, thirdPersonCamera, shield;

    //VARIABLES TO ALLOW THE SHIP MOVE WITH THE CURSOR
    public float lookRotSpeed = 90f;
    private Vector2 lookInput, screenCenter, mouseDistance;

    // Start is called before the first frame update
    void Start()
    {
        //SETS UP THE VALUES FOR THE SHIPS SPEED/HP/SHIELD && CHECKS WHICH CAMERA IS ON INITIALLY
        statBars.SetMaxSpeed(maxSpeed);
        statBars.SetMaxHullHealth(hullHealth);
        statBars.SetMaxShield(shieldHealth);
        fpCamOn = true;
        tpCamOn = false;
        maxHullHealth = hullHealth;
        maxShieldHealth = shieldHealth;

        //STOPS THE MOUSE FROM GOING OFF SCREEN
        Cursor.lockState = CursorLockMode.Confined;

        //FINDS THE CENTER OF THE SCREEN
        screenCenter.x = Screen.width * .5f;
        screenCenter.y = Screen.height * .5f;
    }

    // Update is called once per frame
    void Update()
    {
        //FINDS THE POSITION OF THE MOUSE CURSOR
        lookInput.x = Input.mousePosition.x;
        lookInput.y = Input.mousePosition.y;

        //FINDS THE DISTANCE FROM MOUSE TO CENTER OF SCREEN
        mouseDistance.x = (lookInput.x - screenCenter.x) / screenCenter.x;
        mouseDistance.y = (lookInput.y - screenCenter.y) / screenCenter.y;

        //CLAMPS CURSOR ROTATION SPEED
        mouseDistance = Vector2.ClampMagnitude(mouseDistance, 1f);

        //ROTATES THE PLAYER WITH MOUSE CURSOR
        transform.Rotate(-mouseDistance.y * lookRotSpeed * Time.deltaTime, mouseDistance.x * lookRotSpeed * Time.deltaTime, 0f, Space.Self);


        //RAW USED BECAUSE WE DON'T WANT ANY SMOOTHING YET
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");


        //ROTATES THE SHIP ON THE Z AXIS
        if (vertical > 0 && speed < maxSpeed)
        {
            speed = speed + 10 * Time.deltaTime;
        }
        if (vertical < 0 && speed > minSpeed)
        {
            speed = speed - 10 * Time.deltaTime;

        }
        statBars.setSpeed(speed);

        //ALLOWS THE SHIP TO GO FORWARD
        transform.position += transform.forward * speed * Time.deltaTime;

        //ALLOWS THE SHIP TO ROLL LEFT OR RIGHT
        if (horizontal > 0)
        {
            transform.Rotate(0f, 0f, -0.25f);
        }
        if (horizontal < 0)
        {
            transform.Rotate(0f, 0f, 0.25f);
        }
     
        if (shieldHealth == 0)
        {
            shield.SetActive(false);
        }
        else
            {
                shield.SetActive(true);
            }

        //DELETE THIS
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(10);
            gotHit = true;
            timeLastHit = 0;
        }

        if (shieldHealth == 0)
        {
            CheckShieldRecharge();
        }


        //CHAGES CAMERA FROM 1ST PERSON TO 3RD PERSON AND VICE VERSA
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            changeCamera();
        }

        if (camChange)
        {
            thirdPersonCamera.SetActive(false);
            firstPersonCamera.SetActive(true);
        }

        if (!camChange)
        {
            firstPersonCamera.SetActive(false);
            thirdPersonCamera.SetActive(true);
        }

        if (!gotHit && shieldHealth < maxShieldHealth)
        {
            shieldHealth ++;
            statBars.setShield(shieldHealth);
        }
    }

    //CHECKS IF THE SHIP HAS BEEN HIT && REACTIVES THE SHIELD RECHARGE IF NOT HIT AFTER CERTAIN TIME
    void CheckShieldRecharge()
    {
        timeLastHit = timeLastHit + 1 * Time.deltaTime;
        if (timeLastHit >= chargeInitialTime)
        {
            gotHit = false;
            timeLastHit = 0;
        }
    }

    //CHANGES BETWEEN FIRST AND THIRD PERSON
    void changeCamera()
    {
        camChange = !camChange;
    }

    //ALLOWS THE SHIP TO TAKE SHIELD DAMAGE/ HEALTH DAMAGE IF THERE IS NO SHIELD
    void TakeDamage(int damage)
    {
        if (shieldHealth > 0)
        {
            shieldHealth = shieldHealth - damage;
            statBars.setShield(shieldHealth);
        }
        else if (shieldHealth == 0 && hullHealth > 0)
        {
            hullHealth = hullHealth - damage;
            statBars.setHullHealth(hullHealth);
        }
    }

}
