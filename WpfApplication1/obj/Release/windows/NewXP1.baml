   M S B A M L   `   `   `  ���� Q  MExperienceMainControls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null_Dclr-namespace:ExperienceMainControls;assembly=ExperienceMainControlsExperienceMainControls  O KCustomControlLibrary, Version=0.0.0.0, Culture=neutral, PublicKeyToken=nullY@clr-namespace:CustomControlLibrary;assembly=CustomControlLibraryCustomControlLibrary  Launcher$   WpfApplication1.windows.NewXP1   \ XPresentationFramework, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    8x,http://schemas.microsoft.com/winfx/2006/xaml    Y
expControlDclr-namespace:ExperienceMainControls;assembly=ExperienceMainControls    _CustomControlLibrary@clr-namespace:CustomControlLibrary;assembly=CustomControlLibrary    -     � Title$;  5Bienvenido al sistema de gestión de la Experiencia 1��$	��800��$
��Auto��$��0q� � SizeToContent$ WidthAndHeight=� � 
ResizeMode$ NoResize=� � Icon$2 ,/Launcher;component/windows/imagenes/Xp1.ico�� � WindowStartupLocation$ CenterScreen=�$��5q�$��Infinity��$
��Left=�.���� -   $��	mainPanel��.+�)   #ExperienceMainControls.MainControls  -   $��flowControls��$��10q�   DefaultFileExtension$	 xp1��$��Center=�   RandomCheckBoxActive ��  �� Path$ Random� �� Mode$ TwoWay=�	   ProtocolNumber	 �� $ CurrentProtocol�$ OneWay=�
   ProtocolState
 �� $ Estado�$ OneWay=��� -   $��xpControlsPanel�� �� Orientation$ 
Horizontal=�.+��� -   $��	groupBox1��$"��Configuración del protocolo��$
��Auto��$
��Auto��$��Stretch=�.���� -   $��protocolBodyPanel��.+��� -   $��panelProtocolTitle��$ 
Horizontal=� � ToolTip$; 5Protocolo seleccionado (para alteración de valores).��.+��� -   $��labelProtocolLabel��$
��Auto��$
��Auto��$
��Bold"�$��Center=�.��
Protocolo:�� -	   $��labelProtocolNumber��$
��Auto��$
��Auto��$
��Bold"�$��Center=����� $ IndiceVisual�0   *ExperienceMainControls.PerProtocolControls  -
   $��perProtocolControls��$��Center=�   TimeNextProtocol �� $ TimeNextProtocol�$ TwoWay=�   IsActive �� $ IsActive�$ TwoWay=�   Invertir �� $ Invertir�$ TwoWay=�   EnNegro �� $ EnNegro�$ TwoWay=�   CyclesToNextProtocol �� $ CyclesNextProtocol�$ TwoWay=��� -   $��protocolSpecificSeparator���� -   $��ProtocolSpecificMainPanel��$ 
Horizontal=�.+��� -   $��
SoundPanel��$
��Auto��$
��Auto��$ Vertical=�$��Bottom=�.+�� -   $��gridCEP��$
��Auto��$
��Auto��$��10,10q�$��Center=�$u oTiempo en segundos para proceder al siguiente protocolo en la secuencia, en caso de hallarse activo el tracking�� � ColumnDefinitions �� $
��Auto ��� $
��Auto ��� $
��Auto �.+��� -   $��labelCiclosEntrePulso��$��1��$��Center=�$	��0,5q�$v pTiempo en segundos para proceder al siguiente protocolo en la secuencia, en caso de hallarse activo el tracking.��.��Ciclos entre cada pulso:(� $��2��$��10,0,0,0q�$e _Número de ciclos de emisión de sonido que deben transcurrir para que se emita un pulso de 5v.��.��(  "CustomControlLibrary.NumericUpDown  -     Name$ CyclesBwnPulse��   Change$ 1~�   Maximum$
 20.0~�   Minimum$	 0.0~�   DecimalPlaces$ 0��$��0q�$��30��   Value �� $ CiclosEntrePulso�$ TwoWay=��� -   $��gbSonido��$��Sonido��$
��Auto��$
��Auto��$��5,2.5q�$��Center=�$��Center=�.���� -   $��spSonido��$
��Auto��$
��Auto��.+��� -   $��cbActivateSound��$��16��$
��Auto��$
��Left=�$��
10,10,10,5q�$0 *Activa la reproducción de pulsos sonoros.�� d� 	IsChecked �� $ ActivateSound�.��Activar sonido�� -   $��cbSync��$��16��$
��30,5q�$
��Auto��$
��Left=�$C =Sincroniza el sonido con el inicio de la animación de dedeo.�� �� $ 	SoundSync�.��Sincronizar con animación� -   $��grid2��$
��Auto��$
��Auto��$��
30,5,10,10q�$��Stretch=�$F @Determina la velocidad con la que se reproducen las animaciones.�� �� $
��Auto ��� $
��Auto ��� $
��Auto �.+��� -   $��label3��$��1��$��Center=�$	��0,5q�$3 -Frecuencia con la que se reproduce el sonido.��.��Frec. de reproducción:(� $��2��$��10,0,0,0q�$3 -Frecuencia con la que se reproduce el sonido.��.��  -   $ nudSoundFreq��$
 0.01~�$ 1000.0~�$	 0.1~�$ 2��$��0q�$��30�� �� $ SoundFrequency�$ TwoWay=��� -   $��gbAnims��$��5,2.5q�$��
Animación��$
��Auto��$
��Auto��$��Center=�.���� -   $��spAnims��$
��Auto��$
��Auto��.+��� -   $��cbActivateAnims��$��16��$
��Auto��$
��Left=�$��
10,10,10,5q�$0 *Activa la animación automática del dedo.�� �� $ ActivateAnimation�.��-+Activar animaciones (desactiva el tracking)� -   $��grid3��$
��Auto��$
��Auto��$��10,5,10,2.5q�$��Stretch=�$F @Determina la velocidad con la que se reproducen las animaciones.�� �� $
��Auto ��� $
��Auto ��� $
��Auto �.+��� -   $��label4��$��1��$��Center=�$	��0,5q�$8 2Tiempo que pasa hasta que se inicia la animación.��.��Contacto anterior:(� $��2��$��80,0,0,0q�$8 2Tiempo que pasa hasta que se inicia la animación.��$��Stretch=�.��  -   $ nudPassiveFreq��$
 0.01~�$ 1000.0~�$	 0.0~�$ 3��$��0q�$��30�� �� $ PassiveFrequency�$ TwoWay=�� -   $��grid4��$
��Auto��$
��Auto��$��10,2.5q�$��Stretch=�$F @Determina la velocidad con la que se reproducen las animaciones.�� �� $
��Auto ��� $
��Auto ��� $
��Auto �.+��� -   $��label5��$��1��$��Center=�$	��0,5q�$F @Determina la velocidad con la que se reproducen las animaciones.��.��Movimiento:(� $��2��$��	110,0,0,0q�$F @Determina la velocidad con la que se reproducen las animaciones.��.��  -    $ nudActiveFreq��$
 0.01~�$ 1000.0~�$	 0.0~�$ 3��$��0q�$��30�� �� $ ActiveFrequency�$ TwoWay=�� -!   $��grid33��$
��Auto��$
��Auto��$��10,2.5q�$��Stretch=�$F @Determina la velocidad con la que se reproducen las animaciones.�� �� $
��Auto ��� $
��Auto ��� $
��Auto �.+��� -"   $��label64��$��1��$��Center=�$	��0,5q�$) #Tiempo que pasa tras la animación.��.��Contacto posterior:(� $��2��$��74,0,0,0q�$) #Tiempo que pasa tras la animación.��$��Stretch=�.��  -#   $ nudPassiveFreqPost��$
 0.01~�$ 1000.0~�$	 0.0~�$ 3��$��0q�$��30�� �� $ PostPassiveFrequency�$ TwoWay=��� -$   $��stackPanel3��$
��Auto��$
��Auto��$ 
Horizontal=�$��Stretch=�.+��� -%   $��sliderValue��$��30��$��25��$��RightToLeft=�$��5,5,5,0q�����  �� ElementName$ sliderPercentage��$ Value��� -&   $��labelAnimPerc��$��0,5,5,5q�$��25��$
��Auto��$��0,5,5,5q�.��% de animación:�� -'   $��sliderPercentage��$��5,5,5,5q�$��22��$	��140�� � Maximum$	 100Q� �� TickPlacement$ TopLeft=� � SmallChange$ 1Q� �� TickFrequency$ 1Q�$6 0Cantidad de movimiento del dedo en la animación�� � LargeChange$ 10Q�  �� IsSnapToTickEnabled  . ! �� IsSelectionRangeEnabled! .  " �� Interval$" 1��# � Value# �� $ AnimationBlending�$ TwoWay=��� -(   $��BotonCopyToAllSeparator��$��0,10,0,5q��� -)   $��botonCopytoAll��$
��Auto��$��10q�$; 5Copia el contenido del protocolo en todos los demás.��$��Center=�.���� $ 
Horizontal=�$��Center=�$��Stretch=�.+��� $��15��$��imagenes\page_copy.png���� $	��5,2q�.��Copiar a todos,   &ExperienceMainControls.TreeViewControl  -*   $��tvProtocolosControl��$��10q�$��Center=��� -+   $��dbgBox��$y�Hidden=�$
��Auto��$��0���� -,   $��
botonSalir��$��23��$��75��$��10q�.��Salir