﻿#pragma checksum "..\..\BaseWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4A543C13DE31FB905AA409C0D13C6F886B6B54B5"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using RNA_Folding;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace RNA_Folding {
    
    
    /// <summary>
    /// BaseWindow
    /// </summary>
    public partial class BaseWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 16 "..\..\BaseWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Change_Base_Button;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\BaseWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton A_Radio;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\BaseWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton U_Radio;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\BaseWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton G_Radio;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\BaseWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton C_Radio;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\BaseWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label Base_ID_Label;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\BaseWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label Base_Type_Label;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\BaseWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label Select_Label;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/RNA-Folding;component/basewindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\BaseWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.Change_Base_Button = ((System.Windows.Controls.Button)(target));
            
            #line 16 "..\..\BaseWindow.xaml"
            this.Change_Base_Button.Click += new System.Windows.RoutedEventHandler(this.Change_Base_Button_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.A_Radio = ((System.Windows.Controls.RadioButton)(target));
            return;
            case 3:
            this.U_Radio = ((System.Windows.Controls.RadioButton)(target));
            return;
            case 4:
            this.G_Radio = ((System.Windows.Controls.RadioButton)(target));
            return;
            case 5:
            this.C_Radio = ((System.Windows.Controls.RadioButton)(target));
            return;
            case 6:
            this.Base_ID_Label = ((System.Windows.Controls.Label)(target));
            return;
            case 7:
            this.Base_Type_Label = ((System.Windows.Controls.Label)(target));
            return;
            case 8:
            this.Select_Label = ((System.Windows.Controls.Label)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
