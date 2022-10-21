using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateY : MonoBehaviour
{
	public int rotaterY = 50;

	void AAA()
	{

	}

	// Start is called before the first frame update
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		transform.Rotate(0, rotaterY * Time.deltaTime, 0);
	}
}
