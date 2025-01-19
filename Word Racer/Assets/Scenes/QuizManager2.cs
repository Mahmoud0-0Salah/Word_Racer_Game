using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class QuizManager2 : MonoBehaviour {

	private string[] Words; 
	public Text Type;
	public Text Time;
	int ca =10;
	int cur =0;
	Coroutine timer;
    public GameObject Checkpointpanel;
    private AudioSource[] audioSource;
	public Image[] img;        
	public Sprite[] Aimg;   
    public Text Total;
	bool Hide = false;
	
	void Start()
	{
		Words = new string[] { "Frog", "Fish", "Eye", "Earth", "Duck", "Cow", "Bat", "Apple", "Fox" };
        audioSource = GetComponents<AudioSource>();
	
	}
	public void start()
	{
		timer = StartCoroutine(time());
		Type.text="";
	}
	public void Disp(int index)
	{
		if (!Hide)
			return;
		if (Words[cur].Equals(Words[index], StringComparison.OrdinalIgnoreCase))
		{
			audioSource[0].Play(); 
			img[index].sprite = Aimg[index];
			cur++;
		}
		else
			audioSource[1].Play(); 
	}

	IEnumerator time()
    {
		while (ca>0)
		{
			ca--;
   		    yield return new WaitForSeconds(1);
		}
    }

	void Update()
	{
		if (!Hide&& ca !=0)
		{
			Time.text = "Focus, champion! " + (ca / 60) + ":" + (ca % 60).ToString("D2");
			return;
		}
		//Debug.Log(cur);
		if (ca == 0  || cur ==9)
		{
			if (Hide)
				CheckPoint();
			else
			{
				hide();
				Hide =true;
				ca=120;
			}
		}
		Type.text = Words[cur];
		Time.text = "Remaining time " + (ca / 60) + ":" + (ca % 60).ToString("D2");
	}

	public void CheckPoint()
    {
		StopCoroutine(timer);
		if (ca!=0)
			Total.text = "Great work!";
        else
			Total.text = "Time end";
		Checkpointpanel.SetActive(true);
		ca=10;
		cur = 0;
		Hide=false;
    }

	void hide()
	{
		foreach (var image in img)
		{
			image.sprite = img[9].sprite; 
		}
	
	}

}
