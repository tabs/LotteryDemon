﻿#pragma checksum "..\..\..\Pages\SetupWindow.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "39AC41FF72DA65F1856C736E18E1DB56"
//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.18408
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

using FirstFloor.ModernUI.Presentation;
using FirstFloor.ModernUI.Windows;
using FirstFloor.ModernUI.Windows.Controls;
using FirstFloor.ModernUI.Windows.Converters;
using FirstFloor.ModernUI.Windows.Navigation;
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


namespace 预彩精灵.Pages {
    
    
    /// <summary>
    /// mainDialog
    /// </summary>
    public partial class mainDialog : FirstFloor.ModernUI.Windows.Controls.ModernDialog, System.Windows.Markup.IComponentConnector {
        
        
        #line 25 "..\..\..\Pages\SetupWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox an_QiNum;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\..\Pages\SetupWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox an_GeNum;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\..\Pages\SetupWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TwoNumStatus;
        
        #line default
        #line hidden
        
        
        #line 47 "..\..\..\Pages\SetupWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox ThreeNumStatus;
        
        #line default
        #line hidden
        
        
        #line 51 "..\..\..\Pages\SetupWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox fourNumStatus;
        
        #line default
        #line hidden
        
        
        #line 55 "..\..\..\Pages\SetupWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox FiveNumStatus;
        
        #line default
        #line hidden
        
        
        #line 68 "..\..\..\Pages\SetupWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox StartIndex;
        
        #line default
        #line hidden
        
        
        #line 72 "..\..\..\Pages\SetupWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox EndIndex;
        
        #line default
        #line hidden
        
        
        #line 76 "..\..\..\Pages\SetupWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox ForecastNum;
        
        #line default
        #line hidden
        
        
        #line 82 "..\..\..\Pages\SetupWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button SaveSetupBtn;
        
        #line default
        #line hidden
        
        
        #line 83 "..\..\..\Pages\SetupWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button CancelSetupBtn;
        
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
            System.Uri resourceLocater = new System.Uri("/预彩精灵;component/pages/setupwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Pages\SetupWindow.xaml"
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
            this.an_QiNum = ((System.Windows.Controls.TextBox)(target));
            
            #line 25 "..\..\..\Pages\SetupWindow.xaml"
            this.an_QiNum.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.an_QiNum_PreviewTextInput);
            
            #line default
            #line hidden
            return;
            case 2:
            this.an_GeNum = ((System.Windows.Controls.TextBox)(target));
            
            #line 29 "..\..\..\Pages\SetupWindow.xaml"
            this.an_GeNum.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.an_GeNum_PreviewTextInput);
            
            #line default
            #line hidden
            return;
            case 3:
            this.TwoNumStatus = ((System.Windows.Controls.TextBox)(target));
            
            #line 43 "..\..\..\Pages\SetupWindow.xaml"
            this.TwoNumStatus.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.TwoNumStatus_PreviewTextInput);
            
            #line default
            #line hidden
            return;
            case 4:
            this.ThreeNumStatus = ((System.Windows.Controls.TextBox)(target));
            
            #line 47 "..\..\..\Pages\SetupWindow.xaml"
            this.ThreeNumStatus.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.ThreeNumStatus_PreviewTextInput);
            
            #line default
            #line hidden
            return;
            case 5:
            this.fourNumStatus = ((System.Windows.Controls.TextBox)(target));
            
            #line 51 "..\..\..\Pages\SetupWindow.xaml"
            this.fourNumStatus.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.fourNumStatus_PreviewTextInput);
            
            #line default
            #line hidden
            return;
            case 6:
            this.FiveNumStatus = ((System.Windows.Controls.TextBox)(target));
            
            #line 55 "..\..\..\Pages\SetupWindow.xaml"
            this.FiveNumStatus.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.FiveNumStatus_PreviewTextInput);
            
            #line default
            #line hidden
            return;
            case 7:
            this.StartIndex = ((System.Windows.Controls.TextBox)(target));
            
            #line 68 "..\..\..\Pages\SetupWindow.xaml"
            this.StartIndex.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.StartIndex_PreviewTextInput);
            
            #line default
            #line hidden
            return;
            case 8:
            this.EndIndex = ((System.Windows.Controls.TextBox)(target));
            
            #line 72 "..\..\..\Pages\SetupWindow.xaml"
            this.EndIndex.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.EndIndex_PreviewTextInput);
            
            #line default
            #line hidden
            return;
            case 9:
            this.ForecastNum = ((System.Windows.Controls.TextBox)(target));
            
            #line 76 "..\..\..\Pages\SetupWindow.xaml"
            this.ForecastNum.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.ForecastNum_PreviewTextInput);
            
            #line default
            #line hidden
            return;
            case 10:
            this.SaveSetupBtn = ((System.Windows.Controls.Button)(target));
            
            #line 82 "..\..\..\Pages\SetupWindow.xaml"
            this.SaveSetupBtn.Click += new System.Windows.RoutedEventHandler(this.SaveSetupBtn_Click);
            
            #line default
            #line hidden
            return;
            case 11:
            this.CancelSetupBtn = ((System.Windows.Controls.Button)(target));
            
            #line 83 "..\..\..\Pages\SetupWindow.xaml"
            this.CancelSetupBtn.Click += new System.Windows.RoutedEventHandler(this.CancelSetupBtn_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

