using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    [SerializeField] GameObject[] Fishes = new GameObject[5];
    GameObject Fish;

    Vector3 SpawnPoint = new Vector3();

    float[] spawnPoint_x = {12.0f,-12.0f};

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("FishGenerate");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator FishGenerate()
    {
        int random = Random.Range(0,5);
        float spawnPointY = Random.Range(-4.0f,4.0f);
        int spawnPointX = Random.Range(0,2);
        SpawnPoint =  new Vector3(spawnPoint_x[spawnPointX],spawnPointY,0f);
        this.Fish = Instantiate(Fishes[random],SpawnPoint,Quaternion.identity);
        if(spawnPointX == 0) {
            Fish.tag = "Right";
        } else {
            Fish.tag = "Left";
        }

        yield return new WaitForSeconds(3);

        StartCoroutine("FishGenerate");
    }
}
