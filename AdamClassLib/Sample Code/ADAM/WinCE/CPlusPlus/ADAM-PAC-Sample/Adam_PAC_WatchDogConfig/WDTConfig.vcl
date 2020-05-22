<html>
<body>
<pre>
<h1>Build Log</h1>
<h3>
--------------------Configuration: WDTConfig - Win32 (WCE x86) Debug--------------------
</h3>
<h3>Command Lines</h3>
Creating command line "rc.exe /l 0x409 /fo"X86Dbg/WDTConfig.res" /d UNDER_CE=500 /d _WIN32_WCE=500 /d "UNICODE" /d "_UNICODE" /d "DEBUG" /d "WCE_PLATFORM_STANDARDSDK_500" /d "_X86_" /d "x86" /d "_i386_" /r "C:\Documents and Settings\USER\桌面\ADAM_PAC_Examples\ADAM_PAC_WatchDogConfig\WDTConfig.rc"" 
Creating temporary file "C:\DOCUME~1\USER\LOCALS~1\Temp\RSP32B1.tmp" with contents
[
/nologo /W3 /Zi /Od /D "DEBUG" /D "_i386_" /D UNDER_CE=500 /D _WIN32_WCE=500 /D "WCE_PLATFORM_STANDARDSDK_500" /D "UNICODE" /D "_UNICODE" /D "_X86_" /D "x86" /D "_WIN32_WCE_CEPC" /FR"X86Dbg/" /Fp"X86Dbg/WDTConfig.pch" /Yu"stdafx.h" /Fo"X86Dbg/" /Fd"X86Dbg/" /Gs8192 /GF /c 
"C:\Documents and Settings\USER\桌面\ADAM_PAC_Examples\ADAM_PAC_WatchDogConfig\WDTConfig.cpp"
"C:\Documents and Settings\USER\桌面\ADAM_PAC_Examples\ADAM_PAC_WatchDogConfig\WDTConfigDlg.cpp"
]
Creating command line "cl.exe @C:\DOCUME~1\USER\LOCALS~1\Temp\RSP32B1.tmp" 
Creating temporary file "C:\DOCUME~1\USER\LOCALS~1\Temp\RSP32B2.tmp" with contents
[
/nologo /W3 /Zi /Od /D "DEBUG" /D "_i386_" /D UNDER_CE=500 /D _WIN32_WCE=500 /D "WCE_PLATFORM_STANDARDSDK_500" /D "UNICODE" /D "_UNICODE" /D "_X86_" /D "x86" /D "_WIN32_WCE_CEPC" /FR"X86Dbg/" /Fp"X86Dbg/WDTConfig.pch" /Yc"stdafx.h" /Fo"X86Dbg/" /Fd"X86Dbg/" /Gs8192 /GF /c 
"C:\Documents and Settings\USER\桌面\ADAM_PAC_Examples\ADAM_PAC_WatchDogConfig\StdAfx.cpp"
]
Creating command line "cl.exe @C:\DOCUME~1\USER\LOCALS~1\Temp\RSP32B2.tmp" 
Creating temporary file "C:\DOCUME~1\USER\LOCALS~1\Temp\RSP32B3.tmp" with contents
[
/nologo /base:"0x00010000" /stack:0x10000,0x1000 /entry:"wWinMainCRTStartup" /incremental:yes /pdb:"X86Dbg/ADAM_PAC_WatchDogConfig.pdb" /debug /out:"X86Dbg/ADAM_PAC_WatchDogConfig.exe" /subsystem:windowsce,5.00 /MACHINE:IX86 
".\X86Dbg\StdAfx.obj"
".\X86Dbg\WDTConfig.obj"
".\X86Dbg\WDTConfigDlg.obj"
".\X86Dbg\WDTConfig.res"
]
Creating command line "link.exe @C:\DOCUME~1\USER\LOCALS~1\Temp\RSP32B3.tmp"
<h3>Output Window</h3>
Compiling resources...
Compiling...
StdAfx.cpp
Compiling...
WDTConfig.cpp
WDTConfigDlg.cpp
Generating Code...
Linking...
   Creating library X86Dbg/ADAM_PAC_WatchDogConfig.lib and object X86Dbg/ADAM_PAC_WatchDogConfig.exp
corelibc.lib(wwinmain.obj) : warning LNK4209: debugging information corrupt; recompile module; linking object as if no debug info
corelibc.lib(onexit.obj) : warning LNK4209: debugging information corrupt; recompile module; linking object as if no debug info
corelibc.lib(crt0dat.obj) : warning LNK4209: debugging information corrupt; recompile module; linking object as if no debug info
corelibc.lib(crt0init.obj) : warning LNK4209: debugging information corrupt; recompile module; linking object as if no debug info
Creating command line "bscmake.exe /nologo /o"X86Dbg/WDTConfig.bsc"  ".\X86Dbg\StdAfx.sbr" ".\X86Dbg\WDTConfig.sbr" ".\X86Dbg\WDTConfigDlg.sbr""
Creating browse info file...
<h3>Output Window</h3>




<h3>Results</h3>
ADAM_PAC_WatchDogConfig.exe - 0 error(s), 4 warning(s)
</pre>
</body>
</html>
