using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GateKeyChecker : MonoBehaviour
{
    public Item itemToCheck;

    public bool gotItem;

    public UnityEvent itemMissing;
    public UnityEvent itemAvailable;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (!gotItem)
            {
                for (int i = 0; i < GameManager.instance.itemsHeld.Length; i++)
                {
                    if (GameManager.instance.itemsHeld[i] == itemToCheck.itemName)
                    {
                        gotItem = true;
                        Debug.Log("Tienes la llave, puedes usar la puerta");
                        break;
                    }

                    Debug.Log("No has conseguido la llave, no es posible abrir la puerta");
                }
            }

            if (gotItem)
            {
                itemAvailable?.Invoke();
            }
            else
            {
                itemMissing?.Invoke();
            }
        }
    }
        
}
