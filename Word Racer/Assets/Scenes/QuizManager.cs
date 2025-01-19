using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class QuizManager : MonoBehaviour {

	public Sprite[] Numbers;        
	public Sprite[] Words;        
    private List<Sprite> objPrefabs = new List<Sprite>();
	public Image img;
	public Text text;
	public Text Time;
	public int index;
	public InputField  inputField;
    public GameObject Checkpointpanel;
    public Text Total;
	private int score =0;
	int ca =180;
	Coroutine timer;
    private AudioSource[] audioSource;
	
	void Start()
	{
        audioSource = GetComponents<AudioSource>();
	}

    public void Nums()
    {
        objPrefabs.Clear();
        foreach (var i in Numbers)
        {
            objPrefabs.Add(i);
        }

	}

    public void words()
    {
        objPrefabs.Clear();
        foreach (var i in Words)
        {
            objPrefabs.Add(i);
        }

	}

	public void start()
	{
		ca=180;
		index =0;
		img.sprite = objPrefabs[0];
		timer = StartCoroutine(time());
	}
	void Update()
	{
		if (ca == 0 )
			CheckPoint();
		Time.text = "Remaining time " + (ca / 60) + ":" + (ca % 60).ToString("D2");
	}
	public void OnSubmit()
    {
        var userInput = inputField.text;

		if (userInput == null || userInput.Trim() == "")
			return;
			
		if (userInput.Equals(objPrefabs[index].name, StringComparison.OrdinalIgnoreCase))
		{
			audioSource[0].Play(); 
			score++;
		}
		else
			audioSource[1].Play(); 
			
		text.text= "Your score is " + score;
		if (index==8)
		{
			CheckPoint();
		}
		index++;
		img.sprite = objPrefabs[index];
		inputField.text = "";
    }

	public void CheckPoint()
    {
		StopCoroutine(timer);
        Checkpointpanel.SetActive(true);
        Total.text = "Your score is " + score;
		score =0;
		ca=180;
		text.text="";
		index=0;
		img.sprite = objPrefabs[index];
    }


	IEnumerator time()
    {
		while (ca>0)
		{
			ca--;
   		    yield return new WaitForSeconds(1);
		}
    }
}
