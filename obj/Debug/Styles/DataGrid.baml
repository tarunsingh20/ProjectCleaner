   M S B A M L   `   `   `  ����\  XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089   bool2VisibilityConverter  �� 
TargetType �� 
ResourceId �� TypeInTargetAssembly&     System.Windows.Controls.DataGrid �� Property �� Value �� 
TargetType'   !System.Windows.VisualStateManager   VisualStateGroups%   System.Windows.VisualStateGroup   States    System.Windows.VisualState   
Storyboard	 �� 
TargetName
 �� TargetProperty8  2System.Windows.Media.Animation.EasingColorKeyFrame �� KeyTime  ControlMouseOverColor �� Value  ControlPressedColor R� KeyTime  System.Windows.Visibility   	Collapsed R� Value ��Name J� SnapsToDevicePixels �� EndPoint �� 
StartPoint  BorderLightColor � Color � Offset  BorderMediumColor  ControlLightColor  ControlMediumColor �Name J� Opacity � Points �� Stretch  
GlyphColor �� Color  BorderDarkColor ��Name �� Padding ��Name � ColumnDefinitions � RowDefinitions     SelectAllCommand7   1System.Windows.Controls.DataGridHeadersVisibility
!   All" �� ConverterParameter!#    HeadersVisibilityConverter$ �� 	Converter% �� RelativeSource& �� AncestorTypeG   ASystem.Windows.Controls.Primitives.DataGridColumnHeadersPresenter'  Name(   Column) ��Name* �� CanContentScroll+ ��Name, �� Orientation- �� ViewportHeight. �� ViewportSize/ �� ScrollableHeight0 � Maximum*1 �� #ComputedVerticalScrollBarVisibility2 � Value3 �� Mode4 �� ViewportWidth5 �� ScrollableWidth,6 �� %ComputedHorizontalScrollBarVisibility7 �� Triggers8 P� Property9 P� Value*   $System.Windows.Controls.DataGridCell "	 DatagridCurrentCellBorderColor)	   #System.Windows.Controls.DataGridRow 
 ContentAreaColorLight  ContentAreaColorDark  ControlDarkColor?
   9System.Windows.Controls.Primitives.SelectiveScrollingGrid?   9System.Windows.Controls.Primitives.DataGridCellsPresenter: 	  
ItemsPanelA   ;System.Windows.Controls.Primitives.DataGridDetailsPresenter; 	  DetailsVisibility$< 
  SelectiveScrollingOrientation;   5System.Windows.Controls.SelectiveScrollingOrientation=   Vertical#>    RowDetailsScrollingConverter:   4System.Windows.Controls.Primitives.DataGridRowHeader
?   Row  RowHeaderGripperStyle@ �� OrientationA n�Name  ColumnHeaderGripperStyle=   7System.Windows.Controls.Primitives.DataGridColumnHeaderB  NameC J� IsHitTestVisible�� 5      D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     :x,http://schemas.microsoft.com/winfx/2006/xaml      5      Bmc;http://schemas.openxmlformats.org/markup-compatibility/2006  5      8d2http://schemas.microsoft.com/expression/blend/2008  5      %C;  &	        (��      5   
   $" DataGridSelectAllButtonStyle��"   )7  7  '       '  m    7 	 '	      7 
 7  7  7  7  7  7  7  7  7  7  7  7  7  7  7  7  7  7  7  &	 �*    '  �+    7  7   7  7  &	 �3    '  �4    7  7  '  \9    �� 5      6#   �� 5      "  ��6   .�5   
   ��  � �� 5      �� 5      " ��6"   .R�5      �  5        5      CommonStates��. 5   "     
Normal��6.     5   "   	MouseOver��. 5   &   �� .��5   *   �� $	 Border��6G   $a
 [(Shape.Fill).                         (GradientBrush.GradientStops)[1].(GradientStop.Color)�5   3   .g�5   .     $ 0��6B   8   5   ,   5   +   5   '   5   #     5   "   Pressed��. 5    &   �� .��5!   *   �� $	 Border��6G   $a
 [(Shape.Fill).                         (GradientBrush.GradientStops)[1].(GradientStop.Color)�5"   3   .g�5$   .     $ 0��6B   8  5%   ,   5&   +   5'   '   5(   #     5)   "   Disabled��. 5*   &   �� .��5+   *   T� $
 (UIElement.Visibility)�6H   $	 Arrow��5,   4   ..�5-   .   i� $ 0��6E   # Z 5.   /   5/   +   50   '   51   #   52      .+�54      �� $ Border��6$    . ��56      �� 57   "   $ 0.5,1&�66   $ 0.5,0&�58   &   .��59   &   � # �  63   $ 0Q�5:   !   � 5;   &   # �  63   $ 1Q�5<   !   5=   #   ��5?      �� 5@   "   $ 0.5,1&�66   $ 0.5,0&�5A   &   .��5B   &   � # �  63   $ 0Q�5C   !   � 5D   &   # �  63   $ 1Q�5E   !   5F   #   5H      � 5I      $ Arrow��6"   $��Right=�5J      $��8,8,3,3q�5K      $
 0.15Q�5L       �   ��� ��� ��� ��� $ Uniform=�5N      $��Bottom=�5O      ��5P      �� 5Q   "   # �  62   5S      5T      5U      5W      5X      �� 5[      "    6   .�5\   
   ��  � ��# � ��5]      �� 5^   
    � �� 5_      �� 5`      $ 0.5,1&�6&   $ 0.5,0&�5a      .��5b      � # �  6#   $ 0Q�5c      � 5d      # �  6#   $ 1Q�5e      5f      5h      �� 5i   
    � ��$ 1q�5j      �� 5k   
     �@  RowDetailsVisibilityMode$ VisibleWhenSelected=�5l      �� 5m   
    � �� . 5n      �� 5o   
    �@��PanningMode$
 Both=�5p      �� 5q   
    �@��IsFlicksEnabled .  5r      �� 5s   
    � �� 5t      �� 5u      "   6"   .R�5v      �� $ border��6    . #��z��5x      #��z��5y      # z��5z      ��5{      �� 5|      # �  6.    5~        5      CommonStates��. 5�   "     Disabled��. 5�   &   �� .��5�   *   �� $	 border��6G   $I
 C(Panel.Background).                         (SolidColorBrush.Color)�5�   3   .g�5�   .     $ 0��6B   # �  5�   ,   5�   +   5�   '   5�   #     5�   "   
