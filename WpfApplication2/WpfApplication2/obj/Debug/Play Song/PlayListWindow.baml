   M S B A M L   `   `   `  ����N  JPersion Assistant08, Version=4.0.0.0, Culture=neutral, PublicKeyToken=nullM+clr-namespace:Persion_Assistant08.Play_SongPersion_Assistant08.Play_Song  5   	   2    ,Persion_Assistant08.Play_Song.PlayListWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   =local+clr-namespace:Persion_Assistant08.Play_Song     5   	     � Title$  PlayListWindow��5   	   $	��453��6    $	��360��6-      Window_Style#��[  69    � 	Resources 5	        GotFocusColor �� Color  LostFocusColor  DGStyle �� 
TargetType)  #System.Windows.Controls.DataGridRow �� Property �� Value �� Triggers P� Property P� Value	 :� RoutedEvent
 �� TargetProperty R� KeyTime R� Value��%�  &	       &	      &	 D     7  7  �� 5
   
   $ Green��60   �� 5   
   $ Transparent��61   �� 5   
   "  6    .�5      ��  � �� �	#FFB3B3B36+   �� 5       � ��$ 25��6'   �� 5       � ��$ Stretch=�6;    5      P� 5       �@ 
IsSelected . . �5      ��  � �� �	#FF26262663   5      P� 5       �@��AlternationIndex$ 0��6C   . �5      ��  � �� �	#FF38383863   5      P� 5       �@��AlternationIndex$ 1��6C   . �5      ��  � �� �	#FF33333363   5      :� 5      $	 DataGrid.GotFocus��6   .[�5       �� .��5!      �� .��5"      T� $
 
Background�6<   ..�5#   "   i� $ 0:0:0��69   8   6I   5$      5%      5&      5'      :� 5)      $	 DataGrid.LostFocus��6   .[�5*      �� .��5+      �� .��5,      T� $
 
Background�6<   ..�5-   "   i� $ 0:0:0��69   8  6I   5.      5/      50      51      53      54      .��56      �  � RowDefinitions 57   
   �� 58      $	��20* �6   �� 59      $
��433* �6   .+�5<   
   �� 
������  Border_Style#��[ 6'   $��2��6M   ._�5=      �  � ColumnDefinitions 5>      �� 5?      $��* �6'   63   �� 5@      $��* �6'   63   �� 5A      $��* �6'   63   �� 5B      $��* �6'   63   .+�5D      � $��0��6    5E      �� 5G      $��* �6+   67   �� 5H      $��3* �6+   68   .+�5J      �� -   5         ��Name$
 icon��5J      $��0��6+     	IconStyle#��[ 6;   $��6,0,0,7q�6^   6r   �� 5K      -   5         ��Name$ title��5K       $��1��6/   
������ ��6X   ��  �� Source$
 Text��6y   5M      � 5N      $��3��6    5O      �� 5P      $	��49* �6+   �� 5Q      $��9* �6+   �� 5R      $	��23* �6+   �� 5S      $	��19* �6+   .+�5U      �� -   5        $*��$/Fonts And Pictures/exit_1205508.png��5U      $��10��6J   $��Center=�6U   $��3��6r   $��5,4,4,7q�6�   �� 5V      -   5        $��11��5V      $
��Left=�6'   $��2��6B   $��5,4,0,7q�6s   $/��)/Fonts And Pictures/029-ScaleDown-512.png��6�   5X      5Y      5[      � 5\   
   $��1��6   
�������  
Grid_Style#��[ 63    5]      �� 5^      $	��28* �6    �� 5_      $
��341* �6    �� 5`      $	��64* �6    .+�5b      � $��	10,0,10,0q�6   
������  5c      �� 5d      $��* �6'   �� 5e      $��* �6'   �� 5f      $��* �6'   .+�5h      �  5i      �� 5j      $��* �6+   �� 5k      $��* �6+   �� 5l      $��* �6+   5n      5o      � 5p      $��	10,0,10,0q�6   ���#a3abb7$��1��6<   .+�5q      &   System.Windows.Controls.DataGrid  -   5          Name$ AudioDG��5q      
������ $��1q�6F   6   5r      � 5s      
������ $��2��6,   $��
10,2,10,-2q�69    5t      �� 5u      $��* �6'   �� 5v      $��* �6'   �� 5w      $��* �6'   �� 5x      $��* �6'   �� 5y      $��* �6'   �� 5z      $��* �6'   .+�5}      �� -   5        $
��Load��5}        Button_Style#��[ 6%   $��5��6K   $
��22pxq�6[   $
��Left=�6i   .��5~      �� $O��I/Persion Assistant08;component/Fonts And Pictures/Audio player/upload.png��6   6q   5      �� 5�      -   5        $
��Save��5�      #��[ 6%   $��4��6K   $
��22pxq�6[   $
��Left=�6i   .��5�      �� $M��G/Persion Assistant08;component/Fonts And Pictures/Audio player/save.png��6   6o   5�      �� 5�      -   5        $��Remove��5�      #��[ 6'   $��3��6M   $
��22pxq�6]   $
��Left=�6k   .��5�      �� $N��H/Persion Assistant08;component/Fonts And Pictures/Audio player/minus.png��6   6p   5�      �� 5�      -	   5        $	��Add��5�      #��[ 6$   $��2��6J   $
��22pxq�6Z   $��Right=�6h   .��5�      �� $L��F/Persion Assistant08;component/Fonts And Pictures/Audio player/add.png��6   6n   5�      �� 5�      -
   5        $
��Down��5�      #��[ 6%   $��1��6K   $
��22pxq�6[   $
��Left=�6i   .��5�      �� $S��M/Persion Assistant08;component/Fonts And Pictures/Audio player/down-arrow.png��6   6u   5�      �� 5�      -   5        $��Up��5�      #��[ 6#   $��0��6I   $
��22pxq�6Y   $��Right=�6g   .��5�      �� $Q��K/Persion Assistant08;component/Fonts And Pictures/Audio player/up-arrow.png��6   6s   5�      5�      5�      5�      5�      