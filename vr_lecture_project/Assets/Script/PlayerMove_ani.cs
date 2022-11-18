using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove_ani : MonoBehaviour
{
    public int Speed = 2;
    public float RotateX = 15.0f;
    Animator animator; //애니메이터를 사용하는 변수를 추가하였습니다.

    void Start()
    {
        this.animator = GetComponent<Animator>();
        //시작과 동시에 해당 물체에서 등록된 애니메이터콤포넌트를 불러와 애니메이터 변수에 넣습니다.
    }

    void Update()
    {
        transform.Rotate(0, Input.GetAxis("Mouse X") * RotateX, 0);

        float keyHorizontal = Input.GetAxis("Horizontal");
        float keyVertical = Input.GetAxis("Vertical");

        transform.Translate(Vector3.right * Speed * Time.smoothDeltaTime * keyHorizontal);
        transform.Translate(Vector3.forward * Speed * Time.smoothDeltaTime * keyVertical);

        this.animator.SetFloat("axis_x", keyHorizontal);
        this.animator.SetFloat("axis_y", keyVertical);
        //애니메이터 파일 내 x축 y축 슬라이드를 키입력과 연동합니다.
    }
}