﻿#pragma checksum "..\..\ConnectionSettings.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "0D52EDF89A05725B57DCDCD04C19655D30D77C957370EB28A01643821FC0ECE8"
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


namespace USBMediaController {
    
    
    /// <summary>
    /// ConnectionSettings
    /// </summary>
    public partial class ConnectionSettings : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 22 "..\..\ConnectionSettings.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbx_portName;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\ConnectionSettings.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbx_baudrate;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\ConnectionSettings.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_apply;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\ConnectionSettings.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_cancel;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\ConnectionSettings.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbx_handshake;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\ConnectionSettings.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbx_parity;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\ConnectionSettings.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbx_dataBits;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\ConnectionSettings.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbx_stopBits;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\ConnectionSettings.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbx_readTimeout;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\ConnectionSettings.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbx_writeTimeout;
        
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
            System.Uri resourceLocater = new System.Uri("/USBGameStick;component/connectionsettings.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\ConnectionSettings.xaml"
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
            
            #line 13 "..\..\ConnectionSettings.xaml"
            ((USBMediaController.ConnectionSettings)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.Window_MouseDown);
            
            #line default
            #line hidden
            return;
            case 2:
            this.cbx_portName = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 3:
            this.cbx_baudrate = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 4:
            this.btn_apply = ((System.Windows.Controls.Button)(target));
            
            #line 25 "..\..\ConnectionSettings.xaml"
            this.btn_apply.Click += new System.Windows.RoutedEventHandler(this.btn_apply_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.btn_cancel = ((System.Windows.Controls.Button)(target));
            
            #line 26 "..\..\ConnectionSettings.xaml"
            this.btn_cancel.Click += new System.Windows.RoutedEventHandler(this.btn_cancel_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.cbx_handshake = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 7:
            this.cbx_parity = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 8:
            this.cbx_dataBits = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 9:
            this.cbx_stopBits = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 10:
            this.tbx_readTimeout = ((System.Windows.Controls.TextBox)(target));
            return;
            case 11:
            this.tbx_writeTimeout = ((System.Windows.Controls.TextBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

