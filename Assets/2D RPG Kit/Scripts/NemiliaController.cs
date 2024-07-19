using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NemiliaController : MonoBehaviour
{
    public Transform target; // El personaje principal
    public float distance = 2.0f; // Distancia a mantener detrás del personaje principal
    private void Start()
    {
        target = GameObject.FindWithTag("Player").GetComponent<Transform>();
    }

    void Update()
    {
        if (target != null)
        {
            Vector3 targetPosition = target.position;
            Vector3 direction = (targetPosition - transform.position).normalized;
            Vector3 newPosition = targetPosition - direction * distance;

            transform.position = new Vector3(newPosition.x, newPosition.y, transform.position.z);
        }
    }

}
