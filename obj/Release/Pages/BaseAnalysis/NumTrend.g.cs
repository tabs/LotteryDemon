﻿#pragma checksum "..\..\..\..\Pages\BaseAnalysis\NumTrend.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "D0C1B3DF6DA016BD94244EFFF90C1C41"
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
    /// NumTrend
    /// </summary>
    public partial class NumTrend : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 2 "..\..\..\..\Pages\BaseAnalysis\NumTrend.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal 预彩精灵.Pages.NumTrend NumTrendWindow;
        
        #line default
        #line hidden
        
        
        #line 62 "..\..\..\..\Pages\BaseAnalysis\NumTrend.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox AChBox;
        
        #line default
        #line hidden
        
        
        #line 63 "..\..\..\..\Pages\BaseAnalysis\NumTrend.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox BChBox;
        
        #line default
        #line hidden
        
        
        #line 64 "..\..\..\..\Pages\BaseAnalysis\NumTrend.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox CChBox;
        
        #line default
        #line hidden
        
        
        #line 65 "..\..\..\..\Pages\BaseAnalysis\NumTrend.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox DChBix;
        
        #line default
        #line hidden
        
        
        #line 67 "..\..\..\..\Pages\BaseAnalysis\NumTrend.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid ReTable;
        
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
            System.Uri resourceLocater = new System.Uri("/预彩精灵;component/pages/baseanalysis/numtrend.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Pages\BaseAnalysis\NumTrend.xaml"
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
            this.NumTrendWindow = ((预彩精灵.Pages.NumTrend)(target));
            
            #line 9 "..\..\..\..\Pages\BaseAnalysis\NumTrend.xaml"
            this.NumTrendWindow.MouseEnter += new System.Windows.Input.MouseEventHandler(this.NumTrendWindow_MouseEnter);
            
            #line default
            #line hidden
            
            #line 9 "..\..\..\..\Pages\BaseAnalysis\NumTrend.xaml"
            this.NumTrendWindow.Loaded += new System.Windows.RoutedEventHandler(this.NumTrendWindow_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.AChBox = ((System.Windows.Controls.CheckBox)(target));
            return;
            case 3:
            this.BChBox = ((System.Windows.Controls.CheckBox)(target));
            return;
            case 4:
            this.CChBox = ((System.Windows.Controls.CheckBox)(target));
            return;
            case 5:
            this.DChBix = ((System.Windows.Controls.CheckBox)(target));
            return;
            case 6:
            this.ReTable = ((System.Windows.Controls.DataGrid)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

