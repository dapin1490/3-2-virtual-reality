using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReloadScene : MonoBehaviour
{
    int sceneIndex;
    int frame;

    // Start is called before the first frame update
    void Start()
    {
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
        frame = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.P) || OVRInput.Get(OVRInput.Button.Three))
        {
            frame += 1;
        }

        if (frame >= 300)
        {
            frame = 0;
            SceneManager.LoadScene(sceneIndex);
            print("reload scene");
        }
    }
}
