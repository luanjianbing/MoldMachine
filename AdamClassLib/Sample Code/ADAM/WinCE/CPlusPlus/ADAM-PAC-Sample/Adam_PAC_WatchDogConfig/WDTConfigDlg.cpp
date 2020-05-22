// WDTConfigDlg.cpp : implementation file
//

#include "stdafx.h"
#include "WDTConfig.h"
#include "WDTConfigDlg.h"
#include "wdtdrv.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif


HANDLE g_hWDT;   // Handle of Watchdog driver


/////////////////////////////////////////////////////////////////////////////
// CWDTConfigDlg dialog

CWDTConfigDlg::CWDTConfigDlg(CWnd* pParent /*=NULL*/)
	: CDialog(CWDTConfigDlg::IDD, pParent)
{
	//{{AFX_DATA_INIT(CWDTConfigDlg)
		// NOTE: the ClassWizard will add member initialization here
	//}}AFX_DATA_INIT
	// Note that LoadIcon does not require a subsequent DestroyIcon in Win32
	m_hIcon = AfxGetApp()->LoadIcon(IDR_MAINFRAME);
}

void CWDTConfigDlg::DoDataExchange(CDataExchange* pDX)
{
	CDialog::DoDataExchange(pDX);
	//{{AFX_DATA_MAP(CWDTConfigDlg)
	DDX_Control(pDX, IDC_WATCHDOG_TIMER, m_WdtTimerSpan);
	//}}AFX_DATA_MAP
}

BEGIN_MESSAGE_MAP(CWDTConfigDlg, CDialog)
	//{{AFX_MSG_MAP(CWDTConfigDlg)
	ON_BN_CLICKED(IDC_ENABLE_DISABLE, OnEnableDisable)
	ON_BN_CLICKED(IDC_STROBE, OnStrobe)
	ON_BN_CLICKED(IDC_REBOOT, OnReboot)
	//}}AFX_MSG_MAP
END_MESSAGE_MAP()

/////////////////////////////////////////////////////////////////////////////
// CWDTConfigDlg message handlers