Normal��6.   5�      ._�5�      �� $ DG_ScrollViewer��6'   |�.  
���   ���5�      �� 5�   "   " ��62   .R�5�   &   �  5�   *   �� 5�   .   $
��Auto �6?   �� 5�   .   $��* �6?   �� 5�   .   $
��Auto �6?    5�   *   �� 5�   .   $
��Auto �6<   �� 5�   .   $��* �6<   �� 5�   .   $
��Auto �6<   .+�5�   *   �� |�.  #��Z  5�      ��5�      C� *�� $" DataGridSelectAllButtonStyle��"   +y�5�      �� *HeadersVisibility+#" Z! #$ Z# % �� "&   ��5�      �� *CellsPanelHorizontalOffset+% �� "&     5�   *   $!' PART_ColumnHeadersPresenter��6I   $��1��5�   5   y�5�   5   �� *HeadersVisibility+#" Z( #$ Z# % �� "&   �� 5�   *   $!) PART_ScrollContentPresenter��6A   $��2��5�   -   $��1��5�   -   #* z��5�   -   �� 5�   *   $+ PART_VerticalScrollBar��64   $��2��5�       $��1��5�       $, Vertical=�5�       #. z- 5�       #0 z/ 5�       #y�z1 5�       2 5�       �� *VerticalOffset+$3 OneWay=�% �� *TemplatedParent+� 5�   *   $��1��6/   $��2��5�       5�   .   �� 5�   2   ��6C   �� **(NonFrozenColumnsViewportHorizontalOffset+% �� "&   �� 5�   2   $��* �6C   .+�5�   .   �� $+ PART_HorizontalScrollBar��68   $��1��5�   "   $, 
Horizontal=�5�   "   #. z4 5�   "   #0 z5 5�   "   #y�z6 5�   "   2 5�   "   �� *HorizontalOffset+$3 OneWay=�% �� *TemplatedParent+5�   +   5�   '   5�   #   .��5�      �� # z 6-   5�      5�      5�      5�      7 5�   
   P� 5�      8 �@��
