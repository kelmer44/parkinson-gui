using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;
using Microsoft.Win32;
using WpfApplication1.Experiencias;
using WpfApplication1.Experiencias.Exp2;

namespace WpfApplication1.windows
{
    /// <summary>
    /// Lógica de interacción para XP2.xaml
    /// </summary>
    public partial class XP2
    {
        private readonly DispatcherTimer _dispatcherTimer = new DispatcherTimer();
        private readonly Serializer _fileSaver = new Serializer();
        private readonly SocketManager _sm;
        private Experiencia2 _exp2Class = new Experiencia2(100);
        private List<Composite> _listaData;


        public XP2()
        {
            InitializeComponent();

            _exp2Class.Started = false;

            for (int i = 0; i < _exp2Class.NumberOfProtocols; i++)
            {
                var p = _exp2Class.GetProtocolo(i);
                p.IsActive = false;
                p.Invertir = (i % 2 == 0);
                p.CyclesNextProtocol = 10;
                p.TimeNextProtocol = 10f;
                p.EnNegro = false;
                p.ActiveAnim = ProtocoloExp2.AnimOptions.DerechoRecto;
                p.ActiveIllum = ProtocoloExp2.IllumOptions.Random;
                p.AutoAnim = false;
                p.EnNegro = false;
                p.CiclosEntrePulso = 0;
                p.TimeToShowTarget = 1.0f;
                p.TimeToStartAnimation = 1.0f;
                p.TimeToEndAnimation = 2.0f;
                p.ExtraWaitingTime = 3.0f;
            }

            _listaData = GetData();
            tvProtocolos.ItemsSource = _listaData;

            _dispatcherTimer.Tick += DispatcherTimerTick;
            _dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 0, 1);
            _dispatcherTimer.Start();

            stackPanel4.DataContext = _exp2Class;
            wpanel.DataContext = _exp2Class.GetProtocolo(0);

            _sm = SocketManager.Instance;
            _sm.CreateReceivingSocket(IPAddress.Any, 5002);

        }


        private List<Composite> GetData()
        {
            List<Composite> lista = new List<Composite>();
            return lista;
            //IEnumerable<Composite> query = from p in _exp2Class.Protocolos
            //                               select new Composite
            //                               {
            //                                   Name = "Protocolo " + (p.IndiceProtocolo + 1),
            //                                   Indice = p.IndiceProtocolo,
            //                                   Activo = true,
            //                                   Children = new List<Composite>
            //                                                             {
            //                                                                 new Composite
            //                                                                     {
            //                                                                         Name =
            //                                                                             string.Format("Activo: {0}",
            //                                                                                           p.IsActive),
            //                                                                         Activo = false
            //                                                                     },
            //                                                                 new Composite
            //                                                                     {
            //                                                                         Name = string.Format(
            //                                                                                 "En Negro: {0}",
            //                                                                                 p.EnNegro),
            //                                                                         Activo = false
            //                                                                     },
            //                                                                 new Composite
            //                                                                     {
            //                                                                         Name =
            //                                                                             string.Format("Invertir: {0}",
            //                                                                                           p.Invertir),
            //                                                                         Activo = false
            //                                                                     },
            //                                                                 new Composite
            //                                                                     {
            //                                                                         Name =
            //                                                                             string.Format("Animación activa: {0}",
            //                                                                                           p.ActiveAnim),
            //                                                                         Activo = false
            //                                                                     },
            //                                                                 new Composite
            //                                                                     {
            //                                                                         Name =
            //                                                                             string.Format(
            //                                                                                 "Diana iluminada: {0}",
            //                                                                                 p.ActiveIllum),
            //                                                                         Activo = false
            //                                                                     },
            //                                                                 new Composite
            //                                                                     {
            //                                                                         Name =
            //                                                                             string.Format(
            //                                                                                 "Velocidad mov.: {0}",
            //                                                                                 p.HandSpeed),
            //                                                                         Activo = false
            //                                                                     },
            //                                                                 new Composite
            //                                                                     {
            //                                                                         Name =
            //                                                                             string.Format(
            //                                                                                 "Retardo de rep: {0}",
            //                                                                                 p.RepeatTime),
            //                                                                         Activo = false
            //                                                                     },
            //                                                                 new Composite
            //                                                                     {
            //                                                                         Name =
            //                                                                             string.Format(
            //                                                                                 "Animación: {0}",
            //                                                                                 p.AutoAnim?"Sí":"No"),
            //                                                                         Activo = false
            //                                                                     },
            //                                                                 new Composite
            //                                                                     {
            //                                                                         Name =
            //                                                                             string.Format(
            //                                                                                 "Tiempo de disparo de animación: {0}",
            //                                                                                 p.Delay),
            //                                                                         Activo = false
            //                                                                     },
            //                                                                     new Composite
            //                                                                     {
            //                                                                         Name =
            //                                                                             string.Format(
            //                                                                                 "Ciclos siguiente protocolo: {0}",
            //                                                                                 p.CyclesNextProtocol),
            //                                                                         Activo = false
            //                                                                     },
            //                                                                 new Composite
            //                                                                     {
            //                                                                         Name =
            //                                                                             string.Format(
            //                                                                                 "Tiempo siguiente protocolo: {0}",
            //                                                                                 p.TimeNextProtocol),
            //                                                                         Activo = false
            //                                                                     },
            //                                                                 new Composite
            //                                                                     {
            //                                                                         Name = string.Format(
            //                                                                                 "Prioridad Ciclos/Tiempo: {0}",
            //                                                                                 p.PrioridadCiclos?"Ciclos":"Tiempo"),
            //                                                                         Activo = false
            //                                                                     },

            //                                                             }
            //                               };

            //return query.ToList();
        }


