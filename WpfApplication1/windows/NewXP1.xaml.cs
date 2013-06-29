using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;
using WpfApplication1.Experiencias;
using WpfApplication1.Experiencias.Exp1;

namespace WpfApplication1.windows
{
    /// <summary>
    /// Lógica de interacción para NewXP2.xaml
    /// </summary>
    public partial class NewXP1 : Window
    {

        private readonly DispatcherTimer _dispatcherTimer = new DispatcherTimer();
        private readonly Serializer _fileSaver = new Serializer();
        private readonly SocketManager _sm;
        private Experiencia1 _exp1Class = new Experiencia1(100);
        private List<Composite> _listaData;
        private readonly TreeView _tvProtocolos;
        
        public NewXP1()
        {
            InitializeComponent();
            _exp1Class.Started = false;
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


            _tvProtocolos = tvProtocolosControl.TreeViewProtocolos;

            _listaData = GetData();
            _tvProtocolos.ItemsSource = _listaData;



            flowControls.DataContext = _exp1Class;
            xpControlsPanel.DataContext = _exp1Class.GetProtocolo(0);

            _dispatcherTimer.Tick += DispatcherTimerTick;
            _dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 0, 1);
            _dispatcherTimer.Start();

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
            _exp1Class.ResetSignal = false;
            _sm.RecibeDatos();


            byte[] recibidos = _sm.ReceivedBytes;
            if (recibidos != null)
            {
                var numero = BitConverter.ToSingle(recibidos, 0);
                var ciclo = BitConverter.ToSingle(recibidos, 1);

                _exp1Class.CurrentProtocol = (int)numero;
                //Numero = (int)numero;
                //label52.Content = (int)ciclo;
            }

            dbgBox.Text =
                  "Started: " + _exp1Class.Started
                + " Random: " + _exp1Class.Random
                + " Current Protocol: " + _exp1Class.CurrentProtocol
                + " En negro: " + _exp1Class.GetProtocolo(0).EnNegro
                + " Invertir: " + _exp1Class.GetProtocolo(0).Invertir
                + " Activo: " + _exp1Class.GetProtocolo(0).IsActive

                + " Anim Active: " + _exp1Class.GetProtocolo(0).ActivateAnimation
                + " Anim Blending: " + _exp1Class.GetProtocolo(0).AnimationBlending / 100.0f
                + " \nActiveFreq: " + 1 / _exp1Class.GetProtocolo(0).ActiveFrequency
                + " PassiveFreq: " + _exp1Class.GetProtocolo(0).PassiveFrequency
                + " PostPassiveFreq: " + _exp1Class.GetProtocolo(0).PostPassiveFrequency

                + " Sound Active: " + _exp1Class.GetProtocolo(0).ActivateSound
                + " Sync: " + _exp1Class.GetProtocolo(0).SoundSync
                + " SoundFreq: " + _exp1Class.GetProtocolo(0).SoundFrequency

                + " Ciclos entre pulso" + _exp1Class.GetProtocolo(0).CiclosEntrePulso
                + "Prioridad ciclos? \n" + _exp1Class.GetProtocolo(0).PrioridadCiclos
                + " Ciclos next prot" + _exp1Class.GetProtocolo(0).CyclesNextProtocol
                + " Time next prot" + _exp1Class.GetProtocolo(0).TimeNextProtocol

                + " Contador: " + DateTime.Now;

        }

        private void RefreshTree()
        {
            if (_tvProtocolos == null)
                return;

            var g = _tvProtocolos.SelectedItem as Composite;

            _listaData = GetData();
            _tvProtocolos.ItemsSource = _listaData;
            TreeViewItem tvi;
            if (g != null)
            {
                tvi = _tvProtocolos.ItemContainerGenerator.ContainerFromIndex(g.Indice) as TreeViewItem;

                if (tvi != null)
                {
                    tvi.IsSelected = true;
                }

                xpControlsPanel.DataContext = _exp1Class.GetProtocolo(g.Indice);
            }
        }


