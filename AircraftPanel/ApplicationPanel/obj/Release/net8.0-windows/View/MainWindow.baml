   M S B A M L   `   `   `  ����   	ViewModel8*clr-namespace:ViewModel;assembly=ViewModel	ViewModel   ApplicationPanel   View.MainWindow   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     @d2http://schemas.microsoft.com/expression/blend/2008     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @	viewmodel*clr-namespace:ViewModel;assembly=ViewModel     -   $��ResponsiveWindow��  � Title$  
MainWindow��$	��450��$	��800�� � AllowsTransparency$
 True�� � 
ResizeMode$ CanResizeWithGrip=� � WindowStartupLocation$ CenterScreen=� � WindowStyle$
 None=�$	��250��$	��600��
������  � 	Resources  �� MergedDictionaries �� Source��  �� $H Bpack://application:,,,/View;component/Resources/Styles/Button.xaml?��� $J Dpack://application:,,,/View;component/Resources/Styles/DataGrid.xaml?�%    .��� .+��� -    ��Name$ 
MainBorder�����#222222���#3A4149$��5q�	 �� CornerRadius$	 20��._�� 
 � RowDefinitions
 �� $
��Auto ��� $
��Auto ��� $
��1.5* � � ColumnDefinitions �� $��* �$	��250���� $��* �$	��350��.+�o� $��0��
������ 
�������$��5q�.@�m� $��Файл�����#444444
�������.@�m� $
��Open�����#555555
������� m� Command �� *OpenCommand+��  �� Orientation$ 
Horizontal=�$��Right=�$��0��$��1��.+���  
  MaxApp#��[  ���� *CommandHelper.MaxAppCommand+����  �� ElementName$ ResponsiveWindow���� $��0��$��1��  ExitApp#��[ ���� *CommandHelper.CloseAppCommand+���� $ ResponsiveWindow���� $&�� Departure of aircraft passengers��$��	20 0 10 0q�
�������$��Italic$�$��Century Gothic)�$��30(�$
��Wrap=�$
��Left=�$��1��$��0���� $ 
Horizontal=�$��Right=�$��20q�$��1��$��1��.+��� $��Moscow Time��$��20q�
�������$��Italic$�$��Century Gothic)�$��15(� �� TextAlignment$ Center=�$
��Left=�$��1��$��1���� 
���   �$��50��$	��150��
��� ���$��40(�$ Center=�$G��Apack://application:,,,/View;component/Resources/Fonts/#DS-Digital)����� *CurrentTime+&   System.Windows.Controls.DataGrid  -   $��PassengerTable��$��2��$��2��   AutoGenerateColumns$ False��$��Stretch=�$��Stretch=�   GridLinesVisibility$ 
Horizontal=�   HorizontalGridLinesBrush
 �����$��2q�$��20q�
������ 
������    RowBackground �#0d1507   CanUserResizeRows$ False��   CanUserAddRows$ False�� %� IsVirtualizing$
 True�� %� VirtualizationMode$ 	Recycling=����� *CurrentPagePassengers+   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ 	Last Name��   Width5  /System.Windows.Controls.DataGridLengthConverter$ *   DataGridTextColumnStyle   	CellStyle# [   CustomHeaderStyle   HeaderStyle# [ 1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *Passenger.LastName+  $ 
First Name��$ * # [ # [  �� *Passenger.FirstName+  $ 
Patronymic��$ * # [ # [  �� *Passenger.Patronymic+  $ Flight Number��$
 1.1* # [ # [  �� *Flight.RouteNumber+  $ Departure Time��$
 1.1* # [ # [  �� *Flight.DepartureTime+