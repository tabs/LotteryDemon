   M S B A M L   `   `   `  ����   预彩精灵!    预彩精灵.Pages.NumTrend   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     Z VFirstFloor.ModernUI, Version=1.0.9.0, Culture=neutral, PublicKeyToken=bc9b0c37bf06c6a90mui&http://firstfloorsoftware.com/ModernUI  -     >�Name$  NumTrendWindow�� � 	Resources    mutipleTable_Header �� Orientation  mutipleTable_Columns  ContentCenterStyle �� 
TargetType �� Property �� Value  ColumnHeaderCenterStyle=  7System.Windows.Controls.Primitives.DataGridColumnHeader��%  &	        &	     &	 ,    &	 �    �� .R��� $��Stretch=�$��Stretch=�.+��� ._��� $��邮箱��$	��340��$��Center=��� ._��� 
���   ��� $	��340��$ 
Horizontal=�.+��� $��邮箱1��$	��170��$��Center=�$��Center=��� 
���   �$��1q��� $��邮箱2��$	��170��$��Center=�$��Center=��� .R��� $
��Auto��$
��Auto��$ 
Horizontal=�.+��� ._��� $��1,0,1,0q�$	��170��$��Center=�$��Center=����� *ea+�� ._��� 
�������$��1q�
���   �$��0,0,0,0q��� ._��� $��1,0,1,0q�$	��170��$��Center=�$��Center=����� *eb+�� " ��.���  � ��$ Center=���  � ��$ Center=���  � ��$ 15(��� "  .���  � ��$ Center=���  � ��$ Center=���  � ��$ 20(�.���   ContentRoot#��[  � RowDefinitions �� $��30���� .+��� $ 
Horizontal=�.+��� -    ��Name$ AChBox��$��统计A��$��80��$��20,0,0,0q� d� 	IsChecked$
 TrueY��� -   $ BChBox��$��统计B��$��80��$��20,0,0,0q�$
 TrueY��� -   $ CChBox��$��统计C��$��80��$��20,0,0,0q�$
 TrueY��� -   $ DChBix��$��统计D��$��80��$��20,0,0,0q�$
 TrueY�&   System.Windows.Controls.DataGrid  -   	  Name$	 ReTable��
   
IsReadOnly
 . $��
 10,10,0,0q�   AutoGenerateColumns .     GridLinesVisibility$	 All=�$��1������    	CellStyle �� dgc��*  $System.Windows.Controls.DataGridCell"  .���  � ��$ Center=���  � ��$ Center=�   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   HeaderStyle# [ 1  +System.Windows.Controls.DataGridBoundColumn   ElementStyle# [    Header$ 编号��   Width5  /System.Windows.Controls.DataGridLengthConverter$ 80    Binding �� *Snum+ �� Mode$ TwoWay=�  # [ # [ $ 日期��$ 80  �� *	Numdate+$ TwoWay=�  # [ # [ $ 本期号码��$	 100  �� *Num+$ TwoWay=�  # [ # [ $ 1��$ 50  �� *eleone+  # [ # [ $ 2��$ 50  �� *eletwo+  # [ # [ $ 3��$ 50  �� *
elethree+  # [ # [ $ 4��$ 50  �� *	elefour+  # [ # [ $ 5��$ 50  �� *	elefive+  # [ # [ $ 6��$ 50  �� *elesix+  # [ # [ $ 7��$ 50  �� *
eleseven+  # [ # [ $ 8��$ 50  �� *
eleeight+