using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scenee : MonoBehaviour
{
    public bool isTrue;     //����� ������?

    public int sscene;   //�� ����

    public int exit = 0;                        //�ⱸ
    public TMP_Text dayText;                    //�ⱸ ������ ä��

    void Start()
    {
        sscene = Random.Range(0, 1);
        SceneManager.LoadScene(sscene);      
    }

    void Update()
    {
        if (isTrue == true)                      //������ ��
        {
            exit++;                             //�ⱸ ��ȣ +1
            dayText.text = exit.ToString(exit + "Days");
        }

        else if (isTrue == false)              //Ʋ���� ��
        {
            exit = 0;                           //�ⱸ ��ȣ 0��. (�ʱ�ȭ)
            dayText.text = exit.ToString(exit + "Days");
        }
    }

    public void Exit()
    {
        Scene nowscene = SceneManager.GetActiveScene();
            if (nowscene.buildIndex == 1)                       
            {
                //�������̶� ��� �κ��� �÷��̾ �־�� �� �� ���ƿ���..
            }
    }
}
