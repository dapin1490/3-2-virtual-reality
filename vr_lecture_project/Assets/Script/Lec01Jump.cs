using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lec01Jump : MonoBehaviour
{
	public float jumpSpeed = 5.0f;  // ���� �ӵ�, ���� �����մϴ�. 
	public bool isGrounded = false; // bool�� int, float�� ���� ������ Ư¡�ε�, true, false �� ���� ���� ���մϴ�.
	Rigidbody rgbd; //rigidbody �Ӽ��� ����� �����Դϴ�. ���� ���Ƿ� ���� rgbd��� ��Ī���� ������ ��������ϴ�.

	void Start()
	{
		rgbd = GetComponent<Rigidbody>(); //�Ʊ� ���� rgbd������ ���� ��ü�� rigidbody�� �ҷ��ɴϴ�
	}

	private void OnCollisionEnter() // ��ü�� �浹�ϸ�, �Ʒ� ��ũ��Ʈ�� �����մϴ�.
	{
		isGrounded = true;    //�� ������ ���� �غ� ��ٴ� ǥ�÷� ����Ͽ����ϴ�.
		// ��(�ƹ� ��ü)�� ��������� Ȱ��ȭ �˴ϴ�  
	}

	void Update()
	{
		if (isGrounded) // isGrounded==true �� ���� ���Դϴ�. ���� ����ִ� ���¶�� �Ʒ� ��ũ��Ʈ�� ����մϴ�.
		{
			if (Input.GetKeyDown(KeyCode.Space)) // �����̽��� ������(down) �Ʒ� ��ũ��Ʈ�� �����մϴ�.
			{
				rgbd.AddForce(new Vector3(0, 1, 0) * jumpSpeed, ForceMode.Impulse);
				// ���������� ���� ���ϴ� addforce ����Դϴ�. y������ 1��ŭ ���� ���ϰ�, jumpspeed�� �� �ӵ��� �����ϸ� impulse�� �ѹ��� ���� ���� �ִ� ���� �ǹ��մϴ�. 
				isGrounded = false; //������ ������ �ݺ� ������ ���� ���� ������ �������ٰ� ���¸� �ٲߴϴ�.
			}
		}
	}
}

