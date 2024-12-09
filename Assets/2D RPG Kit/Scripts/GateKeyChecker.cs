using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class GateKeyChecker : MonoBehaviour
{
    public Item itemToCheck;

    public bool gotItem;

    public UnityEvent itemMissing;
    public UnityEvent itemAvailable;
    public Transform closeGate;
    public Transform openGate;

    private void Start()
    {
        closeGate = gameObject.transform.Find("CloseGate");
        openGate = gameObject.transform.Find("OpenGate");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (!gotItem)
            {
                for (int i = 0; i < GameManager.instance.itemsHeld.Length; i++)
                {
                    GameMenu.instance.decisionMessage.SetActive(true);
                    if (GameManager.instance.itemsHeld[i] == itemToCheck.itemName)
                    {
                        gotItem = true;    
                    
                        break;
                    }

                    
                }
            }

            if (gotItem)
            {
                Debug.Log("Tienes la llave, puedes usar la puerta");
                GameMenu.instance.decisionText.text = "Tienes la llave, ¿deseas abrir la puerta?";
                GameMenu.instance.decisionNo.gameObject.SetActive(true);
                GameMenu.instance.decisionYes.gameObject.SetActive(true);
                itemAvailable?.Invoke();
            }
            else
            {
                Debug.Log("No has conseguido la llave, no es posible abrir la puerta");
                GameMenu.instance.decisionText.text = "No has conseguido la llave aún,\n no es posible abrir la puerta";
                GameMenu.instance.decisionNo.gameObject.SetActive(false);
                GameMenu.instance.decisionYes.gameObject.SetActive(false);
                itemMissing?.Invoke();
            }

            GameMenu.instance.decisionMessage.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        GameMenu.instance.decisionMessage.SetActive(false);
    }

    public void OpenGate()
    {
        Debug.Log("Abriendo la puerta");
        closeGate.gameObject.SetActive(false);
        openGate.gameObject.SetActive(true);
        
        GameMenu.instance.decisionMessage.SetActive(false);
    }
}
