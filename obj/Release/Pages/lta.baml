   M S B A M L   `   `   `  ����   预彩精灵    预彩精灵.Pages.lta   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     Z VFirstFloor.ModernUI, Version=1.0.9.0, Culture=neutral, PublicKeyToken=bc9b0c37bf06c6a90mui&http://firstfloorsoftware.com/ModernUI    � 	Resources     ContentCenterStyle �� 
TargetType �� Property �� Value  ColumnHeaderCenterStyle=  7System.Windows.Controls.Primitives.DataGridColumnHeader��%�   &	        &	 W     �� " ��.���  � ��$ Center=���  � ��$ Center=���  � ��$ 15(��� "  .���  � ��$ Center=���  � ��$ Center=���  � ��$ 20(�.���   ContentRoot#��[  � ShowGridLines .  � ColumnDefinitions �� $	��130���� .+��� .+��� $	��100��$	��Top=� �� Orientation$ Vertical=�.+��� -    ��Name$ StartCulcBtn��$��开始分析��$	��100��$��10,0,0,0q�$
��Left=��� -   $ StopCulcBtn��$��停止分析��$	��100��$��	10,10,0,0q�$
��Left=��� -   $ SetupBtn��$��分析设置��$	��100��$��	10,10,0,0q�$
��Left=�R� -    R�Name$ TreeUi��$	��150��$	��300��$��0,10,0,0q�.@�Q� $��[A]综合走势��.@�Q� $��两个数的走势��.@�Q� -   	 Q�Name$	 AtwoNumTrend0��$��
附加得0��Q� -   $	 AtwoNumTrend9��$��
附加得9��Q� $��三个数的走势��.@�Q� -   $	 AthreeNumTrend0��$��
附加得0��Q� -   $	 AthreeNumTrend9��$��
附加得9��Q� -	   $	 AthreeNumTrend09��$��得0得9��Q� $��四个数的走势��.@�Q� -
   $	 AfourNumTrend0��$��
附加得0��Q� -   $	 AfourNumTrend9��$��
附加得9��Q� -   $	 AfourNumTrend09��$��得0得9��Q� -   $	 AfiveNumTrend��$��五个数的走势��Q� $��[B]综合走势��.@�Q� $��两个数的走势��.@�Q� -   $	 BtwoNumTrend0��$��
附加得0��Q� -   $	 BtwoNumTrend9��$��
附加得9��Q� $��三个数的走势��.@�Q� -   $	 BthreeNumTrend0��$��
附加得0��Q� -   $	 BthreeNumTrend9��$��
附加得9��Q� -   $	 BthreeNumTrend09��$��得0得9��Q� $��四个数的走势��.@�Q� -   $	 BfourNumTrend0��$��
附加得0��Q� -   $	 BfourNumTrend9��$��
附加得9��Q� -   $	 BfourNumTrend09��$��得0得9��Q� -   $	 BfiveNumTrend��$��五个数的走势��Q� $��[C]综合走势��.@�Q� $��两个数的走势��.@�Q� -   $	 CtwoNumTrend0��$��
附加得0��Q� -   $	 CtwoNumTrend9��$��
附加得9��Q� $��三个数的走势��.@�Q� -   $	 CthreeNumTrend0��$��
附加得0��Q� -   $	 CthreeNumTrend9��$��
附加得9��Q� -   $	 CthreeNumTrend09��$��得0得9��Q� $��四个数的走势��.@�Q� -   $	 CfourNumTrend0��$��
附加得0��Q� -   $	 CfourNumTrend9��$��
附加得9��Q� -   $	 CfourNumTrend09��$��得0得9��Q� -   $	 CfiveNumTrend��$��五个数的走势��Q� $��[D]综合走势��.@�Q� $��两个数的走势��.@�Q� -    $	 DtwoNumTrend0��$��
附加得0��Q� -!   $	 DtwoNumTrend9��$��
附加得9��Q� $��三个数的走势��.@�Q� -"   $	 DthreeNumTrend0��$��
附加得0��Q� -#   $	 DthreeNumTrend9��$��
附加得9��Q� -$   $	 DthreeNumTrend09��$��得0得9��Q� $��四个数的走势��.@�Q� -%   $	 DfourNumTrend0��$��
附加得0��Q� -&   $	 DfourNumTrend9��$��
附加得9��Q� -'   $	 DfourNumTrend09��$��得0得9��Q� -(   $	 DfiveNumTrend��$��五个数的走势���� $	��200��$��10,0,0,0q�$	��Top=�$ Vertical=�$��2��.+�� -)   
 �Name$	
 prb��$	��800��$��10��$	��Top=�$��0,0,0,0q�{�.  � IsIndeterminate .  &   System.Windows.Controls.DataGrid  -*     Name$ ReslutTable��   
IsReadOnly . $�� 0,5,0,0q�   AutoGenerateColumns .  $��2��   GridLinesVisibility$	 All=�����    	CellStyle �� dgb��*  $System.Windows.Controls.DataGridCell"  .���  � ��$ Center=�   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   HeaderStyle# [ 1  +System.Windows.Controls.DataGridBoundColumn   ElementStyle# [     Header$ 算法公式��   Width5  /System.Windows.Controls.DataGridLengthConverter$	 100    Binding �� *AlgorithmFormula+ �� Mode$ TwoWay=�  # [ # [  $ 区间��$ 80  �� *
KuangNum+$ TwoWay=�  # [ # [  $ 结果区间��$	 100  �� *	ResultNum+$ TwoWay=�  # [ # [  $ 连续次数��$	 100  �� *
ColdTime+$ TwoWay=