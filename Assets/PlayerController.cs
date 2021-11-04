using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{

	public float moveSpeed;

	public Vector2 input;

	Rigidbody2D rb;

	void Awake()
	{
		rb = GetComponent<Rigidbody2D>();
	}

	void Update()
	{
		input = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
		rb.AddForce(input * moveSpeed);
		if (rb.velocity.magnitude > 5)
			rb.velocity = Vector3.ClampMagnitude(rb.velocity, 5);
	}
}
