using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateLR : MonoBehaviour
{
	int dir = 1;
	public float Aposition = -1.0f;
	public float Bposition = 1.0f;
	public float speed = 1.0f;

	// Start is called before the first frame update
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		if (transform.position.z < Aposition)
		{
			dir = 1;
		}
		else if (transform.position.z > Bposition)
		{
			dir = -1;
		}
		transform.Translate(Vector3.forward * speed * Time.deltaTime * dir);
	}
}
