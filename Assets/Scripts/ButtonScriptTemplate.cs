using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonScriptTemplate : MonoBehaviour
{
    
    void Start() // iki farklı script kullanmak yerine farklı bir şekilde yaklaşmak istedim.
    {
        GetComponent<Button>().onClick.AddListener(StartGame);
    }

    public virtual void StartGame()
    {
        
    }
}