IsGrouping9 . . �5�      ��  � �� .  5�      5�      5�      �� 5�      "   6   .�5�   
   ��  � �� 5�      �� 5�      "  6"   .R�5�      �� $ border��6   
������ $��1q�5�      
������  .  5�        5�      FocusStates��. 5�   "     	Unfocused��6.     5�   "   Focused��6.   5�        5�      CurrentStates��. 5�   "     Regular��6.     5�   "   Current��. 5�   &   �� .��5�   *   �� $	 border��6G   $K
 E(Border.BorderBrush).                         (SolidColorBrush.Color)�5�   3   .g�5�   .     $ 0��6B   8   5�   ,   5�   +   5�   '   5�   #   5�      ._�5     �� # z 6+   5     5     5     5     �� 5	     "  	 6   .�5
  
   ��  � �� 5     �� 5     # �  6"   5     �� 5  
    �@J�SnapsToDevicePixels . 5     �� 5  
    �@=�ErrorTemplate 5     Z� �� 5  
    �@	 ValidationErrorTemplate 5     �� 5     .R�5     �� 
���  ��$��2,0,0,0q�5     $��!��5     $��Center=�5     5     5     �� 5  
    � �� 5     �� 5     " 	 6"   .R�5      �� $ 
DGR_Border��6   #��z��5!     #��z��5"      . ��5$     �� 5%     $ 0.5,1&�62   $ 0.5,0&�5&  $   .��5'  "   � $ Transparent��6/   $ 0Q�5(     � 5)  "   # �  6/   $ 1Q�5*     5+      5-       5.     CommonStates��. 5/  "     
Normal��6.     52  "   Normal_AlternatingRow��. 53  &   �� .��54  *   �� $	 
DGR_Border��6G   $g
 a(Panel.Background).                         (GradientBrush.GradientStops)[0].(GradientStop.Color)�55  3   .g�57  .     $ 0��6B   8   58  ,   59  +   �� 5:  *   $	 
DGR_Border��6G   $g
 a(Panel.Background).                         (GradientBrush.GradientStops)[1].(GradientStop.Color)�5;  3   .g�5>  .     $ 0��6B   8  5?  ,   5@  +   5A  '   5B  #     5I  "   Normal_Selected��. 5J  &   �� .��5K  *   �� $	 
DGR_Border��6G   $g
 a(Panel.Background).                         (GradientBrush.GradientStops)[0].(GradientStop.Color)�5L  3   .g�5N  .     $ 0��6B   8  5O  ,   5P  +   �� 5Q  *   $	 
DGR_Border��6G   $g
 a(Panel.Background).                         (GradientBrush.GradientStops)[1].(GradientStop.Color)�5R  3   .g�5T  .     $ 0��6B   8  5U  ,   5V  +   5W  '   5X  #     5Z  "   Unfocused_Selected��. 5[  &   �� .��5\  *   �� $	 
