   M S B A M L   `   `   `  ����D  @ViewModel, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null8*clr-namespace:ViewModel;assembly=ViewModel	ViewModel  5   	    View   View.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   @	viewmodel*clr-namespace:ViewModel;assembly=ViewModel     5   	   -   5        $��ResponsiveWindow��5	        � Title$  
MainWindow��6	   $	��450��64   $	��800��6A    � AllowsTransparency$
 True��5
   	    � 
ResizeMode$ CanResizeWithGrip=�5   	    � WindowStartupLocation$ CenterScreen=�5   	    � WindowStyle$
 None=�5   	   $	��250��5   	   $	��600��5   	   
������  � 	Resources 5       �� MergedDictionaries �� Source�� 5   
    5      �� 5      $H Bpack://application:,,,/View;component/Resources/Styles/Button.xaml?�6%   �� 5      $J Dpack://application:,,,/View;component/Resources/Styles/DataGrid.xaml?�6%   %    5      .��5      � .+�5   
   �� -   5         ��Name$ 
MainBorder��5      ���#222222���#3A4149$��5q�5       	 �� CornerRadius$	 20��5!      ._�5"      � 
 � RowDefinitions
 5#      �� 5$      $
��Auto �6$   �� 5%      $
��Auto �6$   �� 5&      $
��1.5* �6$    � ColumnDefinitions 5(      �� 5)      $��* �6'   $	��250��61   �� 5*      $��* �6'   $	��350��61   .+�5,      o� $��0��6   
������ 
�������$��5q�6S   .@�5-      m� $��Файл��6   ���#444444
�������.@�5.      m� $
��Open��6#   ���#555555
������� m� Command 61   �� *OpenCommand+5/   4   50      51      �� 52       �� Orientation$ 
Horizontal=�6   $��Right=�66   $��0��6R   $��1��6_   .+�53      ��  
  MaxApp#��[  55      ��53      �� *CommandHelper.MaxAppCommand+��54      ��  �� ElementName$ ResponsiveWindow��55      �� 56      $��0��57      $��1��6"     ExitApp#��[ 59      ��56      �� *CommandHelper.CloseAppCommand+��58      �� $ ResponsiveWindow��59      5:      �� 5<      $&�� Departure of aircraft passengers��6   $��	20 0 10 0q�5=      
�������$��Italic$�5?      $��Century Gothic)�5@      $��30(�5A      $
��Wrap=�5B      $
��Left=�5C      $��1��5D      $��0��6)   5E      �� 5F      $ 
Horizontal=�6   $��Right=�66   $��20q�6R   $��1��6^   $��1��6k   .+�5G      �� $��Moscow Time��6    $��20q�63   
�������$��Italic$�5I       $��Century Gothic)�5J       $��15(�5K        �� TextAlignment$ Center=�5L       $
��Left=�5M       $��1��6;   $��1��6H   5N      �� 5O      
���   �$��50��5P       $	��150��5Q       
��� ���$��40(�5S       $ Center=�6.   $G��Apack://application:,,,/View;component/Resources/Fonts/#DS-Digital)�5T       ��5U       �� *CurrentTime+6?   5V      &   System.Windows.Controls.DataGrid  5X      -   5        $��PassengerTable��5X      $��2��61   $��2��6>      AutoGenerateColumns$ False��5Y      $��Stretch=�5Z      $��Stretch=�5[         GridLinesVisibility$ 
Horizontal=�5\         HorizontalGridLinesBrush
 �����$��2q�5^      $��20q�5_      
������ 
������    RowBackground �#0d1507   CanUserResizeRows$ False��5c         CanUserAddRows$ False��5d       %� IsVirtualizing$
 True��5e   A    %� VirtualizationMode$ 	Recycling=�6n   ��6   �� *CurrentPagePassengers+   Columns 5f      0  *System.Windows.Controls.DataGridTextColumn  5g      ,  &System.Windows.Controls.DataGridColumn   Header$ 	Last Name��6)      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 5h   %     DataGridTextColumnStyle   	CellStyle# [ 5j   %     CustomHeaderStyle   HeaderStyle# [ 5k   %   1  +System.Windows.Controls.DataGridBoundColumn   Binding 5i   %   �� *Passenger.LastName+5k   %     5l      $ 
First Name��6)   $ * 5m   %   # [ 5o   %   # [ 5p   %    5n   %   �� *Passenger.FirstName+5p   %     5q      $ 
Patronymic��6%   $ * 5r   %   # [ 5t   %   # [ 5u   %    5s   %   �� *Passenger.Patronymic+5u   %     5v      $ Flight Number��6)   $
 1.1* 5w      # [ 5y      # [ 5z       5x      �� *Flight.RouteNumber+5z        5{      $ Departure Time��6)   $
 1.1* 5|      # [ 5~      # [ 5       5}      �� *Flight.DepartureTime+5      5�      5�   
   5�      5�      5�      