using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;
using Microsoft.Win32;
using WpfApplication1.Experiencias;
using WpfApplication1.Experiencias.Exp1;

namespace WpfApplication1.windows
{
    /// <summary>
    /// Lógica de interacción para Experiencia1.xaml
    /// </summary>
    public partial class XP1 : Window
    {
        private readonly DispatcherTimer _dispatcherTimer = new DispatcherTimer();
        private readonly Serializer _fileSaver = new Serializer();
        private readonly SocketManager _sm;
        private Experiencia1 _exp1Class = new Experiencia1(100);
        private List<Composite> _listaData;

        public XP1()
        {
            InitializeComponent();

            _exp1Class.Started = false;

            mainPanel.Children.Remove(dbgBox);

            for (int i = 0; i < _exp1Class.NumberOfProtocols; i++)
            {
                ProtocoloExp1 p = _exp1Class.GetProtocolo(i);
                p.IsActive = false;
                p.Invertir = (i % 2 == 0);
                p.ActivateSound = false;
                p.SoundFrequency = 1.0f;
                p.SoundSync = false;
                p.ActivateAnimation = true;
                p.ActiveFrequency = 1.0f;
                p.PassiveFrequency = 0.0f;
                p.PostPassiveFrequency = 0.0f;
                p.AnimationBlending = 50;
                p.CyclesNextProtocol = 10;
                p.TimeNextProtocol = 10f;
                p.CiclosEntrePulso = 0;
                p.PrioridadCiclos = true;
                p.EnNegro = false;

            }


            _listaData = GetData();
            tvProtocolos.ItemsSource = _listaData;

            _dispatcherTimer.Tick += DispatcherTimerTick;
            _dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 0, 1);
            _dispatcherTimer.Start();


            stackPanel4.DataContext = _exp1Class;
            wpanel.DataContext = _exp1Class.GetProtocolo(0);

            _sm = SocketManager.Instance;

            _sm.CreateReceivingSocket(IPAddress.Any, 5001);
        }


        private List<Composite> GetData()
        {
            IEnumerable<Composite> query = from p in _exp1Class.Protocolos
                                           select new Composite
                                                      {
                                                          Name = "Protocolo " + (p.IndiceProtocolo + 1),
                                                          Indice = p.IndiceProtocolo,
                                                          Activo = true,
                                                          Children = new List<Composite>
                                                                         {
                                                                             new Composite
                                                                                 {
                                                                                     Name =
                                                                                         string.Format("Activo: {0}",
                                                                                                       p.IsActive),
                                                                                     Activo = false
                                                                                 },
                                                                             new Composite
                                                                                 {
                                                                                     Name = string.Format(
                                                                                             "En Negro: {0}",
                                                                                             p.EnNegro),
                                                                                     Activo = false
                                                                                 },
                                                                             new Composite
                                                                                 {
                                                                                     Name =
                                                                                         string.Format("Invertir: {0}",
                                                                                                       p.Invertir),
                                                                                     Activo = false
                                                                                 },
                                                                             new Composite
                                                                                 {
                                                                                     Name =
                                                                                         string.Format("Sonido: {0}",
                                                                                                       p.ActivateSound),
                                                                                     Activo = false
                                                                                 },
                                                                             new Composite
                                                                                 {
                                                                                     Name =
                                                                                         string.Format(
                                                                                             "Frecuencia del sonido: {0}",
                                                                                             p.SoundFrequency),
                                                                                     Activo = false
                                                                                 },
                                                                             new Composite
                                                                                 {
                                                                                     Name =
                                                                                         string.Format(
                                                                                             "Sincronizar sonido: {0}",
                                                                                             p.SoundSync),
                                                                                     Activo = false
                                                                                 },
                                                                             new Composite
                                                                                 {
                                                                                     Name =
                                                                                         string.Format(
                                                                                             "Animación/Tracking: {0}",
                                                                                             p.ActivateAnimation?"Animación":"Tracking"),
                                                                                     Activo = false
                                                                                 },
                                                                             new Composite
                                                                                 {
                                                                                     Name =
                                                                                         string.Format(
                                                                                             "Tiempo activo: {0}",
                                                                                             p.ActiveFrequency),
                                                                                     Activo = false
                                                                                 },
                                                                             new Composite
                                                                                 {
                                                                                     Name =
                                                                                         string.Format(
                                                                                             "Tiempo pasivo Previo: {0}",
                                                                                             p.PassiveFrequency),
                                                                                     Activo = false
                                                                                 },
                                                                             new Composite
                                                                                {
                                                                                     Name = string.Format(
                                                                                             "Tiempo Pasivo Posterior: {0}",
                                                                                             p.PostPassiveFrequency),
                                                                                     Activo = false
                                                                                 },
                                                                             new Composite
                                                                                 {
                                                                                     Name =
                                                                                         string.Format(
                                                                                             "Animation blending: {0}",
                                                                                             p.AnimationBlending),
                                                                                     Activo = false
                                                                                 },
                                                                             new Composite
                                                                                 {
                                                                                     Name =
                                                                                         string.Format(
                                                                                             "Ciclos siguiente protocolo: {0}",
                                                                                             p.CyclesNextProtocol),
                                                                                     Activo = false
                                                                                 },
                                                                             new Composite
                                                                                 {
                                                                                     Name =
                                                                                         string.Format(
                                                                                             "Tiempo siguiente protocolo: {0}",
                                                                                             p.TimeNextProtocol),
                                                                                     Activo = false
                                                                                 },
                                                                             new Composite
                                                                                 {
                                                                                     Name =
                                                                                         string.Format(
                                                                                             "Ciclos entre cada pulso: {0}",
                                                                                             p.CiclosEntrePulso),
                                                                                     Activo = false
                                                                                 },
                                                                             new Composite
                                                                                 {
                                                                                     Name = string.Format(
                                                                                             "Prioridad Ciclos/Tiempo: {0}",
                                                                                             p.PrioridadCiclos?"Ciclos":"Tiempo"),
                                                                                     Activo = false
                                                                                 },
                                                                                 
                                                                         }
                                                      };

            return query.ToList();
        }


