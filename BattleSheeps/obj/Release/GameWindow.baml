   M S B A M L   `   `   `  ���� G  CBattleSheeps, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:BattleSheepsBattleSheeps      BattleSheeps.GameWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     ,localclr-namespace:BattleSheeps     -     �Name$  
gameWindow�� � Title$ BattleSheeps��$	��593��$	��862�� � WindowStartupLocation$ CenterScreen=� � ShowActivated .  � WindowStyle$
 None=�$	��862��$	��593��$��0��$��0��$��15q� � 
ResizeMode$ CanMinimize=� � Icon$ Images/sheepICO.ico��.���  � ColumnDefinitions �� .+��� -    ��Name$ playerStackpanel��$
��Left=�$	��400��$��
10,183,0,0q�$	��Top=�$	��400��	 K� ZIndex$	 3���� -   $ computerStackpanel��$
��Left=�$	��400��$��452,183,0,0q�$	��Top=�$	��400��$	 3���� -   
 ��Name$
 btnBack��$
��BACK��$
��Left=�$��32��$��793,100,0,0q�$	��Top=�$��41�� J� Effect 3  -System.Windows.Media.Effects.DropShadowEffect     Color$ 	#FFAEAEAE���� -   $
 btnReset��$��RESET��$
��Left=�$��32��$��
793,60,0,0q�$	��Top=�$��41��   $ 	#FFAEAEAE���� $	��YOU��$
��Left=�$��
216,15,0,0q�$	��Top=�$��25(�
����  ��� $��COMPUTER��$
��Left=�$��
548,15,0,0q�$	��Top=�$��25(�
���  ���� -    ��Name$ lblScorePlayer��$	��[0]��$
��Left=�$��
345,15,0,0q�$	��Top=�$��25(�
����  ��� -   $ lblScoreComputer��$	��[0]��$
��Left=�$��
454,15,0,0q�$	��Top=�$��25(�
���  ���� $��-��$
��Left=�$��
407,15,0,0q�$	��Top=�$��25(��� -   $ lblPlayerSheep��$��# enemy sheep destroyed��$
��Left=�$��
216,63,0,0q�$	��Top=� J� RenderTransformOrigin$ -0.079,-0.385&�$	��168��
����  ��� -	   $ lblComputerSheep��$ ��# friendly sheep destroyed��$
��Left=�$��
487,63,0,0q�$	��Top=�$ -0.079,-0.385&�$	��199��$��Right=�
���  ���� -
   $ lblGamesPlayed��$��# Games Played��$
��Left=�$��
342,84,0,0q�$	��Top=�$��20(�
���   ��� -   $ lblTurns��$��Turn: #��$
��Left=�$��380,112,0,0q�$	��Top=�$��20(�
���   ��� ���	#FFF4F4F5$
��Left=�$	��139��$��	10,10,0,0q�
���   �$	��Top=�$	��842��$	 -1��