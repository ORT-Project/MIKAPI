   M S B A M L   `   `   `  ����H  DMekiApiClient, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:MekiApiClientMekiApiClient  5   	       MekiApiClient.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   -localclr-namespace:MekiApiClient     5   	     � Title$  MekiApi Client��5   	   $	��450��6    $	��800��6-    � WindowStartupLocation$ CenterScreen=�5   	    � 	Resources 5      6   0MekiApiClient.StringIsEmptyToVisibilityConverter &  "StringIsEmptyToVisibilityConverter3  -System.Windows.Media.Effects.DropShadowEffect  ShadowEffect   
BlurRadius   ShadowDepth   Color  FadeInAnimation �� TargetProperty W� From	 W� To	 g� Duration��%�   &	        &	      &	 Q       5   
   63     5	   
   $ 10Q�60   $ 3Q�6@   $ 	#40000000��6P   �� 5
   
   .��5      W� $ Opacity�6    05       16'   $	 0:0:1D�6.   5      5      .��5      � ���	#FFF0F0F0
 � RowDefinitions
 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   ��  �� Orientation$ 
Horizontal=�6   $��Center=�6.   $��10q�6K   $��0��6W   .+�5      �� -   5        $�� Get Users��5      $C��=pack://application:,,,/FontAwesome.WPF;component/#FontAwesome)�6+   $��5q�6�   $��10q�6�   �� 5      -   5        $��Create User��5      $��5q�6D   $��10q�6O   5      �� 5   
   
������� �� CornerRadius$ 10��6$    �� Padding$ 10q�66   $��10q�6C   $��1��6O    J� Effect# [ 6\   ._�5      �� $ Vertical=�6   $��Center=�60   .+�5      � $��5q�6   .+�5       �� -   5         ��Name$ UsernameTextBox��5       $	��200��67   $��Center=�6C   �� 5!      $��Enter Username��6     J� IsHitTestVisible$ False��5"       
�������$��Center=�5$       $��5,0,0,0q�5%       y�5&       �� *Text+ �� ElementName$ UsernameTextBox�� �� 	Converter# [  5'      � 5(      $��5q�6   .+�5)      �� -   5        $ EmailTextBox��5)      $	��200��64   $��Center=�6@   �� 5*      $��Enter Email��6    $ False��5+       
�������$��Center=�5-       $��5,0,0,0q�5.       y�5/       �� *Text+$ EmailTextBox��# [  50      51      52      �� 55   
   
�������$ 10��6$   $��10q�66   $��2��6B   # [ 6O   ._�56      �� -   5         ��Name$ UsersListView��56       J� Opacity$ 0Q�6.    �� View 57      �� 58      .P�59      �� $��ID��6)    �� Width$	 100��6Y    �� DisplayMemberBinding 65   �� *Id+6Y   �� 5:      $��Username��6)   $	 200��6e    6;   �� *
Username+6e   �� 5;      $��Email��6)   $	 300��6_    68   �� *Email+6_   5<      5>      5?      5@      5A      