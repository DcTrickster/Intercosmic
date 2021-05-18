using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 6f;
    public float boostSpeed = 12f;
    public float rotSpeed = 10f;
    public GameObject firstPersonCamera, thirdPersonCamera, trails, finalCamera;
    private bool camChange;
    public bool boosting, recharging;
    public Animator anim;
    public float health = 10f;
    public int boostFuel,maxFuel = 100;
    GameManager gm;
    public Text boostAmount1st, boostAmount3rd, recharging1st, recharging3rd;

    // Start is called before the first frame update
    void Start()
    {
        firstPersonCamera.SetActive(false);
        thirdPersonCamera.SetActive(true);
        gm = FindObjectOfType<GameManager>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (boosting)
        {
            transform.position += transform.forward * boostSpeed * Time.deltaTime;
            trails.SetActive(true);
        }
        else
        {
            transform.position += transform.forward * speed * Time.deltaTime;
            trails.SetActive(false);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Rotate(Vector3.right * rotSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.Rotate(Vector3.left * rotSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.up * rotSpeed * Time.deltaTime);
            anim.SetFloat("Speed", 0.2f);
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            anim.SetFloat("Speed", 0f);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.down * rotSpeed * Time.deltaTime);
            anim.SetFloat("Speed", -0.2f);
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            anim.SetFloat("Speed", 0f);
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            anim.SetTrigger("RollLeft");
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            anim.SetTrigger("RollRight");
        }
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            changeCamera();
        }

        if (Input.GetKey(KeyCode.LeftShift) && boostFuel > 0 && !recharging)
        {
            boosting = true;
            boostFuel--;
        }
        else
        {
            boosting = false;
            if (boostFuel < maxFuel)
            {
                boostFuel++;
            }
        }

        boostAmount1st.text = "Booster Fuel: " + boostFuel + "/ " + maxFuel;
        boostAmount3rd.text = "Booster Fuel: " + boostFuel + "/ " + maxFuel;

        if (boostFuel == 0)
        {
           StartCoroutine(Recharge());
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

        if (recharging)
        {
            recharging1st.text = "Recharging...";
            recharging3rd.text = "Recharging...";
        }
        else if (!recharging)
        {
            recharging1st.text = null;
            recharging3rd.text = null;
        }
    }

    void changeCamera()
    {
        camChange = !camChange;
    }

    IEnumerator Recharge()
    {
        recharging = true;

        yield return new WaitForSeconds(5f);

        recharging = false;
  

    }

    public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            gm.gameOver = true;
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
        else if (other.gameObject.tag == "Untouchable")
        {
            gm.gameOver = true;
            Destroy(this.gameObject);
        }
    }
}
