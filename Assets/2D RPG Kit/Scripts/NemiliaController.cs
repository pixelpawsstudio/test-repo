using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NemiliaController : MonoBehaviour
{
    public Transform target; // El personaje principal
    public float followDistance = 2.0f; // Distancia a mantener detrás del personaje principal
    public float minDistance = 1.0f; // Distancia mínima antes de empezar a seguir
    public float delayTime = 0.5f; // Tiempo de espera antes de comenzar a seguir
    public float lerpSpeed = 2.0f; // Velocidad de interpolación para el movimiento suave
    public Animator animator;
    public float currentDistance;

    private bool isWaiting = false;
    private float waitTimer = 0.0f;

    private Vector3 lastPosition;
    private Vector3 currentPosition;



    private const float epsilon = 0.01f;

    private void Start()
    {
        target = GameObject.FindWithTag("Player").GetComponent<Transform>();
        lastPosition = transform.position;

    }

    void Update()
    {
        if (target != null)
        {
            currentPosition = transform.position;
            Vector3 targetPosition = target.position;
            Vector3 direction = (targetPosition - transform.position).normalized;
            currentDistance = Vector3.Distance(transform.position, target.position);

            //float dynamicLerpSpeed = lerpSpeed * (currentDistance / followDistance);
            if (currentDistance > followDistance + epsilon)
            {
                if (!isWaiting)
                {
                    // Moverse hacia el personaje principal de manera suave
                    Vector3 newPosition = Vector3.Lerp(transform.position, targetPosition - direction * followDistance, Time.deltaTime * lerpSpeed);
                    transform.position = new Vector3(newPosition.x, newPosition.y, transform.position.z);

                    animator.SetFloat("moveX", direction.x);
                    animator.SetFloat("moveY", direction.y);

                    animator.SetFloat("lastMoveX", direction.x);
                    animator.SetFloat("lastMoveY", direction.y);
                }
                else
                {
                    // Esperar a que pase el tiempo de espera antes de empezar a seguir
                    animator.SetFloat("moveX", 0);
                    animator.SetFloat("moveY", 0);
                    waitTimer += Time.deltaTime;
                    if (waitTimer >= delayTime)
                    {
                        isWaiting = false;
                        waitTimer = 0.0f;
                    }
                }
            }
            else if (currentDistance < minDistance)
            {
                // Si el personaje principal está demasiado cerca, activar el tiempo de espera
                animator.SetFloat("moveX", 0);
                animator.SetFloat("moveY", 0);
                isWaiting = true;
                waitTimer = 0.0f;
            }
            else
            {
                animator.SetFloat("moveX", 0);
                animator.SetFloat("moveY", 0);
            }

            // Actualizar la última posición
            lastPosition = currentPosition;
        }
    }

}
