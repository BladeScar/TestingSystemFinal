   M S B A M L   `   `   `  ����H  DTestingSystem, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:TestingSystem.ViewTestingSystem.View  5   	   A%clr-namespace:TestingSystem.ViewModelTestingSystem.ViewModel  5   	   %    TestingSystem.View.RegisterView   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:TestingSystem.View     5   	   4vm%clr-namespace:TestingSystem.ViewModel     5   	     � Title$  RegisterView��5	   	   $	��300��6   $	��300��6+    � DataContext 5
      7   1TestingSystem.ViewModel.AuthentificationViewModel  5   
   .��5      � .+�5   
   �� $��Username��6   $
��Left=�6#   $��	34,12,0,0q�6>   $	��Top=�6Q   $	��102��6i   �� 5   
   $��Password��6   $
��Left=�6#   $��	34,43,0,0q�6>   $	��Top=�6Q   $	��102��6i   �� 5   
   $��Repeat Password��6   $
��Left=�6*   $��	34,77,0,0q�6E   $	��Top=�6X   $	��102��6p    J� RenderTransformOrigin$ 0.485,-1.368&�6|   �� 5   
   -   5        $��usrTxt��5      $
��Left=�6    $��23��6;   $��
136,15,0,0q�6G    �� TextWrapping$
 Wrap=�6[   $�� ��6o   $	��Top=�6w   $	��120��6�   G� 5   
   -   5        $��passTxt��5      $
��Left=�6%   $��
136,43,0,0q�6@   $	��Top=�6T   $��26��6l   $	��120��6x   �� 5   
   -   5        $��Register��5      $
��Left=�6$   $	��Top=�6?   $	��222��6W   $��
34,183,0,0q�6c   $��25��6w   6�   �� 5   
   -   5        $��Go Back��5      $
��Left=�6#   $	��Top=�6>   $	��222��6V   $��
34,213,0,0q�6b   $��25��6v   6�   G� 5   
   $
��Left=�6   $��
136,77,0,0q�61   $	��Top=�6E   $��26��6]   $	��120��6i   	� 5   
   -   5        $��
StudentBtn��5      $��Student��6(   $
��Left=�6:   $��Center=�6U   $	��120��6p   $��	55,30,0,0q�6|   6�   	� 5   
   -   5        $��
TeacherBtn��5      $��Teacher��6(   $��Right=�6:   $��Center=�6V   $	��120��6q   $��	0,30,10,0q�6}   6�   �� 5   
   $��Center=�6   $��Center=�6-   .��5      �� $%��Are you a student or a teacher?��6   $��	0,-15,0,0q�6>   5      5      5      