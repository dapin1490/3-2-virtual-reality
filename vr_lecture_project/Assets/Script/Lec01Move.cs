using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lec01Move : MonoBehaviour
{
	public float Speed = 2;
	public float RotateX = 15.0f;

	void Start()
	{
		print("Move script start");
	}

	void Update()
	{//void update는 스크립트가 실행되면 계속 반복적으로 실행됩니다.//
		transform.Rotate(0, Input.GetAxis("Mouse X") * RotateX, 0);
		//transform은 객체를 움직이는 명령어입니다. rotate는 회전이며 뒤에 괄호 안은 x축, y축, z축을 의미합니다. //
		
		// input.getaxis는 유니티에서 받아들이는 특정 키 값으로 mouse x는 마우스의 x축을 의미하며 그 값에 앞서 설정한rotateX값을 곱해주어 속도를 결정합니다.//
		float keyHorizontal = Input.GetAxis("Horizontal");
		float keyVertical = Input.GetAxis("Vertical");
		
		//float(소수) 변수를 새로 정의합니다. input.getaxis의 horizontal은 키보드의 좌우나 ad, 조이스틱의 좌우입니다. vertical은 상하입니다//
		transform.Translate(Vector3.right * Speed * Time.smoothDeltaTime * keyHorizontal);
		transform.Translate(Vector3.forward * Speed * Time.smoothDeltaTime * keyVertical);
		//앞서 사용한 transform에 translate를 추가하여 x, y, x 축으로 이동하게 합니다. 
		//vector3. 뒤에 방향을 넣고 (left, right, forward, back, up, down)거기에 앞서 설정한 speed값을 곱한 뒤 
		//시간당 속도(Time.smoothDeltaTime)와 키입력값을 곱해줍니다. 조이스틱이면 기울임에 따라 속도가 바뀔 수 있습니다.)
	}
}
