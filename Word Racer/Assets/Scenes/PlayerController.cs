using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float forwardSpeed = 10f;
    public float laneDistance = 0f;
    public Text Type;
    public Text Total;
    public GameObject Checkpointpanel;
    int Num;
    Transform[] allTransforms;
    GameObject player;
    private AudioSource audioSource;

    void Start()
    {
        allTransforms = GetComponentsInChildren<Transform>();
        foreach (Transform t in allTransforms)
        {
            
            if (t.gameObject.activeInHierarchy)
            {
                player = t.gameObject;
                break;
            }
        }
        Num=0;
        forwardSpeed = 0f;
        laneDistance =player.transform.position.x;
        audioSource = GetComponent<AudioSource>();
        if (audioSource != null)
        {
    		audioSource.loop = true; 
            audioSource.Stop();
        }
    }

    void Update()
    {
        if (audioSource != null && forwardSpeed==0f )
        {
    		audioSource.loop = true; 
            audioSource.Stop();
        }
        if (Input.GetKeyDown(KeyCode.Space)&&audioSource != null)
            audioSource.Play();
        else if (Input.GetKeyUp(KeyCode.Space)&&audioSource != null)
            audioSource.Stop();
       player.transform.Translate(Vector3.forward * (Input.GetKey(KeyCode.Space) ? forwardSpeed * 2f : forwardSpeed) * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.LeftArrow))
            laneDistance = Mathf.Clamp(laneDistance - 10f, -10f, 10f);
        if (Input.GetKeyDown(KeyCode.RightArrow))
            laneDistance = Mathf.Clamp(laneDistance + 10f, -10f, 10f);

        Vector3 targetPosition = new Vector3(laneDistance,player.transform.position.y,player.transform.position.z);
       player.transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * 10f);
    }

    void OnCollisionEnter(Collision collision)
    {
        Num++;
        if (Num  % 10==0)
            CheckPoint();

        if (collision.gameObject.tag != "Player" && collision.gameObject.tag != "Car" )
        {
            Type.text = collision.gameObject.tag;
            Destroy(collision.gameObject);
        }
    }

    public void StartGame()
    {
        forwardSpeed = 25f;
    }

    public void CheckPoint(bool Click = true)
    {
        forwardSpeed = 0f;
        laneDistance = 0;
        Checkpointpanel.SetActive(true);
        Total.text = (Click) ? "You have collect " + (Num) + " new words." : "                      Quit ?";
    }
    
    public void EndGame()
    {
        Num=0;
        forwardSpeed = 0f;
        laneDistance = 0;
        player.transform.position = new Vector3(0f, 0f,player.transform.position.z+1000);
        Type.text = "";

    }
  
}