        //Event Handlers
        private void BotonSalirClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void MainPanelStartClick(object sender, RoutedEventArgs e)
        {
            _exp1Class.Started = true;
            _exp1Class.Estado = Experiencia.Estados.Running;
        }

        private void MainPanelStopClick(object sender, RoutedEventArgs e)
        {

            _exp1Class.Started = false;
            _exp1Class.Estado = Experiencia.Estados.Stopped;
        }

        private void MainPanelResetClick(object sender, RoutedEventArgs e)
        {
            _exp1Class.Estado = Experiencia.Estados.Restarting;
            _exp1Class.ResetSignal = true;
        }

        private void MainPanelGuardarClick(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show("Guardar");
            string filename = flowControls.SaveFileName;
            _fileSaver.SerializeXp1(filename, _exp1Class);
        }

        private void MainPanelCargarClick(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show("Cargar");
            // Open document
            string filename = flowControls.LoadFileName;
            _exp1Class = null;
            _exp1Class = _fileSaver.DeSerializeExp1(filename);
            flowControls.DataContext = _exp1Class;
            xpControlsPanel.DataContext = _exp1Class.GetProtocolo(0);
            RefreshTree();
            _exp1Class.ResetSignal = true;
        }

        private void WindowClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            _exp1Class.CloseConnection();
            _dispatcherTimer.Stop();
        }

        private void UcProtocolListDisableAllClick(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < _exp1Class.NumberOfProtocols; i++)
            {
                ProtocoloExp1 p = _exp1Class.GetProtocolo(i);
                p.IsActive = false;
            }
            RefreshTree();
        }

        private void UcProtocolListEnableAllClick(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < _exp1Class.NumberOfProtocols; i++)
            {
                ProtocoloExp1 p = _exp1Class.GetProtocolo(i);
                p.IsActive = true;
            }
            RefreshTree();
        }

        private void UcProtocolListRefreshClick(object sender, RoutedEventArgs e)
        {
            RefreshTree();
        }

        private void UcProtocolListSelectProtocolClick(object sender, RoutedEventArgs e)
        {

            var t = (TreeView)sender;

            if (t == null)
                return;

            var g = t.SelectedItem as Composite;


            if (g != null)
            {
                xpControlsPanel.DataContext = _exp1Class.GetProtocolo(g.Indice);
                if (perProtocolControls != null)
                {
                    perProtocolControls.RadioButtonPriorizarCiclos = _exp1Class.GetProtocolo(g.Indice).PrioridadCiclos;
                    perProtocolControls.RadioButtonPriorizarTiempo = !_exp1Class.GetProtocolo(g.Indice).PrioridadCiclos;
                }
            }
            mainPanel.DataContext = _exp1Class;
        }


        private void CopyToAllButtonClick(object sender, RoutedEventArgs e)
        {
            ProtocoloExp1 protocoloActual;
            int indiceProtocolo = 0;
            if (_tvProtocolos == null)
                return;

            var g = _tvProtocolos.SelectedItem as Composite;

            _listaData = GetData();
            _tvProtocolos.ItemsSource = _listaData;
            TreeViewItem tvi;
            if (g != null)
            {
                tvi = _tvProtocolos.ItemContainerGenerator.ContainerFromIndex(g.Indice) as TreeViewItem;

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

        private void PerProtocolControlsPriorityCycleClick(object sender, RoutedEventArgs e)
        {
            ProtocoloExp1 p = (ProtocoloExp1)xpControlsPanel.DataContext ?? _exp1Class.GetProtocolo(0);
            p.PrioridadCiclos = true;
        }

        private void PerProtocolControlsPriorityTimeClick(object sender, RoutedEventArgs e)
        {
            ProtocoloExp1 p = _exp1Class.GetProtocolo(((ProtocoloExp1)xpControlsPanel.DataContext).IndiceProtocolo);
            p.PrioridadCiclos = false;
        }
    }
}
