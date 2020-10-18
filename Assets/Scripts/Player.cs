using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public Healthbar healthbarScript;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            healthbarScript.health -= 10;
            Destroy(other.gameObject);

            if(healthbarScript.health <= 0)
            {
                SceneManager.LoadScene(2);
            }
        }
    }
}
