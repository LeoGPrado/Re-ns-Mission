using UnityEngine;

public class canmbiarAudioSelectorGamplay : MonoBehaviour
{
    public AudioSource MusicaSelector;
    public GameObject MusicaGameplay;

    public void descativarSelectorMusica()
    {
        MusicaSelector.enabled = false;
        MusicaGameplay.SetActive(true);
    }
}