        private void DispatcherTimerTick(object sender, EventArgs e)
        {
            _listaData = GetData();


            _exp1Class.EnviaDatos();
            //_exp1Class.RecibeDatos();
            _sm.RecibeDatos();


            byte[] recibidos = _sm.ReceivedBytes;
            if (recibidos != null)
            {
                var numero = BitConverter.ToSingle(recibidos, 0);
                var ciclo = BitConverter.ToSingle(recibidos, 1);

                _exp1Class.CurrentProtocol = (int) numero;
                label40.Content = (int)numero;
                //label52.Content = (int)ciclo;
            }

            dbgBox.Text = "Started: " + _exp1Class.Started
                + " Random: " + _exp1Class.Random
                + " Anim Active: " + _exp1Class.GetProtocolo(0).ActivateAnimation
                + " Invertir: " + _exp1Class.GetProtocolo(0).Invertir
                + " Sound Active: " + _exp1Class.GetProtocolo(0).ActivateSound
                + " \nActiveFreq: " + 1 / _exp1Class.GetProtocolo(0).ActiveFrequency
                + " PassiveFreq: " + _exp1Class.GetProtocolo(0).PassiveFrequency
                + " Sync: " + _exp1Class.GetProtocolo(0).SoundSync
                + " SoundFreq: " + _exp1Class.GetProtocolo(0).SoundFrequency
                + " Anim Blending: " + _exp1Class.GetProtocolo(0).AnimationBlending / 100.0f
                + " Current Protocol: " + _exp1Class.CurrentProtocol
                + " Contador: " + DateTime.Now
                + " En negro: " + _exp1Class.GetProtocolo(0).EnNegro
                + "\n";

            //label40.Content = (_exp1Class.CurrentProtocol + 1);

            switch (_exp1Class.Estado)
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
            _exp1Class.Started = true;
            _exp1Class.Estado = Experiencia.Estados.Running;
        }

        private void BtnStopClick(object sender, RoutedEventArgs e)
        {
            _exp1Class.Started = false;
            _exp1Class.Estado = Experiencia.Estados.Stopped;
        }

        private void BotonSalirClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void TvProtocolosSelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            var t = (TreeView) sender;

            if (t == null)
                return;

            var g = t.SelectedItem as Composite;


