using TMPro;
using UnityEngine;

public class MicroUI : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown dropdown;
    [SerializeField] private MicroVolume volume;

    private int m_index;
    private void Awake()
    {
        foreach (string device in Microphone.devices)
        {
            dropdown.options.Add(new TMP_Dropdown.OptionData(device));
        }
        
        volume.SetMicrophone(Microphone.devices[0]);
        
        dropdown.onValueChanged.AddListener(SelectDevice);
    }

    private void SelectDevice(int index)
    {
        Microphone.End(Microphone.devices[m_index]);

        m_index = index;
        volume.SetMicrophone(Microphone.devices[m_index]);
    }
}
