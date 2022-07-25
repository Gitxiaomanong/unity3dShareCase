using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemy : MonoBehaviour
{
    public static enemy Instace;
    private Slider slider;

    public AudioClip[] audios;

    private int index=0;

    private int timerIndex;
        
    void Start()
    {
        Instace = this;

        slider = transform.Find("Canvas/Slider").GetComponent<Slider>();

        index = 0;
    }

    void Update()
    {
    }

    public void startHp(float number, GameObject gameObject)
    {
        slider.value -= number / 100;
        if (slider.value <= 0)
        {
            AudioManager.Instace.playAudio(GameManager.Instace.gameConfg.clip4);
            Die(gameObject);
            index++;
            repeatedlyFun(index);
        }
    }

    public void Die(GameObject gameObject)
    {
        Destroy(gameObject);
    }

    public void repeatedlyFun(int index)
    {
        index = 0;
        AudioManagerS.Instance.playAudio(this.audios[index]);
    }

}
