<html>
<body>
<pre>
<h1>Build Log</h1>
<h3>
--------------------Configuration: Adam50XXDIO - Win32 (WCE x86) Debug--------------------
</h3>
<h3>Command Lines</h3>
Creating command line "rc.exe /l 0x409 /fo"X86Dbg/Adam50XXDIO.res" /d "WCE_PLATFORM_STANDARDSDK_500" /d UNDER_CE=500 /d _WIN32_WCE=500 /d "UNICODE" /d "_UNICODE" /d "DEBUG" /d "_X86_" /d "x86" /d "_i386_" /r "C:\Documents and Settings\USER\орн▒\ADAM_PAC_Examples\ADAM_50XX_DIO\Adam50XXDIO.rc"" 
Creating temporary file "C:\DOCUME~1\USER\LOCALS~1\Temp\RSP2157.tmp" with contents
[
/nologo /W3 /Zi /Od /I "../Include" /D "DEBUG" /D "_i386_" /D UNDER_CE=500 /D _WIN32_WCE=500 /D "WCE_PLATFORM_STANDARDSDK_500" /D "i_386_" /D "UNICODE" /D "_UNICODE" /D "_X86_" /D "x86" /Fp"X86Dbg/Adam50XXDIO.pch" /Yu"stdafx.h" /Fo"X86Dbg/" /Fd"X86Dbg/" /Gs8192 /GF /c 
"C:\Documents and Settings\USER\орн▒\ADAM_PAC_Examples\ADAM_50XX_DIO\Adam50XXDIO.cpp"
]
Creating command line "cl.exe @C:\DOCUME~1\USER\LOCALS~1\Temp\RSP2157.tmp" 
Creating temporary file "C:\DOCUME~1\USER\LOCALS~1\Temp\RSP2158.tmp" with contents
[
/nologo /W3 /Zi /Od /I "../Include" /D "DEBUG" /D "_i386_" /D UNDER_CE=500 /D _WIN32_WCE=500 /D "WCE_PLATFORM_STANDARDSDK_500" /D "i_386_" /D "UNICODE" /D "_UNICODE" /D "_X86_" /D "x86" /Fp"X86Dbg/Adam50XXDIO.pch" /Yc"stdafx.h" /Fo"X86Dbg/" /Fd"X86Dbg/" /Gs8192 /GF /c 
"C:\Documents and Settings\USER\орн▒\ADAM_PAC_Examples\ADAM_50XX_DIO\StdAfx.cpp"
]
Creating command line "cl.exe @C:\DOCUME~1\USER\LOCALS~1\Temp\RSP2158.tmp" 
Creating temporary file "C:\DOCUME~1\USER\LOCALS~1\Temp\RSP2159.tmp" with contents
[
commctrl.lib coredll.lib corelibc.lib /nologo /base:"0x00010000" /stack:0x10000,0x1000 /entry:"WinMainCRTStartup" /incremental:yes /pdb:"X86Dbg/Adam50XXDIO.pdb" /debug /nodefaultlib:"OLDNAMES.lib" /nodefaultlib:libc.lib /nodefaultlib:libcd.lib /nodefaultlib:libcmt.lib /nodefaultlib:libcmtd.lib /nodefaultlib:msvcrt.lib /nodefaultlib:msvcrtd.lib /out:"X86Dbg/Adam50XXDIO.exe" /subsystem:windowsce,5.00 /MACHINE:IX86 
".\X86Dbg\Adam50XXDIO.obj"
".\X86Dbg\StdAfx.obj"
".\X86Dbg\Adam50XXDIO.res"
"..\Lib\ADS5550DIO.lib"
]
Creating command line "link.exe @C:\DOCUME~1\USER\LOCALS~1\Temp\RSP2159.tmp"
<h3>Output Window</h3>
Compiling resources...
Compiling...
StdAfx.cpp
Compiling...
Adam50XXDIO.cpp
Linking...
corelibc.lib(pegwmain.obj) : warning LNK4209: debugging information corrupt; recompile module; linking object as if no debug info
corelibc.lib(crt0dat.obj) : warning LNK4209: debugging information corrupt; recompile module; linking object as if no debug info
corelibc.lib(crt0init.obj) : warning LNK4209: debugging information corrupt; recompile module; linking object as if no debug info




<h3>Results</h3>
Adam50XXDIO.exe - 0 error(s), 3 warning(s)
</pre>
</body>
</html>
