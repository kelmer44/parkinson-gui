using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using CustomControlLibrary;

namespace WpfApplication1.Experiencias.Exp3
{
    public class GrupoPuerta
    {
        private readonly RadioButton _botonAbierta;
        private readonly RadioButton _botonAuto;
        private readonly RadioButton _botonCerrada;
        private readonly GroupBox _groupBox;
        private readonly Label _labelNud;
        private readonly NumericUpDown _nUpDown;
        private readonly StackPanel _stackPanel;

        public GrupoPuerta(int idx)
        {
            //<GroupBox Header="Puerta 1" Height="Auto" Name="groupBox4" Width="Auto" Margin="10">
            //        <StackPanel Height="Auto" Name="stackPanelP1" Width="Auto">
            //            <RadioButton Height="16" Name="radioButtonP10" Width="Auto" Margin="10,5">Abierta</RadioButton>
            //            <RadioButton Height="16" Name="radioButtonP11" Width="Auto" Margin="10,5">Cerrada</RadioButton>
            //            <RadioButton Height="16" Name="radioButtonP12" Width="Auto" Margin="10,5">Auto</RadioButton>
            //        </StackPanel>
            //    </GroupBox>

            _groupBox = new GroupBox
                            {
                                Header = "Puerta " + idx,
                                Height = Double.NaN,
                                Width = Double.NaN,
                                Margin = new Thickness(10),
                                Name = "groupBoxPuerta" + idx,
                                ToolTip = "Estado actual de la puerta " + idx
                            };
            _stackPanel = new StackPanel {Height = Double.NaN, Width = Double.NaN, Name = "stackPanelP" + idx};

            _botonCerrada = new RadioButton
                                {
                                    Height = Double.NaN,
                                    Width = Double.NaN,
                                    Name = "botonCerradaP" + idx,
                                    Margin = new Thickness(10, 5, 10, 5),
                                    Content = "Cerrada",
                                    GroupName = "grupoRBPuerta" + idx,
                                    ToolTip = "Puerta " + idx + " cerrada."
                                };
            _botonAbierta = new RadioButton
                                {
                                    Height = Double.NaN,
                                    Width = Double.NaN,
                                    Name = "botonAbiertaP" + idx,
                                    Margin = new Thickness(10, 5, 10, 5),
                                    Content = "Abierta",
                                    GroupName = "grupoRBPuerta" + idx,
                                    ToolTip = "Puerta " + idx + " abierta.",
                                    IsChecked = true
                                };

            _botonAuto = new RadioButton
                             {
                                 Height = Double.NaN,
                                 Width = Double.NaN,
                                 Name = "botonAutoP" + idx,
                                 Margin = new Thickness(10, 5, 10, 5),
                                 Content = "Auto",
                                 GroupName = "grupoRBPuerta" + idx,
                                 ToolTip = "Puerta " + idx + " con apertura automática por proximidad."
                             };
            _nUpDown = new NumericUpDown
                           {
                               Margin = new Thickness(0),
                               Height = 30,
                               ToolTip = "Tamaño de la puerta " + idx + "."
                           };
            NUpDown.DecimalPlaces = 2;
            NUpDown.Change = new decimal(0.01);
            NUpDown.Maximum = new decimal(1.2);
            NUpDown.Minimum = new decimal(0.75);
            NUpDown.Name = "nud" + idx;

            _labelNud = new Label
                            {
                                Name = "labelNud" + idx,
                                VerticalAlignment = VerticalAlignment.Center,
                                Padding = new Thickness(0, 5, 0, 5),
                                ToolTip = "Fija el tamaño de las puerta" + idx + ".",
                                Content = "Tamaño puerta:"
                            };
        }


        public StackPanel StackPanel1
        {
            get { return _stackPanel; }
        }

        public RadioButton BotonCerrada
        {
            get { return _botonCerrada; }
        }

        public RadioButton BotonAuto
        {
            get { return _botonAuto; }
        }

        public RadioButton BotonAbierta
        {
            get { return _botonAbierta; }
        }

        public GroupBox GroupBox1
        {
            get { return _groupBox; }
        }

        public NumericUpDown NUpDown
        {
            get { return _nUpDown; }
        }

        public Label LabelNud
        {
            get { return _labelNud; }
        }

        public Binding NudBinding { get; set; }
        public Binding AbiertaBinding { get; set; }
        public Binding AutoBinding { get; set; }
        public Binding CerradaBinding { get; set; }

    }
}