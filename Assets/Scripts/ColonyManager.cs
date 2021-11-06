using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

public class ColonyManager : MonoBehaviour
{

	public GameObject AntPrefab;

	public float match = 1;
	public float collide = 1;
	public float center = 1;

	public int population = 10;

	[ReadOnly]
	public Vector3 averagePosition;

	[ReadOnly]
	public List<Ant> ants;

	void Start()
	{
		for (int i = 0; i < population; i++)
			ants.Add(Instantiate(AntPrefab, transform.position, Quaternion.identity, transform).GetComponent<Ant>());
	}

	void Update()
	{
		foreach (Ant ant in ants)
		{
			// Average pos
			Vector3 vel = ant.transform.up;
		}
	}
}
