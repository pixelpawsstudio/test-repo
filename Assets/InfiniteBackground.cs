using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfiniteBackground : MonoBehaviour
{
    public float speed = 2f;  // Velocidad a la que se mueve el fondo
    public GameObject[] backgrounds;  // Array de sprites del fondo

    private float spriteWidth;  // Ancho de un sprite

    void Start()
    {
        // Asume que todos los sprites tienen el mismo ancho
        spriteWidth = backgrounds[0].GetComponent<SpriteRenderer>().bounds.size.x;
    }

    void Update()
    {
        // Mover cada sprite hacia la izquierda
        foreach (GameObject background in backgrounds)
        {
            background.transform.Translate(Vector2.left * speed * Time.deltaTime);

            // Si el sprite sale completamente de la pantalla, lo reposiciona al final
            if (background.transform.position.x < -spriteWidth)
            {
                RepositionBackground(background);
            }
        }
    }

    void RepositionBackground(GameObject background)
    {
        // Encuentra el sprite más a la derecha
        GameObject rightmostBackground = backgrounds[0];
        foreach (GameObject bg in backgrounds)
        {
            if (bg.transform.position.x > rightmostBackground.transform.position.x)
            {
                rightmostBackground = bg;
            }
        }

        // Reposiciona el sprite al final de la secuencia
        float newX = rightmostBackground.transform.position.x + spriteWidth;
        background.transform.position = new Vector3(newX, background.transform.position.y, background.transform.position.z);
    }
}
