using Command;

namespace Shikibu.Scripts.Command.TextBase
{
    public class CommandExecutorBase
    {
        private static AdvCommandList _commandList;

        public static void Initialize(AdvCommandList commandList)
        {
            _commandList = commandList;
        }
    }
}