   M S B A M L   `   `   `  ���� O  KCustomControlLibrary, Version=0.0.0.0, Culture=neutral, PublicKeyToken=nullY@clr-namespace:CustomControlLibrary;assembly=CustomControlLibraryCustomControlLibrary   Launcher!   WpfApplication1.windows.XP2   \ XPresentationFramework, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    8x,http://schemas.microsoft.com/winfx/2006/xaml    _CustomControlLibrary@clr-namespace:CustomControlLibrary;assembly=CustomControlLibrary      � Title$  Experiencia 2��$
��1980��$
��Auto�� � SizeToContent$ WidthAndHeight=� � 
ResizeMode$ CanResizeWithGrip=� � Icon$2 ,/Launcher;component/windows/imagenes/Xp2.ico��.���� -   $��stackPanel1��$��12q�$��Stretch=�.+��� -   $��label1��$��28��$
��Auto��$��Center=�.��86Bienvenido al sistema de gestión de la Experiencia 2.�� -   $��stackPanelMainMenu��$
��Auto��$
��Auto��$��Center=� �� Orientation$ 
Horizontal=�$��0,5,0,0q�.+��� $��0q�
������� �� CornerRadius$ 2,2,2,2��$��Stretch=�$��Stretch=�._��� $ 
Horizontal=�$��Stretch=�$��Stretch=�.+��� -   $��stackPanel6��$��0q�$
��Auto��$
��Auto��$��Center=�$��Stretch=�$ Vertical=�.+��� -   $��btnStart�� � ToolTip$( "Marca el inicio de la experiencia.��$��25��$
��Auto��$��Stretch=�$	��5,0q�$��Stretch=�$
��10,5q�$
��Left=�.���� $ 
Horizontal=�$��Center=�$��Stretch=�.+��� $��20��$��imagenes\811214142.png���� $	��5,2q�.��	Iniciar�� -   $��btnStop��$h bDetiene temporalmente la ejecución de la experiencia hasta volver a pulsar "Iniciar Experiencia".��$��25��$
��Auto��$��Stretch=�$	��5,0q�$��Stretch=�$
��10,5q�$
��Left=�.���� $ 
Horizontal=�$��Center=�$
��Left=�.+��� $��20��$%��imagenes\control-pause-icon.png��$��Center=�$��Center=�$��UniformToFill=� �� StretchDirection$
 Both=��� $	��5,2q�.��Pausar�� -   $��btnReser��$* $Reinicia la secuencia de protocolos.��$
��Auto��$��Stretch=�$��25��$	��5,0q�$��Stretch=�$
��10,5q�$
��Left=�.���� $ 
Horizontal=�$��Center=�$��Stretch=�.+��� $��20��$"��imagenes\POWER - RESTART.png���� $	��5,2q�.��	Reiniciar�� $��1q�
�������$ 2,2,2,2��$��Center=�$��Stretch=�$��0,0,10,0q�._��� -   $��stackPanel7��$��0q�$
��Auto��$
��Auto��$��Stretch=�$��Stretch=�.+��� $��	10,5,10,0q�.��Orden aleatorio�� -	   $��label38��$
��Auto��$
��Auto��$
��Bold"�$
��Left=�$��	10,5,10,0q�$��2q�.��	Estado:�� -
   $��label41��$
��Auto��$
��Auto��$��Center=�$��0q�$��2q�$4 .Estado actual de ejecución de la experiencia.��.��En ejecución�� -   $��label39��$
��Auto��$
��Auto��$
��Bold"�$
��Left=�$
��10,0q�$��2q�.��Protocolo en ejecución:�� -   $��label40��$
��Auto��$
��Auto��$��Center=�$��0,0,0,5q�$��2q�$��1��$@ :Índice del protocolo que se está ejecutando actualmente.���� $��1q�
�������$ 2,2,2,2��$��Center=�$��Stretch=�$��0,0,10,0q�._��� $ Vertical=�$��Stretch=�$��0q�.+��� -   $��BotonCargarProtocolo��$��25��$��80��$��Center=�$��
10,10,10,5q�$O IRecupera los de configuración guardados, rechazando los cambios acuales.��$
��Left=�.���� $ 
Horizontal=�$��Center=�$��Stretch=�.+��� $��20��$��imagenes\48x48-open.png���� $	��5,2q�.��Cargar�� -   $��botonGuardarProtocolo��$��25��$��80��$��Center=�$��	10,5,10,5q�$> 8Almacena la configuración actual para futuras sesiones.��$
��Left=�.���� $ 
Horizontal=�$��Center=�$��Stretch=�.+��� $��20��$��imagenes\24_save.png���� $	��5,2q�.��	Guardar�� -   $��archivo��$
��Bold"�$	��350��$��
10,5,10,10q�$! Archivo en uso actualmente.��.��Ningún archivo cargado.�� $��Stretch=�$��10,10q��� -   $��stackPanel4��$
��Auto��$
��Auto��$ 
Horizontal=�.+�� -   $��wpanel�� � Orientation$ 
Horizontal=�$��Stretch=�$��Center=�}�.  $
��10,0q�$
��Auto��.+��� -   $��	groupBox1��$"��Configuración del protocolo��$
��Auto��$
��Auto��$��Stretch=�.���� -   $��spDianasTracking��$
��Auto��$
��Auto��.+��� $ 
Horizontal=�$; 5Protocolo seleccionado (para alteración de valores).��.+��� -   $��label7��$
��Auto��$
��Auto��$
��Bold"�$��Center=�.��
Protocolo:�� -   $��label6��$
��Auto��$
��Auto��$
��Bold"�$��Center=����� 	 �� Path$	 IndiceVisual��� $ 
Horizontal=�$��Center=�.+��� $ Vertical=�$��Stretch=�.+��� -   $��cbActive��$��16��$	��120��$
��10,5q�$7 1Activa/desactiva la ejecución de este protocolo.��
 d� 	IsChecked
 �� $	 IsActive�.��Protocolo activo�� -   $��cbInvert��$��16��$	��120��$
��10,5q�$2 ,Invierte el tracking o la animación activa.��
 �� $	 Invertir�.��Invertir lados�� -   $��cbPantallaNegra��$��16��$	��120��$��5q�$T NEl protocolo se ejecutará, pero se mostrará la pantalla en negro al usuario.��
 �� $	 EnNegro�.��
En negro�� $ Vertical=�$��Center=�.+�� -   $��grid23��$
��Auto��$
��Auto��$��5q�$��Center=�$u oTiempo en segundos para proceder al siguiente protocolo en la secuencia, en caso de hallarse activo el tracking�� � ColumnDefinitions �� $
��Auto ��� $
��Auto ��� $
��Auto �.+�	� -   $��botonPriorizarTiempo��$��16��$��1�� 	� 	GroupName$ priority��$��5q�$v pTiempo en segundos para proceder al siguiente protocolo en la secuencia, en caso de hallarse activo el tracking.��.��" Tiempo siguiente protocolo (ms):(� $��2��$��10,0,0,0q�$u oTiempo en segundos para proceder al siguiente protocolo en la secuencia, en caso de hallarse activo el tracking��.��(   "CustomControlLibrary.NumericUpDown  -     Name$ SecsNextProtocol��   Change$	 0.1~�   Maximum$ 60000.0~�   Minimum$	 0.0~�   DecimalPlaces$ 1��$��0q�$��30��   Value �� $	 TimeNextProtocol� �� Mode$ TwoWay=�� -   $��grid24��$
��Auto��$
��Auto��$��5q�$��Center=�$u oTiempo en segundos para proceder al siguiente protocolo en la secuencia, en caso de hallarse activo el tracking�� �� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto �.+�	� -   $��botonPriorizarCiclos��$��16��$��1��$��5q�$ priority��$v pTiempo en segundos para proceder al siguiente protocolo en la secuencia, en caso de hallarse activo el tracking.��$

 TrueY�.��Ciclos siguiente protocolo:(� $��2��$��45,0,0,0q�$u oTiempo en segundos para proceder al siguiente protocolo en la secuencia, en caso de hallarse activo el tracking��.��  -   $ CyclesNextProtocol��$ 1~�$ 100000~�$ 5~�$ 2��$��0q�$��30�� �� $	 CyclesNextProtocol�$ TwoWay=��� $ 
Horizontal=�.+��� -   $��gbDianas��$��Dianas��$
��Auto��$
��Auto��$��5q�$��Center=�$	��Top=�.���� -    $��spDianas��$
��Auto��$
��Auto��$��Stretch=�$��Stretch=�.+�� -!   $��grid1��$
��Auto��$
��Auto��$��10,10q�$��Stretch=�$C =Especifica el tiempo entre la aparición de una diana y otra.�� �� $
��Auto ��� $
��Auto ��� $
��Auto �.+��� -"   $��label2��$��1��$��Center=�$	��0,5q�$C =Especifica el tiempo entre la aparición de una diana y otra.��.��Tiempo de repetición:�� $��2��$��30,0,0,0q�$C =Especifica el tiempo entre la aparición de una diana y otra.��$��50������ $	 
RepeatTime�$ TwoWay=�	� -#   $��rbRandom��$��16��$
��Auto��$��
10,10,10,5q�$
��Left=�$ targetState��$D >Activa la iluminación de una u otra diana de forma aleatoria.��$

 TrueY�.��Iluminar aleatoriamente	� -$   $��rbRightPanel��$��16��$
��Auto��$
��10,5q�$
��Left=�$ targetState��$- 'Ilumina repetidamente la diana derecha.��.��Iluminar panel derecho	� -%   $��rbLeftPanel��$��16��$
��Auto��$��
10,5,10,10q�$
��Left=�$ targetState��$/ )Ilumina repetidamente la diana izquierda.��.��Iluminar panel izquierdo�� -&   $��gbAnims��$��Animaciones��$
��Auto��$
��Auto��$��Center=�$��5q�.���� -'   $��spAnims��$
��Auto��$
��Auto��$��Stretch=�.+��� -(   $��enableAnims��$��16��$
��Auto��$
��Left=�$��10q�$I CActiva el uso de animaciones, ignorando la información de captura.��
 �� $	 AutoAnim�.��Activar animaciones�� -)   $��labelCurrentAnimation��$��28��$
��Auto��$
��Left=�$
��10,0q�{���  �� ElementName$ enableAnims��$	 	IsChecked�.��Animación activa:	� -*   $��animationRightStraight��$��16��$
��Auto��$
��50,5q�$ currentAnimation��$5 /Activa el reaching del brazo derecho al frente.��$

 TrueY�{��� $ enableAnims��$	 	IsChecked�.��Brazo derecho recto	� -+   $��animationRightOblique��$��16��$
��Auto��$
��50,5q�$ currentAnimation��$; 5Activa el reaching del brazo derecho al lado opuesto.��{��� $ enableAnims��$	 	IsChecked�.��Brazo derecho oblicuo	� -,   $��animationLeftStraight��$��16��$
��Auto��$
��50,5q�$ currentAnimation��$7 1Activa el reaching del brazo izquierdo al frente.��{��� $ enableAnims��$	 	IsChecked�.��Brazo izquierdo recto	� --   $��animationLeftOblique��$��16��$
��Auto��$��
50,5,10,20q�$ currentAnimation��$= 7Activa el reaching del brazo izquierdo al lado opuesto.��{��� $ enableAnims��$	 	IsChecked�.��Brazo izquierdo oblicuo� -.   $��grid2��$
��Auto��$
��Auto��$
��10,0q�$��Stretch=�$F @Determina la velocidad con la que se reproducen las animaciones.�� �� $
��Auto ��� $
��Auto ��� $
��Auto �.+��� -/   $��label3��$��1��$��Center=�$	��0,5q�$F @Determina la velocidad con la que se reproducen las animaciones.��.��Velocidad de movimiento:�� $��2��$��30,0,0,0q�$F @Determina la velocidad con la que se reproducen las animaciones.��$��50������ $	 	HandSpeed�$ TwoWay=�� -0   $��grid3��$
��Auto��$
��Auto��$
��10,0q�$��Stretch=�$D >Retardo entre que aparece la diana y se dispara la animación.�� �� $
��Auto ��� $
��Auto ��� $
��Auto �.+��� -1   $��label4��$��1��$��Center=�$	��0,5q�$D >Retardo entre que aparece la diana y se dispara la animación.��.��Retardo de disparo:�� $��2��$��60,0,0,0q�$D >Retardo entre que aparece la diana y se dispara la animación.��$��50������ $	 Delay�$ TwoWay=��� .+��� -2   $��labelProtocolos��$��20��$
��Auto��$
��Left=�$��0q�$
��10,0q�.��!Protocolos (click para editar):R� -3   $��tvProtocolos��$
��10,5q�$��Stretch=�$	��Top=�$	��200��$	��292��$��0��$v pHaga clic en un protocolo para alterar sus parámetros. Pulse actualizar para reflejar los cambios en el árbol.������  �� 
TargetType" Q�.���  �� Property � {� �� Value �� $	 Activo���  �@Q�
IsExpanded .  ����  �� ItemsSource �� $	 Children�.R��� $ 
Horizontal=�.+��� $��imagenes\file_icon.gif��$��0,0,5,0q��� ���� $
	 Name��� -4   $��button1��$
��Auto��$��Center=�$7 1Actualiza la información reflejada en el árbol.��.���� $ 
Horizontal=�$��Center=�$��Stretch=�.+��� $��15��$��imagenes\refresh-icon.png���� $	��5,2q�.��
Actualizar�� -5   $��stackPanel2��$��10q�$ Vertical=�$
��Auto��$
��Auto��$��Center=�.+��� -6   $��activateAll��$	��120��$
��10,5q�$" Activa todos los protocolos.��$
��Left=�.���� $ 
Horizontal=�$��Center=�$
��Left=�.+��� $��15��$"��imagenes\icon_check_mark.gif��$
��Left=��� $	��5,2q�$
��Left=�.��Activar todos�� -7   $��deactitateAll��$	��120��$
��10,5q�$% Desactiva todos los protocolos.��$	��Top=�.���� $ 
Horizontal=�$��Center=�$��Stretch=�.+��� $��15��$��imagenes\150.png���� $	��5,2q�.��Desactivar todos�� -8   $��button2��$��23��$��75��$��Right=�$��10q�.��Salir�� -9   $��dbgBox��$
��Auto��$
��Auto��