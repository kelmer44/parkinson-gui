   M S B A M L   `   `   `  ���� O  KCustomControlLibrary, Version=0.0.0.0, Culture=neutral, PublicKeyToken=nullY@clr-namespace:CustomControlLibrary;assembly=CustomControlLibraryCustomControlLibrary   Launcher!   WpfApplication1.windows.Xp3   \ XPresentationFramework, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    8x,http://schemas.microsoft.com/winfx/2006/xaml    _CustomControlLibrary@clr-namespace:CustomControlLibrary;assembly=CustomControlLibrary    -     � Title$  Experiencia 3��$
��Auto��$	��620�� � 
ResizeMode$ NoResize=� � SizeToContent$ Height=� � Icon$2 ,/Launcher;component/windows/imagenes/Xp3.ico��$��Center=�.���� -   $��stackPanel1��$��Stretch=�$
��Auto��.+��� -   $��label1��$��28��$
��Auto��$��Center=�.��86Bienvenido al sistema de gestión de la Experiencia 3.�� -   $��
separator1��$��5��$
��Auto��$
��10,2q��� -   $��stackPanel6��$
��Auto��$	��Top=�$��5q�.+��� -   $!��btnIniciarExperiencia4Click��$��23��$
��Auto��$��Center=�$��5q�$
��10,0q� � ToolTip$( "Marca el inicio de la experiencia.��.��Iniciar experiencia� -   $��grid4��$
��Auto��$
��Auto��$��Center=� � ColumnDefinitions �� $
��Auto ��� $
��Auto �.+��� -   $��stackPanel2�� � DataContext$ 
_exp3Class�� �� Orientation$ 
Horizontal=�$��0q�$��1��$��Stretch=�.+��� -	   $��	groupBox1��$��Cámara activa��$
��Auto��$	��200��$
��Left=�$��Stretch=�$
��10,5q�.���� -
   $��stackPanel3��$
��Auto��$
��Auto��$��Center=�.+�	� -   $��rbFirstPerson��$��16��$	��120��$
��10,5q�$) #Perspectiva subjetiva de la escena.�� d� 	IsChecked$
 TrueY�$��Center=�$��Center=�.��Primera persona	� -   $��rbThirdPerson��$��16��$	��120��$
��10,5q�$( "Perspectiva exterior al personaje.��$��Center=�$��Center=�.��Tercera persona�� -   $��	groupBox2��$��Parámetros��$
��Auto��$
��Auto��$
��10,5q�.���� -   $��stackPanel4��$
��Auto��$
��Auto��$
��Left=�.+��� -   $��
cbAutoAnim��$��16��$
��Auto��$
��10,5q�$G AAnima las piernas del personaje en lugar de utilizar el tracking.�� �� 	 �� Path$	 AutoAnim�.��%#Animación controlada por ordenador� -   $��grid2��$
��Auto��$
��Auto��$
��10,0q�$��Stretch=� �� $
��Auto ��� $
��Auto ��� $
��Auto �.+��� -   $��label3��$��1��$��Center=�$	��0,5q�$/ )Velocidad a la que se mueve el personaje.��.��Velocidad de animación:(� $��2��$��65,0,0,0q�$/ )Velocidad a la que se mueve el personaje.��.��(   "CustomControlLibrary.NumericUpDown  -   
  Name$
 nudAnimSpeed��   Change$
 0.01~�   Maximum$	 1.5~�   Minimum$	 0.5~�   DecimalPlaces$ 2��$��0q�$��30��   Value �� $	 	AnimSpeed� �� Mode$ TwoWay=�� -   $��grid3��$
��Auto��$
��Auto��$
��10,0q�$��Stretch=� �� $
��Auto ��� $
��Auto ��� $
��Auto �.+��� -   $��label4��$��1��$��Center=�$	��0,5q�$��0,0,5,0q�$K ECantidad de movimiento de los brazos que acompaña al de las piernas.��.��#!Amplitud de movimiento de brazos:(� $��2��$��0q�$K ECantidad de movimiento de los brazos que acompaña al de las piernas.��.��  -   $
 nudArmSpread��$
 0.01~�$	 1.0~�$	 0.0~�$ 2��$��0q�$��30�� �� $	 	ArmSpread�$ TwoWay=��� -   $��	groupBox3��$��Control de puertas��$
��Auto��$
��Auto��$
��10,5q�.��� -   $��
wrapPanel1��$
��Auto��$
��Auto���� $ 
Horizontal=�$��Stretch=�.+��� -   $��stackPanelSaveLoad��$
��Auto��$
��Auto��$ 
Horizontal=�$
��Left=�$��10q�.+��� -   $��btnLoad��$��23��$
��Auto��$
��10,0q�$��
10,10,5,10q�$< 6Carga las opciones de configuración desde un archivo.��.��Cargar configuración�� -   $��btnSave��$��23��$
��Auto��$
��10,0q�$��
10,10,5,10q�$7 1Guarda los datos de configuración en un archivo.��.��Guardar configuración�� -   $��stackPanel5��$
��Auto��$
��Auto��$ 
Horizontal=�$��Right=�$��20,10,10,10q�.+��� -   $��btnReset��$��23��$
��Auto��$
��10,0q�$��
10,10,5,10q�$O IDevuelve el personaje a la habitación número 1 y reinicia la secuencia.��.��Reiniciar experiencia�� -   $��button3��$��23��$��75��$��
5,10,10,10q�$ Vuelve al menú principal��.��Salir