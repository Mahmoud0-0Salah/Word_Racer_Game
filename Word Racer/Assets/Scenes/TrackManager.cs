using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackManager : MonoBehaviour
{
    public GameObject[] trackPrefabs;           
    public GameObject[] Fruits;         
    public GameObject[] Nums;         
    private List<GameObject> activeTracks = new List<GameObject>();
    private List<GameObject> objPrefabs = new List<GameObject>();
    private static List<GameObject> activeobj = new List<GameObject>();
    public Transform playerTransform;
    public Transform playerTransform1;
    public Transform playerTransform2;
    public float trackLength = 30f;            
    public float objSpawnRate = 0.2f;       

    private float[] lanePositions = { 10f, 0f, -10f }; 


    void Update()
    {
        playerTransform = (playerTransform1.gameObject.activeInHierarchy)? playerTransform1:playerTransform2;
        if (playerTransform.position.z + 100 > activeTracks[activeTracks.Count - 1].transform.position.z || playerTransform.position.z + 10 < activeTracks[0].transform.position.z)
        {
            Destroy(activeTracks[0]);
            activeTracks.RemoveAt(0);
            SpawnTrack();
        }
    }
    void SpawnTrack()
    {
        GameObject track = Instantiate(trackPrefabs[Random.Range(0, trackPrefabs.Length)]);
        //Destroy(track,10);
        
        float spawnZPosition = 0f; 

        if (activeTracks.Count > 0)
        {
            if (playerTransform.position.z + 100 < activeTracks[0].transform.position.z)
                spawnZPosition = playerTransform.position.z + trackLength - 100; 
            else
                spawnZPosition = activeTracks[activeTracks.Count - 1].transform.position.z + trackLength;
        }
        else
        {
            spawnZPosition = playerTransform.position.z + trackLength - 100; 
        }

        track.transform.position = new Vector3(7.206063f, 0, spawnZPosition);
        activeTracks.Add(track);

        if (Random.value < objSpawnRate)
        {
            SpawnObj(spawnZPosition);
        }
    }

    void SpawnObj(float trackZPosition)
    {
        GameObject Obj = Instantiate(objPrefabs[Random.Range(0, objPrefabs.Count)]);
        Destroy(Obj,7);

        float lanePositionX = lanePositions[Random.Range(0, lanePositions.Length)];

        activeobj.Add(Obj);

        Obj.transform.position = new Vector3(lanePositionX, 2f, trackZPosition + Random.Range(-10f, 10f));

    }


    public void DestroyObj()
    {
        for (int i=0 ;i<activeobj.Count;i++)
        {
            Destroy(activeobj[i]);
           // Debug.Log("DDDDDDDDDDDDDDDDDDDDDd");
            activeobj.RemoveAt(i);  
        }
        objPrefabs.Clear();
    }

    public void Fruit()
    {
        objPrefabs.Clear();
        foreach (var i in Fruits)
        {
            objPrefabs.Add(i);
        }
        objSpawnRate = .5f;
        if (activeTracks.Count!=0)
             return;
        for (int i = 0; i < trackPrefabs.Length; i++)
        {
            activeTracks.Add(trackPrefabs[i]);
            SpawnTrack();
        }
    }

    public void Num()
    {
        objPrefabs.Clear();
        foreach (var i in Nums)
        {
            objPrefabs.Add(i);
        }
        objSpawnRate = .5f;
        if (activeTracks.Count!=0)
             return;
        for (int i = 0; i < trackPrefabs.Length; i++)
        {
            activeTracks.Add(trackPrefabs[i]);
            SpawnTrack();
        }
    }
}
