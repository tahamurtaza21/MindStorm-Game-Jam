using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Spawner : MonoBehaviour
{
    // Start is called before the first frame update
    
    [SerializeField] int NumberOfBees = 50;
    
    [SerializeField] float TimeDelayToSpawnBee = 3f;
    [SerializeField] float ReduceTimeDelay = 2f;
    [SerializeField] float HowMuchToReduceDelay = 0.05f;
    [SerializeField] float MinimumTimeDelay = 1f;
    [SerializeField] float HowLongToWaitToReduce = 8f;
    
    [SerializeField] float ReduceTimeSpeed = 5f;
    [SerializeField] float HowMuchToIncreaseSpeed = 0.1f;
    [SerializeField] float MaxSpeed = 0.5f;
    [SerializeField] float StartingSpeed = 0.2f;

    public GameObject Bee;
    private int BeesSpawned = 0;
    public GameObject[] SpawnPoints;
    
    Coroutine spawnBee;
    Coroutine ReducingTime;
    Coroutine IncreasingSpeed;
    Coroutine reduceSpawnbee;

    
    void Start()
    {
        spawnBee = StartCoroutine("SpawnBee");
        ReducingTime = StartCoroutine("DecreaseTime");
        IncreasingSpeed = StartCoroutine("IncreaseSpeed");
        reduceSpawnbee = StartCoroutine("DecreaseSpawnBeeCount");
    }

    void Update()
    {
        if(TimeDelayToSpawnBee <= MinimumTimeDelay)
        {
            StopCoroutine(ReducingTime);
        }

        if(StartingSpeed >= MaxSpeed)
        {
            StopCoroutine(IncreasingSpeed);
        }
    }

    IEnumerator SpawnBee()
    {
        while(NumberOfBees >= BeesSpawned)
        {
            GameObject SpawnPoint = SpawnPoints[Random.Range(0, SpawnPoints.Length)];

            BeesSpawned += 1;

            Debug.Log("TheNumberOfBeesSpawned " + BeesSpawned);

            GameObject BeeCreated = Instantiate(Bee, SpawnPoint.transform);

            BeeCreated.GetComponent<Bee>().MoveSpeed = StartingSpeed;

            yield return new WaitForSeconds(TimeDelayToSpawnBee);
        }
    }


    IEnumerator DecreaseSpawnBeeCount()
    {
        while (NumberOfBees >= BeesSpawned)
        {
            BeesSpawned -= 1;

            yield return new WaitForSeconds(HowLongToWaitToReduce);
        }
    }

    IEnumerator DecreaseTime()
    {
        while (TimeDelayToSpawnBee >= MinimumTimeDelay)
        {
            TimeDelayToSpawnBee -= HowMuchToReduceDelay;

            yield return new WaitForSeconds(ReduceTimeDelay);
        }

    }

    IEnumerator IncreaseSpeed()
    {
        while(MaxSpeed > StartingSpeed)
        {
            StartingSpeed += HowMuchToIncreaseSpeed;

            yield return new WaitForSeconds(ReduceTimeSpeed);
        }
    }
}
