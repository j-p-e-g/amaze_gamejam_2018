using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour
{
	static SoundManager m_instance = null;

	public AudioClip[] m_clickSounds;
	public AudioClip[] m_winSounds;
	public AudioClip[] m_loseSounds;
	public AudioClip[] m_errorSounds;

	private AudioSource m_audio;

	// Use this for initialization
	void Start ()
	{
		m_instance = this;
		m_audio = GetComponent<AudioSource>();
		if (!m_audio)
		{
			Debug.LogError("SoundManager has no audio source!");
		}
	}

	public static SoundManager getInstance()
	{
		return m_instance;
	}

    public void playClickSound()
	{
		if (m_audio && m_clickSounds.Length > 0)
		{
			m_audio.PlayOneShot(m_clickSounds[Random.Range(0, m_clickSounds.Length)]);
		}
	}

	public void playWinSound()
	{
		if (m_audio && m_winSounds.Length > 0)
		{
			m_audio.PlayOneShot(m_winSounds[Random.Range(0, m_winSounds.Length)]);
		}
	}

	public void playLoseSound()
	{
		if (m_audio && m_loseSounds.Length > 0)
		{
			m_audio.PlayOneShot(m_loseSounds[Random.Range(0, m_loseSounds.Length)]);
		}
	}

	public void playErrorSound()
	{
		if (m_audio && m_errorSounds.Length > 0)
		{
			m_audio.PlayOneShot(m_errorSounds[Random.Range(0, m_errorSounds.Length)]);
		}
	}
}
