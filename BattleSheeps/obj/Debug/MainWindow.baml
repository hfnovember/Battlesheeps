   M S B A M L   `   `   `  ����G  CBattleSheeps, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:BattleSheepsBattleSheeps  5   	       BattleSheeps.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:BattleSheeps     5   	     � Title$  BattleSheeps��5   	   $��313.235��6   $��470.098��6/    � WindowStartupLocation$ CenterScreen=�6?    � 
ResizeMode$ NoResize=�6d    � ShowInTaskbar .   � AllowsTransparency .  � WindowStyle$
 None=�6�   .��5	      � .+�5
   
   �� $	��316��6   $	��Top=�6   $��Images/welcome.png��65   $��-3,0,0,0q�6Q    J� RenderTransformOrigin$ 0.5,0.5&�6c   z�5      V� 5      .~�5      �� �� 5       �� AngleX$
 0.36Q�6$   �� 5      T� 5       T� X$ 0.994Q�6)   5      5      �� 5   
   -   5        	 ��Name$	 	btnPlay_5��5      $��PLAY 5x5��6$   $
��Left=�67   $��57��6R   $��
285,73,0,0q�6^   $	��Top=�6r   $	��165��6�   $��20(�6�   $ 0.5,0.5&�6�   $
��Bold"�6�   ���	#FF74FF00
 �� 	ClickMode$
 Press=�6�    J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5         
BlurRadius$ 10Q�6#      ShadowDepth$ 10Q�63      RenderingBias$ Quality=�6D   5      �� 5   
   -   5        $	 
btnPlay_10��5      $��
PLAY 10x10��6%   $
��Left=�6:   $��285,135,0,0q�6U   $	��Top=�6j   $	��165��6�   $��57��6�   ���	#FF74FF00$��20(�6�   $
��Bold"�6�    5        5      5      �� 5   
   -   5        $	 btnExit��5      $
��EXIT��6"   $
��Left=�61   $��57��6L   $��285,225,0,0q�6X   $	��Top=�6m   $	��165��6�   $��20(�6�   $
��Bold"�6�   ���	#FFFF2020 5        5       5"      �� 5#   
   -   5         ��Name$ messageLabel��5#      $
��Left=�6&   $��57��6A   $��
10,225,0,0q�6M   $	��Top=�6a   $	��261��6y   ���	#FF79FFED$
��Bold"�6�   $��Italic$�6�   $��Source Code Pro Black)�6�   $��14(�6�   $��Center=�6�    5$        5%      5'      �� 5(   
   -   5        $ label��5(      $j��dThis game could have only been created by one person: Nicos Kasenides - for UCLan Summer Hacker 2017��6   $
��Left=�6�   $��	4,289,0,0q�6�   $	��Top=�6�   ���	#FFD4D4D4$��9(�6�   5-      5.      