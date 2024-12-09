using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class VideoEndChangeScene : MonoBehaviour
{
    public string sceneName;  // El nombre de la escena a la que quieres cambiar

    void Start()
    {
        // Obtén el componente VideoPlayer y agrega un listener al evento loopPointReached
        VideoPlayer videoPlayer = GetComponent<VideoPlayer>();
        videoPlayer.loopPointReached += OnVideoEnd; // Se suscribe al evento
    }

    void OnVideoEnd(VideoPlayer vp)
    {
        // Cambia a la escena especificada cuando el video termine
        SceneManager.LoadScene(sceneName);
    }
}
