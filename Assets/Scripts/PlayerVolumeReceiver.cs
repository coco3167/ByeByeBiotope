using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerVolumeReceiver : MonoBehaviour
{
    [SerializeField] private MicroVolume microVolume;
    [SerializeField] private float sensibility;
    
    private Rigidbody m_rigidbody;

    private void Awake()
    {
        m_rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        float volume = microVolume.GetWave() * sensibility;
        
        m_rigidbody.AddForce(volume * transform.position.normalized);
    }
}
