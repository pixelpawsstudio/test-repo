using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using static System.TimeZoneInfo;

public class QuestCompleteChangeScene : MonoBehaviour
{
    [Tooltip("Drag and drop the game object that should be activated or deactivated")]
    public GameObject objectToActivate;
    [Tooltip("Choose the quest whose completion should be checked from the Quest Manager")]
    public string questToCheck;
    [Tooltip("Activate the game object when the chosen quest was completed. Leave unchecked if you want to deactivate the game object instead")]
    public bool activeIfComplete;
    [Tooltip("Activate a delay before the activation")]
    public bool waitBeforeActivate;
    [Tooltip("Enter the duration for the delay in seconds")]
    public float waitTime;
    [Tooltip("Enter the duration of transition to the new scene in seconds")]
    public float transitionTime = 1f;
    [Tooltip("Enter the scene name")]
    public string scene;

    private bool initialCheckDone;

    public UnityEvent onActivate;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!initialCheckDone)
        {
            initialCheckDone = true;

            CheckCompletion();
        }
    }

    public void CheckCompletion()
    {
        if (QuestManager.instance.CheckIfComplete(questToCheck))
        {
            if (waitBeforeActivate)
            {
                StartCoroutine(waitCo());
            }
            else
            {
                objectToActivate.SetActive(activeIfComplete);
            }

        }
    }

    IEnumerator waitCo()
    {
        yield return new WaitForSeconds(waitTime);
        ScreenFade.instance.FadeToBlack();
        transitionTime -= Time.deltaTime;
        if (transitionTime <= 0)
        {
            //PlayerController.instance.transform.position = newPosition;
            SceneManager.LoadScene(scene);

        }
    }
}
