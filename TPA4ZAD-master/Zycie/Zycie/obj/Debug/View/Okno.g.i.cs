﻿#pragma checksum "..\..\..\View\Okno.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "35CF08E23BC12D956E2087A1BAE40B9FCE5CAFFE"
//------------------------------------------------------------------------------
// <auto-generated>
//     Ten kod został wygenerowany przez narzędzie.
//     Wersja wykonawcza:4.0.30319.42000
//
//     Zmiany w tym pliku mogą spowodować nieprawidłowe zachowanie i zostaną utracone, jeśli
//     kod zostanie ponownie wygenerowany.
// </auto-generated>
//------------------------------------------------------------------------------

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
using Zycie;


namespace Projekt.View {
    
    
    /// <summary>
    /// Okno
    /// </summary>
    public partial class Okno : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 10 "..\..\..\View\Okno.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TreeView TreeView;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\View\Okno.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button LoadDLL;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\View\Okno.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Browse;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\..\View\Okno.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Buton;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\..\View\Okno.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox listOfSerialize;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\..\View\Okno.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox listOfDeserialize;
        
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
            System.Uri resourceLocater = new System.Uri("/Zycie;component/view/okno.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\View\Okno.xaml"
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
            this.TreeView = ((System.Windows.Controls.TreeView)(target));
            
            #line 10 "..\..\..\View\Okno.xaml"
            this.TreeView.SelectedItemChanged += new System.Windows.RoutedPropertyChangedEventHandler<object>(this.TreeView_OnSelectedItemChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.LoadDLL = ((System.Windows.Controls.Button)(target));
            return;
            case 3:
            this.Browse = ((System.Windows.Controls.Button)(target));
            return;
            case 4:
            this.Buton = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.listOfSerialize = ((System.Windows.Controls.ListBox)(target));
            
            #line 30 "..\..\..\View\Okno.xaml"
            this.listOfSerialize.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.ListOfClientsListBox_OnSelectionChanged);
            
            #line default
            #line hidden
            return;
            case 6:
            this.listOfDeserialize = ((System.Windows.Controls.ListBox)(target));
            
            #line 33 "..\..\..\View\Okno.xaml"
            this.listOfDeserialize.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.ListOfDesesListBox_OnSelectionChanged);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

