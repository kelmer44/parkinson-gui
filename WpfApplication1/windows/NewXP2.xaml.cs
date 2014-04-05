using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;
using WpfApplication1.Experiencias;
using WpfApplication1.Experiencias.Exp2;

namespace WpfApplication1.windows
{
    /// <summary>
    /// Lógica de interacción para BaseWindow.xaml
    /// </summary>
    public partial class NewXP2 : Window
    {
        private const int nProtocolos = 100;
        private readonly DispatcherTimer _dispatcherTimer = new DispatcherTimer();
        private readonly Serializer _fileSaver = new Serializer();
        private readonly SocketManager _sm;
        private Experiencia2 _exp2Class = new Experiencia2(nProtocolos);
        private List<Composite> _listaData;
        private readonly TreeView _tvProtocolos;


        public NewXP2()
        {
            InitializeComponent();

            _exp2Class.Started = false;

            for (int i = 0; i < _exp2Class.NumberOfProtocols; i++)
            {
                ProtocoloExp2 p = _exp2Class.GetProtocolo(i);
                p.IsActive = false;
                p.Invertir = (i%2 == 0);
                p.EnNegro = false;

                p.ActiveAnim = ProtocoloExp2.AnimOptions.DerechoRecto;
                p.ActiveIllum = ProtocoloExp2.IllumOptions.Random;
                p.AutoAnim = false;

                p.CyclesNextProtocol = 1;
                p.TimeNextProtocol = 10f;
                p.PrioridadCiclos = true;
                p.CiclosEntrePulso = 0;

                p.TimeToShowTarget = 1.0f;
                p.TimeToStartAnimation = 1.0f;
                p.TimeToEndAnimation = 2.0f;
                p.ExtraWaitingTime = 3.0f;

                p.DistanceBwnTargets = 50.0f;
                p.ShouldLightenOnTouch = true;
                p.TimeToLightenTarget = 1.2f;
            }

            _tvProtocolos = tvProtocolosControl.TreeViewProtocolos;
            _listaData = GetData();
            _tvProtocolos.ItemsSource = _listaData;


            flowControls.DataContext = _exp2Class;
            xpControlsPanel.DataContext = _exp2Class.GetProtocolo(0);


            _dispatcherTimer.Tick += DispatcherTimerTick;
            _dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 0, 1);
            _dispatcherTimer.Start();


            _sm = SocketManager.Instance;
            _sm.CreateReceivingSocket(IPAddress.Any, 5001);

            for (int i = 0; i < nProtocolos; i++)
                copyFromCombo.Items.Add("Protocolo " + (i + 1));
            copyFromCombo.SelectedIndex = 0;
        }

