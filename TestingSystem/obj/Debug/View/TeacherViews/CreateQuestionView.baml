   M S B A M L   `   `   `  ����H  DTestingSystem, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullQ-clr-namespace:TestingSystem.View.TeacherViewsTestingSystem.View.TeacherViews  5   	   A%clr-namespace:TestingSystem.ViewModelTestingSystem.ViewModel  5   	   8    2TestingSystem.View.TeacherViews.CreateQuestionView   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ?local-clr-namespace:TestingSystem.View.TeacherViews     5   	   4vm%clr-namespace:TestingSystem.ViewModel     5   	     � Title$  Create a New Question��5	   	   $	��300��6'   $	��600��64    � DataContext 5
      .   (TestingSystem.ViewModel.TeacherViewModel  5   
   .��5      �  � ColumnDefinitions 5   
   �� 5      $��1* �6   6,   �� 5      $��1* �6   6,    � RowDefinitions 5   
   �� 5      $
��1.5* �6   �� 5      $
��0.5* �6   �� 5      $��3* �6   �� 5      $��1* �6   �� 5      $��2* �6   .+�5   
   �� $��2��6   $��Center=�6(   $
��Wrap=�6E   $��14(�6Y   $��DemiBold"�6g   kiTo indicate multiple answers separete them with comas (eg. choiceOne,choiceTwo). The right answer should B� 6�   .�6�   �� .�6�   always6�   6   be first in the list.6(  �� 5   
   -   5        $��qstTxt��5      $��2��6   $��Type new question...��6-   $
��Thin"�6I    �� 	IsEnabled . 6�   �� 5   
   -   5        $��ansTxt��5   /   $��1��6   $��1��6   $)��#Type the answers to the question...��6=   $
��Thin"�6h   $	��102��6�   $��0.2,16.6,-0.4,0q�6�   $��3��6�   $	��Top=�6�    . 6  �� 5   
   -   5        $��saveBtn��5      $��3��6    $��10, 5q�6-   $��Save Question��6<   $��18(�6T   6z   �� 5   
   -   5        $��backBtn��5      $��2��6    $��3��60   $��10, 5q�6=   $
��Back��6L   $��20(�6[   6�   5      5       