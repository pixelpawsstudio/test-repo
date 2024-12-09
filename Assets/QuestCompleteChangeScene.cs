using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class QuestCompleteChangeScene : MonoBehaviour
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

    private bool initialCheckDone;

    public UnityEvent onActivate;

    // Use this for initialization
    void Start()
    {
        if (!initialCheckDone)
        {
            initialCheckDone = true;

            CheckCompletion();
        }
    }

    // Update is called once per frame
    void Update()
    {
       

       CheckCompletion();
        
    }

    public void CheckCompletion()
    {
        if (QuestManager.instance.CheckIfComplete(questToCheck))
        {
            Debug.Log("Quest completed");
            if (waitBeforeActivate)
            {
                StartCoroutine(waitCo());
            }
            else
            {
                //ScreenFade.instance.FadeToBlack();
                transitionTime -= Time.deltaTime;
                if (transitionTime <= 0)
                {
                    //PlayerController.instance.transform.position = newPosition;
                    SceneManager.LoadScene(scene);

                }
            }

        }
    }

    IEnumerator waitCo()
    {
        yield return new WaitForSeconds(waitTime);
        //ScreenFade.instance.FadeToBlack();
        transitionTime -= Time.deltaTime;
        if (transitionTime <= 0)
        {
            //PlayerController.instance.transform.position = newPosition;
            SceneManager.LoadScene(scene);

        }
    }
}
