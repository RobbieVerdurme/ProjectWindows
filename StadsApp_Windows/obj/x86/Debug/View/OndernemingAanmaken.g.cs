﻿#pragma checksum "D:\School\ProjectWindows\StadsApp_Windows\View\OndernemingAanmaken.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "D61876B8AE001153614A0EC4C99F3770"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace StadsApp_Windows.View
{
    partial class OndernemingAanmaken : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.17.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 2: // View\OndernemingAanmaken.xaml line 33
                {
                    this.NaamOnderneming = (global::Windows.UI.Xaml.Controls.StackPanel)(target);
                }
                break;
            case 3: // View\OndernemingAanmaken.xaml line 37
                {
                    this.AdresOnderneming = (global::Windows.UI.Xaml.Controls.StackPanel)(target);
                }
                break;
            case 4: // View\OndernemingAanmaken.xaml line 41
                {
                    this.TypeOnderneming = (global::Windows.UI.Xaml.Controls.StackPanel)(target);
                }
                break;
            case 5: // View\OndernemingAanmaken.xaml line 45
                {
                    global::Windows.UI.Xaml.Controls.Button element5 = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)element5).Click += this.btnToevoegenClicked;
                }
                break;
            case 6: // View\OndernemingAanmaken.xaml line 43
                {
                    this.cboSoort = (global::Windows.UI.Xaml.Controls.ComboBox)(target);
                }
                break;
            case 7: // View\OndernemingAanmaken.xaml line 39
                {
                    this.txtAdres = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 8: // View\OndernemingAanmaken.xaml line 35
                {
                    this.txtNaam = (global::Windows.UI.Xaml.Controls.TextBox)(target);
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
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.17.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Windows.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Windows.UI.Xaml.Markup.IComponentConnector returnValue = null;
            return returnValue;
        }
    }
}

