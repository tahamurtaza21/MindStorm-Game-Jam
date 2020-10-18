using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    // Start is called before the first frame update
    
    public ParticleSystem explosion;


    void Start()
    {
        explosion = gameObject.GetComponent<ParticleSystem>();   
    }

    // Update is called once per frame
    

    public void Explode(Vector3 position)
    {
        Instantiate(explosion, position, Quaternion.identity);

        Destroy(gameObject, 1f);
    }
}