DGR_Border��6G   $g
 a(Panel.Background).                         (GradientBrush.GradientStops)[0].(GradientStop.Color)�5]  3   .g�5_  .     $ 0��6B   8  5`  ,   5a  +   �� 5b  *   $	 
DGR_Border��6G   $g
 a(Panel.Background).                         (GradientBrush.GradientStops)[1].(GradientStop.Color)�5c  3   .g�5e  .     $ 0��6B   8  5f  ,   5g  +   5h  '   5i  #     5k  "   Normal_Editing��. 5l  &   �� .��5m  *   �� $	 
DGR_Border��6G   $g
 a(Panel.Background).                         (GradientBrush.GradientStops)[0].(GradientStop.Color)�5n  3   .g�5p  .     $ 0��6B   8  5q  ,   5r  +   �� 5s  *   $	 
DGR_Border��6G   $g
 a(Panel.Background).                         (GradientBrush.GradientStops)[1].(GradientStop.Color)�5t  3   .g�5v  .     $ 0��6B   8  5w  ,   5x  +   5y  '   5z  #     5|  "   MouseOver_Editing��. 5}  &   �� .��5~  *   �� $	 
DGR_Border��6G   $g
 a(Panel.Background).                         (GradientBrush.GradientStops)[0].(GradientStop.Color)�5  3   .g�5�  .     $ 0��6B   8  5�  ,   5�  +   �� 5�  *   $	 
DGR_Border��6G   $g
 a(Panel.Background).                         (GradientBrush.GradientStops)[1].(GradientStop.Color)�5�  3   .g�5�  .     $ 0��6B   8 	 5�  ,   5�  +   5�  '   5�  #     5�  "   MouseOver_Unfocused_Editing��. 5�  &   �� .��5�  *   �� $	 
DGR_Border��6G   $g
 a(Panel.Background).                         (GradientBrush.GradientStops)[0].(GradientStop.Color)�5�  3   .g�5�  .     $ 0��6B   8 
 5�  ,   5�  +   �� 5�  *   $	 
DGR_Border��6G   $g
 a(Panel.Background).                         (GradientBrush.GradientStops)[1].(GradientStop.Color)�5�  3   .g�5�  .     $ 0��6B   8  5�  ,   5�  +   5�  '   5�  #     5�  "   Unfocused_Editing��. 5�  &   �� .��5�  *   �� $	 
DGR_Border��6G   $g
 a(Panel.Background).                         (GradientBrush.GradientStops)[0].(GradientStop.Color)�5�  3   .g�5�  .     $ 0��6B   8  5�  ,   5�  +   �� 5�  *   $	 
DGR_Border��6G   $g
 a(Panel.Background).                         (GradientBrush.GradientStops)[1].(GradientStop.Color)�5�  3   .g�5�  .     $ 0��6B   8  5�  ,   5�  +   5�  '   5�  #     5�  "   	MouseOver��. 5�  &   �� .��5�  *   �� $	 
DGR_Border��6G   $g
 a(Panel.Background).                         (GradientBrush.GradientStops)[0].(GradientStop.Color)�5�  3   .g�5�  .     $ 0��6B   8  5�  ,   5�  +   �� 5�  *   $	 
DGR_Border��6G   $g
 a(Panel.Background).                         (GradientBrush.GradientStops)[1].(GradientStop.Color)�5�  3   .g�5�  .     $ 0��6B   8  5�  ,   5�  +   5�  '   5�  #     5�  "   MouseOver_Selected��. 5�  &   �� .��5�  *   �� $	 
DGR_Border��6G   $g
 a(Panel.Background).                         (GradientBrush.GradientStops)[0].(GradientStop.Color)�5�  3   .g�5�  .     $ 0��6B   8  5�  ,   5�  +   �� 5�  *   $	 
DGR_Border��6G   $g
 a(Panel.Background).                         (GradientBrush.GradientStops)[1].(GradientStop.Color)�5�  3   .g�5�  .     $ 0��6B   8  5�  ,   5�  +   5�  '   5�  #     5�  "    MouseOver_Unfocused_Selected��. 5�  &   �� .��5�  *   �� $	 
DGR_Border��6G   $g
 a(Panel.Background).                         (GradientBrush.GradientStops)[0].(GradientStop.Color)�5�  3   .g�5�  .     $ 0��6B   8  5�  ,   5�  +   �� 5�  *   $	 
DGR_Border��6G   $g
 a(Panel.Background).                         (GradientBrush.GradientStops)[1].(GradientStop.Color)�5�  3   .g�5�  .     $ 0��6B   8  5�  ,   5�  +   5�  '   5�  #   5�     ._�5�     
   5�     �� 5�  "   $
��Auto �63   �� 5�  "   $��* �63    5�     �� 5�  "   $��* �60   �� 5�  "   $
��Auto �60   .+�5�       $��1��65   #��z: 5�  '   # z 5�  '     5�     $��1��67   $��1��5�  )   #y�z; 5�  )   < 5�  )   �� *AreRowDetailsFrozen+#" Z= #$ Z> % �� "&     5�     $��2��60   $< Vertical=�5�  "   y�5�  "   �� *HeadersVisibility+#" Z? #$ Z# % �� "&   5     5     5     5     5     �� 5
     "  n�5  
   .�5  
   ��  � ��$ 8��5     �� 5  
    � ��
 ���� 5     �� 5  
    �@�Cursor$ SizeNS��5     �� 5  
    � �� 5     �� 5     " n�6"   .R�5     �� #��z��6   # z��5     5     5     5     �� 5     "   6   .�5  
   ��  � �� 5     �� 5      "  6"   .R�5!     �  5"       5'     CommonStates��. 5(  "     
Normal��6.     5)  "   Normal_CurrentRow��6.     5*  "   Unfocused_EditingRow��6.     5+  "   Normal_EditingRow��6.     5,  "   	MouseOver��. 5-  &   �� .��5.  *   �� $	 rowHeaderBorder��6G   $g
 a(Panel.Background).                         (GradientBrush.GradientStops)[1].(GradientStop.Color)�5/  3   .g�51  .     $ 0��6B   8   52  ,   53  +   54  '   55  #     56  "   MouseOver_CurrentRow��6.     57  "   "MouseOver_Unfocused_EditingRow��6.     58  "   MouseOver_EditingRow��6.     59  "    MouseOver_Unfocused_Selected��6.     5:  "   MouseOver_Selected��6.     5;  "   +'MouseOver_Unfocused_CurrentRow_Selected��6.     5<  "   !MouseOver_CurrentRow_Selected��6.     5=  "   Unfocused_Selected��6.     5>  "   !Unfocused_CurrentRow_Selected��6.     5?  "   Normal_CurrentRow_Selected��6.     5@  "   Normal_Selected��6.   5A     .+�5C     �� $ rowHeaderBorder��6!   $��10��5D     $��1q�5E     ��5F     �� 5G  "   $ 0.5,1&�66   $ 0.5,0&�5H  &   .��5I  &   � # �  63   $ 0Q�5J  !   � 5K  &   # �  63   $ 1Q�5L  !   5M  #   ��5O     �� 5P  "   $ 0.5,1&�66   $ 0.5,0&�5Q  &   .��5R  &   � # �  63   $ 0Q�5S  !   � 5T  &   # �  63   $ 1Q�5U  !   5V  #   ._�5X     �� $@ 
Horizontal=�6)   .+�5Y  "   �� $��Center=�63   # z 5Z  #   �� 5[  "    .  ��5\     �� *ValidationErrorTemplate+% �� "& 	 y�5^     �� *(Validation.HasError)+8$  % �� "& 	 5a     5b     n� 5d     $A PART_TopHeaderGripper��6    8�� $	��Top=�5f     n� 5g     $A PART_BottomHeaderGripper��6    8�� $��Bottom=�5i     5j     5k     5m     5n     �� 5q     "  n�5r  
   .�5s  
   ��  � ��$ 8��5t     �� 5u  
    � ��
 ���� 5v     �� 5w  
    �@�Cursor$ SizeWE��5x     �� 5y  
    � �� 5z     �� 5{     " n�6"   .R�5|     �� #��z��6   # z��5}     5~     5�     5�     �� 5�     "   6   .�5�  
   ��  � ��$ Center=�65   �� 5�  
    � ��$ Center=�67   �� 5�  
    � ��$
 Bold"�6'   �� 5�  
    � ��$ 12(�6%   �� 5�  
    � ��$ 20��6#   �� 5�  
    � �� 5�     �� 5�     "  6"   .R�5�     � .+�5�     �� $ columnHeaderBorder��6!   $��1q�5�     $ 3,0,3,0q�5�     ��5�     �� 5�  "   $ 0.5,1&�66   $ 0.5,0&�5�  &   .��5�  &   � # �  63   $ 0Q�5�  !   � 5�  &   # �  63   $ 1Q�5�  !   5�  #   ��5�     �� 5�  "   $ 0.5,1&�66   $ 0.5,0&�5�  &   .��5�  &   � # �  63   $ 0Q�5�  !   � 5�  &   # �  63   $ 1Q�5�  !   5�  #   ._�5�     �� #��z��6/   # z 5�  !   #��z��5�  !   5�     n� 5�     $A PART_LeftHeaderGripper��6    $
��Left=�5�     8��  5�     n� 5�     $A PART_RightHeaderGripper��6    $��Right=�5�     8�� 5�     5�     5�     5�     �� 5�  
    � �� 5�     �� 5�     $ 0.5,1&�6&   $ 0.5,0&�5�     .��5�     � # �  6#   $ 0Q�5�     � 5�     # �  6#   $ 1Q�5�     5�     5�     5�     �� 5�     "   6   .�5�  
   ��  � �� 5�     �� 5�     "  6"   .R�5�     � .+�5�       $B PART_FillerColumnHeader��6/   C .  5�  #   �� 5�     5�     5�     5�     5�     5�     