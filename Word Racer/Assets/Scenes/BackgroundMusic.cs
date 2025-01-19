using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
public class BackgroundMusic : MonoBehaviour {

	private AudioSource audioSource;
    public Sprite[] States;         
	public Image img;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
		audioSource.loop = true; 
        audioSource.Play(); 
    }

    public void ToggleMusic()
    {
        if (audioSource.isPlaying)
        {
            audioSource.Pause();
            img.sprite = States[1];
        }
        else
        {
            audioSource.Play();
            img.sprite = States[0];
        }
    }
}
