// WDTConfig.h : main header file for the WDTCONFIG application
//

#if !defined(AFX_WDTCONFIG_H__8FBCFEB7_946C_45A3_860B_E1263BC5193B__INCLUDED_)
#define AFX_WDTCONFIG_H__8FBCFEB7_946C_45A3_860B_E1263BC5193B__INCLUDED_

#if _MSC_VER >= 1000
#pragma once
#endif // _MSC_VER >= 1000

#ifndef __AFXWIN_H__
	#error include 'stdafx.h' before including this file for PCH
#endif

#include "resource.h"		// main symbols

/////////////////////////////////////////////////////////////////////////////
// CWDTConfigApp:
// See WDTConfig.cpp for the implementation of this class
//

class CWDTConfigApp : public CWinApp
{
public:
	CWDTConfigApp();

// Overrides
	// ClassWizard generated virtual function overrides
	//{{AFX_VIRTUAL(CWDTConfigApp)
	public:
	virtual BOOL InitInstance();
	//}}AFX_VIRTUAL

// Implementation

	//{{AFX_MSG(CWDTConfigApp)
		// NOTE - the ClassWizard will add and remove member functions here.
		//    DO NOT EDIT what you see in these blocks of generated code !
	//}}AFX_MSG
	DECLARE_MESSAGE_MAP()
};


/////////////////////////////////////////////////////////////////////////////

//{{AFX_INSERT_LOCATION}}
// Microsoft eMbedded Visual C++ will insert additional declarations immediately before the previous line.

#endif // !defined(AFX_WDTCONFIG_H__8FBCFEB7_946C_45A3_860B_E1263BC5193B__INCLUDED_)
