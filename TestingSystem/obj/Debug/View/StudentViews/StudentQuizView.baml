   M S B A M L   `   `   `  ����H  DTestingSystem, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullQ-clr-namespace:TestingSystem.View.StudentViewsTestingSystem.View.StudentViews  5   	   A%clr-namespace:TestingSystem.ViewModelTestingSystem.ViewModel  5   	   5    /TestingSystem.View.StudentViews.StudentQuizView   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ?local-clr-namespace:TestingSystem.View.StudentViews     5   	   4vm%clr-namespace:TestingSystem.ViewModel     5   	     � Title$  StudentQuizView��5	   	    � SizeToContent$ Height=�6!   $	��800��68   $	��400��6H    � DataContext 5
      .   (TestingSystem.ViewModel.StudentViewModel  5   
   .��5      �  � ColumnDefinitions 5   
   �� 5      $��1* �6   6,   �� 5      $��1* �6   6,    � RowDefinitions 5   
   �� 5      $��1* �6   6*   �� 5      $��4* �6   6*   �� 5      $��1* �6   6*   �� 5      $��1* �6   6*   �� 5      $��1* �6   6*   .+�5   
   �� -   5        $��timer��5   $   $��2��6   $��00:00:00��61   $��Center=�6D   $��Center=�6a   $��24(�6|   $
��Bold"�6�   6�   �� 5   
   $��1��6   $��2��6$   ��. $
��Auto=�6P   .��5      �� -   5        $��	quizPanel��5      $��1��6*   5      5       �� 5"   
   -   5        $��prevBtn��5"      $��2��6    $��0��6-   $��Previous��6=   $��24(�6P   $��Medium"�6^   6�   �� 5#   
   -   5        $��nextBtn��5#      $��2��6    $��1��6-   $
��Next��6=   $��24(�6L   $��Medium"�6Z   6�   �� 5%   
   -   5        $��	submitBtn��5%   2   $��3��6   $��2��6   $��Submit��6C   $��24(�6T   $��Medium"�6b   6�   �� 5&   
   -   5        $��4��5&      $��2��6   $
��Back��62   $��24(�6A   $��Medium"�6O   6z   5'      5(      