using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorScript : MonoBehaviour
{
    public GameObject hazardPrefab;
    float spawnTime = 1.0f;
    float delta = 0f;

    void Update()
    {
        delta += Time.deltaTime;
        if (delta > spawnTime)
        {
            delta = 0f;
            GameObject ar = Instantiate(hazardPrefab);      // prefab에는 레퍼런스를 걸어놓을 수 없어서, UnassignedReferenceException이 뜬다
            float px = Random.Range(-8.4f, 8.4f);           // 따라서, HazardControl에서 Player 할당 방식을 바꿔야 함
            ar.transform.position = new Vector2 (px, 6f);
            spawnTime *= 0.95f;
        }
    }
    /*  내 힘만으로 짰던 코드
    public GameObject hazard;
    static float spawnDelay = 1;
    static int count = 0;
    static int delayCount = 0;
    
    void Start()
    {
        
    }

    void Update()
    {
        if (count++ > spawnDelay)
        {
            count = 0;
            if (delayCount++ > spawnDelay && spawnDelay > 3) { spawnDelay -= 1; }
            HazardSpawn();
        }
        /* if (Input.GetKeyDown(KeyCode.T)) {
            HazardSpawn();
        } *//*
    }

    void HazardSpawn()
    {
        System.Random rand = new System.Random();
        GameObject drop = GameObject.Instantiate(hazard, new Vector3((float)rand.NextDouble() * 20 - 10, 5.5f, 0), Quaternion.identity);
    }
    */
}
