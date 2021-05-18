using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsCalculator : MonoBehaviour
{
    public int pointsWorth;
    GameManager gm;

    // Start is called before the first frame update
    void Start()
    {
        gm = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