            if (g != null)
            {
                wpanel.DataContext = _exp1Class.GetProtocolo(g.Indice);
                if (botonPriorizarCiclos != null)
                {
                    botonPriorizarCiclos.IsChecked = _exp1Class.GetProtocolo(g.Indice).PrioridadCiclos;
                    botonPriorizarTiempo.IsChecked = !_exp1Class.GetProtocolo(g.Indice).PrioridadCiclos;
                }
            }
            stackPanel4.DataContext = _exp1Class;
        }

        private void BotonGuardarProtocoloClick(object sender, RoutedEventArgs e)
        {
            var saveFileDialog = new SaveFileDialog { DefaultExt = ".xp1", Filter = "Configuración de la experiencia 1 (.xp1)|*.xp1" };
            if (saveFileDialog.ShowDialog() == true)
            {
                string filename = saveFileDialog.FileName;
                _fileSaver.SerializeXp1(filename, _exp1Class);

                archivo.Content = filename.Substring(filename.LastIndexOf("\\") + 1);
            }
        }

        void RbSecuencialChecked(object sender, RoutedEventArgs e)
        {
            _exp1Class.Random = false;
        }

        void RbRandomChecked(object sender, RoutedEventArgs e)
        {
            _exp1Class.Random = true;
        }

        private void BtnResetClick(object sender, RoutedEventArgs e)
        {
            _exp1Class.Estado = Experiencia.Estados.Restarting;
            _exp1Class.ResetSignal = true;
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

                wpanel.DataContext = _exp1Class.GetProtocolo(g.Indice);
            }
            else
            {
                wpanel.DataContext = _exp1Class.GetProtocolo(0);
            }
        }

        private void BotonRefresh(object sender, RoutedEventArgs e)
        {
            RefreshTree();
        }

        private void BotonCargarProtocoloClick(object sender, RoutedEventArgs e)
        {
            // Create OpenFileDialog
            var dlg = new OpenFileDialog();

            // Set filter for file extension and default file extension
            dlg.DefaultExt = ".txt";
            dlg.Filter = "Configuración de la experiencia 1 (.xp1)|*.xp1";

            // Display OpenFileDialog by calling ShowDialog method
            bool? result = dlg.ShowDialog();

            // Get the selected file name and display in a TextBox
            if (result == true)
            {
                // Open document
                string filename = dlg.FileName;
                archivo.Content = filename.Substring(filename.LastIndexOf("\\")+1);

                //_exp1Class.CloseConnection();
                _exp1Class = null;

                _exp1Class = _fileSaver.DeSerializeExp1(filename);
                
                RefreshTree();

                _exp1Class.ResetSignal = true;
            }
        }

        private void BotonPriorizarTiempoChecked(object sender, RoutedEventArgs e)
        {
            ProtocoloExp1 p = _exp1Class.GetProtocolo(((ProtocoloExp1)wpanel.DataContext).IndiceProtocolo);
            p.PrioridadCiclos = false;
        }

        private void BotonPriorizarCiclosChecked(object sender, RoutedEventArgs e)
        {
            ProtocoloExp1 p = (ProtocoloExp1) wpanel.DataContext ?? _exp1Class.GetProtocolo(0);

            p.PrioridadCiclos = true;
        }

        void WindowLoaded(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonClick(object sender, RoutedEventArgs e)
        {
            ProtocoloExp1 protocoloActual;
            int indiceProtocolo = 0;
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
                indiceProtocolo = g.Indice;
                protocoloActual = _exp1Class.GetProtocolo(g.Indice);
            }
            else
            {
                protocoloActual = _exp1Class.GetProtocolo(0);
            }

            for (int i = 0; i < _exp1Class.NumberOfProtocols; i++)
            {
                if (i == indiceProtocolo)
                    continue;
                _exp1Class.SetProtocolo(i, protocoloActual);
            }
        }

        private void ActivateAllClick(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < _exp1Class.NumberOfProtocols; i++)
            {
                ProtocoloExp1 p = _exp1Class.GetProtocolo(i);
                p.IsActive = true;
            }
            RefreshTree();
        }

        private void DeactitateAllClick(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < _exp1Class.NumberOfProtocols; i++)
            {
                ProtocoloExp1 p = _exp1Class.GetProtocolo(i);
                p.IsActive = false;
            }
            RefreshTree();
        }

        private void WindowClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            _exp1Class.CloseConnection();
            _dispatcherTimer.Stop();
        }

    }


}