using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject original;

    void Start()
    {
        for (int i=0; i<1000;i++){
            GameObject.Instantiate(original, new Vector3(Random.Range(-10.0f, 10.0f),Random.Range(0, 10.0f), Random.Range(-10.0f, 10.0f)), Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
