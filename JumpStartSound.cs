using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class JumpStartSound : MonoBehaviour
{
    [SerializeField] AudioClip[] audioClip;

    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void JumpStart()
    {
        AudioClip clip = GetRandomClip();
        audioSource.PlayOneShot(clip);
    }

    private AudioClip GetRandomClip()
    {
        int index = Random.Range(0, audioClip.Length - 1);
        return audioClip[index];
    }
}
