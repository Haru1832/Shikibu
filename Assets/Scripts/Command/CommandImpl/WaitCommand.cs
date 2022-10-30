using System;
using System.Collections;
using System.Collections.Generic;
using Command;
using UnityEngine;
using UnityEngine.UI;
using ICommand = Command.ICommand;

public class WaitCommand : ICommand
{
    public override void Setup(UIObjectManager objectManager)
    {
    }


    public IEnumerator Wait(int time)
    {
        yield return new WaitForSeconds(time);
    }

}
