   M S B A M L   `   `   `  ����  USBGameStick+    %USBMediaController.ConnectionSettings   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   >d2http://schemas.microsoft.com/expression/blend/2008    5	   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5
   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -   5           MaterialDesignBody#���   5   	   $��Regular"�5   	   $��13(�5   	   &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5   	      TextRenderingMode$
 Auto=�5   	     MaterialDesignFont#���  5   	    � Title$ ConnectionSettings��5   	   $��336.207��6$   $��268.276��65    � WindowStyle$
 None=�6E    � 
ResizeMode$ NoResize=�6X   $��Center=�6n   $��Center=�6�    � WindowStartupLocation$ CenterScreen=�6�   
������  � AllowsTransparency .  � 	Resources 5        ComPorts � Source	 � XPath  ComSpeed��%�   &	       &	 ?     � 5   
   $ CommsData.xml?�6+   $	 /Comms/Ports��6B   � 5   
   $ CommsData.xml?�6+   $	 /Comms/Baud��6B   5      .��5      ��    MaterialDesignDarkBackground#���  6   
 �� CornerRadius$
 10��6I   ���#eeeeee$��1q�6q   ._�5   
   � $��-2,0,2,0q�6   .+�5      �� $
��Port��6   $
��Left=�6#   $��9,16,0,0q�6>   $	��Top=�6P   �� 5      -   5         ��Name$ cbx_portName��5      $
��Left=�6-   $��
110,16,0,0q�6H   $	��Top=�6\   $	��148��6t   ��6�   ��  �� Source# [ �� 5      $��Baudrate��6   $
��Left=�6'   $��9,49,0,0q�6B   $	��Top=�6T   �� 5      -   5        $ cbx_baudrate��5      $
��Left=�6-   $��
110,45,0,0q�6H   $	��Top=�6\   $	��148��6t   ��6�   �� # [ �� 5      -   5         ��Name$ 	btn_apply��5      $��Apply��6(   $
��Left=�68   $��	9,294,0,0q�6S   $	��Top=�6f   $	��125��6~     MaterialDesignFlatButton#��[ 6�   �� 5      -   5        $ 
btn_cancel��5      $��Cancel��6)   $
��Left=�6:   $��139,294,0,0q�6U   $	��Top=�6j   $	��122��6�    " MaterialDesignFlatAccentButton#��[ 6�   �� 5      $��	Handshake��6   $
��Left=�6(   $��9,82,0,0q�6C   $	��Top=�6U   �� 5      -   5        $ cbx_handshake��5      $
��Left=�6.   $��
110,78,0,0q�6I   $	��Top=�6]   $	��148��6u   �� 5      $��Parity��6   $
��Left=�6%   $��	9,115,0,0q�6@   $	��Top=�6S   �� 5      -   5        $ 
cbx_parity��5      $
��Left=�6+   $��110,111,0,0q�6F   $	��Top=�6[   $	��148��6s   �� 5      $��DataBits��6   $
��Left=�6'   $��	9,148,0,0q�6B   $	��Top=�6U   �� 5       -   5        $ cbx_dataBits��5       $
��Left=�6-   $��110,144,0,0q�6H   $	��Top=�6]   $	��148��6u   �� 5!      $��StopBits��6   $
��Left=�6'   $��	9,181,0,0q�6B   $	��Top=�6U   �� 5"      -	   5        $ cbx_stopBits��5"      $
��Left=�6-   $��110,177,0,0q�6H   $	��Top=�6]   $	��148��6u   �� 5#      $��ReadTimeout��6   $
��Left=�6*   $��	9,214,0,0q�6E   $	��Top=�6X   �� 5$      $��WriteTimeout��6   $
��Left=�6+   $��	9,247,0,0q�6F   $	��Top=�6Y   �� 5%      -
   5         ��Name$ tbx_readTimeout��5%      $
��Left=�6/   $��23��6J   $��110,215,0,0q�6V    �� TextWrapping$
 Wrap=�6k   $�� ��6   $	��Top=�6�   $	��148��6�   �� 5&      -   5        $ tbx_writeTimeout��5&      $
��Left=�60   $��23��6K   $��110,248,0,0q�6W   $
 Wrap=�6l   $�� ��6�   $	��Top=�6�   $	��148��6�   5'      5(      5*      