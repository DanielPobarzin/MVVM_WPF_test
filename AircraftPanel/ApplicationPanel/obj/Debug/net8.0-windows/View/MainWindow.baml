   M S B A M L   `   `   `  ����D  @ViewModel, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null8*clr-namespace:ViewModel;assembly=ViewModel	ViewModel  5       ApplicationPanel!   ApplicationPanel.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @	viewmodel*clr-namespace:ViewModel;assembly=ViewModel     5      -   5          � Title$  
MainWindow��5	      $	��450��6   $	��800��6,    � AllowsTransparency$
 True��5
       � 
ResizeMode$ CanResizeWithGrip=�5       � WindowStartupLocation$ CenterScreen=�5       � WindowStyle$
 None=�5      $	��250��5      $	��600��5      
������  � 	Resources 5       �� MergedDictionaries �� Source�� 5   
    5      �� 5      $T Npack://application:,,,/ApplicationPanel;component/Resources/Styles/Button.xaml?�6%   �� 5      $V Ppack://application:,,,/ApplicationPanel;component/Resources/Styles/DataGrid.xaml?�6%   %    5      .��5      � .+�5   
   �� -   5         ��Name$ 
MainBorder��5      ���#222222���#3A4149$��5q�5   '   	 �� CornerRadius$	 20��5      ._�5       � 
 � RowDefinitions
 5!      �� 5"      $
��Auto �6$   �� 5#      $
��Auto �6$   �� 5$      $
��1.5* �6$    � ColumnDefinitions 5&      �� 5'      $��* �6'   $	��250��61   �� 5(      $��* �6'   $	��350��61   .+�5+      o� $��0��6   
������ 
�������$��5q�6S   .@�5,      m� $��Файл��6   ���#444444
�������.@�5-      m� $
��Open��6#   ���#555555
������� m� Command 61   �� *LoadPassengersCommand+5.   8   5/      50      �� 52       �� Orientation$ 
Horizontal=�6   $��Right=�66   $��0��6R   $��1��6_   .+�53      ��  
  MaxApp#��[  55      ��53      �� *
MaxCommand+��54      ��  �� RelativeSource ��  �� AncestorType
 Window55      �� 56        ExitApp#��[ 58      ��56      �� *CloseCommand+��57      ��  �� 
 Window58      59      �� 5;      $&�� Departure of aircraft passengers��6   $��	20 0 10 0q�5<      
�������$��Italic$�5>      $��Century Gothic)�5?      $��30(�5@      $
��Wrap=�5A      $
��Left=�5B      $��1��5C      $��0��6)   �� 5E      $ 
Horizontal=�6   $��Right=�66   $��20q�6R   $��1��6^   $��1��6k   .+�5F      �� $��Moscow Time��6    $��20q�63   
�������$��Italic$�5H       $��Century Gothic)�5I       $��15(�5J        �� TextAlignment$ Center=�5K       $
��Left=�5L       $��1��6;   $��1��6H   5M      �� 5N      
���   �$��50��5O       $	��150��5P       
��� ���$��40(�5R       $ Center=�6.   $S��Mpack://application:,,,/ApplicationPanel;component/Resources/Fonts/#DS-Digital)�5S       ��5T       �� *CurrentTime+6?   5U      &   System.Windows.Controls.DataGrid  5W      -   5        $��PassengerTable��5W      $��2��61   $��2��6>      AutoGenerateColumns$ False��5X      $��Stretch=�5Y      $��Stretch=�5Z         GridLinesVisibility$ 
Horizontal=�5[         HorizontalGridLinesBrush
 �����$��2q�5]      $��20q�5^      
������ 
������    RowBackground �#0d1507   CanUserResizeRows$ False��5b         CanUserAddRows$ False��5c       %� IsVirtualizing$
 True��5d   A    %� VirtualizationMode$ 	Recycling=�6n   ��6   �� *CurrentPagePassengers+   Columns 5e      0  *System.Windows.Controls.DataGridTextColumn  5f      ,  &System.Windows.Controls.DataGridColumn   Header$ 	Last Name��6)      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 5g   %      
IsReadOnly$
 True��5h   %     DataGridTextColumnStyle   	CellStyle# [ 5j   %     CustomHeaderStyle   HeaderStyle# [ 5k   %   1  +System.Windows.Controls.DataGridBoundColumn   Binding 5i   %   �� *Passenger.LastName+  �� ValidatesOnDataErrors$
  True��5k   %     5l      $ 
First Name��6)   $ * 5m   %   $
 True��5n   %   # [ 5p   %   # [ 5q   %    5o   %   �� *Passenger.FirstName+$
  True��5q   %     5r      $ 
Patronymic��6%   $ * 5s   %   $
 True��5t   %   # [ 5v   %   # [ 5w   %    5u   %   �� *Passenger.Patronymic+$
  True��5w   %     5x      $ Flight Number��6)   $
 1.1* 5y      $
 True��5z      # [ 5|      # [ 5}       5{      �� *Flight.RouteNumber+$
  True��5}        5~      $ Departure Time��6)   $
 1.1* 5      $
 True��5�      # [ 5�      # [ 5�       5�      �� *Flight.DepartureTime+$
  True��5�      5�      5�   
   5�      5�      5�      