        private List<Composite> GetData()
        {
            IEnumerable<Composite> query = from p in _exp2Class.Protocolos
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
                                                                                         string.Format(
                                                                                             "Animación activa: {0}",
                                                                                             p.ActiveAnim),
                                                                                     Activo = false
                                                                                 },
                                                                             new Composite
                                                                                 {
                                                                                     Name =
                                                                                         string.Format(
                                                                                             "Animación: {0}",
                                                                                             p.AutoAnim ? "Sí" : "No"),
                                                                                     Activo = false
                                                                                 },
                                                                             new Composite
                                                                                 {
                                                                                     Name =
                                                                                         string.Format(
                                                                                             "Diana iluminada: {0}",
                                                                                             p.ActiveIllum),
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
                                                                                     Name = string.Format(
                                                                                         "Prioridad Ciclos/Tiempo: {0}",
                                                                                         p.PrioridadCiclos
                                                                                             ? "Ciclos"
                                                                                             : "Tiempo"),
                                                                                     Activo = false
                                                                                 },
                                                                             new Composite
                                                                                 {
                                                                                     Name = string.Format(
                                                                                         "CiclosEntrePulsos: {0}",
                                                                                         p.CiclosEntrePulso),
                                                                                     Activo = false
                                                                                 },
                                                                             new Composite
                                                                                 {
                                                                                     Name =
                                                                                         string.Format(
                                                                                             "Tiempo ap. Diana: {0}",
                                                                                             p.TimeToShowTarget),
                                                                                     Activo = false
                                                                                 },
                                                                             new Composite
                                                                                 {
                                                                                     Name =
                                                                                         string.Format(
                                                                                             "Tiempo inicio Anim: {0}",
                                                                                             p.TimeToStartAnimation),
                                                                                     Activo = false
                                                                                 },
                                                                             new Composite
                                                                                 {
                                                                                     Name =
                                                                                         string.Format(
                                                                                             "Tiempo final Anim: {0}",
                                                                                             p.TimeToEndAnimation),
                                                                                     Activo = false
                                                                                 },
                                                                             new Composite
                                                                                 {
                                                                                     Name =
                                                                                         string.Format(
                                                                                             "Tiempo espera final: {0}",
                                                                                             p.ExtraWaitingTime),
                                                                                     Activo = false
                                                                                 },
                                                                             new Composite
                                                                                 {
                                                                                     Name =
                                                                                         string.Format(
                                                                                             "Distancia entre dianas: {0}",
                                                                                             p.DistanceBwnTargets),
                                                                                     Activo = false
                                                                                 },
                                                                                 new Composite
                                                                                 {
                                                                                     Name =
                                                                                         string.Format(
                                                                                             "Iluminar al toque: {0}",
                                                                                             p.ShouldLightenOnTouch),
                                                                                     Activo = false
                                                                                 },new Composite
                                                                                 {
                                                                                     Name =
                                                                                         string.Format(
                                                                                             "Tiempo de iluminación: {0}",
                                                                                             p.TimeToLightenTarget),
                                                                                     Activo = false
                                                                                 },

                                                                                 
                                                                         }
                                                      };

            return query.ToList();
        }

        private void DispatcherTimerTick(object sender, EventArgs e)
        {
            _listaData = GetData();

            _exp2Class.EnviaDatos();
            _exp2Class.ResetSignal = false;
            _sm.RecibeDatos();

            byte[] recibidos = _sm.ReceivedBytes;
            if (recibidos != null)
            {
                var numero = BitConverter.ToSingle(recibidos, 0);
                var ciclo = BitConverter.ToSingle(recibidos, 1);

                _exp2Class.CurrentProtocol = (int)numero+1;
                Console.Write("PNumber: " + _exp2Class.CurrentProtocol);
                //Numero = (int)numero;
                //label52.Content = (int)ciclo;
            }



            dbgBox.Text =
                "Started: " + _exp2Class.Started
                + " Random: " + _exp2Class.Random
                + " Current Protocol: " + _exp2Class.CurrentProtocol
                + " En negro: " + _exp2Class.GetProtocolo(0).EnNegro
                + " Invertir: " + _exp2Class.GetProtocolo(0).Invertir
                + " Activo: " + _exp2Class.GetProtocolo(0).IsActive
                + " Anim Activada: " + _exp2Class.GetProtocolo(0).AutoAnim
                + " Anim Activa: " + _exp2Class.GetProtocolo(0).ActiveAnim
                + " \nActiveIllum: " + _exp2Class.GetProtocolo(0).ActiveIllum
                + " TimeToShowTarget: " + _exp2Class.GetProtocolo(0).TimeToShowTarget
                + " TimeToStartAnim: " + _exp2Class.GetProtocolo(0).TimeToStartAnimation
                + " TimeToEndAnim: " + _exp2Class.GetProtocolo(0).TimeToEndAnimation
                + " ExtraWaitingTime: " + _exp2Class.GetProtocolo(0).ExtraWaitingTime
                + " Ciclos entre pulso" + _exp2Class.GetProtocolo(0).CiclosEntrePulso
                + "Prioridad ciclos? \n" + _exp2Class.GetProtocolo(0).PrioridadCiclos
                + " Ciclos next prot" + _exp2Class.GetProtocolo(0).CyclesNextProtocol
                + " Time next prot" + _exp2Class.GetProtocolo(0).TimeNextProtocol
                + " Distancia: " + _exp2Class.GetProtocolo(0).DistanceBwnTargets
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

                xpControlsPanel.DataContext = _exp2Class.GetProtocolo(g.Indice);
            }
        }

        //Event Handlers

        private void MainPanelStartClick(object sender, RoutedEventArgs e)
        {
            _exp2Class.Started = true;
            _exp2Class.Estado = Experiencia.Estados.Running;
        }

        private void MainPanelStopClick(object sender, RoutedEventArgs e)
        {
            _exp2Class.Started = false;
            _exp2Class.Estado = Experiencia.Estados.Stopped;
        }

        private void MainPanelResetClick(object sender, RoutedEventArgs e)
        {
            _exp2Class.Estado = Experiencia.Estados.Restarting;
            _exp2Class.ResetSignal = true;
        }

        private void MainPanelGuardarClick(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show("Guardar");
            string filename = flowControls.SaveFileName;
            _fileSaver.SerializeXp2(filename, _exp2Class);
        }

        private void MainPanelCargarClick(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show("Cargar");
            // Open document
            string filename = flowControls.LoadFileName;

            _exp2Class = _fileSaver.DeSerializeExp2(filename);
            _exp2Class.EnviaDatos();
            flowControls.DataContext = _exp2Class;
            xpControlsPanel.DataContext = _exp2Class.GetProtocolo(0);
            RefreshTree();
            _exp2Class.ResetSignal = true;
        }

        private void UcProtocolListDisableAllClick(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < _exp2Class.NumberOfProtocols; i++)
            {
                ProtocoloExp2 p = _exp2Class.GetProtocolo(i);
                p.IsActive = false;
            }
            RefreshTree();
        }

        private void UcProtocolListEnableAllClick(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < _exp2Class.NumberOfProtocols; i++)
            {
                ProtocoloExp2 p = _exp2Class.GetProtocolo(i);
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
            var t = (TreeView) sender;

            if (t == null)
                return;

            var g = t.SelectedItem as Composite;


            if (g != null)
            {
                xpControlsPanel.DataContext = _exp2Class.GetProtocolo(g.Indice);
                perProtocolControls.RadioButtonPriorizarCiclos = _exp2Class.GetProtocolo(g.Indice).PrioridadCiclos;
                perProtocolControls.RadioButtonPriorizarTiempo = !_exp2Class.GetProtocolo(g.Indice).PrioridadCiclos;
                switch (_exp2Class.GetProtocolo(g.Indice).ActiveIllum)
                {
                    case ProtocoloExp2.IllumOptions.Random:
                        rbRandom.IsChecked = true;
                        break;
                    case ProtocoloExp2.IllumOptions.RightPanel:
                        rbRightPanel.IsChecked = true;
                        break;
                    case ProtocoloExp2.IllumOptions.LeftPanel:
                        rbLeftPanel.IsChecked = true;
                        break;
                }

                switch (_exp2Class.GetProtocolo(g.Indice).ActiveAnim)
                {
                    case ProtocoloExp2.AnimOptions.DerechoOblicuo:
                        animationRightOblique.IsChecked = true;
                        break;
                    case ProtocoloExp2.AnimOptions.DerechoRecto:
                        animationRightStraight.IsChecked = true;
                        break;
                    case ProtocoloExp2.AnimOptions.IzquierdoRecto:
                        animationLeftStraight.IsChecked = true;
                        break;
                    case ProtocoloExp2.AnimOptions.IzquierdoOblicuo:
                        animationLeftOblique.IsChecked = true;
                        break;
                }
            }
            flowControls.DataContext = _exp2Class;
        }

        private void RbRandomChecked(object sender, RoutedEventArgs e)
        {
            ProtocoloExp2 p = (ProtocoloExp2) xpControlsPanel.DataContext ?? _exp2Class.GetProtocolo(0);
            p.ActiveIllum = ProtocoloExp2.IllumOptions.Random;
        }

        private void RbRightPanelChecked(object sender, RoutedEventArgs e)
        {
            ProtocoloExp2 p = (ProtocoloExp2) xpControlsPanel.DataContext ?? _exp2Class.GetProtocolo(0);
            p.ActiveIllum = ProtocoloExp2.IllumOptions.RightPanel;
        }

        private void RbLeftPanelChecked(object sender, RoutedEventArgs e)
        {
            ProtocoloExp2 p = (ProtocoloExp2) xpControlsPanel.DataContext ?? _exp2Class.GetProtocolo(0);
            p.ActiveIllum = ProtocoloExp2.IllumOptions.LeftPanel;
        }

        private void AnimationRightStraightChecked(object sender, RoutedEventArgs e)
        {
            ProtocoloExp2 p = (ProtocoloExp2) xpControlsPanel.DataContext ?? _exp2Class.GetProtocolo(0);
            p.ActiveAnim = ProtocoloExp2.AnimOptions.DerechoRecto;
        }

        private void AnimationRightObliqueChecked(object sender, RoutedEventArgs e)
        {
            ProtocoloExp2 p = (ProtocoloExp2) xpControlsPanel.DataContext ?? _exp2Class.GetProtocolo(0);
            p.ActiveAnim = ProtocoloExp2.AnimOptions.DerechoOblicuo;
        }

        private void AnimationLeftStraightChecked(object sender, RoutedEventArgs e)
        {
            ProtocoloExp2 p = (ProtocoloExp2) xpControlsPanel.DataContext ?? _exp2Class.GetProtocolo(0);
            p.ActiveAnim = ProtocoloExp2.AnimOptions.IzquierdoRecto;
        }

        private void AnimationLeftObliqueChecked(object sender, RoutedEventArgs e)
        {
            ProtocoloExp2 p = (ProtocoloExp2) xpControlsPanel.DataContext ?? _exp2Class.GetProtocolo(0);
            p.ActiveAnim = ProtocoloExp2.AnimOptions.IzquierdoOblicuo;
        }

        private void WindowClosing(object sender, CancelEventArgs e)
        {
            _exp2Class.CloseConnection();
            _dispatcherTimer.Stop();
        }

        private void BotonSalirClick(object sender, RoutedEventArgs e)
        {
            Close();
        }


        private void PerProtocolControlsPriorityCycleClick(object sender, RoutedEventArgs e)
        {
            ProtocoloExp2 p = (ProtocoloExp2) xpControlsPanel.DataContext ?? _exp2Class.GetProtocolo(0);
            p.PrioridadCiclos = true;
        }

        private void PerProtocolControlsPriorityTimeClick(object sender, RoutedEventArgs e)
        {
            ProtocoloExp2 p = _exp2Class.GetProtocolo(((ProtocoloExp2) xpControlsPanel.DataContext).IndiceProtocolo);
            //p.PrioridadCiclos = false;
            p.PrioridadCiclos = true;
        }

        private void CopyfromButtonClick(object sender, RoutedEventArgs e)
        {
            int protIndex = copyFromCombo.SelectedIndex;

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
            }

            _exp2Class.SetProtocolo(indiceProtocolo, _exp2Class.Protocolos[protIndex]);
        }
    }
}