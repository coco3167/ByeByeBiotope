using UnityEngine;

public class CubeScaler : MonoBehaviour
{
    [SerializeField] private MicroVolume microVolume;
    
    private void FixedUpdate()
    {
        transform.localScale = Vector3.one * (1 + microVolume.GetLoudness());
    }
}
