﻿#pragma checksum "C:\Users\Boeferrob\Google Drive\School\Hogent\3deJaar\Windows\Projects\StadsApp_Windows\StadsApp_Windows\View\OverzichtOndernemingen.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "ABC457DCD9DD847554182B3749E3F59A"
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
    partial class OverzichtOndernemingen : 
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
            case 2: // View\OverzichtOndernemingen.xaml line 13
                {
                    this.MyMap = (global::Windows.UI.Xaml.Controls.Maps.MapControl)(target);
                }
                break;
            case 3: // View\OverzichtOndernemingen.xaml line 26
                {
                    this.btnZoekOnderneming = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.btnZoekOnderneming).Click += this.btnZoekOnderneming_Click;
                }
                break;
            case 4: // View\OverzichtOndernemingen.xaml line 28
                {
                    this.lvOndernemingen = (global::Windows.UI.Xaml.Controls.ListView)(target);
                }
                break;
            case 5: // View\OverzichtOndernemingen.xaml line 35
                {
                    global::Windows.UI.Xaml.Controls.StackPanel element5 = (global::Windows.UI.Xaml.Controls.StackPanel)(target);
                    ((global::Windows.UI.Xaml.Controls.StackPanel)element5).DoubleTapped += this.StackPanel_DoubleTapped;
                }
                break;
            case 6: // View\OverzichtOndernemingen.xaml line 24
                {
                    this.cboSoorten = (global::Windows.UI.Xaml.Controls.ComboBox)(target);
                }
                break;
            case 7: // View\OverzichtOndernemingen.xaml line 20
                {
                    this.txtZoekOnderneming = (global::Windows.UI.Xaml.Controls.TextBox)(target);
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
