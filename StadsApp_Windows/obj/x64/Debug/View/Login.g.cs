﻿#pragma checksum "C:\Users\Boeferrob\Google Drive\School\Hogent\3deJaar\Windows\Projects\StadsApp_Windows\StadsApp_Windows\View\Login.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "348D93FEAF387347A37AA41AF3078B1E"
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
    partial class Login : 
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
            case 2: // View\Login.xaml line 14
                {
                    this.ErrorMessage = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 3: // View\Login.xaml line 18
                {
                    this.UsernameTextBox = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 4: // View\Login.xaml line 19
                {
                    this.PasswordTextBox = (global::Windows.UI.Xaml.Controls.PasswordBox)(target);
                }
                break;
            case 5: // View\Login.xaml line 20
                {
                    this.PassportSignInButton = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.PassportSignInButton).Click += this.PassportSignInButton_Click;
                }
                break;
            case 6: // View\Login.xaml line 24
                {
                    this.RegisterButtonTextBlock = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                    ((global::Windows.UI.Xaml.Controls.TextBlock)this.RegisterButtonTextBlock).PointerPressed += this.RegisterButtonTextBlock_OnPointerPressed;
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

