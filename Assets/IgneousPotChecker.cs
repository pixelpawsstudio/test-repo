using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class IgneousPotChecker : MonoBehaviour
{
    
    [Tooltip("Choose the quest whose completion should be checked from the Quest Manager")]
    public string questToCheck;
   
    [Tooltip("Activate a delay before the activation")]
    public bool waitBeforeActivate;
    [Tooltip("Enter the duration for the delay in seconds")]
    public float waitTime;
    [Tooltip("Enter the duration of transition to the new scene in seconds")]
    public float transitionTime = 1f;
    [Tooltip("Enter the scene name")]
    public string scene;
    [Tooltip("Enter the dialogue")]
    public GameObject dialogue;


    private bool initialCheckDone;

    public UnityEvent onActivate;

    public Item itemToCheck;

    public bool gotItem;

    public UnityEvent itemMissing;
    public UnityEvent itemAvailable;

    // Update is called once per frame
    void Update()
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

        if (gotItem)
        {
            itemAvailable?.Invoke();
        }
        else
        {
            dialogue.SetActive(true);
            itemMissing?.Invoke();
        }
    }   
}
