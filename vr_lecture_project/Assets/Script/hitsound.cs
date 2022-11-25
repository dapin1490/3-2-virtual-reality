using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hitsound : MonoBehaviour
{
    public AudioSource audioSource;

    void OnCollisionEnter()

    {        
            audioSource.Play(); //오디오 재생
    }
}

