   M S B A M L   `   `   `  ����G  CTravelEaseVS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:TravelEaseVSTravelEaseVS  5   	   I)clr-namespace:TravelEaseVS.MVVM.ViewModelTravelEaseVS.MVVM.ViewModel  5   	       TravelEaseVS.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:TravelEaseVS     5   	   ?	viewModel)clr-namespace:TravelEaseVS.MVVM.ViewModel     5   	   ���#FAF0E6  � Title$  
TravelEase��5   	   $	��740��6   $
��1300��6)    � DataContext 5      -  'TravelEaseVS.MVVM.ViewModel.ViewHandler  5   
   .��5      �� ._�5   
   � 
������  � ColumnDefinitions 5      �� 5      $��1.61* �6#   �� 5      $��6.84* �6#   �� 5      $��1* �6#    � RowDefinitions 5!      �� 5#      $��1* �6    �� 5$      $��6.84* �6    .+�5(      �� $��0��5)      $��3��5*       
  Color1#��[  5+      #��[  5,      5.      � 55      $��1��6   #��[  6     57      �� 58      �� 59      �� 5:      �� 5;      �� 5<      �� 5=      �� 5>      �� 5?      .+�5F      ��   	NavButton#��[ 6   $��0��6<   $
��Home��6I   ��6X   �� *
HMVCommand+�� 5G      #��[ 6   $��1��6<   $��Announced Trips��6I   ��6c   �� *
ATVCommand+�� 5H      #��[ 6   $��2��6<   $��Active Bookings��6I   ��6c   �� *
BKSCommand+�� 5I      #��[ 6   $��3��6<   $��Active Trips��6I   ��6a   �� *
ATVCommand+�� 5J      #��[ 6   $��4��6<   $��My Travel Book��6I   5P      � 5S       5T      �� 5U      $��* �6'   �� 5V      $��1.61* �6'   �� 5W      $��* �6'   .+�5Y      �� $��56��6   $��56��6%   $��1��5Z      ��5\      �� 5_       �� 
TargetType" ��6*   .R�5`      ��  �� CornerRadius$ 56��5a   "   #��z��5b   #   #��z��5c   $   
�������._�5g   "   �� $ 50��6)   ��5h   &   �� 5i   *    �� ImageSource$# Images/TravelEaseMockLogo.png��65   5k   #   5l      5n      5q      �� 5s      -   5        $��0��5t      $��Right=�5u      ��5x      �� 5{      " ��6*   .R�5|      �� $ 50��5}   !   #��z��5~   !   #��z��5   !   #��z��5�   !   ._�5�   "   �� $ 50��6)   ���#4A5164$��1q�6Q   ��5�   &   �� 5�   *   $ Images/ExitIcon.png��65   5�   #   5�       �� Triggers 5�      P� 5�   "    P� Property �@J�IsMouseOver	 P� Value$
	 True��6A   . �5�   &   ��  
 Color2
 �� Value#
 [ 6C    �� Property � ���� 5�   &    � ��$
 45��6>   �� 5�   &    � ��$
 45��6?   5�   #   P� 5�   "    �@J�IsMouseOver$	 False��6A   . �5�   &   �� #
 [  6C    � ���� 5�   &    � ��$
 35��6>   �� 5�   &    � ��$
 35��6?   5�   #   5�      5�      5�      � 5�      $��0��6   $��1��6     5�      �� 5�      $��2* �6'   �� 5�      $��2* �6'   �� 5�      $��3* �6'   .+�5�      � $��2��6    5�      �� 5�      $��* �6(   �� 5�      $��2* �6(   �� 5�      $��* �6(   .+�5�      �� ���#F1F1F1$ 18��5�      
�������$��1q�5�      $��0,0,26,0q�5�      $��1��5�      ._�5�      �� -   5         ��Name$ 	SearchBox��5�      $��0,0,26,0q�5�      
������ $��0q�5�      $��Center=�5�      $��	10,0,35,0q�5�      $��14(�5�      $��	Search...��5�      
�������5�   -   5�      5�      5�      �� 5�      $��1��6   $��1��6-   $��10q�5�      ��5�      �� *MyView+5�      5�      5�      