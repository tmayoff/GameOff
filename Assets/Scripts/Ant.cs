using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

[RequireComponent(typeof(Rigidbody2D))]
public class Ant : Enemy
{
	public float maxSpeed = 5;
	public float steerStrength = 2;
	public float wanderStrength = 1;

	[ReadOnly]
	public Rigidbody2D rb;

	[ReadOnly]
	public Vector2 desiredDirection;
	[ReadOnly]
	public Vector2 velocity;

	void Awake()
	{
		rb = GetComponent<Rigidbody2D>();
	}

	void Update()
	{
		desiredDirection = (desiredDirection + Random.insideUnitCircle * wanderStrength).normalized;

		Vector2 desiredVelocity = desiredDirection * maxSpeed;
		Vector2 desiredSteeringForce = (desiredVelocity - rb.velocity) * steerStrength;
		Vector2 acceleration = Vector2.ClampMagnitude(desiredSteeringForce, steerStrength) / 1;

		velocity = Vector2.ClampMagnitude(velocity + acceleration * Time.deltaTime, maxSpeed);

		float angle = Mathf.Atan2(velocity.y, velocity.x) * Mathf.Rad2Deg;
		transform.position += (Vector3)velocity * Time.deltaTime;
		transform.rotation = Quaternion.Euler(0, 0, angle);
	}

	public void UpdateTargetDirection()
	{

	}
}
