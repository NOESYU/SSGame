using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject starPrefab;
    public GameObject star2Prefab;
    public int cnt = 10;

    public float timeBetSpawnMin = 1.5f;
    public float timeBetSpawnMax = 2.5f;
    private float timeBetSpawn;

    public float superSpawnMin = 10f;
    public float superSpawnMax = 50f;
    public float superBetSpawn;

    public float yMin = -4.5f;
    public float yMax = 4.5f;

    private float xPos = 20f;

    private GameObject[] stars;
    private GameObject stars2;

    private int currentIndex = 0;

    private Vector2 poolPosition = new Vector2(0, 25);
    private float lastSpawnTime;
    private float lastSpawnTime2;

    private void Start()
    {
        stars = new GameObject[cnt];
        for (int i = 0; i < cnt; i++)
        {
            stars[i] = Instantiate(starPrefab, poolPosition, Quaternion.identity);
        }

        stars2 = Instantiate(star2Prefab, poolPosition, Quaternion.identity);
    }

    private void Update()
    {
        if (GameManager.instance.isGameover)
        {
            return;
        }

        //일반별
        if (Time.time >= lastSpawnTime + timeBetSpawn)
        {
            lastSpawnTime = Time.time;

            timeBetSpawn = Random.Range(timeBetSpawnMin, timeBetSpawnMax);

            float yPos = Random.Range(yMin, yMax);

            stars[currentIndex].transform.position = new Vector2(xPos, yPos);
            stars[currentIndex].SetActive(true);
            currentIndex++;

            if (currentIndex >= cnt)
            {
                currentIndex = 0;
            }
        }
        //슈퍼별
        if(Time.time >= lastSpawnTime2 + superBetSpawn)
        {
            lastSpawnTime2 = Time.time;

            superBetSpawn = Random.Range(superSpawnMin, superSpawnMax);

            float yPos = Random.Range(yMin, yMax);

            stars2.transform.position = new Vector2(xPos, yPos);
            stars2.SetActive(true);
        }
        
    }
}
