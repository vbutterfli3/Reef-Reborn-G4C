using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneLoopAudioCutscene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SFXFactory.Instance.PlayLoop(SFXFactory.Instance.cutsceneAudio, 0.3f);
    }

}
