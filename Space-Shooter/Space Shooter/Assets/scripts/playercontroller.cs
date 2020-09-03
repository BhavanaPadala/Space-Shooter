using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]

public class boundary
{
    public float xMin,xMax,zMin,zMax;
}

public class playercontroller : MonoBehaviour
{
    public float speed;
    public boundary Boundary;
    public float tilt;
    public GameObject shot;
    public Transform shotspawn;
    public float firerate;
    private float nextfire;

    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > nextfire)
        {
            nextfire = Time.time + firerate;
            Instantiate(shot, shotspawn.position, shotspawn.rotation);
            GetComponent<AudioSource>().Play();
        }
    }
    void FixedUpdate()
    {
        float movehorizontal=Input.GetAxis("Horizontal");
        float movevertical=Input.GetAxis("Vertical");
        Vector3 movement=new Vector3(movehorizontal,0.0f,movevertical);
        GetComponent<Rigidbody>().velocity=movement*speed;
        GetComponent<Rigidbody>().position= new Vector3
        (
            Mathf.Clamp(GetComponent<Rigidbody>().position.x,Boundary.xMin,Boundary.xMax),
            0.0f,
            Mathf.Clamp(GetComponent<Rigidbody>().position.z,Boundary.zMin,Boundary.zMax)
        );
        GetComponent<Rigidbody>().rotation=Quaternion.Euler(0.0f,0.0f,GetComponent<Rigidbody>().velocity.x*-tilt);
        
    }
}
