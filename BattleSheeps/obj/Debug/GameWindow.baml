   M S B A M L   `   `   `  ����G  CBattleSheeps, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:BattleSheepsBattleSheeps  5   	       BattleSheeps.GameWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:BattleSheeps     5   	   -   5          �Name$  
gameWindow��5   	    � Title$ BattleSheeps��5   	   $	��593��6   $	��862��6+    � WindowStartupLocation$ CenterScreen=�67    � ShowActivated .  � WindowStyle$
 None=�6q   $	��862��6�   $	��593��6�   $��0��6�   $��0��6�   $��15q�6�    � 
ResizeMode$ CanMinimize=�6�   .��5
      �  � ColumnDefinitions 5   
   �� 5      .+�5   
   �� -   5         ��Name$ playerStackpanel��5      $
��Left=�6/   $	��400��6J   $��
10,183,0,0q�6W   $	��Top=�6k   $	��400��6�    K� ZIndex$ 3��6�   �� 5   
   -   5        $ computerStackpanel��5      $
��Left=�61   $	��400��6L   $��452,183,0,0q�6Y   $	��Top=�6n   $	��400��6�   $ 3��6�   �� 5   
   -   5        	 ��Name$	 btnBack��5      $
��BACK��6"   $
��Left=�61   $��32��6L   $��793,100,0,0q�6X   $	��Top=�6m   $��41��6�   
 J� Effect
 5      3  -System.Windows.Media.Effects.DropShadowEffect  5         Color$ 	#FFAEAEAE��6#   5      �� 5   
   -   5        $	 btnReset��5      $��RESET��6#   $
��Left=�63   $��32��6N   $��
793,60,0,0q�6Z   $	��Top=�6n   $��41��6�   
 5        5      $ 	#FFAEAEAE��6#   5      �� 5   
   $	��YOU��6   $
��Left=�6   $��
216,15,0,0q�69   $	��Top=�6M   $��25(�6e   
����  �6s   �� 5   
   $��COMPUTER��6   $
��Left=�6#   $��
548,15,0,0q�6>   $	��Top=�6R   $��25(�6j   
���  ��6x   �� 5   
   -   5         ��Name$ lblScorePlayer��5      $	��[0]��6(   $
��Left=�66   $��
345,15,0,0q�6Q   $	��Top=�6e   $��25(�6}   
����  �6�   �� 5   
   -   5        $ lblScoreComputer��5      $	��[0]��6*   $
��Left=�68   $��
454,15,0,0q�6S   $	��Top=�6g   $��25(�6   
���  ��6�   �� 5   
   $��-��6   $
��Left=�6   $��
407,15,0,0q�67   $	��Top=�6K   $��25(�6c   �� 5   
   -   5        $ lblPlayerSheep��5      $��# enemy sheep destroyed��6(   $
��Left=�6J   $��
216,63,0,0q�6e   $	��Top=�6y    J� RenderTransformOrigin$ -0.079,-0.385&�6�   $	��168��6�   
����  �6�   �� 5    
   -	   5        $ lblComputerSheep��5       $ ��# friendly sheep destroyed��6*   $
��Left=�6O   $��
487,63,0,0q�6j   $	��Top=�6~   $ -0.079,-0.385&�6�   $	��199��6�   $��Right=�6�   
���  ��6�   �� 5!   
   -
   5        $ lblGamesPlayed��5!      $��# Games Played��6(   $
��Left=�6A   $��
342,84,0,0q�6\   $	��Top=�6p   $��20(�6�   
���   �6�   �� 5"   
   -   5        $ lblTurns��5"      $��Turn: #��6"   $
��Left=�64   $��380,112,0,0q�6O   $	��Top=�6d   $��20(�6|   
���   �6�   �� 5#   
   ���	#FFF4F4F5$
��Left=�6%   $	��139��6@   $��	10,10,0,0q�6M   
���   �$	��Top=�6o   $	��842��6�   $ -1��6�   5%      5&      