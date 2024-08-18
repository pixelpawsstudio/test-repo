using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public float magnitude = 0.1f; // Intensidad del shake

    private Vector3 originalPosition;

    void Start()
    {
        originalPosition = transform.localPosition;
    }

    void Update()
    {
        Shake();
    }

    private void Shake()
    {
        float x = Random.Range(-1f, 1f) * magnitude;
        float y = Random.Range(-1f, 1f) * magnitude;

        transform.localPosition = new Vector3(originalPosition.x + x, originalPosition.y + y, originalPosition.z);
    }

    void OnDisable()
    {
        // Restaurar la posición original cuando el script o la cámara se desactiva
        transform.localPosition = originalPosition;
    }
}
