   M S B A M L   `   `   `  ����>  :WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:WPFWPF  5   	   /clr-namespace:WPF.PropertiesWPF.Properties  5   	       WPF.PlayerOverviewWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   #localclr-namespace:WPF     5   	   *pclr-namespace:WPF.Properties     5   	   -   5        $��PlayerOverview��5	   :     � Title$  Player Overview��6	   $	��341��6!   $	��263��6.    � WindowStartupLocation$ CenterScreen=�6P   $	��263��6u   $	��341��6�   .��5      � -   5        $
��grid��5      
���\\�� � RowDefinitions 5   
   �� 5      $��5* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6    � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $��3* �6   �� 5      $��3* �6   �� 5      $��* �6   .+�5   
   �� -   5        $��imagePlayer��5      $��0��6#   $��4��60   $&�� Properties/Images/PlayerIcon.png��6D   $��0,2,0,0q�6n   �� 5   
   -   5        $��lbShirtNumber��5      $��0��6%   $��1��62   $��2��6B   $	��[n]��6V   $��30(�6d   $��Bottom=�6r   $��Center=�6�   $��0,0,0,7q�6�   �� 5   
   $��1��6   $��1��6      WPF.Properties.Resources   Name#��Z 6-   $��Stretch=�6S   $��Stretch=�6q   $
��Left=�6�   $��Center=�6�   �� 5    
   -   5        $��lbName��5       $��1��6   $��2��6+   $��2��6;   $��[name]��6O   $��Stretch=�6`   $��Stretch=�6~   $
��Left=�6�   $��Center=�6�   �� 5!   
   $��2��6   $��1��6   $��	Position:��6-   $��Stretch=�6A   $��Stretch=�6_   $
��Left=�6{   $��Center=�6�   �� 5"   
   -   5        $��
lbPosition��5"      $��2��6"   $��2��6/   $��
[position]��6?   $��Stretch=�6T   $��Stretch=�6r   $
��Left=�6�   $��Center=�6�   �� 5#   
   $��3��6   $��1��6      Captain#��Z 6-   $��Stretch=�6V   $��Stretch=�6t   $
��Left=�6�   $��Center=�6�   �� 5$   
   -   5        $��	lbCaptain��5$      $��3��6!   $��2��6.   $��[yes/no]��6>   $��Stretch=�6Q   $��Stretch=�6o   $
��Left=�6�   $��Center=�6�   �� 5%   
   $��4��6   $��0��6   $��4��6-      Stats#��Z 6B   $��Stretch=�6i   $��Stretch=�6�   $
��Left=�6�   $��Center=�6�   $��5,5,5,5q�6�   �� 5&   
   $��5��6   $��1��6      Goals#��Z 6-   $��Stretch=�6T   $��Stretch=�6r   $
��Left=�6�   $��Center=�6�   �� 5'   
   -   5        $��lbGoals��5'      $��5��6   $��2��6,   $��[goals]��6<   $��Stretch=�6N   $��Stretch=�6l   $
��Left=�6�   $��Center=�6�   �� 5(   
   $��6��6   $��1��6      YellowCards#��Z 6-   $��Stretch=�6Z   $��Stretch=�6x   $
��Left=�6�   $��Center=�6�   �� 5)   
   -	   5        $��lbYellowcards��5)      $��6��6%   $��2��62   $��[yellowCards]��6B   $��Stretch=�6Z   $��Stretch=�6x   $
��Left=�6�   $��Center=�6�   �� 5*   
   -
   5        $��btnClose��5*      	   Close#��Z	 6!   $��7��6H   $��1��6U   $��2��6e   $��Stretch=�6y   $��Stretch=�6�   $��5,2,5,3q�6�   5,      5-      