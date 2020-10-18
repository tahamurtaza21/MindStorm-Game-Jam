using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bee : MonoBehaviour
{
    public GameObject Player;
    public float MoveSpeed = 0.5f;
    public float MinDist = 1f;
    Transform playerPosition;

    public GameObject Dying;
    void Start()
    {
        playerPosition = Player.GetComponent<Transform>();
    }

    void Update()
    {
        GoToPlayer();
    }

    void GoToPlayer()
    {
        transform.LookAt(playerPosition);

        transform.position = Vector3.MoveTowards(transform.position, playerPosition.transform.position - (4 * Vector3.up) , MoveSpeed);
    }

    private void OnTriggerEnter(Collider collision)
    {

        //Debug.Log("Collided");

        GameObject Dead = Instantiate(Dying, gameObject.transform) as GameObject;

        Dead.GetComponent<Explosion>().Explode(gameObject.transform.position);
       
    }
}
