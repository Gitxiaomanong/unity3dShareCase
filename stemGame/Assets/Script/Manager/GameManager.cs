using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instace;

    public GameConfg gameConfg;

    void Start()
    {
        Instace = this;
    }

    void Update()
    {
        
    }
}
