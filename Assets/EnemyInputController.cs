using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInputController : MonoBehaviour
{
    private Steering steering;
    private Arsenal arsenal;

    // Start is called before the first frame update
    void Start()
    {
        steering = GetComponent<Steering>();
        arsenal = GetComponent<Arsenal>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
