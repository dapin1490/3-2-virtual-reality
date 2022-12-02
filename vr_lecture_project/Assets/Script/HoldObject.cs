using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HoldObject : MonoBehaviour
{
    public bool nowGrab = false;
    //하나만 잡도록 잡은 상태를 나타냅니다.

    private void OnTriggerStay(Collider other) //물체가 손에 들어오는 것을 인지합니다.
    {
        if (Input.GetKeyDown("e")&&other.tag == "Grabbable"&!nowGrab)
        {//e키를 누르고, 닿은 물체가 잡을 수 있는 물체인지, 잡아도 되는 상태인지 봅니다.
            other.transform.SetParent(transform); //맞다면 손에 쥡(자식으로 만듦)니다.
            other.GetComponent<Rigidbody>().useGravity = false; //중력해제
            other.GetComponent<Rigidbody>().isKinematic = true; //물리작용해제
            nowGrab = true; //잡고 있으니 이제 다른거 못잡습니다.
        }
        else if(Input.GetKeyDown("e") && other.tag == "Grabbable" == nowGrab)
        { //다시 누르면 역순!
            other.transform.SetParent(null);
            other.GetComponent<Rigidbody>().useGravity = true;
            other.GetComponent<Rigidbody>().isKinematic = false;
            nowGrab = false;
        }
    }    
}
