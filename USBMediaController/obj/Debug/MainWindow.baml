   M S B A M L   `   `   `  ����G  CUSBGameStick, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:USBMediaControllerUSBMediaController  5      #    USBMediaController.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      \ XHardcodet.Wpf.TaskbarNotification, Version=1.0.5.0, Culture=neutral, PublicKeyToken=null)tb http://www.hardcodet.net/taskbar  5      ,local clr-namespace:USBMediaController  5      -   5           MaterialDesignBody#���   5   1   $��Regular"�6o   $��13(�6�   &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�6�      TextRenderingMode$
 Auto=�6�     MaterialDesignFont#���  6�    � Title$ 
MainWindow��5   E   $��417.483��6X   $��788.462��6i    � 
ResizeMode$ NoResize=�6y    � WindowStyle$
 None=�6�   $��Center=�6�   $��Center=�6�    � WindowStartupLocation$ CenterScreen=�6�   
������  � AllowsTransparency .  � 	Resources 5        ComPorts � Source	 � XPath  ComSpeed��%�   &	       &	 ?     � 5	   
   $ CommsData.xml?�6+   $	 /Comms/Ports��6B   � 5
   
   $ CommsData.xml?�6+   $	 /Comms/Baud��6B   5      .��5      ��   MaterialDesignPaper#���  6   
 �� CornerRadius$
 10��6@   ._�5   
   � .+�5      3  -Hardcodet.Wpf.TaskbarNotification.TaskbarIcon  -   5          Name$ 	tray_main��5         ToolTipText$  ��60      TrayToolTip 5      �� 5      #���  6   
���   �$��1q�6d   $
 20��6x   $	��160��6�   $��60��6�   ._�5      � .+�5      �� -   5         ��Name$ lbl_trayInfoConnection��5   $   $	��---��6D   $��Center=�6R   $��Center=�6o   
�������$��0,20,0,0q�6�   �� 5      -   5        $ lbl_trayInfoProfile��5   $   $	��---��6A   $��Center=�6O   $��Center=�6l   
�������$��	0,-20,0,0q�6�   5      5         	TrayPopup 5      �� 5      #���  6   
������ $��1q�6j   $
 10��6~   $	��120��6�   $	��100��6�   ._�5      � .+�5      �� -   5         ��Name$ btn_trayShow��5   %   $
��Show��6;   $��Center=�6J   $��Center=�6g   $��	0,-40,0,0q�6�     MaterialDesignFlatButton#��[ 6�   �� 5      -   5        $ btn_trayClose��5   %   $��Close��6<   $��Center=�6L   $��Center=�6i   $��0,40,0,0q�6�    " MaterialDesignFlatAccentButton#��[ 6�   5      5      5      �� 5       -   5        $ btn_ConnectionSettings��5       $��ustawienia połączenia��65   $
��Left=�6U   $��386,264,0,0q�6p   $	��Top=�6�   $	��181��6�   6�   �� 5!      -   5        $ btn_CommandSettings��5!      $��ustawienia zawartości��62   $
��Left=�6R   $��601,264,0,0q�6m   $	��Top=�6�   $	��181��6�   6�   �� 5"      -	   5        $ btn_connect��5"      $��Połącz��6*   $
��Left=�6;   $��386,301,0,0q�6V   $	��Top=�6k   $	��396��6�   $	��108��6�   �� 5#      -
   5         ��Name$ 
lbxConsole��5#      $
��Left=�6*   $	��Top=�6E   $��	10,35,0,0q�6]   $	��374��6p   $	��371��6}   $��Visible=�6�   $��Visible=�6�   �� 5$      -   5        $ 	btn_close��5$      $��X��6(   $
��Left=�64   $��
738,10,0,0q�6O   $	��Top=�6c   $��40��6{   #��[ 6�   $��40��6�   �� 5%      -   5        $ btn_minimalise��5%      $��_��6-   $
��Left=�69   $��
693,10,0,0q�6T   $	��Top=�6h   $��40��6�   $��40��6�   #��[ 6�   6�   �� 5&      -   5        $ btn_hideToTray��5&      $��V��6-   $
��Left=�69   $��
648,10,0,0q�6T   $	��Top=�6h   $��40��6�   $��40��6�   #��[ 6�   6�   �� 5'      -   5        $ btn_clearConsole��5'      $��Clear console��6/   $
��Left=�6G   $��	10,10,0,0q�6b   $	��Top=�6u   $	��371��6�   $��22��6�   #��[ 6�   �� 5(      $��Connection status:��6   $
��Left=�61   $��386,235,0,0q�6L   $	��Top=�6a   �� 5)      -   5        $ lbl_connectionStatus��5)      $	��---��62   $
��Left=�6@   $��500,235,0,0q�6[   $	��Top=�6p   �� 5*      $��Selected profile:��6   $
��Left=�60   $��386,211,0,0q�6K   $	��Top=�6`   �� 5+      -   5        $ lbl_selectedProfile��5+      $	��---��61   $
��Left=�6?   $��500,211,0,0q�6Z   $	��Top=�6o   �� 5,      $��USB Game Stick v3.0��6   $
��Left=�62   $��
471,19,0,0q�6M   $	��Top=�6a   ���	#FF6464646y   5-      5.      5/      