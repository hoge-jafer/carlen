   M S B A M L   `   `   `  ����A  =Carlen, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:CarlenCarlen  5   	       Carlen.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   &localclr-namespace:Carlen     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)   .��5	      �  � RowDefinitions 5
   
   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $��* �6   .+�5   
   �� ��6   ��  �� ElementName$ qq�� �� Path$ SelectDateTime[0]� �� UpdateSourceTrigger$ PropertyChanged=��� 5   
   $��1��6   ��5      �� $ qq��$ SelectDateTime[1]�$ PropertyChanged=�   Carlen.CustomCalendar  5   
   -   5          Name$ qq��5      $��2��5       $��0,30,0,0q�5         BackGroundEllipesSize$ 35Q�5         SetMonth$ 5��5         DateTimeFontSize$ 20��5      	   SelectItemBackGround$	 	BurlyWood��5      
   SelectItemListBackGround$

 Aqua��5         BackGroundEllipesStretch$
 None=�5      5      5      