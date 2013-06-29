using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Threading;
using CustomControlLibrary;
using Microsoft.Win32;
using WpfApplication1.Experiencias;
using WpfApplication1.Experiencias.Exp1;
using WpfApplication1.Experiencias.Exp3;

namespace WpfApplication1.windows
{
    /// <summary>
    /// Lógica de interacción para XP3.xaml
    /// </summary>
    public partial class Xp3 : Window
    {
        private readonly DispatcherTimer _dispatcherTimer = new DispatcherTimer();
        private Experiencia3 _exp3Class = new Experiencia3();
        private readonly GrupoPuerta[] _gpuertas = new GrupoPuerta[10];
        private readonly Serializer _fileSaver = new Serializer();
        private readonly EnumToBooleanConverter _en = new EnumToBooleanConverter();
        private int _numDoors;

        public Xp3()
        {
            _numDoors = 10;
            InitializeComponent();
            stackPanel2.DataContext = _exp3Class;
            for (int i = 0; i < 10; i++)
            {
                _gpuertas[i] = new GrupoPuerta(i + 1);
                wrapPanel1.Children.Add(_gpuertas[i].GroupBox1);
                _gpuertas[i].GroupBox1.Content = _gpuertas[i].StackPanel1;
                _gpuertas[i].StackPanel1.Children.Add(_gpuertas[i].BotonAbierta);
                _gpuertas[i].StackPanel1.Children.Add(_gpuertas[i].BotonCerrada);
                _gpuertas[i].StackPanel1.Children.Add(_gpuertas[i].BotonAuto);
                _gpuertas[i].StackPanel1.Children.Add(_gpuertas[i].LabelNud);
                _gpuertas[i].StackPanel1.Children.Add(_gpuertas[i].NUpDown);
                _gpuertas[i].BotonCerrada.Checked += CheckedCerrada;
                _gpuertas[i].BotonAbierta.Checked += CheckedAbierta;
                _gpuertas[i].BotonAuto.Checked += CheckedAuto;
                _gpuertas[i].NUpDown.Value = new decimal(1.2);

                _gpuertas[i].NudBinding = new Binding();
                _gpuertas[i].NudBinding.Source = _exp3Class.Puertas[i];
                _gpuertas[i].NudBinding.Path = new PropertyPath("TamanoPuerta");
                _gpuertas[i].NudBinding.Mode = BindingMode.TwoWay;
                _gpuertas[i].NUpDown.SetBinding(NumericUpDown.ValueProperty, _gpuertas[i].NudBinding);
            }
            /*
             * 
             * 
             * <Grid Height="Auto" Name="grid1" Width="Auto" Margin="10,0" HorizontalAlignment="Stretch">
                            <Grid.ColumnDefinitions>
                                <ColumnDefinition Width="Auto" />
                                <ColumnDefinition Width="Auto" />
                                <ColumnDefinition Width="Auto" />
                            </Grid.ColumnDefinitions>
                            <Label Name="label2" Grid.Column="1" VerticalAlignment="Center" Padding="0,5" ToolTip="Fija el tamaño de las puertas de la escena.">Tamaño de las puertas:</Label>
                            <Viewbox Grid.Column="2" Margin="72,0,0,0" ToolTip="Fija el tamaño de las puertas de la escena.">
                                <CustomControlLibrary:NUpDown x:Name="nudDoorSize" Change="0.01" Maximum="1.2" Minimum="0.75" DecimalPlaces="2" Value="{Binding Path=DoorSize, Mode=TwoWay}" Margin="0" Height="30" />
                            </Viewbox>
                        </Grid>
             * 
             * 
             */
            _exp3Class.Started = false;
            _exp3Class.AutoAnim = false;
            _exp3Class.AnimSpeed = 1.0f;
            _exp3Class.DoorSize = 1.0f;
            _exp3Class.ArmSpread = 0.5f;
            _exp3Class.TipoCamara = Experiencia3.CameraType.Primera;


            for (int i = 0; i < 10; i++)
            {
                //if(i%2==0)
                _exp3Class.Puertas[i].EstadoPuerta = PuertaExp3.DoorState.Abierta;
                //else
                //    _exp3Class.SetEstadoPuerta(i, Experiencia3.DoorState.Cerrada);
            }

            _dispatcherTimer.Tick += DispatcherTimerTick;
            _dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 0, 1);
            _dispatcherTimer.Start();

            DataContext = _exp3Class;
        }

        private void WindowLoaded(object sender, RoutedEventArgs e)
        {
        }

        private void DispatcherTimerTick(object sender, EventArgs e)
        {
            string puertaString = "";
            for (int i = 0; i < 10; i++)
            {
                puertaString += "Puerta " + (i + 1) + ": " + _exp3Class.GetPuerta(i).EstadoPuerta + " Tamano: " +
                                _exp3Class.Puertas[i].TamanoPuerta + "|||";
                if (i == 5)
                    puertaString += "\n";
            }

            //textBox1.Text = "Started: " + _exp3Class.Started
            //                + " AnimSpeed: " + _exp3Class.AnimSpeed
            //                + " ArmSpread: " + _exp3Class.ArmSpread
            //                + " DoorSize:" + _exp3Class.DoorSize
            //                + " AutoAnim: " + _exp3Class.AutoAnim
            //                + " Persona: " + _exp3Class.TipoCamara
            //                + "\n" + puertaString;
            //restablecemos el context
            stackPanel2.DataContext = _exp3Class;
            _exp3Class.EnviaDatos();
        }


