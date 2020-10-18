using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Visyde;

public class Rock : MonoBehaviour
{
    // Start is called before the first frame update

    public float forwardForce = 2000f;
    //public bool HitEnemy = false;

    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(Camera.main.GetComponent<V_SMC_Camera>().fireDirection * forwardForce);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            SumScore.Add(10);
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

}
