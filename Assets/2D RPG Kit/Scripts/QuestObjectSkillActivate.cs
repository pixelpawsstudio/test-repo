
using UnityEngine;
using UnityEngine.Events;

public class QuestObjectSkillActivate : MonoBehaviour {
    
    [Tooltip("Choose the quest whose completion should be checked from the Quest Manager")]
    public string questToCheck;

    private bool initialCheckDone;


    public Skill skillToAdd;
    private bool skillAdded;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (!skillAdded)
        {
            CheckCompletion();
        }
        
        
	}

    public void CheckCompletion()
    {
        if(QuestManager.instance.CheckIfComplete(questToCheck))
        {
            Debug.Log("Se completo el quest de fusion");

            GameManager.instance.characterStatus.ForEach(character =>
            {
                if(character.characterName == "Ichop")
                {
                    character.AddSkill(skillToAdd);
                    skillAdded= true;
                }
            });


        }
       
    }

}
