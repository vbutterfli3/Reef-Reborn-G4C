using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneLoopingAudio : MonoBehaviour
{
    void Start()
    {
        SFXFactory.Instance.PlayLoop(SFXFactory.Instance.wholeGameAudio, 0.3f);
    }
}