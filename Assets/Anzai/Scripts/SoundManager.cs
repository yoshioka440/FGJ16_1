using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class SoundManager : MonoBehaviour {

    private AudioSource m_AudioSource;
    public AudioClip[] sound;
	public AudioClip[] bgm;

	// Use this for initialization
	void Start () {
        m_AudioSource = GetComponent<AudioSource>();
        m_AudioSource.loop = true;
	}
	
    public void SoundRings(int value)
    {
        m_AudioSource.PlayOneShot(sound[value]);
    }
		
}
