using System.Collections;
using System.Collections.Generic;
using Command;
using UnityEngine;

[RequireComponent(typeof(UIObjectManager))]
public class CommandManager : MonoBehaviour
{
    [SerializeField] private UIObjectManager UIObjectManager;
    
    private AdvCommandList _advCommandList;
    
    private void Awake()
    {
        _advCommandList = new AdvCommandList(UIObjectManager);
        CommandExecutor.Initialize(_advCommandList);
    }
}
