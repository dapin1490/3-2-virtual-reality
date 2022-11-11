using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove_ani : MonoBehaviour
{
    public int Speed = 2;
    public float RotateX = 15.0f;
    Animator animator;

    void Start()
    {
        this.animator = GetComponent<Animator>();
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
    }
}
