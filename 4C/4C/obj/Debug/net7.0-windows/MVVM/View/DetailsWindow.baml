   M S B A M L   `   `   `  ����U  QLiveCharts.Wpf, Version=0.9.7.0, Culture=neutral, PublicKeyToken=0bc1f845d1ebb8dfG4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.WpfLiveCharts.Wpf  5   	   = 94C, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:_4C.MVVM.View_4C.MVVM.View 5   	   !   _4C.MVVM.View.DetailsWindow   5   	   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Dlvc4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.Wpf     5   	   -localclr-namespace:_4C.MVVM.View     5   	     � Title$  DetailsWindow��5	   	   $	��450��6   $	��400��6,   .��5
      � 
�������.+�5   
   �� 
����ح�$��22(�6,   $��Light"�6:   .@�5      �� $
��Info��6   
������ 
������ .��5      �� -   5        $��PropertiesPanel��5      $��10q�64   5      5      �� 5      $��Markets��6   
������ 
������ .��5      �� -   5        $��	lbMarkets��5      
������ 
������ ��5      �� *	Markets+��5      �� 5      .R�5      �  � ColumnDefinitions 5   "   �� 5   &   $	��200 �67   �� 5   &   .+�5   "   �� $��16(�6,   $��Light"�6:   �� 5   &   -   5        $��http://example.com?�5   0   .�6}   .�5   *   �� ��64   �� *
ExchangeId+5   '   5    #   �� 5!   "   $��1��6,   $��14(�6V   ��6<   �� *
PriceUsd+6V   5"      5#      5%      5&      �� 5'      $��History��6   
������ 
������ .��5(      #   LiveCharts.Wpf.CartesianChart  &    LiveCharts.Wpf.Charts.Base.Chart   Series 6%   �� *SeriesCollection+   AxisX 5)      �� *XAxis+   AxisY 5*      �� *YAxis+5+      5,      5-      5.      