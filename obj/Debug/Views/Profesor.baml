   M S B A M L   `   `   `  ����Q  MPlatforma_Educationala, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:Platforma_Educationala.ViewsPlatforma_Educationala.Views  5   	   +    %Platforma_Educationala.Views.Profesor   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   <local*clr-namespace:Platforma_Educationala.Views     5   	     � Title$  Profesor��5   	   $	��450��6   $	��800��6'   .��5	      �  � ColumnDefinitions 5
   
   �� 5      �� 5      �� 5       � RowDefinitions 5   
   �� 5      $	��25* �6   �� 5      $
��192* �6   .+�5   
   �� 
���   �$��4,0,5,50q�6$   .+�5      �� $��Selecteaza clasa��6   $��15(�60   $	��291��6>   
 �� Top$ -1��6J   $��27��6Z   �� 5      -   5        $��cbClasa��5   C    �� Left$ 6��6u   $ 22��6�   $	��193��6�   ��6R   �� *	ClassList+6�   �� 5      $��Selecteaza materia ��6   $��15(�63   $	��185��6A   $��27��6M   $	 253��6Y   $ -3��6k   �� 5      -   5        $��	cbMaterie��5      $	 258��6M   $ 25��6_   $	��233��6o    J� RenderTransformOrigin$ 0.412,0.533&�6{   ��6)   �� *MateriiList+6{   �� 5      $��Selecteaza elev ��6   $��15(�60   $	��233��6>   $��27��6J   $	 544��6V   $ -3��6h   �� 5      -   5        $��cbElev��5   B   $	 548��6R   $ 25��6d   $	��221��6t   $ 0.412,0.533&�6�   5      �� 5!   
   $��1��6   .+�5"      �� -   5        $��txtNote��5"      $y�Hidden=�6#   $
��Note��67   $��17(�6G   &   System.Windows.Controls.DataGrid  5#      -   5          Name$ dtaGrid��5#   ,   $y�Hidden=�6   $	��194��6=   $	��237��6J   �� 5$      -   5        $��Adauga��5$   *   $y�Hidden=�6   
���   �$��Adauga��6b   $��37��6s   6�   �� 5%      -   5        $��Modifica��5%   A   $y�Hidden=�6,   
���   �$��Modifica��6g   $��37��6z   6�   �� 5&      -   5        $��sterge��5&   &   $��Sterge��6   
���   �$y�Hidden=�6^   $��37��6r   6�   5)      �� 5+   
   $��1��6   $��1��6"   .+�5,      �� -	   5        $��txtAbs��5,      $y�Hidden=�6"   $��Absente��66   $��17(�6I     5-      -
   5        $ 
dtsABSGrid��5-   +   $y�Hidden=�6   $	��198��6?   $	��250��6L   6Z   �� 5.      -   5        $��	AdaugaABS��5.      $��Adauga��6&   
���   �$y�Hidden=�6M   6x   �� 5/      -   5        $��	stergeAbs��5/   )   $��	Motiveaza��6   
���   �$y�Hidden=�6f   $��37��6z   6�   50      �� 52   
   $��1��6   $��2��6"   .+�53      �� -   5         ��Name$ 	Afiseaza1��53   P   $��Afiseaza��6   
���   �$y�Hidden=�6<   $��37��6   $	��223��6�   �� 54      -   5         ��Name$ MedieLbl��54      $y�Hidden=�6&   $��Media��6:   $��17(�6J   $��39��6X   �� 55      -   5        	 ��Name$	 txtMedie��55   ,   $y�Hidden=�6   $��33��6?   $	��253��6K   �� 56      -   5        $ 
calculeaza��56   W   $y�Hidden=�6   
���   �$��
Calculeaza��6k   �� 57      -   5        $��	Diriginte��57   ;   $��20(�6   $��	Diriginte��6L   $y�Hidden=�6`   
���   �$��59��6�   6�   58      5:      5;      