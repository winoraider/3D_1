using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] GameObject obstacleprefab;
    Vector3 spawnPos = new Vector3(25,0,0);
    float elapsedTime;
    PlayerController2 playerControllerScript;
    // Start is called before the first frame update
    void Start()
    {
      playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController2>();
    }

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;
        if(elapsedTime > 2.0f && !playerControllerScript.gameOver)
        {
            elapsedTime = 0.0f;
            Instantiate(obstacleprefab, spawnPos, obstacleprefab.transform.rotation);
        }
    }
}