        private void CheckedCerrada(object sender, RoutedEventArgs e)
        {
            string number = ((RadioButton) sender).Name.Substring(((RadioButton) sender).Name.Length - 1, 1);
            int numPuerta = int.Parse(number);
            if (numPuerta == 0) numPuerta = 10;
            _exp3Class.GetPuerta(--numPuerta).EstadoPuerta = PuertaExp3.DoorState.Cerrada;
        }

        private void CheckedAbierta(object sender, RoutedEventArgs e)
        {
            string number = ((RadioButton) sender).Name.Substring(((RadioButton) sender).Name.Length - 1, 1);
            int numPuerta = int.Parse(number);
            if (numPuerta == 0) numPuerta = 10;
            _exp3Class.GetPuerta(--numPuerta).EstadoPuerta = PuertaExp3.DoorState.Abierta;
        }

        private void CheckedAuto(object sender, RoutedEventArgs e)
        {
            string number = ((RadioButton) sender).Name.Substring(((RadioButton) sender).Name.Length - 1, 1);
            int numPuerta = int.Parse(number);
            if (numPuerta == 0) numPuerta = 10;
            _exp3Class.GetPuerta(--numPuerta).EstadoPuerta = PuertaExp3.DoorState.Auto;
        }

        private void BtnIniciarExperiencia4Click(object sender, RoutedEventArgs e)
        {
            _exp3Class.Started = true;
        }

        private void RbFirstPersonChecked(object sender, RoutedEventArgs e)
        {
            _exp3Class.TipoCamara = Experiencia3.CameraType.Primera;
        }

        private void RbThirdPersonChecked(object sender, RoutedEventArgs e)
        {
            _exp3Class.TipoCamara = Experiencia3.CameraType.Tercera;
        }


        private void BtnLoadClick(object sender, RoutedEventArgs e)
        {
            // Create OpenFileDialog
            var dlg = new OpenFileDialog();

            // Set filter for file extension and default file extension
            dlg.DefaultExt = ".xp3";
            dlg.Filter = "Configuración de la Experiencia 3 (.xp3)|*.xp3";

            // Display OpenFileDialog by calling ShowDialog method
            bool? result = dlg.ShowDialog();

            // Get the selected file name and display in a TextBox
            if (result == true)
            {
                // Open document
                string filename = dlg.FileName;

                //_exp1Class.CloseConnection();
                _exp3Class = null;

                _exp3Class = (Experiencia3)_fileSaver.DeSerializeExp3(filename);
                for (int i = 0; i < 10; i++)
                {

                    //aL ABRIR HAY QUE RESTABLECER LOS BINDINGS, VAYA UD. A SABER POR QUÉ
                    _gpuertas[i].NudBinding = new Binding();
                    _gpuertas[i].NudBinding.Source = _exp3Class.Puertas[i];
                    _gpuertas[i].NudBinding.Path = new PropertyPath("TamanoPuerta");
                    _gpuertas[i].NudBinding.Mode = BindingMode.TwoWay;
                    _gpuertas[i].NUpDown.SetBinding(NumericUpDown.ValueProperty, _gpuertas[i].NudBinding);

                    _gpuertas[i].AbiertaBinding = new Binding();
                    _gpuertas[i].AbiertaBinding.Source = _exp3Class.Puertas[i];
                    _gpuertas[i].AbiertaBinding.Path = new PropertyPath("EstadoPuerta");
                    _gpuertas[i].AbiertaBinding.Mode = BindingMode.TwoWay;
                    _gpuertas[i].AbiertaBinding.Converter = _en;
                    _gpuertas[i].AbiertaBinding.ConverterParameter = PuertaExp3.DoorState.Abierta;
                    _gpuertas[i].BotonAbierta.SetBinding(ToggleButton.IsCheckedProperty, _gpuertas[i].AbiertaBinding);

                    _gpuertas[i].CerradaBinding = new Binding();
                    _gpuertas[i].CerradaBinding.Source = _exp3Class.Puertas[i];
                    _gpuertas[i].CerradaBinding.Path = new PropertyPath("EstadoPuerta");
                    _gpuertas[i].CerradaBinding.Mode = BindingMode.TwoWay;
                    //Para bindear un radiobutton hay que hacer unb enumtobool converter
                    _gpuertas[i].CerradaBinding.Converter = _en;
                    _gpuertas[i].CerradaBinding.ConverterParameter = PuertaExp3.DoorState.Cerrada;
                    _gpuertas[i].BotonCerrada.SetBinding(ToggleButton.IsCheckedProperty, _gpuertas[i].CerradaBinding);


                    _gpuertas[i].AutoBinding = new Binding();
                    _gpuertas[i].AutoBinding.Source = _exp3Class.Puertas[i];
                    _gpuertas[i].AutoBinding.Path = new PropertyPath("EstadoPuerta");
                    _gpuertas[i].AutoBinding.Mode = BindingMode.TwoWay;
                    _gpuertas[i].AutoBinding.Converter = _en;
                    _gpuertas[i].AutoBinding.ConverterParameter = PuertaExp3.DoorState.Auto;
                    _gpuertas[i].BotonAuto.SetBinding(ToggleButton.IsCheckedProperty, _gpuertas[i].AutoBinding);

                }
            }   
        }

        private void BtnSaveClick(object sender, RoutedEventArgs e)
        {
            var saveFileDialog = new SaveFileDialog { DefaultExt = ".xp3", Filter = "Configuración de la Experiencia 3 (.xp3)|*.xp3" };
            if (saveFileDialog.ShowDialog() == true)
            {
                string filename = saveFileDialog.FileName;

                
                _fileSaver.SerializeXp3(filename, _exp3Class);
            }

        }

        private void Button3Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}