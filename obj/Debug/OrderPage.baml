   M S B A M L   `   `   `  ����B  >Ukraine, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:UkraineUkraine  5          Ukraine.OrderPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      'localclr-namespace:Ukraine     5      -   5          N� Title$  	OrderPage��5	      .��5      �  � RowDefinitions 5   
   �� 5      $��50 �6   �� 5      $	��350 �6   �� 5      $��50 �6   .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ 
DGridOrder��5      $��1��6'      
IsReadOnly .    AutoGenerateColumns .  
�������   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6%      Header$ Клиент��6/   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6?   �� *Client.c_name+  5      $ * 6%   $ Тип��6/    6<   �� *AdvertType.a_type+  5      $ * 6%   $ Менеджер��6/    6A   �� *	User.u_ID+  5      $ * 6%   $( "Длительность (сек.)��6/    6L   �� *o_durationInSecond+  5      $ * 6%   $" Стоимость (руб.)��6/    6I   �� *o_cost+  5      $ * 6%   $ Дата (MM.DD.YYYY)��6/    6J   �� *o_date+4  .System.Windows.Controls.DataGridTemplateColumn  5      	   CellTemplate	 5      �� 5      .R�5      �� 
 ��Name$
 BtnEd��68   -   5        $��Изменить��5   %   6G   5      5       5"      �� 5#   
    �� Orientation$ 
Horizontal=�6   $��Right=�6.   $��Bottom=�6J   $��0 0 30 0q�6e   .+�5$      �� -   5         ��Name$ OrFilter��5$      $��0��6)   $	��100��66    � ToolTip$ Фильтрация��6B    � Cursor$
 Hand��6W   6e   �� 5%      -   5        $ 	OrSorting��5%      $��0��6*   $	��100��67   $  Отсортировать��6C   $
 Hand��6[   6i   �� 5&      -   5         ��Name$ OrFind��5&      $��0��6'   $ 
Поиск��64   5'      �� 5(   
   $ 
Horizontal=�6   $��2��6.   .+�5)      �� -   5        $
 BtnAdd��5)   5   $��Добавить��6   $��2��6(   6E   �� 5*      -   5        $
 BtnDel��5*   4   $��Удалить��6   $��2��6'   6D   5+      �� 5,   
   $��Фильтрация��6   $��0��6&   $��Right=�64   $��
0 0 345 35q�6P   $
��Bold"�6d   �� 5-   
   $��Сортировка��6   $��0��6&   $��Right=�63   $��
0 0 235 35q�6O   $
��Bold"�6c   �� 5.   
   $0��*D:\Смирнов\УП 07\image\search.png��6   $��Right=�6;   $��	0 22 10 9q�6W   5/      50      