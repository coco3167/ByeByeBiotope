using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerVolumeReceiver : MonoBehaviour
{
    [SerializeField] private float sensibility;
    
    private Rigidbody m_rigidbody;
    private MicroVolume m_microVolume;

    private void Awake()
    {
        m_rigidbody = GetComponent<Rigidbody>();

        Vector2 rawStartPosition = Random.insideUnitCircle.normalized * 7;
        transform.position = new Vector3(rawStartPosition.x, 0, rawStartPosition.y);
    }

    private void FixedUpdate()
    {
        float volume = m_microVolume.GetWave() * sensibility;
        
        m_rigidbody.AddForce(volume * transform.position.normalized);
    }

    public void Initialize(MicroVolume microVolume)
    {
        m_microVolume = microVolume;
    }
}
