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

        public static void ShowText(String text,String characterName = null)
        {
            var command = (ShowTextCommand)_commandList.GetCommandOfType<ShowTextCommand>();
            
            command.ShowText(text, characterName);
        }

        public static IEnumerator Wait(float time)
        {
            var command = (WaitCommand)_commandList.GetCommandOfType<WaitCommand>();

            yield return command.Wait(time);
        }

        public static IEnumerator WaitClicked()
        {
            var command = (WaitClickedCommand)_commandList.GetCommandOfType<WaitClickedCommand>();
            
            yield return command.Wait();
        }

        public static void DisplayCharacter(String name, float x, float y)
        {
            var command = (DisplayCharacterCommand)_commandList.GetCommandOfType<DisplayCharacterCommand>();
            
            command.Display(name, x, y);
        }
        
        public static void DisplayItem(String name, float x, float y)
        {
            var command = (DisplayItemImageCommand)_commandList.GetCommandOfType<DisplayItemImageCommand>();
            
            command.Display(name, x, y);
        }

        public static void DeleteItem(String itemName)
        {
            var command = (DisplayItemImageCommand)_commandList.GetCommandOfType<DisplayItemImageCommand>();
            
            command.DeleteItemImage(itemName);
        }
        
        public static void Start()
        {
            var command = (StartCommand)_commandList.GetCommandOfType<StartCommand>();
            
            command.Start();
        }

        public static void End()
        {
            var command = (EndCommand)_commandList.GetCommandOfType<EndCommand>();

            command.End();
        }

        public static IEnumerator WaitTextCompleted()
        {
            var command = (WaitTextCompletedCommand)_commandList.GetCommandOfType<WaitTextCompletedCommand>();

            yield return command.WaitTextCompleted();
            Debug.Log("WaitEnd");
        }

        public static void Move(String characterName, float x, float y)
        {
            var command = (MoveCommand)_commandList.GetCommandOfType<MoveCommand>();

            command.Move(characterName, x, y);
        }

        public static void ChangeBackGroundAlpha(String backGroundName)
        {
            var command = (BackGroundCommand)_commandList.GetCommandOfType<BackGroundCommand>();
            
            command.ChangeBackGroundAlpha(backGroundName);
        }

        public static void DeleteCharacterImage(String characterName)
        {
            var command = (DisplayCharacterCommand)_commandList.GetCommandOfType<DisplayCharacterCommand>();
            
            command.DeleteCharacterImage(characterName);
        }

        public static int EditLineNum = 104;
    }
}