BOOL CWDTConfigDlg::OnInitDialog()
{
	CDialog::OnInitDialog();

	// Set the icon for this dialog.  The framework does this automatically
	//  when the application's main window is not a dialog
	SetIcon(m_hIcon, TRUE);			// Set big icon
	SetIcon(m_hIcon, FALSE);		// Set small icon
	
	CenterWindow(GetDesktopWindow());	// center to the hpc screen

	// TODO: Add extra initialization here
   
   TCHAR szClassName[60];
   wsprintf(szClassName, TEXT("WDT1:"));
   DWORD dwTemp;
   
   g_hWDT = CreateFile(szClassName, GENERIC_READ | GENERIC_WRITE, 0, NULL,
      OPEN_EXISTING, FILE_ATTRIBUTE_NORMAL, NULL);
   
   if ( g_hWDT != INVALID_HANDLE_VALUE ) {
      RETAILMSG (TRUE, (TEXT("Createfile Success \r\n")));
   }
   
   // get the chip type of watchdog timer.
   DeviceIoControl(
      g_hWDT, 
      IOCTL_WDT_GET_CHIPSET_TYPE, 
      NULL, 
      0, 
      &m_dwChipsetType, 
      1, 
      &dwTemp, 
      NULL);
   // get timer span index of watchdog
   DeviceIoControl(
      g_hWDT,
      IOCTL_WDT_GET_TIMEOUT,
      NULL,
      0,
      &m_nTimerSpanIndex,
      1,
      &dwTemp,
      NULL);
   // get enable status of watchdog
   DeviceIoControl(
      g_hWDT,
      IOCTL_WDT_GET_ENABLE_STATUS,
      NULL,
      0,
      &m_nEnableStatus,
      1,
      &dwTemp,
      NULL);

   if ( (m_dwChipsetType!=WDT_CHIPSET_TYPE_443)
      && (m_dwChipsetType!=WDT_CHIPSET_TYPE_W83977AF)
      && (m_dwChipsetType!=WDT_CHIPSET_TYPE_W83627HF) 
      && (m_dwChipsetType!=WDT_CHIPSET_TYPE_F75111R) 
	  && (m_dwChipsetType!=WDT_CHIPSET_TYPE_S3C24X0) 
	  && (m_dwChipsetType!=WDT_CHIPSET_TYPE_XSC)
	  && (m_dwChipsetType!=WDT_CHIPSET_TYPE_SCH311X)
	  && (m_dwChipsetType!=WDT_CHIPSET_TYPE_ADAM5550))
   {
      m_dwChipsetType = WDT_CHIPSET_TYPE_UNKNOWN;
   }

   if ( m_nEnableStatus==WATCHDOG_ENABLED )
   {
      SendDlgItemMessage(
         IDC_ENABLE_DISABLE,
         WM_SETTEXT,
         0,
         reinterpret_cast<LPARAM>( L"&Disable" ) );   
   }
   if ( m_nEnableStatus==WATCHDOG_DISABLED )
   {
      SendDlgItemMessage(
         IDC_ENABLE_DISABLE,
         WM_SETTEXT,
         0,
         reinterpret_cast<LPARAM>( L"&Enable" ) );
      GetDlgItem(IDC_STROBE)->EnableWindow(FALSE);
	  GetDlgItem(IDC_REBOOT)->EnableWindow(FALSE);
   }

   // add watchdog timer span value in list.
   if ( m_dwChipsetType == WDT_CHIPSET_TYPE_443 || m_dwChipsetType == WDT_CHIPSET_TYPE_XSC)
   {
      m_WdtTimerSpan.AddString(_T("2 Seconds"));
      m_WdtTimerSpan.AddString(_T("5 Seconds"));
      m_WdtTimerSpan.AddString(_T("10 Seconds"));
      m_WdtTimerSpan.AddString(_T("15 Seconds"));
      m_WdtTimerSpan.AddString(_T("30 Seconds"));
      m_WdtTimerSpan.AddString(_T("45 Seconds"));
      m_WdtTimerSpan.AddString(_T("60 Seconds")); 
   }
   else if ( m_dwChipsetType == WDT_CHIPSET_TYPE_W83977AF )
   {
      m_WdtTimerSpan.AddString(_T("15 Seconds"));
      m_WdtTimerSpan.AddString(_T("45 Seconds"));
      m_WdtTimerSpan.AddString(_T("1 Minute 15 Seconds"));
      m_WdtTimerSpan.AddString(_T("2 Minutes 15 Seconds"));
      m_WdtTimerSpan.AddString(_T("3 Minutes 15 Seconds"));
      m_WdtTimerSpan.AddString(_T("4 Minutes 15 Seconds"));
      m_WdtTimerSpan.AddString(_T("5 Minutes 15 Seconds"));
      m_WdtTimerSpan.AddString(_T("10 Minutes 15 Seconds"));
      m_WdtTimerSpan.AddString(_T("20 Minutes 15 Seconds"));
      m_WdtTimerSpan.AddString(_T("30 Minutes 15 Seconds"));
      m_WdtTimerSpan.AddString(_T("40 Minutes 15 Seconds"));
      m_WdtTimerSpan.AddString(_T("50 Minutes 15 Seconds"));
      m_WdtTimerSpan.AddString(_T("1 Hour 15 Seconds"));
      m_WdtTimerSpan.AddString(_T("2 Hour 15 Seconds"));
   }
   else if ( m_dwChipsetType == WDT_CHIPSET_TYPE_W83627HF )
   {
      m_WdtTimerSpan.AddString(_T("15 Seconds"));
      m_WdtTimerSpan.AddString(_T("45 Seconds"));
      m_WdtTimerSpan.AddString(_T("1 Minute 15 Seconds"));
      m_WdtTimerSpan.AddString(_T("2 Minutes 15 Seconds"));
      m_WdtTimerSpan.AddString(_T("3 Minutes 15 Seconds"));
      m_WdtTimerSpan.AddString(_T("4 Minutes 15 Seconds"));
   }
   else if ( m_dwChipsetType == WDT_CHIPSET_TYPE_S3C24X0 )
   {
      m_WdtTimerSpan.AddString(_T("2 Seconds"));
      m_WdtTimerSpan.AddString(_T("5 Seconds"));
      m_WdtTimerSpan.AddString(_T("10 Seconds"));
      m_WdtTimerSpan.AddString(_T("15 Seconds"));
      m_WdtTimerSpan.AddString(_T("30 Seconds"));
      m_WdtTimerSpan.AddString(_T("40 Seconds"));
   }
   else if ( m_dwChipsetType == WDT_CHIPSET_TYPE_F75111R || m_dwChipsetType == WDT_CHIPSET_TYPE_SCH311X || m_dwChipsetType == WDT_CHIPSET_TYPE_ADAM5550 )
   {
      m_WdtTimerSpan.AddString(_T("15 Seconds"));
      m_WdtTimerSpan.AddString(_T("45 Seconds"));
      m_WdtTimerSpan.AddString(_T("1 Minute 15 Seconds"));
      m_WdtTimerSpan.AddString(_T("2 Minutes 15 Seconds"));
      m_WdtTimerSpan.AddString(_T("3 Minutes 15 Seconds"));
      m_WdtTimerSpan.AddString(_T("4 Minutes 15 Seconds"));
   }

   m_WdtTimerSpan.SetCurSel(m_nTimerSpanIndex);
   
	return TRUE;  // return TRUE  unless you set the focus to a control
}

