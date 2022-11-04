using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class CameraShift : MonoBehaviour
{
    // Start is called before the first frame update

    PostProcessVolume m_Volume;
    ChromaticAberration m_ChromaticAberration;
    public float shift;

    public static float EaseInQuad(float start, float end, float value)
    {
        end -= start;
        return end * value * value + start;
    }

    void Start()
    {
        m_Volume = GetComponent<PostProcessVolume>();
        m_Volume.profile.TryGetSettings(out m_ChromaticAberration);

    }

    // Update is called once per frame
    void Update()
    {
        //this is probably an inefficient way to do this, but it works for now
        //I kind of want to scale it exponentially, but this is a simplier way to implement it for now
        if(GameManager.instance.timerDone == false)
        {
           shift = GameManager.instance.stopwatch/GameManager.instance.timer;

            m_ChromaticAberration.intensity.value = Mathf.Lerp(0, 1, EaseInQuad(0, 1, shift));


        }
        
        



    }
}
