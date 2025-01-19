using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour {
	
    public GameObject Player1;
    public GameObject Player2;

	
    public void EnablePlayer1()
    {
        Player2.SetActive(false);
        Player1.SetActive(true);
        if (Player1.transform.position.z!=0 || Player2.transform.position.z!=0)
        {
            Player1.transform.position = new Vector3(0f, 0f,Player2.transform.position.z+1000);
            Player2.transform.position = new Vector3(0f, 0f,Player2.transform.position.z+1000);
        }
    }


	public void EnablePlayer2()
    {
        Player1.SetActive(false);
        Player2.SetActive(true);
        if (Player1.transform.position.z!=0 || Player2.transform.position.z!=0)
        {
            Player2.transform.position = new Vector3(0f, 0f,Player1.transform.position.z+1000);
            Player1.transform.position = new Vector3(0f, 0f,Player1.transform.position.z+1000);
        }
    }


}
