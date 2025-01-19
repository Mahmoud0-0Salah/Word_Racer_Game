using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LettersManager : MonoBehaviour {
   
    public Sprite[] Letters;         
	public Image img;
    private AudioSource[] audioSource;

	void Start()
	{
        audioSource = GetComponents<AudioSource>();
	}
	public void ch(int index)
	{
        img.gameObject.SetActive(true);
		img.sprite = Letters[index];
		audioSource[index].Play(); 
	}

	public void close()
	{
        img.gameObject.SetActive(false);
	}
}
