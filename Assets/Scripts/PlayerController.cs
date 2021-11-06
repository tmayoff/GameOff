using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{

	public Transform weaponSlot;

	public float moveSpeed;

	private Animator anim;
	private Rigidbody2D rb;

	void Awake()
	{
		rb = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
	}

	void Update()
	{
		Vector2 input = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
		rb.AddForce(input * moveSpeed);
		if (rb.velocity.magnitude > 5)
			rb.velocity = Vector3.ClampMagnitude(rb.velocity, 5);

		if (input.magnitude > 0)
		{
			anim.SetFloat("Horizontal", input.x);
			anim.SetFloat("Vertical", input.y);
			weaponSlot.rotation = Quaternion.Euler(0f, 0f, Mathf.Atan2(input.y, input.x) * Mathf.Rad2Deg - 90);
		}
	}
}
