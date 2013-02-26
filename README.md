# resharper-stylecop-comments

This simple plugin for ReSharper allows you to use StyleCop friendly comments for suppressing warnings. StyleCop has specific requirements for blank lines following single line C# comments (``// Comment``). These requirements are ignored if you use four slashes (``//// Comment``).

Unfortunately, ReSharper doesn't like you using four slashes when suppressing warnings, so you can't use this style of comment to suppress warnings. With this plugin, ReSharper allows four slashes. Like this:

``
//// resharper disable InconsistentNaming
    var _sausages = GetSausages();
//// resharper restore InconsistentNaming
``

Note that you can't mix and match styles. If you disable a warning with a comment with four slashes, you must use four slashes to restore the warning.

## How do I get it? ##

If you wish to just install a copy of the plugins without building yourself:

- Download the latest zip file: [resharper-stylecop-comments.1.0.zip](http://dl.bintray.com/content/citizenmatt/resharper-plugins/resharper-stylecop-comments.1.0.zip)
- Extract everything
- Run the Install-StyleCopComments.7.1.bat batch file

## Building ##

To build the source, you need the [ReSharper 7.1 SDK](http://www.jetbrains.com/resharper/download/index.html) installed. Then just open the src\resharper-stylecop-comments.sln file and build.

