using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    public float jumpSpeed = 5.0f;
    public bool isGrounded = false;
    Rigidbody rgbd;
    Animator animator; //애니메이터를 사용하는 변수를 추가하였습니다.

    public bool readyattack = true; //공격 가능한 상황에만 공격하게 합니다.
    public float delay = 1.0f; //공격 딜레이를 추가합니다.
    void Start()
    {
        rgbd = GetComponent<Rigidbody>();
        this.animator = GetComponent<Animator>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        isGrounded = true;
        this.animator.SetBool("isGround1", true); ﻿//애니메이터 파일 변수에서 땅에 있는 상황을 알려 줍니다.
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1") && readyattack) 
            // &&는 양측 조건이 모두 만족될 때 아래 내용을 실행합니다. readyattack==true의미입니다.
        {
            readyattack = false; //공격 후 바로 공격이 안되도록 합니다.
            this.animator.SetTrigger("Attack1"); //공격 애니메이션 트리거 신호를 보냅니다.
            StartCoroutine(Wait());  // 아래 IEnumerator 메서드를 실행합니다.
        }
        if (isGrounded)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                this.animator.SetTrigger("Jumping"); ﻿//점프 애니메이션을 실행합니다.﻿
                this.animator.SetBool("isGround1", false); ﻿﻿//공중에 있는 조건으로 바꿉니다.
                rgbd.AddForce(new Vector3(0, 1, 0) * jumpSpeed, ForceMode.Impulse);
                isGrounded = false;
            }
        }
    }
    IEnumerator Wait()  //잠깐 딜레이를 주는 용도입니다. 
    {
        yield return new WaitForSeconds(delay);  //delay에 있는 숫자만큼의 초를 기다립니다
        readyattack = true;  //몇초가 지난 뒤 다시 공격 가능으로 바꿉니다.
    }
}