        private void DispatcherTimerTick(object sender, EventArgs e)
        {
            _listaData = GetData();

            //dbgBox.Text = "Started: " + _exp2Class.Started
            //                + " RepeatTime: " + _exp2Class.RepeatTime
            //                + " Invertir: " + _exp2Class.Invertir
            //                + " AutoAnim: " + _exp2Class.AutoAnim
            //                + " \nActiveAnim: " + _exp2Class.ActiveAnim
            //                + " HandSpeed: " + _exp2Class.HandSpeed
            //                + " Delay: " + _exp2Class.Delay 
            //                + " ActiveIllum: " + _exp2Class.ActiveIllum
            //                + "\n";


            _exp2Class.EnviaDatos();
            _sm.RecibeDatos();

            byte[] recibidos = _sm.ReceivedBytes;
            if (recibidos != null)
            {
                var numero = BitConverter.ToSingle(recibidos, 0);
                var ciclo = BitConverter.ToSingle(recibidos, 1);

                _exp2Class.CurrentProtocol = (int)numero;
                label40.Content = (int)numero;
                //label52.Content = (int)ciclo;
            }

            switch (_exp2Class.Estado)
            {
                case (Experiencia.Estados.Running):
                    label41.Content = "Iniciado";
                    break;
                case (Experiencia.Estados.Stopped):
                    label41.Content = "Detenido";
                    break;
                case (Experiencia.Estados.Stopping):
                    label41.Content = "Deteniendo...";
                    break;
                case (Experiencia.Estados.NotStarted):
                    label41.Content = "No iniciado.";
                    break;
                case (Experiencia.Estados.Restarting):
                    label41.Content = "Reiniciando...";
                    break;
            }
        }

        private void BtnStartClick(object sender, RoutedEventArgs e)
        {
            _exp2Class.Started = true;
            _exp2Class.Estado = Experiencia.Estados.Running;
        }
        private void BtnStopClick(object sender, RoutedEventArgs e)
        {
            _exp2Class.Started = false;
            _exp2Class.Estado = Experiencia.Estados.Stopped;
        }

