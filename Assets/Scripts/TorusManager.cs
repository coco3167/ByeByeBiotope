using System;
using UnityEngine;

public class TorusManager : MonoBehaviour
{
    [SerializeField] private float maxSize, scaleSpeed;
    private void FixedUpdate()
    {
        transform.localScale = Vector3.Lerp(transform.localScale, Vector3.one * maxSize, scaleSpeed * Time.deltaTime);

        if (Vector3.SqrMagnitude(transform.localScale - Vector3.one * maxSize) < Vector3.kEpsilon)
        {
            Destroy(gameObject);
        }
    }
}
