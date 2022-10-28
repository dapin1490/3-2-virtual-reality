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
	{//void update�� ��ũ��Ʈ�� ����Ǹ� ��� �ݺ������� ����˴ϴ�.//
		transform.Rotate(0, Input.GetAxis("Mouse X") * RotateX, 0);
		//transform�� ��ü�� �����̴� ��ɾ��Դϴ�. rotate�� ȸ���̸� �ڿ� ��ȣ ���� x��, y��, z���� �ǹ��մϴ�. //
		
		// input.getaxis�� ����Ƽ���� �޾Ƶ��̴� Ư�� Ű ������ mouse x�� ���콺�� x���� �ǹ��ϸ� �� ���� �ռ� ������rotateX���� �����־� �ӵ��� �����մϴ�.//
		float keyHorizontal = Input.GetAxis("Horizontal");
		float keyVertical = Input.GetAxis("Vertical");
		
		//float(�Ҽ�) ������ ���� �����մϴ�. input.getaxis�� horizontal�� Ű������ �¿쳪 ad, ���̽�ƽ�� �¿��Դϴ�. vertical�� �����Դϴ�//
		transform.Translate(Vector3.right * Speed * Time.smoothDeltaTime * keyHorizontal);
		transform.Translate(Vector3.forward * Speed * Time.smoothDeltaTime * keyVertical);
		//�ռ� ����� transform�� translate�� �߰��Ͽ� x, y, x ������ �̵��ϰ� �մϴ�. 
		//vector3. �ڿ� ������ �ְ� (left, right, forward, back, up, down)�ű⿡ �ռ� ������ speed���� ���� �� 
		//�ð��� �ӵ�(Time.smoothDeltaTime)�� Ű�Է°��� �����ݴϴ�. ���̽�ƽ�̸� ����ӿ� ���� �ӵ��� �ٲ� �� �ֽ��ϴ�.)
	}
}
