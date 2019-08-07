using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAgainButton : ButtonScriptTemplate
{
    public override void StartGame()
    {
        SceneLoader.StartScene();
    }
}
