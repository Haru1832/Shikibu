using System;
using System.Collections;
using Command.CommandImpl;
using UnityEngine;
using XLua;

namespace Command
{
    public class CommandExecutor
    {
        private static AdvCommandList _commandList;

        public static void Initialize(AdvCommandList commandList)
        {
            _commandList = commandList;
        }
        

[LuaCallCSharp]
public static void DisplayCharacter(System.String name,System.Single x,System.Single y)
{
    DisplayCharacterCommand command = (DisplayCharacterCommand)_commandList.GetCommandOfType<DisplayCharacterCommand>();
    command.Display(name,x,y);
}
[LuaCallCSharp]
public static void DeleteCharacterImage(System.String characterName)
{
    DisplayCharacterCommand command = (DisplayCharacterCommand)_commandList.GetCommandOfType<DisplayCharacterCommand>();
    command.DeleteCharacterImage(characterName);
}
[LuaCallCSharp]
public static void DisplayItem(System.String name,System.Single x,System.Single y)
{
    DisplayItemImageCommand command = (DisplayItemImageCommand)_commandList.GetCommandOfType<DisplayItemImageCommand>();
    command.Display(name,x,y);
}
[LuaCallCSharp]
public static void DeleteItemImage(System.String itemName)
{
    DisplayItemImageCommand command = (DisplayItemImageCommand)_commandList.GetCommandOfType<DisplayItemImageCommand>();
    command.DeleteItemImage(itemName);
}
[LuaCallCSharp]
public static void ShowText(System.String _talkText,System.String characterName)
{
    ShowTextCommand command = (ShowTextCommand)_commandList.GetCommandOfType<ShowTextCommand>();
    command.ShowText(_talkText,characterName);
}
[LuaCallCSharp]
public static System.Collections.IEnumerator Wait()
{
    WaitClickedCommand command = (WaitClickedCommand)_commandList.GetCommandOfType<WaitClickedCommand>();
    yield return command.Wait();
}
[LuaCallCSharp]
public static System.Collections.IEnumerator Wait(System.Single time)
{
    WaitCommand command = (WaitCommand)_commandList.GetCommandOfType<WaitCommand>();
    yield return command.Wait(time);
}
[LuaCallCSharp]
public static void ChangeBackGroundAlpha(System.String backGroundName)
{
    Command.CommandImpl.BackGroundCommand command = (Command.CommandImpl.BackGroundCommand)_commandList.GetCommandOfType<Command.CommandImpl.BackGroundCommand>();
    command.ChangeBackGroundAlpha(backGroundName);
}
[LuaCallCSharp]
public static void ChangeCharacterImage(System.String characterName,System.String changeCharacterName)
{
    Command.CommandImpl.ChangeCharacterImageCommand command = (Command.CommandImpl.ChangeCharacterImageCommand)_commandList.GetCommandOfType<Command.CommandImpl.ChangeCharacterImageCommand>();
    command.ChangeCharacterImage(characterName,changeCharacterName);
}
[LuaCallCSharp]
public static void End()
{
    Command.CommandImpl.EndCommand command = (Command.CommandImpl.EndCommand)_commandList.GetCommandOfType<Command.CommandImpl.EndCommand>();
    command.End();
}
[LuaCallCSharp]
public static void Move(System.String characterName,System.Single x,System.Single y)
{
    Command.CommandImpl.MoveCommand command = (Command.CommandImpl.MoveCommand)_commandList.GetCommandOfType<Command.CommandImpl.MoveCommand>();
    command.Move(characterName,x,y);
}
[LuaCallCSharp]
public static void Start()
{
    Command.CommandImpl.StartCommand command = (Command.CommandImpl.StartCommand)_commandList.GetCommandOfType<Command.CommandImpl.StartCommand>();
    command.Start();
}
[LuaCallCSharp]
public static System.Collections.IEnumerator WaitTextCompleted()
{
    Command.CommandImpl.WaitTextCompletedCommand command = (Command.CommandImpl.WaitTextCompletedCommand)_commandList.GetCommandOfType<Command.CommandImpl.WaitTextCompletedCommand>();
    yield return command.WaitTextCompleted();
}

        public static int EditLineNum = 18;
    }
}
