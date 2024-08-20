using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteoAddIV : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 initialForce;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        initialForce = new Vector3(0f, -10f, 0f);
        rb.AddForce(initialForce, ForceMode.Impulse);
    }

}
