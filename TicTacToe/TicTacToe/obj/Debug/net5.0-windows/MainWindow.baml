   M S B A M L   `   `   `  ����D  @TicTacToe, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:TicTacToe	TicTacToe  5   	       TicTacToe.MainWindow   5   	   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:TicTacToe     5   	     � Title$  
MainWindow��5   	   $
��1000��6   $	��800��6*    � 	Resources 5	      #   TicTacToe.VisibilityConverter   VisibilityConverter��%   &	          5
   
   6$   5      .��5      �  � ShowGridLines$
 True��6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $	��800 �6    � ColumnDefinitions 5   
   �� 5      $	��800 �6   .+�5   
   �� $��0��6   $��0��6"   $��10q�62   $��Center=�6>   .+�5      �� -   5         ��Name$ txtGameOver��5   P   $��Winner:��6   $��10q�6'   $��Center=�63   
���  ��$��28(�5   -   $
��Bold"�6;   y�5      �� *
GameOver+ �� 	Converter# [  5      �� 5      -   5         ��Name$ btnReset��5      $��Reset��6'   $��4q�67   $	��100��6C   y�5      �� *
GameOver+# [  5      � 5    
   -   5         �Name$ 
visualGrid��5"      $��1��5       $��0��5!      $��0,0,0,20q�5#      5$      5%      5&      