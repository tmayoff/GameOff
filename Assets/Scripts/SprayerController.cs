using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SprayerController : MonoBehaviour
{

	ParticleSystem ps;

	void Awake()
	{
		ps = GetComponentInChildren<ParticleSystem>();
	}

	void Update()
	{
		if (Input.GetButtonDown("Fire1"))
			ps.Play();
		if (Input.GetButtonUp("Fire1"))
			ps.Stop();
	}
}
