using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelManager : MonoBehaviour
{
    public GameObject Startpanel;
    public GameObject Checkpointpanel;
    public GameObject MainMneu;
    public GameObject ChooseCharacter;
    public GameObject EnglishAlphabet;
    public GameObject QuizType;
    public GameObject Quiz;
    public GameObject Quiz2;
    public GameObject QuizDiff;
    public GameObject EndQuiz;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void PlaySound()
    {
		audioSource.Play(); 
    }

    public void DisableStart()
    {
        Startpanel.SetActive(false);
        PlaySound();
    }

    public void EnableStart()
    {
        Startpanel.SetActive(true);
        PlaySound();
    }

    public void DisableCheckpoint()
    {
        Checkpointpanel.SetActive(false);
        PlaySound();
    }

    public void EnableCheckpoint()
    {
        Checkpointpanel.SetActive(true);
        PlaySound();
    }

    public void DisableMainMneu()
    {
        MainMneu.SetActive(false);
        PlaySound();
    }

    public void EnableMainMneu()
    {
        MainMneu.SetActive(true);
        PlaySound();
    }

    public void DisableMainChooseCharacter()
    {
        ChooseCharacter.SetActive(false);
        PlaySound();
    }

    public void EnableMainChooseCharacter()
    {
        ChooseCharacter.SetActive(true);
        PlaySound();
    }

    public void DisableEnglishAlphabet()
    {
        EnglishAlphabet.SetActive(false);
        PlaySound();
    }

    public void EnableEnglishAlphabet()
    {
        EnglishAlphabet.SetActive(true);
        PlaySound();
    }

    public void DisableQuizType()
    {
        QuizType.SetActive(false);
        PlaySound();
    }

    public void EnableQuizType()
    {
        QuizType.SetActive(true);
        PlaySound();
    }

    public void DisableQuiz()
    {
        Quiz.SetActive(false);
        PlaySound();
    }

    public void EnableQuiz()
    {
        Quiz.SetActive(true);
        PlaySound();
    }

    public void DisableQuiz2()
    {
        Quiz2.SetActive(false);
        PlaySound();
    }

    public void EnableQuiz2()
    {
        Quiz2.SetActive(true);
        PlaySound();
    }

    public void DisableEndQuiz()
    {
        EndQuiz.SetActive(false);
        PlaySound();
    }

    public void EnableEndQuiz()
    {
        EndQuiz.SetActive(true);
        PlaySound();
    }

    public void DisableQuizDiff()
    {
        QuizDiff.SetActive(false);
        PlaySound();
    }

    public void EnableQuizDiff()
    {
        QuizDiff.SetActive(true);
        PlaySound();
    }
}
