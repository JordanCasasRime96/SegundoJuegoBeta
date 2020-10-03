using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicBackground : MonoBehaviour
{

    public GameObject music;

    void Start()
    {
        Instantiate(music);
    }

}
