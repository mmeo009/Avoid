using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scenee : MonoBehaviour
{
    public bool isTrue;     //제대로 갔나염?

    public int sscene;   //씬 랜덤

    public int exit = 0;                        //출구
    public TMP_Text dayText;                    //출구 나오는 채팅

    void Start()
    {
        sscene = Random.Range(0, 1);
        SceneManager.LoadScene(sscene);      
    }

    void Update()
    {
        if (isTrue == true)                      //맞췄을 때
        {
            exit++;                             //출구 번호 +1
            dayText.text = exit.ToString(exit + "Days");
        }

        else if (isTrue == false)              //틀렸을 때
        {
            exit = 0;                           //출구 번호 0번. (초기화)
            dayText.text = exit.ToString(exit + "Days");
        }
    }

    public void Exit()
    {
        Scene nowscene = SceneManager.GetActiveScene();
            if (nowscene.buildIndex == 1)                       
            {
                //아이템이랑 닿는 부분은 플레이어에 넣어야 할 것 같아여ㅓ..
            }
    }
}
