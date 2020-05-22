<html>
<body>
<pre>
<h1>Build Log</h1>
<h3>
--------------------Configuration: ADAM_5550_Interrupt - Win32 (WCE x86) Debug--------------------
</h3>
<h3>Command Lines</h3>
Creating command line "rc.exe /l 0x409 /fo"X86Dbg/ADAM_5550_Interrupt.res" /d "WCE_PLATFORM_STANDARDSDK_500" /d UNDER_CE=500 /d _WIN32_WCE=500 /d "UNICODE" /d "_UNICODE" /d "DEBUG" /d "_X86_" /d "x86" /d "_i386_" /r "C:\Documents and Settings\USER\桌面\ADAM_PAC_Examples\ADAM_PAC_Interrupt\ADAM_5550_Interrupt.rc"" 
Creating temporary file "C:\DOCUME~1\USER\LOCALS~1\Temp\RSP21F2.tmp" with contents
[
/nologo /W3 /Zi /Od /I "..\Include" /D "DEBUG" /D "_i386_" /D UNDER_CE=500 /D _WIN32_WCE=500 /D "WCE_PLATFORM_STANDARDSDK_500" /D "i_386_" /D "UNICODE" /D "_UNICODE" /D "_X86_" /D "x86" /FR"X86Dbg/" /Fp"X86Dbg/ADAM_5550_Interrupt.pch" /Yu"stdafx.h" /Fo"X86Dbg/" /Fd"X86Dbg/" /Gs8192 /GF /c 
"C:\Documents and Settings\USER\桌面\ADAM_PAC_Examples\ADAM_PAC_Interrupt\ADAM_5550_AutoPolling.cpp"
"C:\Documents and Settings\USER\桌面\ADAM_PAC_Examples\ADAM_PAC_Interrupt\ADAM_5550_Interrupt.cpp"
]
Creating command line "cl.exe @C:\DOCUME~1\USER\LOCALS~1\Temp\RSP21F2.tmp" 
Creating temporary file "C:\DOCUME~1\USER\LOCALS~1\Temp\RSP21F3.tmp" with contents
[
/nologo /W3 /Zi /Od /I "..\Include" /D "DEBUG" /D "_i386_" /D UNDER_CE=500 /D _WIN32_WCE=500 /D "WCE_PLATFORM_STANDARDSDK_500" /D "i_386_" /D "UNICODE" /D "_UNICODE" /D "_X86_" /D "x86" /FR"X86Dbg/" /Fp"X86Dbg/ADAM_5550_Interrupt.pch" /Yc"stdafx.h" /Fo"X86Dbg/" /Fd"X86Dbg/" /Gs8192 /GF /c 
"C:\Documents and Settings\USER\桌面\ADAM_PAC_Examples\ADAM_PAC_Interrupt\StdAfx.cpp"
]
Creating command line "cl.exe @C:\DOCUME~1\USER\LOCALS~1\Temp\RSP21F3.tmp" 
Creating temporary file "C:\DOCUME~1\USER\LOCALS~1\Temp\RSP21F4.tmp" with contents
[
commctrl.lib coredll.lib corelibc.lib ADS5550DIO.lib /nologo /base:"0x00010000" /stack:0x10000,0x1000 /entry:"WinMainCRTStartup" /incremental:yes /pdb:"X86Dbg/ADAM_PAC_Interrupt.pdb" /debug /nodefaultlib:"OLDNAMES.lib" /nodefaultlib:libc.lib /nodefaultlib:libcd.lib /nodefaultlib:libcmt.lib /nodefaultlib:libcmtd.lib /nodefaultlib:msvcrt.lib /nodefaultlib:msvcrtd.lib /out:"X86Dbg/ADAM_PAC_Interrupt.exe" /libpath:"..\Lib" /subsystem:windowsce,5.00 /MACHINE:IX86 
".\X86Dbg\ADAM_5550_AutoPolling.obj"
".\X86Dbg\ADAM_5550_Interrupt.obj"
".\X86Dbg\StdAfx.obj"
".\X86Dbg\ADAM_5550_Interrupt.res"
]
Creating command line "link.exe @C:\DOCUME~1\USER\LOCALS~1\Temp\RSP21F4.tmp"
<h3>Output Window</h3>
Compiling resources...
Compiling...
StdAfx.cpp
Compiling...
ADAM_5550_AutoPolling.cpp
ADAM_5550_Interrupt.cpp
Generating Code...
Linking...
corelibc.lib(pegwmain.obj) : warning LNK4209: debugging information corrupt; recompile module; linking object as if no debug info
corelibc.lib(crt0dat.obj) : warning LNK4209: debugging information corrupt; recompile module; linking object as if no debug info
corelibc.lib(crt0init.obj) : warning LNK4209: debugging information corrupt; recompile module; linking object as if no debug info




<h3>Results</h3>
ADAM_PAC_Interrupt.exe - 0 error(s), 3 warning(s)
</pre>
</body>
</html>
