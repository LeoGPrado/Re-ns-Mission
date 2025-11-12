using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CinematicController : MonoBehaviour
{
    [SerializeField] private VideoPlayer videoPlayer;
    [SerializeField] private Button saltarCinematica;
    [SerializeField] private string siguienteEscena = "escena";
    void Start()
    {
        videoPlayer.loopPointReached += AlTerminarVideo;

        if (saltarCinematica != null)
            saltarCinematica.onClick.AddListener(SaltarVideo);
    }

    void AlTerminarVideo(VideoPlayer vp)
    {
        LoadNextScene();
    }

    public void SaltarVideo()
    {
        LoadNextScene();
    }

    void LoadNextScene()
    {
        SceneManager.LoadScene(siguienteEscena);
    }
}