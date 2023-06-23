using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TextTest : MonoBehaviour
{
    public int hp = 180;
    public Text textHpUI; // hp ui 
    public Text textStateUI; // state 
    // Start is called before the first frame update
    // void Start()
    // {
        
    // }

    // Update is called once per frame
    void Update()
    {
        textHpUI.text = hp.ToString();

        if (Input.GetMouseButtonDown(0)) // 마우스 왼쪽 버튼
        {
            hp += 10;
        }

        if (Input.GetMouseButtonDown(1)) // 마우스 오른쪼 버튼
        {
            hp -= 10;
        }

        if (hp <= 50)
       {
        textStateUI.text = "Run!";
       }
       else if (hp >= 200)
       {
        textStateUI.text = "Attack!";
       }
       else
       {
        textStateUI.text = "Defence!";
       }
    }
}
