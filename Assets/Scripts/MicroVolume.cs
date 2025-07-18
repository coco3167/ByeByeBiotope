using System;
using Unity.Mathematics;
using UnityEngine;

public class MicroVolume : MonoBehaviour
{
    private const int Length = 1;
    private const int SampleWindow = 64;

    [SerializeField] private float threshold, sensibility;

    private AudioClip m_audioClip;
    private string m_deviceName;
    private void FixedUpdate()
    {
        Debug.Log(GetLoudness());
    }

    public float GetLoudness()
    {
        float rawLoudness = GetLoudness(Microphone.GetPosition(m_deviceName));
        rawLoudness *= sensibility;
        
        if (rawLoudness < threshold)
            return 0;
        
        return rawLoudness;
    }

    private float GetLoudness(int clipPosition)
    {
        int startPosition = clipPosition - SampleWindow;
        
        if (startPosition < 0)
            return 0;
        
        float[] waveData = new float[SampleWindow];
        m_audioClip.GetData(waveData, startPosition);

        float sum = 0;
        
        for (int loop = 0; loop < SampleWindow; loop++)
        {
            sum += Math.Abs(waveData[loop]);
        }

        return sum / SampleWindow;
    }

    public void SetMicrophone(string device)
    {
        m_deviceName = device;
        m_audioClip = Microphone.Start(m_deviceName, true, Length, AudioSettings.outputSampleRate);
    }
}
