   M S B A M L   `   `   `  ����N  JPersion Assistant08, Version=4.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:WpfApplication2WpfApplication2  5   	   [ WSystem.Windows.Forms, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089Y@clr-namespace:System.Windows.Forms;assembly=System.Windows.FormsSystem.Windows.Forms 5   	   /    )Persion_Assistant08.Play_Video.Play_video   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:WpfApplication2     5   	   RForms@clr-namespace:System.Windows.Forms;assembly=System.Windows.Forms     5   	   H DMahApps.Metro, Version=1.6.5.1, Culture=neutral, PublicKeyToken=null6mah,http://metro.mahapps.com/winfx/xaml/controls  6X   -   5          � Title$  
Play_video��5	   	   $��562.5��6   $
��1000��6+   .��5      � .+�5   
   �� -   5         ��Name$ seekBar��5      $��Bottom=�6"    � Maximum$	 100Q�6=    � SmallChange$ 1Q�6L    � LargeChange$ 10Q�6\    �� TickFrequency$ 10Q�6m   $��
0,483,10,0q�6�   
��� ������	#FFDE9C0F J� OpacityMask
 �   �)  #MahApps.Metro.Controls.SliderHelper   TrackValueFillBrush �	#CCDE9C0F   TrackValueFillHoverBrush �	#CCDE9C0F!	   TrackValueFillPressedBrush	 �	#CCDE9C0F
 J� Opacity$
 20Q�6h   J� Effect 5      -  'System.Windows.Media.Effects.BlurEffect  5         RenderingBias$ Quality=�6   5      r� 5   
   -   5         r�Name$ mediaElement��5       r� LoadedBehavior$ Manual=�6.   $��0,5,0,46q�6m   $��Center=�6:  $��Center=�6U   � Cursor$
 None��6r   r� Source 6�   �� *
VideoUri+ �� NotifyOnSourceUpdated .  �� NotifyOnTargetUpdated . 6r  �� 5   
   -   5         ��Name$ button��5      $@��:/Persion Assistant08;component/Fonts And Pictures/#B Karim)�6!   $��12(�6i   
��� ���$��پخش��6�   
��� ���$��237,0,448,18q�6�   $��Bottom=�6�   $��75��6�   6�   �� 5   
   -   5        $ button1��5      $@��:/Persion Assistant08;component/Fonts And Pictures/#B Karim)�6"   $��12(�6j   
��� ���$��توقف��6�   
��� ���$��459,0,226,18q�6�   $��Bottom=�6�   $��75��6�   6�   �� 5   
   -   5        $ button2��5      
��� ���$��مکث��66   $@��:/Persion Assistant08;component/Fonts And Pictures/#B Karim)�6D   $��12(�6�   
��� ���$��697,0,220,17q�6�   $��75��6�   $��32��6�   $��Bottom=�6�    J� RenderTransformOrigin$ 0.5,0.5&�6  z�5      V� 5      .~�5      �� �� 5       �� AngleX$ 0Q�6$   �� 5       �� Angle$ 0Q�6&   T� 5       T� X$ -0.99Q�6)    T� Y$ 0.062Q�63   5        � DataContext 5"      '  !System.Windows.Forms.MouseButtons 5#      None=�6+   5%      �� 5&   
   -   5        $ button3��5&      
��� ���$@��:/Persion Assistant08;component/Fonts And Pictures/#B Karim)�66   $��12(�6~   $��تغییر اندازه��6�   
��� ���$��352,0,333,18q�6�   $��Bottom=�6�   $��75��6�   6�   �� 5'   
   -   5         ��Name$ currentTimeTextBlock��5'      $@��:/Persion Assistant08;component/Fonts And Pictures/#B Karim)�62   $��12(�6z   $��Bottom=�6�   $��10,0,687,30q�6�   $
��Wrap=�6�   ���	#FFF7F7F76�   �� 5*   
   -	   5        $ button4��5*      
��� ���$��زیرنویس��66   $��136,0,548,18q�6I   $��Bottom=�6_   $��75��6z   $ 0.5,0.5&�6�   
��� ���$@��:/Persion Assistant08;component/Fonts And Pictures/#B Karim)�6�   $��12(�6  �� 5+   
   -
   5         ��Name$ richTextBox��5+      
�������$��B Zar)�6>   $��25(�6S   $	��100��6b   $��	0,0,10,51q�6o   $��Bottom=�6�   $	��750��6�   $��0q�6�    �� TextAlignment$ Center=�6�   $��	ExtraBold"�6�   . �5-      /� .T�5.      J� .*�6   .*�5/      �� 50      51      52      55      56      