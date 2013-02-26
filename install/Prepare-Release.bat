@echo off
setlocal enableextensions

mkdir StyleCopComments.7.1 2> NUL
copy /y ..\src\resharper-stylecop-comments\bin\Release\*.* StyleCopComments.7.1\
