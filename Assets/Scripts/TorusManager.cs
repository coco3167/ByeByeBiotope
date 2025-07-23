using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class TorusManager : MonoBehaviour
{
    [SerializeField] private float maxSize, scaleSpeed;

    private MeshRenderer m_renderer;
    private static readonly int Color1 = Shader.PropertyToID("_Color");

    private void Start()
    {
        //m_renderer = GetComponent<MeshRenderer>();
        //Debug.Log("created");
    }

    private void FixedUpdate()
    {
        transform.localScale = Vector3.Lerp(transform.localScale, Vector3.one * maxSize, scaleSpeed * Time.deltaTime);

        float distanceUntilComplete = Vector3.SqrMagnitude(transform.localScale - Vector3.one * maxSize);
        if (distanceUntilComplete < Vector3.kEpsilon)
        {
            Destroy(gameObject);
        }
        
        //m_renderer.material.SetColor(Color1, Color.Lerp(Color.white, Color.clear, distanceUntilComplete));
    }
}
