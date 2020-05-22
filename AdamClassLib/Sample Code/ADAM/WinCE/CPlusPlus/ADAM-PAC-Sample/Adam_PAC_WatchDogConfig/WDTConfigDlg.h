// WDTConfigDlg.h : header file
//

#if !defined(AFX_WDTCONFIGDLG_H__9D166A3D_F3EC_45BB_90FD_5CDD0CA81CA9__INCLUDED_)
#define AFX_WDTCONFIGDLG_H__9D166A3D_F3EC_45BB_90FD_5CDD0CA81CA9__INCLUDED_

#if _MSC_VER >= 1000
#pragma once
#endif // _MSC_VER >= 1000

/////////////////////////////////////////////////////////////////////////////
// CWDTConfigDlg dialog

class CWDTConfigDlg : public CDialog
{
// Construction
public:
	CWDTConfigDlg(CWnd* pParent = NULL);	// standard constructor

// Dialog Data
	//{{AFX_DATA(CWDTConfigDlg)
	enum { IDD = IDD_WDTCONFIG_DIALOG };
	CComboBox	m_WdtTimerSpan;
	//}}AFX_DATA

	// ClassWizard generated virtual function overrides
	//{{AFX_VIRTUAL(CWDTConfigDlg)
	protected:
	virtual void DoDataExchange(CDataExchange* pDX);	// DDX/DDV support
	//}}AFX_VIRTUAL

// Implementation
protected:
	HICON m_hIcon;

	// Generated message map functions
	//{{AFX_MSG(CWDTConfigDlg)
	virtual BOOL OnInitDialog();
	afx_msg void OnEnableDisable();
	afx_msg void OnStrobe();
	afx_msg void OnReboot();
	//}}AFX_MSG
	DECLARE_MESSAGE_MAP()
private:
	UINT m_nEnableStatus;
	UINT m_nTimerSpanIndex;
	DWORD m_dwChipsetType;
};

//{{AFX_INSERT_LOCATION}}
// Microsoft eMbedded Visual C++ will insert additional declarations immediately before the previous line.

#endif // !defined(AFX_WDTCONFIGDLG_H__9D166A3D_F3EC_45BB_90FD_5CDD0CA81CA9__INCLUDED_)
