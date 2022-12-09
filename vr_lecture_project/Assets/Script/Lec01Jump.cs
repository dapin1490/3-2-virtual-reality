using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lec01Jump : MonoBehaviour
{
	public float jumpSpeed = 5.0f;  // 점프 속도, 힘을 결정합니다. 
	public bool isGrounded = false; // bool은 int, float와 같이 변수의 특징인데, true, false 두 가지 값을 지닙니다.
	Rigidbody rgbd; //rigidbody 속성을 사용할 예정입니다. 제가 임의로 정한 rgbd라는 명칭으로 변수를 만들었습니다.

	void Start()
	{
		rgbd = GetComponent<Rigidbody>(); //아까 만든 rgbd변수에 현재 객체의 rigidbody를 불러옵니다
	}

	private void OnCollisionEnter() // 물체가 충돌하면, 아래 스크립트를 실행합니다.
	{
		isGrounded = true;    //이 변수는 점프 준비가 됬다는 표시로 사용하였습니다.
		// 땅(아무 물체)에 닿아있으면 활성화 됩니다  
	}

	void Update()
	{
		if (isGrounded) // isGrounded==true 를 줄인 말입니다. 땅에 닿아있는 상태라면 아래 스크립트를 허용합니다.
		{
			if (Input.GetKeyDown(KeyCode.Space)) // 스페이스를 누르면(down) 아래 스크립트를 실행합니다.
			{
				rgbd.AddForce(new Vector3(0, 1, 0) * jumpSpeed, ForceMode.Impulse);
				// 물리적으로 힘을 가하는 addforce 명령입니다. y축으로 1만큼 힘을 가하고, jumpspeed는 그 속도를 가속하며 impulse는 한번에 강한 힘을 주는 것을 의미합니다. 
				isGrounded = false; //점프를 했으면 반복 실행을 막기 위해 땅에서 떨어졌다고 상태를 바꿉니다.
			}
		}
	}
}

