﻿#pragma checksum "..\..\..\windows\MainMenu.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "BB554AE4EA7D89EFD0F1D6A533742E2A"
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.586
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
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


namespace WpfApplication1.windows {
    
    
    /// <summary>
    /// Window1
    /// </summary>
    public partial class Window1 : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 6 "..\..\..\windows\MainMenu.xaml"
        internal System.Windows.Controls.StackPanel stackPanel1;
        
        #line default
        #line hidden
        
        
        #line 7 "..\..\..\windows\MainMenu.xaml"
        internal System.Windows.Controls.Label label1;
        
        #line default
        #line hidden
        
        
        #line 9 "..\..\..\windows\MainMenu.xaml"
        internal System.Windows.Controls.Border border1;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\..\windows\MainMenu.xaml"
        internal System.Windows.Controls.Image image1;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\..\windows\MainMenu.xaml"
        internal System.Windows.Controls.Button botonExp1;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\..\windows\MainMenu.xaml"
        internal System.Windows.Controls.Button botonExp2;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\..\windows\MainMenu.xaml"
        internal System.Windows.Controls.Button botonExp3;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\..\windows\MainMenu.xaml"
        internal System.Windows.Controls.Button exitButton;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Launcher;component/windows/mainmenu.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\windows\MainMenu.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.stackPanel1 = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 2:
            this.label1 = ((System.Windows.Controls.Label)(target));
            return;
            case 3:
            this.border1 = ((System.Windows.Controls.Border)(target));
            return;
            case 4:
            
            #line 11 "..\..\..\windows\MainMenu.xaml"
            ((System.Windows.Documents.Hyperlink)(target)).RequestNavigate += new System.Windows.Navigation.RequestNavigateEventHandler(this.Hyperlink_RequestNavigate);
            
            #line default
            #line hidden
            return;
            case 5:
            this.image1 = ((System.Windows.Controls.Image)(target));
            return;
            case 6:
            this.botonExp1 = ((System.Windows.Controls.Button)(target));
            
            #line 16 "..\..\..\windows\MainMenu.xaml"
            this.botonExp1.Click += new System.Windows.RoutedEventHandler(this.BotonExp1Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.botonExp2 = ((System.Windows.Controls.Button)(target));
            
            #line 17 "..\..\..\windows\MainMenu.xaml"
            this.botonExp2.Click += new System.Windows.RoutedEventHandler(this.BotonExp2Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.botonExp3 = ((System.Windows.Controls.Button)(target));
            
            #line 18 "..\..\..\windows\MainMenu.xaml"
            this.botonExp3.Click += new System.Windows.RoutedEventHandler(this.BotonExp3Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.exitButton = ((System.Windows.Controls.Button)(target));
            
            #line 19 "..\..\..\windows\MainMenu.xaml"
            this.exitButton.Click += new System.Windows.RoutedEventHandler(this.ExitButtonClick);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

