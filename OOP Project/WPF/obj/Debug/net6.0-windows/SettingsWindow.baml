   M S B A M L   `   `   `  ����>  :WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:WPFWPF  5   	   /clr-namespace:WPF.PropertiesWPF.Properties  5   	       WPF.Settings   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   #localclr-namespace:WPF     5   	   *pclr-namespace:WPF.Properties     5   	   -   5          �Name$  settingsWindow��5   	      WPF.Properties.Resources   Settings � Title# Z 5	   	   $	��389��61   $	��344��6>    � WindowStartupLocation$ CenterScreen=�6k   .��5
      � -   5         �Name$ 
gridCommon��5
      $	��428��6   $	��Top=�6,    � ColumnDefinitions 5   
   �� 5      $��0* �6   �� 5      $	��37* �6   �� 5      $
��270* �6   �� 5      $	��23* �6    � RowDefinitions 5   
   �� 5      $
��185* �6   �� 5      $	��29* �6   .+�5   
   �� -   5         ��Name$ 
gbLanguage��5         Language#��Z 6'   $��	0,3,0,315q�6P   	 J� RenderTransformOrigin$	 0.499,1.322&�6c   $��4��6�   .��5      �� 
 �� Orientation$
 
Horizontal=�6   $��44,0,0,0q�62   $��19��6D   .+�5      	� -   5         	�Name$ rbtnEnglish��5      $��English��63   $	��116��6E   $	 0.027,0.629&�6Q    	� 	GroupName$ 
gbLanguage��6u    d� 	IsChecked$
 TrueY�6�   6�   	� 5      -   5        $ 
rbtnFrench��5      $��	Français��62   $	��118��6E   $	 0.027,0.629&�6Q   $ 
gbLanguage��6�   5      5      �� 5   
   -   5        $ gbChampionship��5         Championship#��Z 6+   $��
0,65,0,253q�6X   $	 0.499,1.322&�6l   $��4��6�   .��5      �� $
 
Horizontal=�6   $��44,0,0,0q�62   $��19��6D   .+�5      	� -   5        $ rbtnMen��5      
   Men#��Z 6/   $	��116��6T   $	 0.027,0.629&�6`   $ gbChampionship��6�   $
 TrueY�6�   6�   	� 5      -   5        $ 	rbtnWomen��5         Women#��Z 61   $	��118��6X   $	 0.027,0.629&�6d   $ gbChampionship��6�   6�   5      5       �� 5!   
   -	   5        $ 	gbFavTeam��5!         FavTeam#��Z 6&   $��0,124,0,195q�6N   $��4��6c   �� 5"   
   -
   5         ��Name$ cbCountries��5"      $
��Left=�6(   $��
33,144,0,0q�6C   $	��Top=�6W   $	��264��6o   $��3��6{   $��22��6�   �� 5#   
   -   5        $ gbDisplayMode��5#         DispMode#��Z 6*   $��0,184,0,135q�6S   $��4��6h   �� 5$   
   -   5        $ cbDisplayModes��5$      $
��Left=�6+   $��
33,204,0,0q�6F   $	��Top=�6Z   $	��264��6r   $��3��6~   $��22��6�   .@�5%      ��    
Fullscreen#��Z 6   �� 5&      $��853x569��6   �� 5'      $��930x595��6   �� 5(      $��1205x649��6   5)      �� 5*   
   -   5        $ gbLocal��5*         Local#��Z 6$   $��
0,242,0,76q�6J   $	 0.499,1.322&�6^   $��4��6�   .��5+      �� -   5         ��Name$ checkBoxIsLocal��5+      
   Yes#��Z 60   6{   5,      �� 5-   
   -   5         ��Name$ 
btnConfirm��5-         Confirm#��Z 6%   $
��Left=�6N   $��	7,303,0,0q�6i   $	��Top=�6|   $��40��6�   $��86��6�   $��2��6�   �� 5.   
   -   5        $ 	btnCancel��5.         Cancel#��Z 6$   $
��Left=�6L   $��165,303,0,0q�6g   $	��Top=�6|   $��40��6�   $��86��6�   $��2��6�   5/      50      