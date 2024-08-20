using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    private GameObject target;
    private Rigidbody rb;
    private Vector3 tagPos;        
    private float force = 15;
    private float initilaTime;
    private float delay = 0.7f;
    private float endtime = 4f;
    


    private void AddInitialForce()
    {
        float randomX = UnityEngine.Random.Range(-12,12);
        float randomZ = UnityEngine.Random.Range(-12,12);
        Vector3 force = new Vector3(randomX, 5, randomZ);
        rb.AddForce(force, ForceMode.Impulse);
    }

    private void Start() 
    {
        rb = GetComponent<Rigidbody>();
        target = GameObject.Find("Player");
        AddInitialForce();
        initilaTime = Time.time;
    }

    private void Update()
    {
        if (tagPos != null)
        {
            if (Time.time - initilaTime >= delay)
            {
                tagPos = target.transform.position;
                AddSecondForce(tagPos);
            }
            if (Time.time - initilaTime >= endtime)
            {
                Destroy(this.gameObject);
            }
        }
    }

    private void AddSecondForce(Vector3 tagPos)
    {
        Vector3 secondD = tagPos - this.transform.position;
        float sum = Mathf.Abs(secondD.x) + Mathf.Abs(secondD.y) + Mathf.Abs(secondD.z);
        Vector3 secondForce = new Vector3((secondD.x/sum) * force, (secondD.y/sum) * force, (secondD.z/sum) * force);
        rb.AddForce(secondForce);
    }

    public void Broke()
    {
        Destroy(this.gameObject);
    }
}
