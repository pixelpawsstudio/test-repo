using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class AquaCrystalChecker : MonoBehaviour
{
    public Item itemToCheck;

    public bool gotItem;

    public UnityEvent itemMissing;
    public UnityEvent itemAvailable;
    public GameObject defaultDialogue;
    public GameObject crystalDialogue;
    public GameObject postCrytaslDialogue;
    

    private void Start()
    {
        
    }

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
                    
                        break;
                    }

                    
                }
            }

            if (gotItem && !QuestManager.instance.completedQuests[13])
            {
                Debug.Log("Tienes el cristal aqua, aún no se completa el quest, desactiva el dialogo default, activa el dialogo del cristal");
                defaultDialogue.SetActive(false);
                crystalDialogue.SetActive(true);
                postCrytaslDialogue.SetActive(false);
                itemAvailable?.Invoke();
            }
            else if(gotItem && QuestManager.instance.completedQuests[13])
            {
                defaultDialogue.SetActive(false);
                crystalDialogue.SetActive(false);
                postCrytaslDialogue.SetActive(true);
                Debug.Log("Tienes el cristal aqua, ya se completo el quest, activa el dialogo post quest");
                itemAvailable?.Invoke();
            }
            else
            {
                Debug.Log("No has conseguido el cristal, deja el dialogo default");
                defaultDialogue.SetActive(true);
                crystalDialogue.SetActive(false);
                postCrytaslDialogue.SetActive(false);
                itemMissing?.Invoke();
            }

           
        }
    }
}
