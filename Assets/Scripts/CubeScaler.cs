using UnityEngine;

public class CubeScaler : MonoBehaviour
{
    [SerializeField] private MicroVolume microVolume;
    [SerializeField] private bool scaleX, scaleY, scaleZ;
    
    private void FixedUpdate()
    {
        Vector3 coordinatesToScale = new Vector3(scaleX ? 1 : 0, scaleY ? 1 : 0, scaleZ ? 1 : 0);
        
        transform.localScale = Vector3.one + microVolume.GetLoudness() * coordinatesToScale;
    }
}
