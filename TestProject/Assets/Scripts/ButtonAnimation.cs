using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonAnimation : MonoBehaviour
{
    Vector3 position = new Vector3(-300.0f,100.0f,0f);
    Vector3 currentPos = new Vector3();
    RectTransform rect;
    // Start is called before the first frame update
    void Start()
    {
        rect = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveButton();
    }

    void MoveButton()
    {
        if(rect.localPosition.x <= -300.0f) {
            return;
        }
        rect.localPosition += new Vector3(-2f,0f,0f);
    }
}
