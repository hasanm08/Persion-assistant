﻿#pragma checksum "..\..\Play video.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "DAF4F19BA4AEB969A26B04E2C56FC23C4C7A0DC8"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using MahApps.Metro;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
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
using WpfApplication2;


namespace WpfApplication2 {
    
    
    /// <summary>
    /// Play_video
    /// </summary>
    public partial class Play_video : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 11 "..\..\Play video.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Slider seekBar;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\Play video.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MediaElement mediaElement;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\Play video.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button button;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\Play video.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button button1;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\Play video.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button button2;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\Play video.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button button3;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\Play video.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock currentTimeTextBlock;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\Play video.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button button4;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\Play video.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RichTextBox richTextBox;
        
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
            System.Uri resourceLocater = new System.Uri("/Persion Assistant08;component/play%20video.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Play video.xaml"
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
            
            #line 9 "..\..\Play video.xaml"
            ((WpfApplication2.Play_video)(target)).KeyUp += new System.Windows.Input.KeyEventHandler(this.Window_KeyUp);
            
            #line default
            #line hidden
            
            #line 9 "..\..\Play video.xaml"
            ((WpfApplication2.Play_video)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            
            #line 9 "..\..\Play video.xaml"
            ((WpfApplication2.Play_video)(target)).KeyDown += new System.Windows.Input.KeyEventHandler(this.Window_KeyDown);
            
            #line default
            #line hidden
            return;
            case 2:
            this.seekBar = ((System.Windows.Controls.Slider)(target));
            
            #line 11 "..\..\Play video.xaml"
            this.seekBar.MouseLeftButtonUp += new System.Windows.Input.MouseButtonEventHandler(this.SeekSlider_MouseLeftButtonUp);
            
            #line default
            #line hidden
            
            #line 11 "..\..\Play video.xaml"
            this.seekBar.PreviewMouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.SeekSlider_PreviewMouseLeftButtonDown);
            
            #line default
            #line hidden
            
            #line 11 "..\..\Play video.xaml"
            this.seekBar.PreviewMouseLeftButtonUp += new System.Windows.Input.MouseButtonEventHandler(this.SeekSlider_PreviewMouseLeftButtonUp);
            
            #line default
            #line hidden
            
            #line 11 "..\..\Play video.xaml"
            this.seekBar.ValueChanged += new System.Windows.RoutedPropertyChangedEventHandler<double>(this.SeekBar_ValueChanged);
            
            #line default
            #line hidden
            
            #line 11 "..\..\Play video.xaml"
            this.seekBar.DragOver += new System.Windows.DragEventHandler(this.SeekBar_DragOver);
            
            #line default
            #line hidden
            return;
            case 3:
            this.mediaElement = ((System.Windows.Controls.MediaElement)(target));
            
            #line 19 "..\..\Play video.xaml"
            this.mediaElement.MediaOpened += new System.Windows.RoutedEventHandler(this.MediaElement_MediaOpened);
            
            #line default
            #line hidden
            
            #line 19 "..\..\Play video.xaml"
            this.mediaElement.Loaded += new System.Windows.RoutedEventHandler(this.MediaElement_Loaded);
            
            #line default
            #line hidden
            
            #line 19 "..\..\Play video.xaml"
            this.mediaElement.MediaEnded += new System.Windows.RoutedEventHandler(this.MediaElement_MediaEnded);
            
            #line default
            #line hidden
            
            #line 19 "..\..\Play video.xaml"
            this.mediaElement.MouseEnter += new System.Windows.Input.MouseEventHandler(this.MediaElement_MouseEnter);
            
            #line default
            #line hidden
            return;
            case 4:
            this.button = ((System.Windows.Controls.Button)(target));
            
            #line 20 "..\..\Play video.xaml"
            this.button.Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.button1 = ((System.Windows.Controls.Button)(target));
            
            #line 21 "..\..\Play video.xaml"
            this.button1.Click += new System.Windows.RoutedEventHandler(this.Button1_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.button2 = ((System.Windows.Controls.Button)(target));
            
            #line 23 "..\..\Play video.xaml"
            this.button2.Click += new System.Windows.RoutedEventHandler(this.Button2_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.button3 = ((System.Windows.Controls.Button)(target));
            
            #line 36 "..\..\Play video.xaml"
            this.button3.Click += new System.Windows.RoutedEventHandler(this.Button3_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.currentTimeTextBlock = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 9:
            this.button4 = ((System.Windows.Controls.Button)(target));
            
            #line 40 "..\..\Play video.xaml"
            this.button4.Click += new System.Windows.RoutedEventHandler(this.Button4_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.richTextBox = ((System.Windows.Controls.RichTextBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

