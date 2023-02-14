using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float my_swim_speed = 0.01f;
    public float myHp = 100;
    public float myBodySize;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MySwim();
        myDestroy();
    }

    void MySwim()
    {
        if(Input.GetKey(KeyCode.A)) {
            this.transform.Translate(-1 * my_swim_speed,0f,0f);
        }
        if(Input.GetKey(KeyCode.D)) {
            this.transform.Translate(my_swim_speed,0f,0f);
        }
        if(Input.GetKey(KeyCode.W)) {
            this.transform.Translate(0f,my_swim_speed,0f);
        }
        if(Input.GetKey(KeyCode.S)) {
            this.transform.Translate(0f,-1 * my_swim_speed,0f);
        }
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        int enemyFishSize = collision.gameObject.GetComponent<EnemyFish>().enBodySize;
        if(this.myBodySize > enemyFishSize) {
            Destroy(collision.gameObject);
            myBodySize += enemyFishSize;
            Vector3 mySize;
            mySize = this.gameObject.transform.localScale;
            mySize.x += 0.05f;
            mySize.y += 0.05f;
            this.gameObject.transform.localScale = mySize;
        } else {
            this.myHp -= 0.1f;
        }
    }

    void myDestroy()
    {
        if(this.myHp <= 0) {
            Destroy(this.gameObject);
        }
    }
}
