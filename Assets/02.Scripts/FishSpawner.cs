using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject fishPrefab;
    public int cnt = 5;

    public float timeBetSpawnMin = 0.5f;
    public float timeBetSpawnMax = 1.5f;
    private float timeBetSpawn;

    public float yMin = -4.5f;
    public float yMax = 4.5f;
    private float xPos = 20f;

    private GameObject[] fishes;

    private int currentIndex = 0;

    private Vector2 poolPosition = new Vector2(0, 25);
    private float lastSpawnTime;

    private void Start()
    {
        fishes = new GameObject[cnt];
        
        for(int i = 0; i < cnt; i++)
        {
            fishes[i] = Instantiate(fishPrefab, poolPosition, Quaternion.identity);
        }
    }

    private void Update()
    {
        if (GameManager.instance.isGameover)
        {
            return;
        }

        if(Time.time >= lastSpawnTime + timeBetSpawn)
        {
            lastSpawnTime = Time.time;

            timeBetSpawn = Random.Range(timeBetSpawnMin, timeBetSpawnMax);

            float yPos = Random.Range(yMin, yMax);

            fishes[currentIndex].transform.position = new Vector2(xPos, yPos);
            currentIndex++;

            if (currentIndex >= cnt)
            {
                currentIndex = 0;
            }
        }
    }
}