        private void BtnResetClick(object sender, RoutedEventArgs e)
        {
            _exp2Class.Estado = Experiencia.Estados.Restarting;
            _exp2Class.ResetSignal = true;


        }
        

        private void RbRandomChecked(object sender, RoutedEventArgs e)
        {
                ProtocoloExp2 p = (ProtocoloExp2)wpanel.DataContext ?? _exp2Class.GetProtocolo(0);
                p.ActiveIllum = ProtocoloExp2.IllumOptions.Random;
        }

        private void RbRightPanelChecked(object sender, RoutedEventArgs e)
        {
            ProtocoloExp2 p = (ProtocoloExp2)wpanel.DataContext ?? _exp2Class.GetProtocolo(0);
            p.ActiveIllum = ProtocoloExp2.IllumOptions.RightPanel;
        }

        private void RbLeftPanelChecked(object sender, RoutedEventArgs e)
        {
            ProtocoloExp2 p = (ProtocoloExp2)wpanel.DataContext ?? _exp2Class.GetProtocolo(0);
            p.ActiveIllum = ProtocoloExp2.IllumOptions.LeftPanel;
        }

        private void AnimationRightStraightChecked(object sender, RoutedEventArgs e)
        {
            ProtocoloExp2 p = (ProtocoloExp2)wpanel.DataContext ?? _exp2Class.GetProtocolo(0);
            p.ActiveAnim = ProtocoloExp2.AnimOptions.DerechoRecto;
        }

        private void AnimationRightObliqueChecked(object sender, RoutedEventArgs e)
        {
            ProtocoloExp2 p = (ProtocoloExp2)wpanel.DataContext ?? _exp2Class.GetProtocolo(0);
            p.ActiveAnim = ProtocoloExp2.AnimOptions.DerechoOblicuo;
        }

        private void AnimationLeftStraightChecked(object sender, RoutedEventArgs e)
        {
            ProtocoloExp2 p = (ProtocoloExp2)wpanel.DataContext ?? _exp2Class.GetProtocolo(0);
            p.ActiveAnim = ProtocoloExp2.AnimOptions.IzquierdoRecto;
        }

        private void AnimationLeftObliqueChecked(object sender, RoutedEventArgs e)
        {
            ProtocoloExp2 p = (ProtocoloExp2)wpanel.DataContext ?? _exp2Class.GetProtocolo(0);
            p.ActiveAnim = ProtocoloExp2.AnimOptions.IzquierdoOblicuo;
        }

        private void Button2Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void BotonGuardarProtocoloClick(object sender, RoutedEventArgs e)
        {
            var saveFileDialog = new SaveFileDialog { DefaultExt = ".xp2", Filter = "Configuración de la experiencia 2 (.xp2)|*.xp2" };
            if (saveFileDialog.ShowDialog() == true)
            {
                string filename = saveFileDialog.FileName;
                _fileSaver.SerializeXp2(filename, _exp2Class);

                archivo.Content = filename.Substring(filename.LastIndexOf("\\") + 1);
            }
        }

        private void BotonCargarProtocoloClick(object sender, RoutedEventArgs e)
        {
            // Create OpenFileDialog
            var dlg = new OpenFileDialog
                          {
                              DefaultExt = ".xp2",
                              Filter = "Configuración de la experiencia 2 (.xp2)|*.xp2"
                          };

            // Set filter for file extension and default file extension

            // Display OpenFileDialog by calling ShowDialog method
            var result = dlg.ShowDialog();

            // Get the selected file name and display in a TextBox
            if (result == true)
            {
                // Open document
                string filename = dlg.FileName;
                archivo.Content = filename.Substring(filename.LastIndexOf("\\") + 1);

                //_exp1Class.CloseConnection();
                _exp2Class = null;

                _exp2Class = _fileSaver.DeSerializeExp2(filename);

                RefreshTree();

                _exp2Class.ResetSignal = true;
            }
        }

