﻿#pragma checksum "..\..\Window1.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "8470C730B67C5F258B6ED19B8223FF75"
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión del motor en tiempo de ejecución:2.0.50727.4952
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


namespace WpfApplication1 {
    
    
    /// <summary>
    /// Window1
    /// </summary>
    public partial class Window1 : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 6 "..\..\Window1.xaml"
        internal System.Windows.Controls.StackPanel stackPanel1;
        
        #line default
        #line hidden
        
        
        #line 7 "..\..\Window1.xaml"
        internal System.Windows.Controls.Image image1;
        
        #line default
        #line hidden
        
        
        #line 8 "..\..\Window1.xaml"
        internal System.Windows.Controls.Button botonExp1;
        
        #line default
        #line hidden
        
        
        #line 9 "..\..\Window1.xaml"
        internal System.Windows.Controls.Button button2;
        
        #line default
        #line hidden
        
        
        #line 10 "..\..\Window1.xaml"
        internal System.Windows.Controls.Button button3;
        
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
            System.Uri resourceLocater = new System.Uri("/WpfApplication1;component/window1.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Window1.xaml"
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
            this.image1 = ((System.Windows.Controls.Image)(target));
            
            #line 7 "..\..\Window1.xaml"
            this.image1.ImageFailed += new System.EventHandler<System.Windows.ExceptionRoutedEventArgs>(this.image1_ImageFailed);
            
            #line default
            #line hidden
            return;
            case 3:
            this.botonExp1 = ((System.Windows.Controls.Button)(target));
            return;
            case 4:
            this.button2 = ((System.Windows.Controls.Button)(target));
            return;
            case 5:
            this.button3 = ((System.Windows.Controls.Button)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}