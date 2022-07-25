using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public static UI Instace;
    public Text bulltNumber;

    void Start()
    {
        Instace = this;
        bulltNumberFun(ScifiRifle.Instace.currentNumber);
    }

    void Update()
    {
        
    }

    public void bulltNumberFun(int number)
    {
        bulltNumber.text = "子弹数量:" + number;
    }
}
