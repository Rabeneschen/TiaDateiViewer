   M S B A M L   `   `   `  ����  TiaFileViewer'    !TiaFileViewer.View.FileViewerView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5         SharedFileViewerViewModel  � DataContext#  [  5       � 	Resources 5
       �� MergedDictionaries �� Source�� 5   
    5      �� 5      $@ :/TiaFileViewer;component/Resources/ResourceDictionary.xaml?�6%   %    5      .��5      �  � RowDefinitions 5   
   �� 5      $��2* �6   �� 5      $��5* �6   �� 5      $��1* �6   .+�5   
   ��   UpperBorderStyle#��[ 6   $��0��6<   �� 5   
     InnerBorderStyle#��[ 6   $��1��6<   �� 5   
     BottomBorderStyle#��[ 6   $��2��6=   ._�5      ��  �� Orientation$ 
Horizontal=�6   .+�5      ��   IconicButtonFileOpenStyle#��[ 6   ��6L   �� *OpenFileDialogCommand+�� 5        VerticalSeparatorStyle#��[ 6   �� 5        IconicButtonSettingsStyle#��[ 6   �� 5         IconicButtonCompareStyle#��[ 6   �� 5!        IconicButtonCsvExportStyle#��[ 6   5"      5#      �� 5%   
   -   5         ��Name$ TypesListBox��5%       $��0��6    	 TypesListBoxStyle#��[	 66    
 TypeItemStyle#��[
 5'      $��Center=�5(      ��5&      �� *ListOfItems+ �� SelectedValue 5)      �� *SelectedTypeGroupItem+ �� Mode$ TwoWay=�y�5*      �� *TypesVisibility+��5+      �� 5,      .R�5-      �� $��Center=�6!   $��Center=�6>   $��15(�6Y   $��DemiBold"�6g   ��5.      `� 5/      	 �� StringFormat$	 	{0} ({1})��6,   .1�50   #   �� 
 �� Path$

 Type�6+   �� 51   #   $
 Count�6+   52       54      55      57      �� 59   
   -   5        $ ElementsListBox��59       $��1��6     ElementsListBoxStyle#��[ 69   $
��Left=�5;        NameItemStyle#��[ 5<      ��5:      �� *ListOfElements+y�5=      �� *ElementsVisibility+��5>      �� 5?      .R�5@      �� $��Center=�6    $��Center=�6=   $��15(�6X   $��DemiBold"�6f   ��5A      �� 5B      5D      5E      5G      5I      5J      