        private void TvProtocolosSelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            var t = (TreeView)sender;

            if (t == null)
                return;

            var g = t.SelectedItem as Composite;


            if (g != null)
            {
                wpanel.DataContext = _exp2Class.GetProtocolo(g.Indice);
                ProtocoloExp2 protocolo = _exp2Class.GetProtocolo(g.Indice);
                if (botonPriorizarCiclos != null)
                {
                    botonPriorizarCiclos.IsChecked = protocolo.PrioridadCiclos;
                    botonPriorizarTiempo.IsChecked = !protocolo.PrioridadCiclos;
                }

                if(rbRandom != null)
                    rbRandom.IsChecked = (protocolo.ActiveIllum == ProtocoloExp2.IllumOptions.Random) ? true : false;
                if(rbRightPanel != null)
                    rbRightPanel.IsChecked = (protocolo.ActiveIllum == ProtocoloExp2.IllumOptions.RightPanel) ? true : false;
                if(rbLeftPanel != null)
                    rbLeftPanel.IsChecked = (protocolo.ActiveIllum == ProtocoloExp2.IllumOptions.LeftPanel ) ? true : false;
                
                if(animationRightStraight != null)
                    animationRightStraight.IsChecked = (protocolo.ActiveAnim == ProtocoloExp2.AnimOptions.DerechoRecto) ? true : false;
                if(animationLeftStraight != null)
                    animationLeftStraight.IsChecked = (protocolo.ActiveAnim == ProtocoloExp2.AnimOptions.IzquierdoRecto) ? true : false;
                if(animationRightOblique != null)
                    animationRightOblique.IsChecked = (protocolo.ActiveAnim == ProtocoloExp2.AnimOptions.DerechoOblicuo) ? true : false;
                if(animationLeftOblique != null)
                    animationLeftOblique.IsChecked = (protocolo.ActiveAnim == ProtocoloExp2.AnimOptions.IzquierdoOblicuo) ? true : false;
                
            }
            stackPanel4.DataContext = _exp2Class;
        }


        private void BotonRefresh(object sender, RoutedEventArgs e)
        {
            RefreshTree();
        }

        private void ActivateAllClick(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < _exp2Class.NumberOfProtocols; i++)
            {
                ProtocoloExp2 p = _exp2Class.GetProtocolo(i);
                p.IsActive = true;
            }
            RefreshTree();
        }

        private void DeactitateAllClick(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < _exp2Class.NumberOfProtocols; i++)
            {
                ProtocoloExp2 p = _exp2Class.GetProtocolo(i);
                p.IsActive = false;
            }
            RefreshTree();
        }

        private void RefreshTree()
        {
            if (tvProtocolos == null)
                return;

            var g = tvProtocolos.SelectedItem as Composite;

            _listaData = GetData();
            tvProtocolos.ItemsSource = _listaData;
            TreeViewItem tvi;
            if (g != null)
            {
                tvi = tvProtocolos.ItemContainerGenerator.ContainerFromIndex(g.Indice) as TreeViewItem;

                if (tvi != null)
                {
                    tvi.IsSelected = true;
                }

                wpanel.DataContext = _exp2Class.GetProtocolo(g.Indice);
            }
            else
            {
                wpanel.DataContext = _exp2Class.GetProtocolo(0);
            }
        }

        private void BotonPriorizarTiempoChecked(object sender, RoutedEventArgs e)
        {
            ProtocoloExp2 p = (ProtocoloExp2)wpanel.DataContext ?? _exp2Class.GetProtocolo(0);
            p.PrioridadCiclos = false;

        }

        private void BotonPriorizarCiclosChecked(object sender, RoutedEventArgs e)
        {
            ProtocoloExp2 p = (ProtocoloExp2)wpanel.DataContext ?? _exp2Class.GetProtocolo(0);
            p.PrioridadCiclos = true;
        }
    }

}
