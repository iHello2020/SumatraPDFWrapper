# SumatraPDFWarpper

[![License](https://img.shields.io/badge/license-MIT-blue.svg)](https://github.com/DarqueWarrior/generator-team/blob/master/LICENSE)
[![NuGet](https://img.shields.io/nuget/dt/SumatraPDFWarpper.svg)](https://www.nuget.org/packages/SumatraPDFWarpper/)
[![Build status](https://vishnevsky.visualstudio.com/SumatraPDFWarpper/_apis/build/status/SumatraPDFWarpper%20Build)](https://vishnevsky.visualstudio.com/SumatraPDFWarpper/_build/latest?definitionId=1)

The SumatraPDFWarpper project Allows to print PDF files uses [SumatraPDF](http://www.columbia.edu/~em36/pdftoprinter.html) util. The package contains SumatraPDF.exe and copys it to the output folder before build event. Also it provides SumatraPDFWarpper class that runs SumatraPDF.exe inside of a "Print" method in a separate process with default timeout 1 minute (the timeout can be overrited by 3rd argument).

Sample usage:

```C#
var filePath = "c:\path\to\pdf\file.pdf";
var printerName = "Vendor Color Printer Name";
var printWrapper = new SumatraPDFWarpper();
printWrapper.Print(filePath, printerName);
```

or

```C#
var filePath = "c:\path\to\pdf\file.pdf";
var networkPrinterName = "\\myprintserver\printer1";
var printTimeout = new TimeSpan(0, 30, 0);
var printWrapper = new SumatraPDFWarpper();
printWrapper.Print(filePath, networkPrinterName, printTimeout);
```