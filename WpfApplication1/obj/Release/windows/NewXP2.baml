   M S B A M L   `   `   `  ���� Q  MExperienceMainControls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null_Dclr-namespace:ExperienceMainControls;assembly=ExperienceMainControlsExperienceMainControls  O KCustomControlLibrary, Version=0.0.0.0, Culture=neutral, PublicKeyToken=nullY@clr-namespace:CustomControlLibrary;assembly=CustomControlLibraryCustomControlLibrary  Launcher$   WpfApplication1.windows.NewXP2   \ XPresentationFramework, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    8x,http://schemas.microsoft.com/winfx/2006/xaml    Y
expControlDclr-namespace:ExperienceMainControls;assembly=ExperienceMainControls    _CustomControlLibrary@clr-namespace:CustomControlLibrary;assembly=CustomControlLibrary    -     � Title$;  5Bienvenido al sistema de gestión de la Experiencia 2��$	��800��$
��Auto��$��0q� � SizeToContent$ WidthAndHeight=� � 
ResizeMode$ NoResize=� � Icon$2 ,/Launcher;component/windows/imagenes/Xp2.ico�� � WindowStartupLocation$ CenterScreen=�$��5q�$��Infinity��$
��Left=�.���� -   $��	mainPanel��.+�)   #ExperienceMainControls.MainControls  -   $��flowControls��$��10q�   DefaultFileExtension$	 xp2��$��Center=�   RandomCheckBoxActive ��  �� Path$ Random� �� Mode$ TwoWay=�	   ProtocolNumber	 �� $ CurrentProtocol�$ TwoWay=�
   ProtocolState
 �� $ Estado�$ OneWay=��� -   $��xpControlsPanel�� �� Orientation$ 
Horizontal=�.+��� -   $��groupProtocolSpecific��$"��Configuración del protocolo��$
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
   $��perProtocolControls��$��Center=�   IsActive �� $ IsActive�$ TwoWay=�   Invertir �� $ Invertir�$ TwoWay=�   EnNegro �� $ EnNegro�$ TwoWay=�   CyclesToNextProtocol �� $ CyclesNextProtocol�$ TwoWay=�   TimeNextProtocol �� $ TimeNextProtocol�$ TwoWay=��� -   $��protocolSpecificSeparator���� -   $��protocolSpecificPanel��$ Vertical=�.+��� -   $��CicleSchemaPanel��$ 
Horizontal=�$��Center=�.+�� -   $��gridCEP��$
��Auto��$
��Auto��$��10,10q�$��Center=�$u oTiempo en segundos para proceder al siguiente protocolo en la secuencia, en caso de hallarse activo el tracking�� � ColumnDefinitions �� $
��Auto ��� $
��Auto ��� $
��Auto �.+��� -   $��labelCiclosEntrePulso��$��1��$��Center=�$	��0,5q�$v pTiempo en segundos para proceder al siguiente protocolo en la secuencia, en caso de hallarse activo el tracking.��.��Ciclos entre cada pulso:(� $��2��$��10,0,0,0q�$e _Número de ciclos de emisión de sonido que deben transcurrir para que se emita un pulso de 5v.��.��(  "CustomControlLibrary.NumericUpDown  -     Name$ CyclesBwnPulse��   Change$ 1~�   Maximum$
 20.0~�   Minimum$	 0.0~�   DecimalPlaces$ 0��$��0q�$��30��   Value �� $ CiclosEntrePulso�$ TwoWay=��� $��10,0,0,0q�$ Vertical=�$��Center=�$��Center=�.+��� $	��5,0q�$��1q�$��Center=�
�������._��� -   $��EsquemaCiclo��$
��Auto��$
��Auto��$/��)/Launcher;component/imagenes/timeFlow.bmp��$��Center=��� -   $��cicleSchema��$��Center=�$��2q�.��Esquema del ciclo�� -   $��protocolSpecificPanel2��$ 
Horizontal=�.+��� -   $��gbDianas��$��Dianas��$
��Auto��$
��Auto��$��5q�$��Center=�$	��Top=�.���� -   $��spDianas��$
��Auto��$
��Auto��$��Stretch=�$��Stretch=�.+��� -   $��stackDistancia��$
��Auto��$
��Auto��$ 
Horizontal=�$��Stretch=�.+��� -   $��labelAnimPerc��$��10,5,5,5q�$��25��$
��Auto��$��0,5,5,5q�.��
Distancia:�� -   $��sliderPercentage��$��5,5,5,5q�$��22��$	��140�� � Maximum$	 100Q� �� TickPlacement$ TopLeft=� � SmallChange$ 1Q� �� TickFrequency$ 1Q�$2 ,Distancia inter-dianas en el espacio virtual�� � LargeChange$ 10Q� �� IsSnapToTickEnabled .  �� IsSelectionRangeEnabled .    �� Interval$  1��! � Value! �� $ DistanceBwnTargets�$ TwoWay=�� -   $��grid1��$
��Auto��$
��Auto��$��10,10q�$��Stretch=�$9 3Tiempo de espera para mostrar la diana en pantalla.�� �� $
��Auto ��� $
��Auto ��� $
��Auto �.+��� -   $��labelTimeToTarget��$��1��$��Center=�$	��0,5q�$9 3Tiempo de espera para mostrar la diana en pantalla.��.��Retardo de diana (1):�� $��2��$��58,0,0,0q�$9 3Tiempo de espera para mostrar la diana en pantalla.��$��50��.������ $ TimeToShowTarget�$ TwoWay=�" �� ValidatesOnDataErrors" .  # �� ValidatesOnExceptions# .  $ �� UpdateSourceTrigger$$ PropertyChanged=�% �� ValidationRules% 5  /System.Windows.Controls.ExceptionValidationRule  .���� -   $��enableIlumOnTocuh��$��16��$
��Auto��$
��Left=�$��5q�$N HMarcar para iluminar la diana al toque ignorando los tiempos inferiores.��& d� 	IsChecked& �� $ ShouldLightenOnTouch�.��Iluminar al toque� -   $��gridIluminaDiana��$
��Auto��$
��Auto��$
��10,2q�$��Stretch=�$: 4Tiempo de espera para iluminar la diana en pantalla.�� �� $
��Auto ��� $
��Auto ��� $
��Auto �.+��� -   $��labelTimeToLighten��$��1��$��Center=�$	��0,5q�$: 4Tiempo de espera para iluminar la diana en pantalla.��.�� Iluminación de diana (1.5.1):�� $��2��$��30,0,0,0q�$: 4Tiempo de espera para iluminar la diana en pantalla.��$��50��.������ $ TimeToLightenTarget�$ TwoWay=�" .  # .  $$ PropertyChanged=�%   .��� -   $��gridEndIluminaDiana��$
��Auto��$
��Auto��$
��10,2q�$��Stretch=�$C =Tiempo de espera para dejar de iluminar la diana en pantalla.�� �� $
��Auto ��� $
��Auto ��� $
��Auto �.+��� -   $��labelTimeToStopLighten��$��1��$��Center=�$	��0,5q�$C =Tiempo de espera para dejar de iluminar la diana en pantalla.��.��Apagado de diana (1.5.2):�� $��2��$��43,0,0,0q�$C =Tiempo de espera para dejar de iluminar la diana en pantalla.��$��50��.������ $ TimeToStopLighten�$ TwoWay=�" .  # .  $$ PropertyChanged=�%   .��� -    $��grid56��$
��Auto��$
��Auto��$��10,10q�$��Stretch=�$: 4Tiempo total de duración del ciclo (1 + 2 + 3 + X).�� �� $
��Auto ��� $
��Auto ��� $
��Auto �.+��� -!   $��labelExtraTime��$��1��$��Center=�$	��0,5q�$: 4Tiempo total de duración del ciclo (1 + 2 + 3 + X).��.��Duración de ciclo (4):�� -"   $��CicledurationTB��$��2��$��58,0,0,0q�$: 4Tiempo total de duración del ciclo (1 + 2 + 3 + X).��$��50��.������ $ ExtraWaitingTime�$ TwoWay=�" .  # .  $$ PropertyChanged=�%   .��	� -#   $��rbRandom��$��16��$
��Auto��$��
10,10,10,5q�$
��Left=�' 	� 	GroupName$' targetState��$D >Activa la iluminación de una u otra diana de forma aleatoria.��$
& TrueY�.��Iluminar aleatoriamente	� -$   $��rbRightPanel��$��16��$
��Auto��$
��10,5q�$
��Left=�$' targetState��$- 'Ilumina repetidamente la diana derecha.��.��Iluminar panel derecho	� -%   $��rbLeftPanel��$��16��$
��Auto��$��
10,5,10,10q�$
��Left=�$' targetState��$/ )Ilumina repetidamente la diana izquierda.��.��Iluminar panel izquierdo�� -&   $��gbAnims��$��Animaciones��$
��Auto��$
��Auto��$��Center=�$��5q�.���� -'   $��spAnims��$
��Auto��$
��Auto��$��Stretch=�.+��� -(   $��enableAnims��$��16��$
��Auto��$
��Left=�$��10q�$I CActiva el uso de animaciones, ignorando la información de captura.��& �� $ AutoAnim�.��Activar animaciones�� -)   $��labelCurrentAnimation��$��28��$
��Auto��$
��Left=�$
��10,0q�{��� ( �� ElementName$( enableAnims��$ 	IsChecked�.��Animación activa:	� -*   $��animationRightStraight��$��16��$
��Auto��$
��50,5q�$' currentAnimation��$5 /Activa el reaching del brazo derecho al frente.��$
& TrueY�{��� $( enableAnims��$ 	IsChecked�.��Brazo derecho recto	� -+   $��animationRightOblique��$��16��$
��Auto��$
��50,5q�$' currentAnimation��$; 5Activa el reaching del brazo derecho al lado opuesto.��{��� $( enableAnims��$ 	IsChecked�.��Brazo derecho oblicuo	� -,   $��animationLeftStraight��$��16��$
��Auto��$
��50,5q�$' currentAnimation��$7 1Activa el reaching del brazo izquierdo al frente.��{��� $( enableAnims��$ 	IsChecked�.��Brazo izquierdo recto	� --   $��animationLeftOblique��$��16��$
��Auto��$��
50,5,10,20q�$' currentAnimation��$= 7Activa el reaching del brazo izquierdo al lado opuesto.��{��� $( enableAnims��$ 	IsChecked�.��Brazo izquierdo oblicuo� -.   $��grid2��$
��Auto��$
��Auto��$
��10,0q�$��Stretch=�$( "Tiempo de inicio de la animación.�� �� $
��Auto ��� $
��Auto ��� $
��Auto �.+��� -/   $��label3��$��1��$��Center=�$	��0,5q�$) #Tiempo de inicio de la animación..��.��Inicio de animación (2):�� $��2��$��60,0,0,0q�$( "Tiempo de inicio de la animación.��$��50��.������ $ TimeToStartAnimation�$ TwoWay=�" .  # .  $$ PropertyChanged=�%   .��� -0   $��grid3��$
��Auto��$
��Auto��$
��10,0q�$��Stretch=�$/ )Tiempo de finalización de la animación.�� �� $
��Auto ��� $
��Auto ��� $
��Auto �.+��� -1   $��label4��$��1��$��Center=�$	��0,5q�$/ )Tiempo de finalización de la animación.��.��Fin de la animación (3):�� $��2��$��60,0,0,0q�$/ )Tiempo de finalización de la animación.��$��50��.������ $ TimeToEndAnimation�$ TwoWay=�" .  # .  $$ PropertyChanged=�%   .��� -2   $��gridCopyFrom��$
��Auto��$
��Auto��$��10,10q�$��Center=�$= 7Copiar la configuración de otro protocolo en el actual�� �� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto �.+��� -3   $��labelCopyFrom��$��5q�$��1��$��Center=�$	��0,5q�$> 8Copiar la configuración de otro protocolo en el actual.��.��Copiar datos del protocolo:�� -4   $��copyFromCombo��$��2��$	��100��$��Center=�$> 8Copiar la configuración de otro protocolo en el actual.���� -5   $��copyfromButton��$��5q�$��3��$> 8Copiar la configuración de otro protocolo en el actual.��.���� $ 
Horizontal=�.+��� $	��2,0q�$��imagenes/page_copy.png���� .��Copiar,   &ExperienceMainControls.TreeViewControl  -6   $��tvProtocolosControl��$��10q�$��Center=��� -7   $��dbgBox��$
��Auto��$��0��$y�Hidden=��� -8   $��
botonSalir��$��23��$��75��$��10q�.��Salir