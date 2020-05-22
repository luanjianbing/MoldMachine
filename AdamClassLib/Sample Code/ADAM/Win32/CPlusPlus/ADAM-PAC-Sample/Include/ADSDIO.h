// The following ifdef block is the standard way of creating macros which make exporting 
// from a DLL simpler. All files within this DLL are compiled with the ADV_API
// symbol defined on the command line. this symbol should not be defined on any project
// that uses this DLL. This way any other project whose source files include this file see 
// ADV_API functions as being imported from a DLL, wheras this DLL sees symbols
// defined with this macro as being exported.
#ifdef __cplusplus
extern "C"
{
#endif

#define ADS_API //__declspec(dllexport)

/**************************************************************************
    Define Status Code
***************************************************************************/
#define SUCCESS                  0
#define DevErrorCode             300

#define MemoryAllocateFailed	(DevErrorCode + 0) 
#define MapAddressFailed		  (DevErrorCode + 1)
#define InvalidDeviceHandle		(DevErrorCode + 2)
#define InvalidModule			    (DevErrorCode + 3)
#define InvalidSlot				    (DevErrorCode + 4)
#define InvalidChannel			  (DevErrorCode + 5)
#define InvalidFunction			  (DevErrorCode + 6)
#define InitInterruptFailed		(DevErrorCode + 7)  
#define FreqMeasurementFailed (DevErrorCode + 8)               
#define InvalidParam	        (DevErrorCode + 9)
#define FIFO_NotReady_Err		  (DevErrorCode + 10)
#define FIFO_Full_Err			    (DevErrorCode + 11)
#define FIFO_DataFail_Err		  (DevErrorCode + 12)
#define Acq_Stop_Err			    (DevErrorCode + 13)

/* ------------------------------------------------------------------- */
/*  Module ID number Definitions                                       */
/* ------------------------------------------------------------------- */
#define	ADAM5017_ID	  	0x04
#define	ADAM5018_ID	  	0x05
#define ADAM5013_ID     0x09  ///!!!+++ Yaojen@ May 2014
#define	ADAM5013A_ID	  0x08
#define	ADAM5013B_ID  	0x09
#define	ADAM5017H_ID	  0x0C
#define	ADAM5017UH_ID  	0x17
#define	ADAM5018H_ID	  0x0D
#define	ADAM5018P_ID	  0x38
#define	ADAM5052_ID	  	0x0F
#define	ADAM5050_ID	  	0x10
#define	ADAM5051_ID	  	0x11
#define	ADAM5056_ID	  	0x12
#define	ADAM5068_ID	  	0x13
#define	ADAM5060_ID	  	0x14
#define	ADAM5024_ID	  	0x18
#define	ADAM5080_ID	  	0x1E
#define ADAM5055_ID	  	0x15
#define ADAM5069_ID	  	0x69
#define ADAM5081_ID	  	0x01
#define ADAM5053_ID	  	0x53
#define ADAM5091_ID	  	0x91
#define ADAM5057_ID	  	0x57	// tony liu 2008/03/25
#define ADAM5081T_ID  	0x03	// tony liu 2008/03/25
#define ADAM5017S_ID  	0x37	// tony liu 2008/04/02
#define ADAM5030_ID	  	0x30	// tony liu 2008/11/20
#define ADAM5095_ID		  0x95	// tony liu 2008/11/20
#define ADAM5240_ID     0x48  // chaowen liu 2011/11/22
#define ADAM5202_ID     0x02  // chaowen liu 2011/11/22
#define InvalidModuleID	0x0
	


/// Adam-5024 Output range
#define	mA_0To20		              0x30
#define	mA_4To20		              0x31
#define	V_0To10			              0x32

/// Adam-5017/5018/5013
#define	AI_IntegrationTime_50Hz		0x80
#define	AI_IntegrationTime_60Hz		0x00


LONG ADS_API ADAMDrvOpen(LONG* handle);
LONG ADS_API ADAMDrvClose(LONG* handle);        

LONG ADS_API SYS_GetNodeID(LONG hHandle, USHORT *o_usNodeID);   
LONG ADS_API SYS_GetModuleID(LONG hHandle, USHORT i_usSlot, USHORT *o_usModuleID);     
LONG ADS_API SYS_WaitForADAM5550IOUpdate(LONG handle, USHORT i_iSlot, SHORT *o_iflag); 
LONG ADS_API SYS_SetPWRLED(LONG hHandle, BOOL i_bPWRLED);  
LONG ADS_API SYS_GetPWRLED(LONG hHandle, BOOL *o_bPWRLED);  
LONG ADS_API SYS_SetRUNLED(LONG hHandle, BOOL i_bRUNLED);  
LONG ADS_API SYS_GetRUNLED(LONG hHandle, BOOL *o_bRUNLED);  
LONG ADS_API SYS_GetADAM5550InitPin(LONG hHandle, BOOL *i_usInitPin);
LONG ADS_API SYS_GetADAM5550ARMFWVer(LONG hHandle, FLOAT *i_fVer);

//	6/4/2007 by Adam.Lin
LONG ADS_API SYS_GetRetainMemBase(LONG hHandle, DWORD *i_dwRetainRAMBase, DWORD *i_dwRetainRAMLen);
//	tony liu 2007/08/08
LONG ADS_API SYS_GetModuleName(LONG hHandle, USHORT i_iSlot, char *o_szName);   

//Reserve for internal use
LONG ADS_API SYS_ResetARM7(LONG handle);
LONG ADS_API SYS_GetDataFmDPRAM(LONG hHandle, ULONG Idx, VOID *src, SHORT size);
LONG ADS_API SYS_MovDataToDPRAM(LONG hHandle, ULONG Idx, VOID *src, SHORT size);
LONG ADS_API SYS_SetFWUpgradeMark(LONG hHandle);     
LONG ADS_API SYS_ClsFWUpgradeMark(LONG hHandle);   
LONG ADS_API SYS_GetCPLDVer(LONG hHandle, USHORT *i_usCPLDVer);
LONG ADS_API SYS_Adam5550LocalBusOutput(LONG handle, USHORT BaseOff, UCHAR o_ucValue);   
LONG ADS_API SYS_Adam5550LocalBusInput(LONG handle, USHORT BaseOff, UCHAR *i_ucValue);   

LONG ADS_API DI_GetValue(LONG handle, USHORT i_usSlot, USHORT i_usChannel, BOOL* o_bValue);
LONG ADS_API DI_GetValues(LONG handle, USHORT i_usSlot, DWORD* o_dwValue);       
LONG ADS_API DIO_GetUniversalStatus(LONG handle, USHORT i_usSlot, WORD* o_dwStatus);
LONG ADS_API DO_SetValue(LONG handle, USHORT i_usSlot, USHORT i_usChannel, BOOL i_bValue);
LONG ADS_API DO_SetValues(LONG handle, USHORT i_usSlot, DWORD o_dwValue);  

LONG ADS_API DIO_GetIOConfig(LONG handle, USHORT i_usSlot, USHORT i_iChannel, BYTE* o_byConfig);
LONG ADS_API DIO_SetIOConfig(LONG handle, USHORT i_usSlot, USHORT i_iChannel, BYTE i_byConfig);
LONG ADS_API DI_GetChannelTotal(LONG handle, USHORT i_iSlot, USHORT* o_iChannels);
LONG ADS_API DO_GetChannelTotal(LONG handle, USHORT i_iSlot, USHORT* o_iChannels);

LONG ADS_API DO_GetPulseOutputWidthAndDelayTime(LONG handle, USHORT i_usSlot, USHORT i_iChannel,
												LONG *o_lPulseHighWidth,
												LONG *o_lPulseLowWidth,
												LONG *o_lHighToLowDelay,
												LONG *o_lLowToHighDelay);

LONG ADS_API DO_SetPulseOutputWidthAndDelayTime(LONG handle, USHORT i_usSlot, USHORT i_iChannel,
												LONG i_lPulseHighWidth,
												LONG i_lPulseLowWidth,
												LONG i_lHighToLowDelay,
												LONG i_lLowToHighDelay);

LONG ADS_API DO_SetPulseOutputAbsoluteCounts(LONG handle, USHORT i_usSlot, USHORT i_iChannel, LONG i_lCounts);
LONG ADS_API DO_GetPulseOutputAbsoluteCounts(LONG handle, USHORT i_usSlot, USHORT i_iChannel, LONG* o_lCounts);

LONG ADS_API DO_SetPulseOutputIncreaseCounts(LONG handle, USHORT i_usSlot, USHORT i_iChannel, LONG i_lCounts);
LONG ADS_API DO_GetPulseOutputIncreaseCounts(LONG handle, USHORT i_usSlot, USHORT i_iChannel, LONG* o_lCounts);

LONG ADS_API DO_SetPulseOutputAbsoluteCounts(LONG handle, USHORT i_usSlot, USHORT i_iChannel, LONG i_lCounts);
LONG ADS_API DO_GetPulseOutputAbsoluteCounts(LONG handle, USHORT i_usSlot, USHORT i_iChannel, LONG* o_lCounts);

LONG ADS_API DO_SetLowToHighDelay(LONG handle, USHORT i_usSlot, USHORT i_iChannel, BOOL i_bValue);
LONG ADS_API DO_SetHighToLowDelay(LONG handle, USHORT i_usSlot, USHORT i_iChannel, BOOL i_bValue);
			 
LONG ADS_API DO_SetPulseOutputMode(LONG handle, USHORT i_usSlot, USHORT i_iChannel, BOOL i_bContinue);
LONG ADS_API DO_SetPulseOutputStart(LONG handle, USHORT i_usSlot, USHORT i_iChannel, BOOL i_bStart);

LONG ADS_API DI_GetDigitalFilterMiniSignalWidth(LONG handle, USHORT i_usSlot, USHORT i_iChannel, LONG *o_lHigh, LONG *o_lLow);
LONG ADS_API DI_SetDigitalFilterMiniSignalWidth(LONG handle, USHORT i_usSlot, USHORT i_iChannel, LONG i_lHigh, LONG i_lLow);
LONG ADS_API DI_SetDigitalFilterStart(LONG handle, USHORT i_usSlot, USHORT i_iChannel, BOOL i_bStart);
LONG ADS_API DI_GetDigitalFilterStart(LONG handle, USHORT i_usSlot, USHORT i_iChannel, BOOL *o_bStart);

LONG ADS_API DI_GetInvertMask(LONG handle, USHORT i_usSlot, USHORT i_iChannel, BOOL *o_bInvertMask);
LONG ADS_API DI_SetInvertMask(LONG handle, USHORT i_usSlot, USHORT i_iChannel, BOOL i_bInvertMask);
LONG ADS_API DI_GetCounterStart(LONG handle, USHORT i_usSlot, USHORT i_iChannel, BOOL *o_bStart);
LONG ADS_API DI_SetCounterStart(LONG handle, USHORT i_usSlot, USHORT i_iChannel, BOOL i_bStart);
LONG ADS_API DI_GetCounterOrFrequencyValue(LONG handle, USHORT i_usSlot, USHORT i_iChannel, LONG *o_lValue);

LONG ADS_API DI_Clear_Counter_Value(LONG hHandle, USHORT i_usSlot, USHORT i_iChannel);
LONG ADS_API DI_ReadCounterOverFlowFlag(LONG handle, USHORT i_usSlot, USHORT i_iChannel, BOOL *o_bOverFlow);
LONG ADS_API DI_ClearCounterOverFlowFlag(LONG handle, USHORT i_usSlot, USHORT i_iChannel, BOOL i_bOverFlow);

//ADAM-5550 Analog input APIs By Adam.Lin
LONG ADS_API AI_GetChannelTotal(LONG handle, USHORT i_iSlot, USHORT* o_iChannels);
LONG ADS_API AI_GetChannelEnabled(LONG handle, USHORT i_iSlot, BOOL* i_bEnabled);
LONG ADS_API AI_SetChannelEnabled(LONG handle, USHORT i_iSlot, BOOL* i_bEnabled);
LONG ADS_API AI_GetRangeIntegrationTime(LONG handle, USHORT i_iSlot, USHORT* o_iIntegrationTime);
LONG ADS_API AI_SetRangeIntegrationTime(LONG handle, USHORT i_iSlot, USHORT i_iIntegrationTime);
LONG ADS_API AI_GetInputRange(LONG handle, USHORT i_iSlot, USHORT i_iChannel, BYTE* o_byRangeCode);
LONG ADS_API AI_SetInputRange(LONG handle, USHORT i_iSlot, USHORT i_iChannel, BYTE i_byRangeCode);

LONG ADS_API AI_GetValue(LONG handle, USHORT i_usSlot, USHORT i_usChannel, FLOAT* o_sValue); 
LONG ADS_API AI_GetValues(LONG hHandle, USHORT i_usSlot, FLOAT* o_fValue); 

LONG ADS_API AI_SetChannelSpanCalibration(LONG handle, USHORT i_iSlot);
LONG ADS_API AI_SetChannelZeroCalibration(LONG handle, USHORT i_iSlot);
 
LONG ADS_API AI_GetCJCValue(LONG handle, USHORT i_iSlot, FLOAT* o_fCJCValue); 
LONG ADS_API AI_SetCJCOffset(LONG handle, USHORT i_iSlot, FLOAT i_fCJCOffset);

// 3/13/2006
LONG ADS_API AO_GetChannelTotal(LONG handle, USHORT i_iSlot, USHORT* o_iChannels);
LONG ADS_API AO_SetOutputRange(LONG handle, USHORT i_iSlot, USHORT i_iChannel, BYTE i_byRange);
LONG ADS_API AO_GetOutputRange(LONG handle, USHORT i_iSlot, USHORT i_iChannel, BYTE *o_byRange);

LONG ADS_API AO_GetValue(LONG handle, USHORT i_usSlot, USHORT i_usChannel, FLOAT* o_sValue); 
LONG ADS_API AO_GetValues(LONG hHandle, USHORT i_usSlot, FLOAT* o_fValue); 
LONG ADS_API AO_SetValue(LONG handle, USHORT i_usSlot, USHORT i_usChannel, FLOAT o_sValue); 
LONG ADS_API AO_SetValues(LONG hHandle, USHORT i_usSlot, FLOAT* o_fValue); 

// 2010/04/15, Tony Liu start
LONG ADS_API ODM17UH_SetStart(LONG hHandle, USHORT i_iSlot);
LONG ADS_API ODM17UH_SetStop(LONG hHandle, USHORT i_iSlot);
LONG ADS_API ODM17UH_SetConfig(LONG hHandle, USHORT i_iSlot, ULONG i_iDataFormat, USHORT i_iAcqNum, ULONG i_iFreq, LONG i_iTrigMode, ULONG i_iFilterMode);
LONG ADS_API ODM17UH_GetConfig(LONG hHandle, USHORT i_iSlot, ULONG *o_iDataFormat, USHORT *o_iAcqNum, ULONG *o_iFreq, LONG *o_iTrigMode, ULONG *o_iFilterMode);
LONG ADS_API ODM17UH_GetValues(LONG hHandle, USHORT i_iSlot, UCHAR *pValue);
LONG ADS_API ODM17UH_GetVersion(LONG hHandle, USHORT i_iSlot, USHORT *o_iVerHigh, USHORT *o_iVerLow);
// 2010/04/15, Tony Liu end

// 2007/11/12, Tony Liu start
LONG ADS_API CNT_GetValue(LONG hHandle, USHORT i_iSlot, USHORT i_iCh, ULONG *o_lValue);
LONG ADS_API CNT_ClearValue(LONG hHandle, USHORT i_iSlot, USHORT i_iCh);
LONG ADS_API CNT_GetRange(LONG hHandle, USHORT i_iSlot, USHORT i_iCh, BYTE *o_byRange);
LONG ADS_API CNT_SetRange(LONG hHandle, USHORT i_iSlot, USHORT i_iCh, BYTE i_byRange);
LONG ADS_API CNT_GetFilter(LONG hHandle, USHORT i_iSlot, ULONG *o_lFilter);
LONG ADS_API CNT_SetFilter(LONG hHandle, USHORT i_iSlot, ULONG i_lFilter);
LONG ADS_API CNT_GetStartup(LONG hHandle, USHORT i_iSlot, USHORT i_iCh, ULONG *o_lStartup);
LONG ADS_API CNT_SetStartup(LONG hHandle, USHORT i_iSlot, USHORT i_iCh, ULONG i_lStartup);
LONG ADS_API CNT_GetState(LONG hHandle, USHORT i_iSlot, USHORT i_iCh, BOOL *o_bCounting);
LONG ADS_API CNT_SetState(LONG hHandle, USHORT i_iSlot, USHORT i_iCh, BOOL i_bCounting);
LONG ADS_API CNT_GetOverflow(LONG hHandle, USHORT i_iSlot, USHORT i_iCh, BOOL *o_bOverflow);
LONG ADS_API CNT_ClearOverflow(LONG hHandle, USHORT i_iSlot, USHORT i_iCh);
LONG ADS_API CNT_GetAlarmFlag(LONG hHandle, USHORT i_iSlot, USHORT i_iCh, BOOL *o_bAlarmFlag);
LONG ADS_API CNT_ClearAlarmFlag(LONG hHandle, USHORT i_iSlot, USHORT i_iCh);
LONG ADS_API CNT_GetAlarmType(LONG hHandle, USHORT i_iSlot, USHORT i_iCh, BYTE *o_byAlarmType);
LONG ADS_API CNT_SetAlarmType(LONG hHandle, USHORT i_iSlot, USHORT i_iCh, BYTE i_byAlarmType);
LONG ADS_API CNT_GetAlarmEnable(LONG hHandle, USHORT i_iSlot, USHORT i_iCh, BOOL *o_bAlarmEnable);
LONG ADS_API CNT_SetAlarmEnable(LONG hHandle, USHORT i_iSlot, USHORT i_iCh, BOOL i_bAlarmEnable);
LONG ADS_API CNT_GetAlarmMap(LONG hHandle, USHORT i_iSlot, USHORT i_iCh, BYTE *o_byAlarmMap);
LONG ADS_API CNT_SetAlarmMap(LONG hHandle, USHORT i_iSlot, USHORT i_iCh, BYTE i_byAlarmMap);
LONG ADS_API CNT_GetAlarmLimit(LONG hHandle, USHORT i_iSlot, USHORT i_iCh, ULONG *o_lAlarmLimit);
LONG ADS_API CNT_SetAlarmLimit(LONG hHandle, USHORT i_iSlot, USHORT i_iCh, ULONG i_lAlarmLimit);
LONG ADS_API CNT_GetDoValue(LONG hHandle, USHORT i_iSlot, USHORT i_iCh, BOOL *o_bDO);
LONG ADS_API CNT_SetDoValue(LONG hHandle, USHORT i_iSlot, USHORT i_iCh, BOOL i_bDO);
LONG ADS_API CNT_GetDoValues(LONG hHandle, USHORT i_iSlot, BYTE *o_byDOs);
LONG ADS_API CNT_SetDoValues(LONG hHandle, USHORT i_iSlot, BYTE i_byDOs);
LONG ADS_API DEBUG_GetRegValue(LONG hHandle, USHORT i_iSlot, USHORT i_iCh, BYTE *o_byValue);
LONG ADS_API DEBUG_SetRegValue(LONG hHandle, USHORT i_iSlot, USHORT i_iCh, BYTE i_byValue);
// 2007/11/12, Tony Liu end
// 2008/11/26, Tony Liu begin
LONG ADS_API CNT_GetFreqAcqTime(LONG hHandle, USHORT i_iSlot, ULONG *o_lFreqActTime);
LONG ADS_API CNT_SetFreqAcqTime(LONG hHandle, USHORT i_iSlot, ULONG i_lFreqActTime);
// 2008/11/26, Tony Liu end

// 2008/01/08, Tony Liu begin
LONG ADS_API SYS_GetKwMbData(LONG hHandle, DWORD i_dwStartAddr, DWORD i_dwLength, BYTE *o_byValues);
LONG ADS_API SYS_SetKwMbData(LONG hHandle, DWORD i_dwStartAddr, DWORD i_dwLength, BYTE *i_byValues);
// 2008/01/08, Tony Liu end



///!!!+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
#if 0  // todo

// 2008/03/27, Tony Liu start
LONG ADS_API ODM81T_GetFrequency(LONG hHandle, USHORT i_iSlot, ULONG *o_iFreq);
LONG ADS_API ODM81T_GetStatus0(LONG hHandle, USHORT i_iSlot, BYTE *o_byStatus);
LONG ADS_API ODM81T_GetStatus1(LONG hHandle, USHORT i_iSlot, BYTE *o_byStatus);
LONG ADS_API ODM81T_GetPulseHighWidth(LONG hHandle, USHORT i_iSlot, USHORT i_iCh, USHORT *o_iWidth);
LONG ADS_API ODM81T_SetPulseHighWidth(LONG hHandle, USHORT i_iSlot, USHORT i_iCh, USHORT i_iWidth);
LONG ADS_API ODM81T_GetPulseLowWidth(LONG hHandle, USHORT i_iSlot, USHORT i_iCh, USHORT *o_iWidth);
LONG ADS_API ODM81T_SetPulseLowWidth(LONG hHandle, USHORT i_iSlot, USHORT i_iCh, USHORT i_iWidth);
LONG ADS_API ODM81T_GetFilter(LONG hHandle, USHORT i_iSlot, USHORT *o_iFilter);
LONG ADS_API ODM81T_SetFilter(LONG hHandle, USHORT i_iSlot, USHORT i_iFilter);
LONG ADS_API ODM81T_SetPulseEnable(LONG hHandle, USHORT i_iSlot, USHORT i_iCh, BOOL i_bEnable);
LONG ADS_API ODM81T_SetWDTEnable(LONG hHandle, USHORT i_iSlot, BOOL i_bEnable);
LONG ADS_API ODM81T_SetWDTUpdate(LONG hHandle, USHORT i_iSlot);
LONG ADS_API ODM81T_GetWDTValue(LONG hHandle, USHORT i_iSlot, USHORT *o_iValue);
LONG ADS_API ODM81T_SetWDTValue(LONG hHandle, USHORT i_iSlot, USHORT i_iValue);
LONG ADS_API ODM81T_GetTriggerMode(LONG hHandle, USHORT i_iSlot, UCHAR *o_iMode);
LONG ADS_API ODM81T_SetTriggerMode(LONG hHandle, USHORT i_iSlot, UCHAR i_iMode);
LONG ADS_API ODM81T_GetOutputErrorCount(LONG hHandle, USHORT i_iSlot, USHORT *o_iValue);
LONG ADS_API ODM81T_GetOutputError(LONG hHandle, USHORT i_iSlot, BOOL *o_bError);
LONG ADS_API ODM81T_ClearOutputError(LONG hHandle, USHORT i_iSlot);
LONG ADS_API ODM81T_GetHardwareStop(LONG hHandle, USHORT i_iSlot, BOOL *o_bStop);
LONG ADS_API ODM81T_ClearHardwareStop(LONG hHandle, USHORT i_iSlot);
// 2008/03/27, Tony Liu end
LONG ADS_API ODM81T_SetCtrl0Flag(LONG hHandle, USHORT i_iSlot, USHORT i_iFlagPos, UCHAR i_iFlagEnable);
LONG ADS_API ODM81T_SetCtrl1Flag(LONG hHandle, USHORT i_iSlot, USHORT i_iFlagPos, UCHAR i_iFlagEnable);
LONG ADS_API ODM81T_SetCtrl0(LONG hHandle, USHORT i_iSlot, UCHAR i_iValue);
LONG ADS_API ODM81T_SetCtrl1(LONG hHandle, USHORT i_iSlot, UCHAR i_iValue);
LONG ADS_API ODM81T_GetFun(LONG hHandle, USHORT i_iSlot, UCHAR i_iFun, UCHAR i_iTotal,
							 UCHAR *o_iVal0, UCHAR *o_iVal1, UCHAR *o_iVal2, UCHAR *o_iVal3);
LONG ADS_API ODM81T_SetFun(LONG hHandle, USHORT i_iSlot, UCHAR i_iFun, UCHAR i_iTotal,
							 UCHAR i_iVal0, UCHAR i_iVal1, UCHAR i_iVal2, UCHAR i_iVal3);

// 2008/04/07, Tony Liu start
LONG ADS_API ODM17S_SetRange(LONG hHandle, USHORT i_iSlot, UCHAR i_byRange);
LONG ADS_API ODM17S_GetRange(LONG hHandle, USHORT i_iSlot, UCHAR *o_byRange);
LONG ADS_API ODM17S_SetMode(LONG hHandle, USHORT i_iSlot, UCHAR i_byMode);
LONG ADS_API ODM17S_GetMode(LONG hHandle, USHORT i_iSlot, UCHAR *o_byMode);
LONG ADS_API ODM17S_SetTrigTotal(LONG hHandle, USHORT i_iSlot, USHORT i_iTrigTotal);
LONG ADS_API ODM17S_GetTrigTotal(LONG hHandle, USHORT i_iSlot, USHORT *o_iTrigTotal);
LONG ADS_API ODM17S_SetSampleRate(LONG hHandle, USHORT i_iSlot, USHORT i_iRate);
LONG ADS_API ODM17S_GetSampleRate(LONG hHandle, USHORT i_iSlot, USHORT *o_iRate);
LONG ADS_API ODM17S_SetEnableChannelTotal(LONG hHandle, USHORT i_iSlot, USHORT i_iTotal);
LONG ADS_API ODM17S_GetEnableChannelTotal(LONG hHandle, USHORT i_iSlot, USHORT *o_iTotal);
LONG ADS_API ODM17S_SetStart(LONG hHandle, USHORT i_iSlot);
LONG ADS_API ODM17S_SetStop(LONG hHandle, USHORT i_iSlot);
LONG ADS_API ODM17S_GetFifoData(LONG hHandle, USHORT i_iSlot, USHORT *o_iValues);
// 2008/04/07, Tony Liu end

#endif   ///!!!----------------------------------------------------------------------------------------------------------------

#ifdef __cplusplus
}
#endif


