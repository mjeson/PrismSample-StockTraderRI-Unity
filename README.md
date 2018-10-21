
# PrismSample-StockTraderRI-Unity
This is a WPF Prism sample for StockTrader Reference Implementation. 
Originally it was created with MEF. This version recreates it with Unity DI.



# No more Panic
   <!--1.Represents function : in Nant is call a target-->
  <!--2. echo is a NAnt-defined task. The task name is the element name. Because this task appears before any target definition--->
  <!--3.This project has ??? targets, each with ??? task. -->
  <!-- 4. Task is e.g. echo -->

# This is how we can do!!
* Using the csc task to compile C# source files
* Using Global tasks to create the directories  e.g. <mkdir dir="source"/> or <echo message="your mesage"/>
* Using global tasks [here](http://nant.sourceforge.net/release/0.85/help/tasks/index.html) e.g. <include/>
* Using **Includes** to bind an external build file. (this relation concept in nant)

# Fun with Wix(Window Installer XML)!!!
* Project Templates
  * Setup Project (.wix)
  * Merge Module Project (.msn)
  * Setup Library Project (wixlib) --> share features between installations
  * Bootstrapper Project --> create a SETUP.EXE
  * Custom Action Projects
* Hierarchy of an Installation
- Product
   - Feacture (many...)
       - Components

* Key Words
  * **Fragment** --> A Container for ComponentGroup Or Directory
  * **ComponentGroup**
  * **Directory** --> to define a directory in wix file
  * **ComponentGroupRef** -->to point a ComponentGroup via Id
  * **Product** --> To define specific infor for your Project (Name, Id, Manufactury)
  * **Component** -->

* Best Pratice
 * one file per component
 * 
* External Tools!!
  * Candle.exe --> To complie your wix project
  * Light.exe --> To Linken your output of candle i think so!!




