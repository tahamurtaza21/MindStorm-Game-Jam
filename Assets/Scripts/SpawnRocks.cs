using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Visyde;

public class SpawnRocks: MonoBehaviour
{
    // Start is called before the first frame update

    //public bool FoundEnemy = false;

    public GameObject rock;

    [SerializeField] float TimeDelayToShoot = 0.5f;
    
    Coroutine Shooting;

    [SerializeField] UnityEngine.Vector3 offset;

    public SumScore scoreTracker;


    void Start()
    {
        Shooting = StartCoroutine("Shoot");
    }

    void ShootAutomatically()
    {
        Instantiate(rock, Camera.main.transform.position + offset , Camera.main.transform.rotation);
    }

    IEnumerator Shoot()
    {
        while(true)
        {
            ShootAutomatically();

            yield return new WaitForSeconds(TimeDelayToShoot);
        }
    }
}