using System;
using System.Collections;

namespace Command
{
    /// <summary>
    /// コマンド基底クラス
    /// MEMO : interfaceで定義していたがAdvCommandList内でこのクラスのサブクラスをリフレクションでインスタンスを生成している部分が
    /// interfaceだと機能しなかったので変更
    /// </summary>
    public abstract class ICommand
    {
        public abstract void Setup(UIObjectManager objectManager);
    }
}