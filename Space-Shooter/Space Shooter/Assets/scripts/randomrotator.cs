using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomrotator : MonoBehaviour
{
    public float tumble;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().angularVelocity = Random.insideUnitSphere*tumble;
    }
}
