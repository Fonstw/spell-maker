using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
	[SerializeField] float movementSpeed = 1000;
	[SerializeField] float rotationSpeed = 100;
	// [SerializeField] Vector2 cameraClamp = new Vector2(5, 60);

	private Rigidbody rb;
	private Transform cameraTransform;

	void Start()
	{
		rb = GetComponent<Rigidbody>();

		for (int i=0 ;i<transform.childCount; i++)
		{
			if (transform.GetChild(i).tag == "MainCamera")
			{
				cameraTransform = transform.GetChild(0);
				break;
			}
		}
	}

	void Update()
	{
		// set movement speed
		Vector3 movement = transform.forward * Input.GetAxis("Vertical");
		movement += transform.right * Input.GetAxis("Horizontal");
		movement *= movementSpeed * Time.deltaTime;
		// apply movement
		if (movement != Vector3.zero)
			rb.velocity = movement;

		// rotate self
		transform.Rotate(0, Input.GetAxis("Mouse X")*rotationSpeed*Time.deltaTime, 0);

		// cameraTransform.Rotate(-Input.GetAxis("Mouse Y")*rotationSpeed*Time.deltaTime, 0, 0);
		cameraTransform.Translate(0, Input.GetAxis("Mouse Y")*rotationSpeed*Time.deltaTime, 0);
		cameraTransform.LookAt(transform);
	}
}
