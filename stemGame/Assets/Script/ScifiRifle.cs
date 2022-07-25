using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScifiRifle : MonoBehaviour
{
    public static ScifiRifle Instace;
    public GameObject bullt;
    public GameObject special;
    public Transform bulltTran;

    public int currentNumber=1000;
    private int currentBullt = 1000;
    private float bulltTimerCd=0.1f;
    private float timer;

    void Start()
    {
        Instace = this;
    }

    void Update()
    {
        timer += Time.deltaTime;
        if(timer> bulltTimerCd&& currentNumber>0&& Input.GetMouseButton(0))
        {
            AudioManager.Instace.playAudio(GameManager.Instace.gameConfg.clip2);
            Instantiate(bullt, bulltTran.position, transform.rotation);
            Instantiate(special, bulltTran.position, transform.rotation);
            currentNumber--;
            timer = 0;
            if (currentNumber == 0)
            {
                AudioManagerS.Instance.playAudio(GameManager.Instace.gameConfg.clip3);
                GetComponent<Animator>().SetTrigger("Reload");
                Invoke("tradeBullt", 1.5f);
            }
            UI.Instace.bulltNumberFun(currentNumber);
        }
        if (Input.GetKeyDown(KeyCode.R))
        {   
            AudioManager.Instace.playAudio(GameManager.Instace.gameConfg.clip3);
            GetComponent<Animator>().SetTrigger("Reload");
            Invoke("tradeBullt", 1.5f);
        }
    }

    private void tradeBullt()
    {
        currentNumber = currentBullt;
        UI.Instace.bulltNumberFun(currentNumber);
    }
}
