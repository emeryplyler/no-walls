using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class CameraShift : MonoBehaviour
{
    // Start is called before the first frame update

    PostProcessVolume m_Volume;
    ChromaticAberration m_ChromaticAberration;
    Grain m_Grain;
    LensDistortion m_LensDistortion;

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
        m_Volume.profile.TryGetSettings(out m_Grain);
        m_Volume.profile.TryGetSettings(out m_LensDistortion);

    }

    private static float Lerp(float a, float b, float t)
    {
        return a + (b - a) * t;
    }

    // Update is called once per frame
    void Update()
    {
        //this is probably an inefficient way to do this, but it works for now
        //I kind of want to scale it exponentially, but this is a simplier way to implement it for now
        if(GameManager.instance.timerDone == false)
        {
           shift = GameManager.instance.stopwatch/GameManager.instance.timer;

            m_ChromaticAberration.intensity.value = Mathf.Lerp(0, 1, EaseInQuad(0f, 1f, shift));
            m_Grain.intensity.value = Mathf.Lerp(0f, 0.4f, EaseInQuad(0f, 1f, shift));
            m_LensDistortion.intensity.value = Lerp(0f, 40f, EaseInQuad(0f, 1f, shift));


        }
        
        



    }
}
