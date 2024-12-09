using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PuzzleSceneChecker : MonoBehaviour
{
    public GameObject nemilia;
    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene().name.Contains("Puzzle")) {
            nemilia.SetActive(false);
        } else if(!SceneManager.GetActiveScene().name.Contains("Puzzle") && !nemilia.activeInHierarchy)
        {
            nemilia.SetActive(true);
        }
    }
}
