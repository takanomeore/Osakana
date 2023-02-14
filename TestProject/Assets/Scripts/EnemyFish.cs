using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFish : MonoBehaviour
{
    public float enfish_swim_speed = -0.01f;
    public int enBodySize;

    bool isChangeSpeed = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        EnemyFishSwim();
    }

    void EnemyFishSwim()
    {
        if(this.tag == "Left" && isChangeSpeed) {
            enfish_swim_speed *= -1;
            this.transform.localScale = new Vector3(-1,1,1);
            isChangeSpeed = false;
        }
        this.transform.Translate(enfish_swim_speed,0f,0f);
    }
}
