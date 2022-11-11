using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject hero; //ī�޶� �Ѿƴٴ� ����Դϴ�.
    float Ymin = 5.0f; //ī�޶� �������� �������Դϴ�. �� ������ �ʹٸ� �����ݽô�.
    float Ymax = 40.0f; //ī�޶� �ö󰡴� �ְ��Դϴ�. 90���� �Ѿ�� �ڷ� ���ư��ϴ�.
    Camera cam; //ī�޶� �����Դϴ�.
    Transform lookat; //ī�޶� �Ѿƴٴ� ��ġ�Դϴ�.
    Transform camtrans; //ī�޶��� ��ġ�Դϴ�.
    float Xnow = 0.0f; //ī�޶� �����̴� �¿��κ����Դϴ�.
    float Ynow = 15.0f; //ī�޶� �����̴� ���ϰ�κ����Դϴ�.

    public float distance = 5.0f; //ī�޶� ��ü�κ��� ������ �ִ� �Ÿ��Դϴ�.
    public float RotateX = 15.0f; //ī�޶��� ȸ���ӵ��Դϴ�. ĳ���� ȸ�� �ӵ��� �Ȱ��ƾ� �մϴ�.

    // Start is called before the first frame update
    void Start()
    {
        lookat = hero.gameObject.transform.transform; //ĳ���ͷκ�����ġ�� �޾ƿɴϴ�.
        camtrans = transform; //ī�޶� ��ġ�� �޾ƿɴϴ�.
        cam = Camera.main; //���� ī�޶� cam������ �Ҵ��մϴ�.
    }

    // Update is called once per frame
    void Update()
    {
        Xnow += Input.GetAxis("Mouse X"); //ī�޶��� �¿����Է��� �޽��ϴ�.
        Ynow -= Input.GetAxis("Mouse Y"); //ī�޶��� ���ϰ���Է��� �޽��ϴ�.
        Ynow = Mathf.Clamp(Ynow, Ymin, Ymax); //ī�޶��� ���� �������� �����մϴ�.
        if (hero == null) //�÷��̾ ������� ��� ������ �����ϱ� ���� �κ��Դϴ�. ������� �����մϴ�.
        {
            gameObject.GetComponent<CameraFollow>().enabled = false; // �ش� ��ũ��Ʈ�� ��Ȱ��ȭ�մϴ�.
        }
    }

    private void LateUpdate()
    //�ٷιٷ� �����ϴ� ���� �ƴ�, �� �ൿ�� �� �Ŀ� �ڵ��� �����մϴ�. �ε巯�� ī�޶� �������� ���ɴϴ�.
    {
        Vector3 dir = new Vector3(0, 0, -distance); //�Ÿ��� �����ݴϴ�.
        Quaternion rotation = Quaternion.Euler(Ynow * 2, Xnow * RotateX, 0);
        //ȸ������ ����ϴ�. ���ϴ� 2��, �¿�� RotateX(ĳ����ȸ����)�� �����־����ϴ�.
        camtrans.position = lookat.position + rotation * dir; //ī�޶� ��ġ�� ������ �ݴϴ�.
        camtrans.LookAt(lookat.position); //ī�޶� �������� �ٶ󺸰� �մϴ�.
    }
}
