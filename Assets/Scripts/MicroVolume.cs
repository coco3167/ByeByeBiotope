using System;
using System.Timers;
using Unity.Mathematics;
using UnityEngine;

public class MicroVolume : MonoBehaviour
{
    private const int Length = 1;
    private const int SampleWindow = 64;

    [SerializeField] private GameObject torus;
    [SerializeField] private float threshold, sensibility, timeBetweenWaves;

    private AudioClip m_audioClip;
    private string m_deviceName;
    
    private bool m_waveAvailable;
    private Timer m_waveTimer = new();

    private void Awake()
    {
        m_waveTimer.Interval = timeBetweenWaves*1000;
        m_waveTimer.Elapsed += OnWaveTimerElapsed;
        
        m_waveTimer.Start();
    }

    private void FixedUpdate()
    {
        //Debug.Log(GetLoudness());
    }

    public float GetWave()
    {
        if (!m_waveAvailable)
            return 0;

        float volume = GetLoudness();
        if (volume != 0)
        {
            m_waveTimer.Start();
            m_waveAvailable = false;
            Instantiate(torus, transform);
        }
        
        return volume;
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

    private void OnWaveTimerElapsed(object obj, ElapsedEventArgs args)
    {
        m_waveAvailable = true;
    }

    public void SetMicrophone(string device)
    {
        m_deviceName = device;
        m_audioClip = Microphone.Start(m_deviceName, true, Length, AudioSettings.outputSampleRate);
    }
}
