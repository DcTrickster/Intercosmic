using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObjects : MonoBehaviour
{
    public GameObject objectPrefab;
    public Vector3 center,size;
    // Start is called before the first frame update
    void Start()
    {
        SpawnObject();
        InvokeRepeating("SpawnObject", 5f, 10f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnObject()
    {
        Vector3 pos = center + new Vector3(Random.Range(-size.x / 2, size.x / 2), Random.Range(-size.y / 2, size.y / 2), Random.Range(-size.z / 2, size.z / 2));
        Instantiate(objectPrefab, pos, Quaternion.identity);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(2, 0, 0, 0.5f);
        Gizmos.DrawCube(center, size);
    }

}
