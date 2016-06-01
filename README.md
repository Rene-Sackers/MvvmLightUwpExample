# MvvmLightUwpExample 
## Summary
A simple UWP application implementing/demonstrating some of the basics of UWP/XAML/MVVM/MVVM Light

I'm not claiming it's entirely correct, mainly created this to find out why my other projects had a million design-time issues.

## Techniques/technologies applied
* UWP (build 10586)
* [Cimbalino.Toolkit.Controls](https://github.com/Cimbalino/Cimbalino-Toolkit)
    * Hamburger frame
* App bar
* MVVM Light
    * MVVM
    * RelayCommand
    * SimpleIOC
        * Design-time/runtime services
* MessageDialog
* Font[Icon](https://msdn.microsoft.com/en-us/windows/uwp/controls-and-patterns/segoe-ui-symbol-font)
* Data binding
* GridView/VariableSizedWrapGrid

Main page
![main page](http://i.imgur.com/DOSynZy.png)

Edit/create page
![edit/create page](http://i.imgur.com/fP2PtEX.png)

Somehow managed to get it to work in design-time
![design time](http://i.imgur.com/riaX17k.png)