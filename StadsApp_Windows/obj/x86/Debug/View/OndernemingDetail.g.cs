﻿#pragma checksum "C:\Users\Boeferrob\Desktop\Windows\Projects\StadsApp_Windows\StadsApp_Windows\View\OndernemingDetail.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "E79052C0023155AF8A45299715A0409B"
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
    partial class OndernemingDetail : 
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
            case 2: // View\OndernemingDetail.xaml line 76
                {
                    global::Windows.UI.Xaml.Controls.Button element2 = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)element2).Click += this.Verwijderen;
                }
                break;
            case 3: // View\OndernemingDetail.xaml line 44
                {
                    this.Vestigingen = (global::Windows.UI.Xaml.Controls.StackPanel)(target);
                }
                break;
            case 4: // View\OndernemingDetail.xaml line 57
                {
                    global::Windows.UI.Xaml.Controls.Button element4 = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)element4).Click += this.VestigingToevoegen;
                }
                break;
            case 5: // View\OndernemingDetail.xaml line 59
                {
                    this.Promoties = (global::Windows.UI.Xaml.Controls.StackPanel)(target);
                }
                break;
            case 6: // View\OndernemingDetail.xaml line 74
                {
                    global::Windows.UI.Xaml.Controls.Button element6 = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)element6).Click += this.PromotieToevoegen;
                }
                break;
            case 7: // View\OndernemingDetail.xaml line 61
                {
                    this.lvPromoties = (global::Windows.UI.Xaml.Controls.ListView)(target);
                }
                break;
            case 8: // View\OndernemingDetail.xaml line 64
                {
                    global::Windows.UI.Xaml.Controls.StackPanel element8 = (global::Windows.UI.Xaml.Controls.StackPanel)(target);
                    ((global::Windows.UI.Xaml.Controls.StackPanel)element8).Tapped += this.Promotie_Tapped;
                }
                break;
            case 9: // View\OndernemingDetail.xaml line 46
                {
                    this.lvVestigingen = (global::Windows.UI.Xaml.Controls.ListView)(target);
                }
                break;
            case 10: // View\OndernemingDetail.xaml line 49
                {
                    global::Windows.UI.Xaml.Controls.StackPanel element10 = (global::Windows.UI.Xaml.Controls.StackPanel)(target);
                    ((global::Windows.UI.Xaml.Controls.StackPanel)element10).DoubleTapped += this.StackPanel_DoubleTapped;
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

