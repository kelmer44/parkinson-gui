   M S B A M L   `   `   `  ���� O  KCustomControlLibrary, Version=0.0.0.0, Culture=neutral, PublicKeyToken=nullY@clr-namespace:CustomControlLibrary;assembly=CustomControlLibraryCustomControlLibrary  C ?Launcher, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:WpfApplication1.windowsWpfApplication1.windows !   WpfApplication1.windows.XP1   \ XPresentationFramework, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    8x,http://schemas.microsoft.com/winfx/2006/xaml    _CustomControlLibrary@clr-namespace:CustomControlLibrary;assembly=CustomControlLibrary    7windows%clr-namespace:WpfApplication1.windows    -     � Title$;  5Bienvenido al sistema de gestión de la Experiencia 1��$	��800��$
��Auto��$��0q� � SizeToContent$ WidthAndHeight=� � 
ResizeMode$ NoResize=� � Icon$2 ,/Launcher;component/windows/imagenes/Xp1.ico�� � WindowStartupLocation$ CenterScreen=�$��5q�$��Infinity��$
��Left=�.���� -   $��	mainPanel��.+��� -   $��stackPanel4��$
��Auto��$
��Auto��$��Center=� �� Orientation$ 
Horizontal=�$��0,5,0,0q�.+��� $��0q�
������� �� CornerRadius$ 2,2,2,2��$��Stretch=�$��Stretch=�._��� $ 
Horizontal=�$��Stretch=�$��Stretch=�.+��� -   $��stackPanel6��$��0q�$
��Auto��$
��Auto��$��Center=�$��Stretch=�$ Vertical=�.+��� -   $��btnStart�� � ToolTip$( "Marca el inicio de la experiencia.��$��25��$
��Auto��$��Stretch=�$	��5,0q�$��Stretch=�$
��10,5q�$
��Left=�.���� $ 
Horizontal=�$��Center=�$��Stretch=�.+��� $��20��$��imagenes\811214142.png���� $	��5,2q�.��	Iniciar�� -   $��btnStop��$h bDetiene temporalmente la ejecución de la experiencia hasta volver a pulsar "Iniciar Experiencia".��$��25��$
��Auto��$��Stretch=�$	��5,0q�$��Stretch=�$
��10,5q�$
��Left=�.���� $ 
Horizontal=�$��Center=�$
��Left=�.+��� $��20��$%��imagenes\control-pause-icon.png��$��Center=�$��Center=�$��UniformToFill=� �� StretchDirection$
 Both=��� $	��5,2q�.��Pausar�� -   $��btnReser��$* $Reinicia la secuencia de protocolos.��$
��Auto��$��Stretch=�$��25��$	��5,0q�$��Stretch=�$
��10,5q�$
��Left=�.���� $ 
Horizontal=�$��Center=�$��Stretch=�.+��� $��20��$"��imagenes\POWER - RESTART.png���� $	��5,2q�.��	Reiniciar�� $��1q�
�������$ 2,2,2,2��$��Center=�$��Stretch=�$��0,0,10,0q�._��� -   $��stackPanel7��$��0q�$
��Auto��$
��Auto��$��Stretch=�$��Stretch=�.+��� $��	10,5,10,0q�.��Orden aleatorio�� -	   $��label38��$
��Auto��$
��Auto��$
��Bold"�$
��Left=�$��	10,5,10,0q�$��2q�.��	Estado:�� -
   $��label41��$
��Auto��$
��Auto��$��Center=�$��0q�$��2q�$4 .Estado actual de ejecución de la experiencia.��.��En ejecución�� -   $��label39��$
��Auto��$
��Auto��$
��Bold"�$
��Left=�$
��10,0q�$��2q�.��Protocolo en ejecución:�� -   $��label40��$
��Auto��$
��Auto��$��Center=�$��0,0,0,5q�$��2q�$��1��$@ :Índice del protocolo que se está ejecutando actualmente.���� $��1q�
�������$ 2,2,2,2��$��Center=�$��Stretch=�$��0,0,10,0q�._��� $ Vertical=�$��Stretch=�$��0q�.+��� -   $��BotonCargarProtocolo��$��25��$��80��$��Center=�$��
10,10,10,5q�$O IRecupera los de configuración guardados, rechazando los cambios acuales.��$
��Left=�.���� $ 
Horizontal=�$��Center=�$��Stretch=�.+��� $��20��$��imagenes\48x48-open.png���� $	��5,2q�.��Cargar�� -   $��botonGuardarProtocolo��$��25��$��80��$��Center=�$��	10,5,10,5q�$> 8Almacena la configuración actual para futuras sesiones.��$
��Left=�.���� $ 
Horizontal=�$��Center=�$��Stretch=�.+��� $��20��$��imagenes\24_save.png���� $	��5,2q�.��	Guardar�� -   $��archivo��$
��Bold"�$	��350��$��
10,5,10,10q�$! Archivo en uso actualmente.��.��Ningún archivo cargado.�� $��5q��� $ 
Horizontal=�.+�� -   $��wpanel��	 � Orientation$	 
Horizontal=�$��Stretch=�$��Center=�}�.  $
��10,0q�$
��Auto��.+��� -   $��	groupBox1��$"��Configuración del protocolo��$
��Auto��$
��Auto��$��Stretch=�.���� .+��� $ 
Horizontal=�$; 5Protocolo seleccionado (para alteración de valores).��.+��� -   $��label7��$
��Auto��$
��Auto��$
��Bold"�$��Center=�.��
Protocolo:�� -   $��label6��$
��Auto��$
��Auto��$
��Bold"�$��Center=����� 
 �� Path$
 IndiceVisual��� $ 
Horizontal=�$��Center=�.+��� $ Vertical=�$��Stretch=�.+��� -   $��cbActive��$��16��$	��120��$
��10,5q�$7 1Activa/desactiva la ejecución de este protocolo.�� d� 	IsChecked �� $
 IsActive�.��Protocolo activo�� -   $��cbInvert��$��16��$	��120��$
��10,5q�$2 ,Invierte el tracking o la animación activa.�� �� $
 Invertir�.��Invertir lados�� -   $��cbPantallaNegra��$��16��$	��120��$��5q�$T NEl protocolo se ejecutará, pero se mostrará la pantalla en negro al usuario.�� �� $
 EnNegro�.��
En negro�� $ Vertical=�$��Center=�.+�� -   $��grid23��$
��Auto��$
��Auto��$��5q�$��Center=�$u oTiempo en segundos para proceder al siguiente protocolo en la secuencia, en caso de hallarse activo el tracking�� � ColumnDefinitions �� $
��Auto ��� $
��Auto ��� $
��Auto �.+�	� -   $��botonPriorizarTiempo��$��16��$��1�� 	� 	GroupName$ priority��$��5q�$v pTiempo en segundos para proceder al siguiente protocolo en la secuencia, en caso de hallarse activo el tracking.��.��" Tiempo siguiente protocolo (ms):(� $��2��$��10,0,0,0q�$u oTiempo en segundos para proceder al siguiente protocolo en la secuencia, en caso de hallarse activo el tracking��.��(   "CustomControlLibrary.NumericUpDown  -     Name$ SecsNextProtocol��   Change$	 0.1~�   Maximum$ 60000.0~�   Minimum$	 0.0~�   DecimalPlaces$ 1��$��0q�$��30��   Value �� $
 TimeNextProtocol� �� Mode$ TwoWay=�� -   $��grid24��$
��Auto��$
��Auto��$��5q�$��Center=�$u oTiempo en segundos para proceder al siguiente protocolo en la secuencia, en caso de hallarse activo el tracking�� �� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto �.+�	� -   $��botonPriorizarCiclos��$��16��$��1��$��5q�$ priority��$v pTiempo en segundos para proceder al siguiente protocolo en la secuencia, en caso de hallarse activo el tracking.��$
 TrueY�.��Ciclos siguiente protocolo:(� $��2��$��45,0,0,0q�$u oTiempo en segundos para proceder al siguiente protocolo en la secuencia, en caso de hallarse activo el tracking��.��  -   $ CyclesNextProtocol��$ 1~�$ 100000~�$ 5~�$ 2��$��0q�$��30�� �� $
 CyclesNextProtocol�$ TwoWay=��� �� $ 
Horizontal=�.+��� -   $��stackPanel1��$
��Auto��$
��Auto��$ Vertical=�$��Bottom=�.+�� -   $��gridCEP��$
��Auto��$
��Auto��$��10,10q�$��Center=�$u oTiempo en segundos para proceder al siguiente protocolo en la secuencia, en caso de hallarse activo el tracking�� �� $
��Auto ��� $
��Auto ��� $
��Auto �.+��� -   $��labelCiclosEntrePulso��$��1��$��Center=�$	��0,5q�$v pTiempo en segundos para proceder al siguiente protocolo en la secuencia, en caso de hallarse activo el tracking.��.��Ciclos entre cada pulso:(� $��2��$��10,0,0,0q�$e _Número de ciclos de emisión de sonido que deben transcurrir para que se emita un pulso de 5v.��.��  -    $ CyclesBwnPulse��$ 1~�$
 20.0~�$	 0.0~�$ 0��$��0q�$��30�� �� $
 CiclosEntrePulso�$ TwoWay=��� -!   $��gbSonido��$��Sonido��$
��Auto��$
��Auto��$��5,2.5q�$��Center=�$��Center=�.���� -"   $��spSonido��$
��Auto��$
��Auto��.+��� -#   $��cbActivateSound��$��16��$
��Auto��$
��Left=�$��
10,10,10,5q�$0 *Activa la reproducción de pulsos sonoros.�� �� $
 ActivateSound�.��Activar sonido�� -$   $��cbSync��$��16��$
��30,5q�$
��Auto��$
��Left=�$C =Sincroniza el sonido con el inicio de la animación de dedeo.�� �� $
 	SoundSync�.��Sincronizar con animación� -%   $��grid2��$
��Auto��$
��Auto��$��
30,5,10,10q�$��Stretch=�$F @Determina la velocidad con la que se reproducen las animaciones.�� �� $
��Auto ��� $
��Auto ��� $
��Auto �.+��� -&   $��label3��$��1��$��Center=�$	��0,5q�$3 -Frecuencia con la que se reproduce el sonido.��.��Frec. de reproducción:(� $��2��$��10,0,0,0q�$3 -Frecuencia con la que se reproduce el sonido.��.��  -'   $ nudSoundFreq��$
 0.01~�$ 1000.0~�$	 0.1~�$ 2��$��0q�$��30�� �� $
 SoundFrequency�$ TwoWay=��� -(   $��gbAnims��$��5,2.5q�$��
Animación��$
��Auto��$
��Auto��$��Center=�.���� -)   $��spAnims��$
��Auto��$
��Auto��.+��� -*   $��cbActivateAnims��$��16��$
��Auto��$
��Left=�$��
10,10,10,5q�$0 *Activa la animación automática del dedo.�� �� $
 ActivateAnimation�.��-+Activar animaciones (desactiva el tracking)� -+   $��grid3��$
��Auto��$
��Auto��$��10,5,10,2.5q�$��Stretch=�$F @Determina la velocidad con la que se reproducen las animaciones.�� �� $
��Auto ��� $
��Auto ��� $
��Auto �.+��� -,   $��label4��$��1��$��Center=�$	��0,5q�$8 2Tiempo que pasa hasta que se inicia la animación.��.��Contacto anterior:(� $��2��$��80,0,0,0q�$8 2Tiempo que pasa hasta que se inicia la animación.��$��Stretch=�.��  --   $ nudPassiveFreq��$
 0.01~�$ 1000.0~�$	 0.0~�$ 3��$��0q�$��30�� �� $
 PassiveFrequency�$ TwoWay=�� -.   $��grid4��$
��Auto��$
��Auto��$��10,2.5q�$��Stretch=�$F @Determina la velocidad con la que se reproducen las animaciones.�� �� $
��Auto ��� $
��Auto ��� $
��Auto �.+��� -/   $��label5��$��1��$��Center=�$	��0,5q�$F @Determina la velocidad con la que se reproducen las animaciones.��.��Movimiento:(� $��2��$��	110,0,0,0q�$F @Determina la velocidad con la que se reproducen las animaciones.��.��  -0   $ nudActiveFreq��$
 0.01~�$ 1000.0~�$	 0.0~�$ 3��$��0q�$��30�� �� $
 ActiveFrequency�$ TwoWay=�� -1   $��grid33��$
��Auto��$
��Auto��$��10,2.5q�$��Stretch=�$F @Determina la velocidad con la que se reproducen las animaciones.�� �� $
��Auto ��� $
��Auto ��� $
��Auto �.+��� -2   $��label64��$��1��$��Center=�$	��0,5q�$) #Tiempo que pasa tras la animación.��.��Contacto posterior:(� $��2��$��74,0,0,0q�$) #Tiempo que pasa tras la animación.��$��Stretch=�.��  -3   $ nudPassiveFreqPost��$
 0.01~�$ 1000.0~�$	 0.0~�$ 3��$��0q�$��30�� �� $
 PostPassiveFrequency�$ TwoWay=��� -4   $��stackPanel3��$
��Auto��$
��Auto��$ 
Horizontal=�$��Stretch=�.+��� -5   $��sliderValue��$��30��$��25��$��RightToLeft=�$��5,5,5,0q�����  �� ElementName$ sliderPercentage��$
 Value��� -6   $��labelAnimPerc��$��0,5,5,5q�$��25��$
��Auto��$��0,5,5,5q�.��% de animación:�� -7   $��sliderPercentage��$��5,5,5,5q�$��22��$	��140�� � Maximum$	 100Q� �� TickPlacement$ TopLeft=� � SmallChange$ 1Q� �� TickFrequency$ 1Q�$6 0Cantidad de movimiento del dedo en la animación�� � LargeChange$ 10Q� �� IsSnapToTickEnabled .  �� IsSelectionRangeEnabled .   �� Interval$ 1�� � Value �� $
 AnimationBlending�$ TwoWay=��� $��0,10,0,5q��� -8   $��botonCopytoAll��$
��Auto��$��10q�$; 5Copia el contenido del protocolo en todos los demás.��$��Center=�.���� $ 
Horizontal=�$��Center=�$��Stretch=�.+��� $��15��$��imagenes\page_copy.png���� $	��5,2q�.��Copiar a todos�� .+��� -9   $��label2��$��20��$
��Auto��$
��Left=�$��0q�$
��10,0q�.��!Protocolos (click para editar):R� -:   $��tvProtocolos��$
��10,5q�$��Stretch=�$	��Top=�$	��200��$	��292��$��0��$v pHaga clic en un protocolo para alterar sus parámetros. Pulse actualizar para reflejar los cambios en el árbol.������  �� 
TargetType" Q�.���   �� Property  � {�! �� Value! �� $
 Activo���   �@Q�
IsExpanded! .  ���� " �� ItemsSource" �� $
 Children�.R��� $ 
Horizontal=�.+��� $��imagenes\file_icon.gif��$��0,0,5,0q��� ���� $

 Name��� -;   $��button1��$
��Auto��$��Center=�$7 1Actualiza la información reflejada en el árbol.��.���� $ 
Horizontal=�$��Center=�$��Stretch=�.+��� $��15��$��imagenes\refresh-icon.png���� $	��5,2q�.��
Actualizar�� -<   $��stackPanel2��$��10q�$ Vertical=�$
��Auto��$
��Auto��$��Center=�.+��� -=   $��activateAll��$	��120��$
��10,5q�$" Activa todos los protocolos.��$
��Left=�.���� $ 
Horizontal=�$��Center=�$
��Left=�.+��� $��15��$"��imagenes\icon_check_mark.gif��$
��Left=��� $	��5,2q�$
��Left=�.��Activar todos�� ->   $��deactitateAll��$	��120��$
��10,5q�$% Desactiva todos los protocolos.��$	��Top=�.���� $ 
Horizontal=�$��Center=�$��Stretch=�.+��� $��15��$��imagenes\150.png���� $	��5,2q�.��Desactivar todos�� -?   $��dbgBox��$
��Auto��$
��Auto���� -@   $��
botonSalir��$��23��$��75��$��10q�.��Salir