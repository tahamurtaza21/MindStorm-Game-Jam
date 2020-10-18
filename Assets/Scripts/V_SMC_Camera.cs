using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Visyde{
	public class V_SMC_Camera : MonoBehaviour {

		//Throwing Rocks
		//public SpawnRocks Spawnrocks;

		public FixedJoystick joystick;
		public float speed;

		// The handler of crosshair sprites:
		public V_SMC_Handler crosshairHandler;

		// For the FPS mouse look:
		float rotationX = 0F;
		float rotationY = 0F;

		// For the raycasting function:
		public Vector3 fireDirection;
		Vector3 firePoint;

		// Use this for initialization
		void Start () {
			// Lock and hide the cursor:

			//Cursor.lockState = CursorLockMode.Locked;
			//Cursor.visible = false;
		}

		// Update is called once per frame
		public void Update () {

			// FPS mouse look:
			rotationX = joystick.Horizontal * speed;
			rotationY = joystick.Vertical * speed;

			Debug.Log("ROTATE!");

			transform.Rotate(Mathf.Clamp(-rotationY, -90f, 90f), Mathf.Clamp(rotationX, -90f, 90f), 0.0f);
			transform.rotation = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, 0);

			//Quaternion rotation = Quaternion.Euler(rotationY, rotationX, 0);
			//transform.rotation = rotation;

			// Call raycast method:
			Hit ();
		}

		void Hit()
		{
			// Raycasting variables:
			RaycastHit hit;
			fireDirection = transform.TransformDirection(Vector3.forward);
			firePoint = transform.position;

			// Do raycasting:
			/* if (Physics.Raycast (firePoint, (fireDirection), out hit, Mathf.Infinity))
			{
				// Change the color based on what object is under the crosshair:
				//if (hit.transform.name == "Friendly") {
				//	crosshairHandler.ChangeColor(Color.green);

				//Debug.Log("Finding");

				/* if (hit.collider.gameObject.tag == "Enemy")
				{
					SpawnRocks.GetComponent<SpawnRocks>().FoundEnemy = true;
					//Debug.Log("Found");
				}
				else
                {
					SpawnRocks.GetComponent<SpawnRocks>().FoundEnemy = false;
                } */

			// Debug the ray out in the editor:
			//Debug.DrawRay(firePoint, fireDirection, Color.green); 
		}
	}
}