void CWDTConfigDlg::OnEnableDisable() 
{
	// TODO: Add your control notification handler code here
   int   nIndex;
   
   nIndex = m_WdtTimerSpan.GetCurSel();
   
   if ( m_nEnableStatus==WATCHDOG_DISABLED )
   {
      m_nEnableStatus=WATCHDOG_ENABLED; 
      SendDlgItemMessage(
         IDC_ENABLE_DISABLE,
         WM_SETTEXT,
         0,
         reinterpret_cast<LPARAM>( L"&Disable" ) );
      GetDlgItem(IDC_STROBE)->EnableWindow(TRUE);
	  GetDlgItem(IDC_REBOOT)->EnableWindow(TRUE);
      // Set Watchdog timer span index
      DeviceIoControl(
         g_hWDT, 
         IOCTL_WDT_SET_TIMEOUT, 
         &nIndex, 
         0, 
         NULL, 
         0, 
         NULL, 
         NULL);
      // enable watchdog timer
      DeviceIoControl(
         g_hWDT, 
         IOCTL_WDT_ENABLE, 
         NULL , 
         0, 
         NULL, 
         0, 
         NULL, 
         NULL);
   }
   else
   {
      m_nEnableStatus=WATCHDOG_DISABLED; 
      SendDlgItemMessage(
         IDC_ENABLE_DISABLE,
         WM_SETTEXT,
         0,
         reinterpret_cast<LPARAM>( L"&Enable" ) );
      GetDlgItem(IDC_STROBE)->EnableWindow(FALSE);
	  GetDlgItem(IDC_REBOOT)->EnableWindow(FALSE);
      // Disable Watchdog timer
      DeviceIoControl(
         g_hWDT, 
         IOCTL_WDT_DISABLE, 
         NULL , 
         0, 
         NULL, 
         0, 
         NULL, 
         NULL);
   }
   
}

void CWDTConfigDlg::OnStrobe() 
{
	// TODO: Add your control notification handler code here
   DeviceIoControl(
      g_hWDT, 
      IOCTL_WDT_STROBE, 
      NULL , 
      0, 
      NULL, 
      0, 
      NULL, 
      NULL);
}

void CWDTConfigDlg::OnReboot() 
{
	// TODO: Add your control notification handler code here
   DeviceIoControl(
      g_hWDT, 
      IOCTL_WDT_REBOOT, 
      NULL , 
      0, 
      NULL, 
      0, 
      NULL, 
      NULL);
}
