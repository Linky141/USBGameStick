   M S B A M L   `   `   `  ����G  CUSBGameStick, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:USBMediaControllerUSBMediaController  5   	   )    #USBMediaController.ControllerConfig   5   	   V RMaterialDesignThemes.Wpf, Version=3.1.1.1361, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5	   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5
   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:USBMediaController     5   	   -   5           MaterialDesignBody#���   5   	   $��Regular"�5   	   $��13(�5   	   &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5   	      TextRenderingMode$
 Auto=�5   	     MaterialDesignFont#���  5   	    � Title$ ControllerConfig��5   	   $	��475��6"   $	��935��6/    � WindowStyle$
 None=�6;   $��Center=�6N   $��Center=�6k    � 
ResizeMode$ NoResize=�6�    � WindowStartupLocation$ CenterScreen=�6�   
������  � AllowsTransparency . .��5      ��    MaterialDesignDarkBackground#���  6    �� CornerRadius$ 10��6I   ���#eeeeee$��1q�6q   $��0,0,0,0q�6�   ._�5   
   � .+�5      �� $��Profile��6   $
��Left=�6&   $��	3,355,0,0q�6A   $	��Top=�6T   $��67��6l   �� 5      -   5         ��Name$ cbx_profile��5      $
��Left=�6,   $��
70,351,0,0q�6G   $	��Top=�6[   $	��640��6s   �� 5      -   5        	 ��Name$	 btn_profileSave��5      $
��Save��6.   $
��Left=�6=   $��686,384,0,0q�6X   $	��Top=�6m   $��75��6�    # MaterialDesignFlatLightBgButton#��[ 6�   �� 5      -   5        $	 btn_profileDelete��5      $��Delete��60   $
��Left=�6A   $��846,384,0,0q�6\   $	��Top=�6q   $��75��6�    " MaterialDesignFlatDarkBgButton#��[ 6�   6�   �� 5      -   5        $ cbx_upAction��5      $
��Left=�6-   $��
148,48,0,0q�6H   $	��Top=�6\   $	��120��6t   �� 5      -   5        $ cbx_act6Action��5      $
��Left=�6/   $��
801,96,0,0q�6J   $	��Top=�6^   $	��120��6v   �� 5      -   5        $ cbx_act3Action��5      $
��Left=�6/   $��801,205,0,0q�6J   $	��Top=�6_   $	��120��6w   �� 5      -   5        $ cbx_act5Action��5      $
��Left=�6/   $��
622,96,0,0q�6J   $	��Top=�6^   $	��120��6v   �� 5      -	   5        $ cbx_leftAction��5      $
��Left=�6/   $��
22,141,0,0q�6J   $	��Top=�6^   $	��120��6v   �� 5      -
   5        $ cbx_rightAction��5      $
��Left=�60   $��280,136,0,0q�6K   $	��Top=�6`   $	��120��6x   �� 5      -   5        $ cbx_act1Action��5      $
��Left=�6/   $��443,205,0,0q�6J   $	��Top=�6_   $	��120��6w   �� 5      -   5        $ cbx_act2Action��5      $
��Left=�6/   $��622,205,0,0q�6J   $	��Top=�6_   $	��120��6w   �� 5      -   5        $ cbx_downAction��5      $
��Left=�6/   $��148,223,0,0q�6J   $	��Top=�6_   $	��120��6w   �� 5       -   5        $ cbx_act4Action��5       $
��Left=�6/   $��
443,96,0,0q�6J   $	��Top=�6^   $	��120��6v   �� 5!      -   5        $	 btn_save��5!      $
��Save��6'   $
��Left=�66   $��	8,430,0,0q�6Q   $	��Top=�6d   $	��353��6|     MaterialDesignFlatButton#��[ 6�   �� 5"      -   5        $	 
btn_cancel��5"      $��Cancel��6)   $
��Left=�6:   $��366,431,0,0q�6U   $	��Top=�6j   $	��517��6�    " MaterialDesignFlatAccentButton#��[ 6�   �� 5#      -   5        $	 btn_profileLoad��5#      $
��Load��6.   $
��Left=�6=   $��603,384,0,0q�6X   $	��Top=�6m   $��75��6�   6�   �� 5$      -   5        $	 btn_profileOverwrite��5$      $��Update��63   $
��Left=�6D   $��766,384,0,0q�6_   $��0,0,0,0q�6t   $	��Top=�6�   $��75��6�   #��[ 6�   �� 5%      -   5        $	 btnHelp��5%      $��?��6&   $
��Left=�62   $��0q�6M   $��888,430,0,0q�6Y   $	��Top=�6n   $��33��6�      MaterialDesignOutlinedButton#��[ 6�   6�   �� 5&      -   5        $	 btnGamepadMode��5&   �   $��Gamepad mode: OFF��6   $
��Left=�61   $��715,351,0,0q�6L   $	��Top=�6a   $	��206��6y   $��28��6�   #��[ 6�   �� 5'      $��DPAD UP��6   $
��Left=�6&   $��
148,24,0,0q�6A   $	��Top=�6U   �� 5(      $��	DPAD DOWN��6   $
��Left=�6(   $��148,199,0,0q�6C   $	��Top=�6X   �� 5)      $��	DPAD LEFT��6   $
��Left=�6(   $��
22,117,0,0q�6C   $	��Top=�6W   �� 5*      $��
DPAD RIGHT��6   $
��Left=�6)   $��280,112,0,0q�6D   $	��Top=�6Y   �� 5+      $��ACTION 4��6   $
��Left=�6'   $��
443,72,0,0q�6B   $	��Top=�6V   �� 5,      $��ACTION 1��6   $
��Left=�6'   $��443,177,0,0q�6B   $	��Top=�6W   �� 5-      $��ACTION 5��6   $
��Left=�6'   $��
622,72,0,0q�6B   $	��Top=�6V   �� 5.      $��ACTION 3��6   $
��Left=�6'   $��801,181,0,0q�6B   $	��Top=�6W   �� 5/      $��ACTION 6��6   $
��Left=�6'   $��
801,72,0,0q�6B   $	��Top=�6V   �� 50      $��ACTION 2��6   $
��Left=�6'   $��622,181,0,0q�6B   $	��Top=�6W   51      52      53      