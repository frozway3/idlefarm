using System.Collections;
using UnityEngine;

public class SoundsController : MonoBehaviour
{
    [SerializeField] AudioSource onClickAudio, BGAudio;
    [SerializeField] AudioClip[] BGMusic;
    private void Start()
    {
        StartCoroutine(PlayBGMusic());
    }
    public void Click(AudioClip clip)
    {
        onClickAudio.PlayOneShot(clip);
    }
    public void RandomMusic()
    {
        BGAudio.clip = BGMusic[Random.Range(0, BGMusic.Length)];
    }
    IEnumerator PlayBGMusic()
    {
        while (true)
        {
            BGAudio.Stop();
            RandomMusic();
            BGAudio.Play();
            yield return new WaitForSeconds(24);
        }
    }
}
