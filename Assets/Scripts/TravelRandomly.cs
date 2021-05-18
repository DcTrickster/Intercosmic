using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TravelRandomly : MonoBehaviour
{
    private Vector3 RandomVector3(float min, float max)
    {
        float x = Random.Range(min, max);
        float y = Random.Range(min, max);
        float z = Random.Range(min, max);

        return new Vector3(x, y, z);
    }
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.velocity = RandomVector3(1f, 10f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
