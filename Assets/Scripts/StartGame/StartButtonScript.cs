using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartButtonScript : ButtonScriptTemplate
{


    public override void StartGame()
    {
        SceneLoader.LoadScene();
    }

}
