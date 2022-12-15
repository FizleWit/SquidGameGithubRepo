using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class SpawnPalyers : MonoBehaviour
{
    public GameObject playerPrefab;

    public float minX; //-9
    public float maxX; //9
    public float minZ; //-16f
    public float maxZ; //-12f


    // Start is called before the first frame update
    void Start()
    {
        Vector3 randomPosition = new Vector3(Random.Range(minX,maxX),1.5f, Random.Range(minZ,maxZ));
        PhotonNetwork.Instantiate(playerPrefab.name, randomPosition, Quaternion.identity);

    }

    // Update is called once per frame
   
}
