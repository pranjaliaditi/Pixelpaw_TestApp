﻿#pragma checksum "D:\Skills\Internships\Pixelpaw\Project\Pixelpaw\MainWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "D5BCBD30666EBE12C6ED0B0689E9CD6CEEA30A7E7AAE041DC903ACD9E6E54CC0"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Pixelpaw
{
    partial class MainWindow : 
        global::Microsoft.UI.Xaml.Window, 
        global::Microsoft.UI.Xaml.Markup.IComponentConnector
    {

        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.UI.Xaml.Markup.Compiler"," 3.0.0.2408")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 2: // MainWindow.xaml line 106
                {
                    this.SessionHistoryListView = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.ListView>(target);
                }
                break;
            case 4: // MainWindow.xaml line 74
                {
                    this.AccelerateButton = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.Primitives.RepeatButton>(target);
                    ((global::Microsoft.UI.Xaml.Controls.Primitives.RepeatButton)this.AccelerateButton).Click += this.OnAccelerateClick;
                    ((global::Microsoft.UI.Xaml.Controls.Primitives.RepeatButton)this.AccelerateButton).PointerReleased += this.OnAccelerateButtonReleased;
                }
                break;
            case 5: // MainWindow.xaml line 70
                {
                    this.ProgressFill = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.Border>(target);
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }

        /// <summary>
        /// GetBindingConnector(int connectionId, object target)
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.UI.Xaml.Markup.Compiler"," 3.0.0.2408")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Microsoft.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Microsoft.UI.Xaml.Markup.IComponentConnector returnValue = null;
            return returnValue;
        }
    }
}

