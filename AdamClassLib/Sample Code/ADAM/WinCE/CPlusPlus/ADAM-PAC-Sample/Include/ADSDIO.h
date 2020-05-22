// #############################################################################
// *****************************************************************************
//                  Copyright (c) 2013, Advantech Automation Corp.
//      THIS IS AN UNPUBLISHED WORK CONTAINING CONFIDENTIAL AND PROPRIETARY
//               INFORMATION WHICH IS THE PROPERTY OF ADVANTECH AUTOMATION CORP.
//
//    ANY DISCLOSURE, USE, OR REPRODUCTION, WITHOUT WRITTEN AUTHORIZATION FROM
//               ADVANTECH AUTOMATION CORP., IS STRICTLY PROHIBITED.
// *****************************************************************************
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
#define MapAddressFailed		(DevErrorCode + 1)
#define InvalidDeviceHandle		(DevErrorCode + 2)
#define InvalidModule			(DevErrorCode + 3)
#define InvalidSlot				(DevErrorCode + 4)
#define InvalidChannel			(DevErrorCode + 5)
#define InvalidFunction			(DevErrorCode + 6)
#define InitInterruptFailed		(DevErrorCode + 7)  
#define FreqMeasurementFailed 	(DevErrorCode + 8)               
#define InvalidParam	        (DevErrorCode + 9)
#define FIFO_NotReady_Err		(DevErrorCode + 10)
#define FIFO_Full_Err			(DevErrorCode + 11)
#define FIFO_DataFail_Err		(DevErrorCode + 12)
#define Acq_Stop_Err			(DevErrorCode + 13)

/* ------------------------------------------------------------------- */
/*  Module ID number Definitions                                       */
/* ------------------------------------------------------------------- */
#define	ADAM5017_ID		0x04
#define	ADAM5018_ID		0x05
#define	ADAM5013A_ID	0x08
#define	ADAM5013B_ID	0x09
#define	ADAM5017H_ID	0x0C
#define	ADAM5017UH_ID	0x17
#define	ADAM5018H_ID	0x0D
#define	ADAM5018P_ID	0x38
#define	ADAM5052_ID		0x0F
#define	ADAM5050_ID		0x10
#define	ADAM5051_ID		0x11
#define	ADAM5056_ID		0x12
#define	ADAM5068_ID		0x13
#define	ADAM5060_ID		0x14
#define	ADAM5024_ID		0x18
#define	ADAM5080_ID		0x1E
#define ADAM5055_ID		0x15
#define ADAM5069_ID		0x69
#define ADAM5081_ID		0x01
#define ADAM5053_ID		0x53
#define ADAM5091_ID		0x91
#define ADAM5057_ID		0x57	// tony liu 2008/03/25
#define ADAM5081T_ID	0x03	// tony liu 2008/03/25
#define ADAM5017S_ID	0x37	// tony liu 2008/04/02
#define ADAM5030_ID		0x30	// tony liu 2008/11/20
#define ADAM5095_ID		0x95	// tony liu 2008/11/20
#define ADAM5240_ID             0x48    // chaowen liu 2011/11/22
#define ADAM5202_ID             0x02    // chaowen liu 2011/11/22


#define InvalidModuleID	0x0

/// Adam-5024 Output range
#define	mA_0To20		0x30
#define	mA_4To20		0x31
#define	V_0To10			0x32

/// Adam-5017/5018/5013
#define	AI_IntegrationTime_50Hz		0x80
#define	AI_IntegrationTime_60Hz		0x00


// Method: ADAMDrvOpen
// action: Initialize the driver
// pre   : i_hHandle = driver handler
// post  : If driver initialization succeeded, function returns SUCCESS,
//         and the i_hHandle will be used for rest of the functions.
//         Otherwise, function returns error code.
LONG ADS_API ADAMDrvOpen(LONG* i_hHandle);

// Method: ADAMDrvClose
// action: Terminate the driver
// pre   : i_hHandle = driver handler
// post  : If driver termination succeeded, function returns SUCCESS,
//         and the i_hHandle has value which will be used for rest of the functions.
//         Otherwise, function returns error code.
LONG ADS_API ADAMDrvClose(LONG* i_hHandle);        

// Method: SYS_GetNodeID
// action: Get the Node ID of the module (the value of the DIP switch 
//         on the right hand side of the module)
// pre   : i_hHandle = driver handler
//         o_usNodeID = the variable to hold the Node ID.
// post  : If getting the Node ID succeeded, function returns SUCCESS,
//         and the o_usNodeID has the value.
//         Otherwise, function returns error code.
LONG ADS_API SYS_GetNodeID(LONG i_hHandle, USHORT *o_usNodeID);   

// Method: SYS_GetModuleID
// action: Get the module ID of the indicated slot.
// pre   : i_hHandle = driver handler
//         i_iSlot = the slot ID (0~7)
//         o_iModuleID = the variable to hold the module ID.
// post  : If getting the module ID succeeded, function returns SUCCESS,
//         and the o_usModuleID has the value.
//         Otherwise, function returns error code.
LONG ADS_API SYS_GetModuleID(LONG i_hHandle, USHORT i_iSlot, USHORT *o_iModuleID);     

// Method: SYS_SetPWRLED
// action: Set the PWR LED to ON/OFF.
// pre   : i_hHandle = driver handler
//         i_bPWRLED = set to TRUE to turn on the LED; or FALSE to turn off.
// post  : If setting the LED succeeded, function returns SUCCESS.
//         Otherwise, function returns error code.
LONG ADS_API SYS_SetPWRLED(LONG i_hHandle, BOOL i_bPWRLED); 

// Method: SYS_GetPWRLED
// action: Get the PWR LED status.
// pre   : i_hHandle = driver handler
//         o_bPWRLED = the variable to hold the status.
// post  : If getting the LED status succeeded, function returns SUCCESS,
//         and the o_bPWRLED has the status.
//         Otherwise, function returns error code.
LONG ADS_API SYS_GetPWRLED(LONG i_hHandle, BOOL *o_bPWRLED);  

// Method: SYS_SetRUNLED
// action: Set the RUN LED to ON/OFF.
// pre   : i_hHandle = driver handler
//         i_bRUNLED = set to TRUE to turn on the LED; or FALSE to turn off.
// post  : If setting the LED succeeded, function returns SUCCESS.
//         Otherwise, function returns error code.
LONG ADS_API SYS_SetRUNLED(LONG i_hHandle, BOOL i_bRUNLED);  

// Method: SYS_GetRUNLED
// action: Get the RUN LED status.
// pre   : i_hHandle = driver handler
//         o_bRUNLED = the variable to hold the status.
// post  : If getting the LED status succeeded, function returns SUCCESS,
//         and the o_bRUNLED has the status.
//         Otherwise, function returns error code.
LONG ADS_API SYS_GetRUNLED(LONG i_hHandle, BOOL *o_bRUNLED);  

// Method: SYS_GetADAM5550InitPin
// action: Get the INIT status whether the it is connected to the ground.
// pre   : i_hHandle = driver handler
//         o_bInitPin = the variable to hold the status.
// post  : If getting the INIT status succeeded, function returns SUCCESS,
//         and the o_usInitPin has the status.
//         Otherwise, function returns error code.
LONG ADS_API SYS_GetADAM5550InitPin(LONG i_hHandle, BOOL *o_bInitPin);

// Method: SYS_GetADAM5550ARMFWVer
// action: Get the ARM firmware version.
// pre   : i_hHandle = driver handler
//         o_fVer = the variable to hold the version.
// post  : If getting the version succeeded, function returns SUCCESS,
//         and the o_fVer has the value.
//         Otherwise, function returns error code.
LONG ADS_API SYS_GetADAM5550ARMFWVer(LONG i_hHandle, FLOAT *o_fVer);

//	6/4/2007 by Adam.Lin
// Method: SYS_GetRetainMemBase
// action: Get the retain memory information.
// pre   : i_hHandle = driver handler
//         o_dwRetainRAMBase = the variable to hold the memory base address.
//         o_dwRetainRAMLen = the variable to hold the memory length.
// post  : If getting the information succeeded, function returns SUCCESS.
//         The o_dwRetainRAMBase has the base address of the retain memory and
//         the o_dwRetainRAMLen has the length of the memory.
//         Otherwise, function returns error code.
LONG ADS_API SYS_GetRetainMemBase(LONG i_hHandle, DWORD *o_dwRetainRAMBase, DWORD *o_dwRetainRAMLen);

// Method: SYS_GetModuleName
// action: Get the module name for those module whose module ID is ADAM5018P_ID by calling SYS_GetModuleID.
// pre   : i_hHandle = driver handler
//         i_iSlot = the slot ID (0~7)
//         o_szName = the variable to hold the name.
// post  : If getting the name succeeded, function returns SUCCESS,
//         and the o_szName has the name of the module, for example "17" for ADMA-5017P.
//         Otherwise, function returns error code.
LONG ADS_API SYS_GetModuleName(LONG i_hHandle, USHORT i_iSlot, char *o_szName);   

// Method: DI_GetValues
// action: Get the DI/DO value of the indicated slot and channel.
// pre   : i_hHandle = driver handler
//         i_iSlot = the slot ID (0~7).
//         i_usChannel = the channel ID (0~).
//         o_bValue = the variable to hold the DIO value.
// post  : If getting value succeeded, function returns SUCCESS,
//         and the o_bValue contains DI/DO value.
//         Otherwise, function returns error code.
LONG ADS_API DI_GetValue(LONG i_hHandle, USHORT i_iSlot, USHORT i_usChannel, BOOL* o_bValue);

// Method: DI_GetValues
// action: Get the all DI/DO values of the indicated slot.
// pre   : i_hHandle = driver handler
//         i_iSlot = the slot ID (0~7).
//         o_dwValue = the variable to hold the DI/DO values
// post  : If getting values succeeded, function returns SUCCESS,
//         and the o_dwValue contains DI/DO values from channel-0 to the last channel.
//         Otherwise, function returns error code.
LONG ADS_API DI_GetValues(LONG i_hHandle, USHORT i_iSlot, DWORD* o_dwValue);
  
// Method: DIO_GetUniversalStatus
// action: Get the DI/DO setting of the indicated slot, this is special for ADAM-5050.
// pre   : i_hHandle = driver handler
//         i_iSlot = the slot ID (0~7).
//         o_wStatus = the variable to hold the DI/DO setting of all channels
// post  : If getting values succeeded, function returns SUCCESS,
//         and the o_dwStatus contains DI/DO setting.
//         For example, the bit-0 = 1 means the channel-0 is DI, otherwise is DO.
//         Otherwise, function returns error code.
LONG ADS_API DIO_GetUniversalStatus(LONG i_hHandle, USHORT i_iSlot, WORD* o_wStatus);

// Method: DI_GetChannelTotal
// action: Get the DI channel total of the indicated slot.
// pre   : i_hHandle = driver handler
//         i_iSlot = the slot ID (0~7).
//         o_iChannels = the variable to hold the DI channel total.
// post  : If getting values succeeded, function returns SUCCESS,
//         and the o_iChannels contains DI channel total.
//         Otherwise, function returns error code.
LONG ADS_API DI_GetChannelTotal(LONG i_hHandle, USHORT i_iSlot, USHORT* o_iChannels);

// Method: DO_GetChannelTotal
// action: Get the DO channel total of the indicated slot.
// pre   : i_hHandle = driver handler
//         i_iSlot = the slot ID (0~7).
//         o_iChannels = the variable to hold the DO channel total.
// post  : If getting values succeeded, function returns SUCCESS,
//         and the o_iChannels contains DO channel total.
//         Otherwise, function returns error code.
LONG ADS_API DO_GetChannelTotal(LONG i_hHandle, USHORT i_iSlot, USHORT* o_iChannels);
                                                                       
// Method: DO_SetValue
// action: Set the DO value of the indicated slot and channel.
// pre   : i_hHandle = driver handler
//         i_iSlot = the slot ID (0~7).
//         i_iChannel = the channel ID (0~).
//         i_bValue = the DO value to be set.
// post  : If setting value succeeded, function returns SUCCESS.
//         Otherwise, function returns error code.
LONG ADS_API DO_SetValue(LONG i_hHandle, USHORT i_iSlot, USHORT i_iChannel, BOOL i_bValue);

// Method: DO_SetValues
// action: Set the DO values of the indicated slot.
// pre   : i_hHandle = driver handler
//         i_iSlot = the slot ID (0~7).
//         i_dwValue = the DO values from channel 0 to the last one. The LSB indicates the channel-0.
// post  : If setting values succeeded, function returns SUCCESS.
//         Otherwise, function returns error code.
LONG ADS_API DO_SetValues(LONG i_hHandle, USHORT i_iSlot, DWORD i_dwValue);  

// Method: AI_GetValue
// action: Get the AI value of the indicated slot and channel.
// pre   : i_hHandle = driver handler
//         i_iSlot = the slot ID (0~7).
//         i_iChannel = the channel ID (0~).
//         o_fValue = the variable to hold the AI value.
// post  : If getting value succeeded, function returns SUCCESS,
//         and the o_sValue contains AI value.
//         Otherwise, function returns error code.
LONG ADS_API AI_GetValue(LONG i_hHandle, USHORT i_iSlot, USHORT i_iChannel, FLOAT* o_fValue);

// Method: AI_GetValues
// action: Get the AI values of the indicated slot.
// pre   : i_hHandle = driver handler
//         i_iSlot = the slot ID (0~7).
//         o_fValue = the variables array to hold the AI values. The size of this array must be the channel total.
// post  : If getting value succeeded, function returns SUCCESS,
//         and the o_fValue contains AI value.
//         Otherwise, function returns error code.
LONG ADS_API AI_GetValues(LONG i_hHandle, USHORT i_iSlot, FLOAT* o_fValue); 

// Method: AI_GetChannelTotal
// action: Get the AI channel total of the indicated slot.
// pre   : i_hHandle = driver handler
//         i_iSlot = the slot ID (0~7).
//         o_iChannels = the variable to hold the AI channel total.
// post  : If getting values succeeded, function returns SUCCESS,
//         and the o_iChannels contains AI channel total.
//         Otherwise, function returns error code.
LONG ADS_API AI_GetChannelTotal(LONG i_hHandle, USHORT i_iSlot, USHORT* o_iChannels);

// Method: AI_GetInputRange
// action: Get the AI input range of the indicated slot and channel.
// pre   : i_hHandle = driver handler
//         i_iSlot = the slot ID (0~7).
//         i_iChannel = the channel ID (0~).
//         o_byRange = the variable to hold the AI input range.
// post  : If getting values succeeded, function returns SUCCESS,
//         and the o_byRangeCode contains AI input range.
//         Otherwise, function returns error code.
LONG ADS_API AI_GetInputRange(LONG i_hHandle, USHORT i_iSlot, USHORT i_iChannel, BYTE* o_byRange);

// Method: AI_SetInputRange
// action: Set the AI input range of the indicated slot and channel.
// pre   : i_hHandle = driver handler
//         i_iSlot = the slot ID (0~7).
//         i_iChannel = the channel ID (0~).
//         i_byRange = the AI input range to set.
// post  : If setting values succeeded, function returns SUCCESS.
//         Otherwise, function returns error code.
LONG ADS_API AI_SetInputRange(LONG i_hHandle, USHORT i_iSlot, USHORT i_iChannel, BYTE i_byRange);

// Method: AI_GetChannelEnabled
// action: Get the AI channels enabled of the indicated slot.
// pre   : i_hHandle = driver handler
//         i_iSlot = the slot ID (0~7).
//         o_bEnabled = the variables array to hold the channels enabled status.
// post  : If getting values succeeded, function returns SUCCESS.
//         Otherwise, function returns error code.
LONG ADS_API AI_GetChannelEnabled(LONG i_hHandle, USHORT i_iSlot, BOOL* o_bEnabled);

// Method: AI_SetChannelEnabled
// action: Set the AI channels enabled of the indicated slot.
// pre   : i_hHandle = driver handler
//         i_iSlot = the slot ID (0~7).
//         i_bEnabled = the enabled values for AI channels.
// post  : If setting values succeeded, function returns SUCCESS.
//         Otherwise, function returns error code.
LONG ADS_API AI_SetChannelEnabled(LONG i_hHandle, USHORT i_iSlot, BOOL* i_bEnabled);

// Method: AO_GetChannelTotal
// action: Get the AO channel total of the indicated slot.
// pre   : i_hHandle = driver handler
//         i_iSlot = the slot ID (0~7).
//         o_iChannels = the variable to hold the AO channel total.
// post  : If getting values succeeded, function returns SUCCESS,
//         and the o_iChannels contains AO channel total.
//         Otherwise, function returns error code.
LONG ADS_API AO_GetChannelTotal(LONG i_hHandle, USHORT i_iSlot, USHORT* o_iChannels);

// Method: AO_SetOutputRange
// action: Set the AO output range of the indicated slot and channel.
// pre   : i_hHandle = driver handler
//         i_iSlot = the slot ID (0~7).
//         i_iChannel = the channel ID (0~).
//         i_byRange = the AO output range to set.
// post  : If setting values succeeded, function returns SUCCESS.
//         Otherwise, function returns error code.
LONG ADS_API AO_SetOutputRange(LONG i_hHandle, USHORT i_iSlot, USHORT i_iChannel, BYTE i_byRange);

// Method: AO_GetOutputRange
// action: Get the AO output range of the indicated slot and channel.
// pre   : i_hHandle = driver handler
//         i_iSlot = the slot ID (0~7).
//         i_iChannel = the channel ID (0~).
//         o_byRange = the variable to hold the AO output range.
// post  : If getting values succeeded, function returns SUCCESS,
//         and the o_byRange contains AO output range.
//         Otherwise, function returns error code.
LONG ADS_API AO_GetOutputRange(LONG i_hHandle, USHORT i_iSlot, USHORT i_iChannel, BYTE *o_byRange);

// Method: AO_GetValue
// action: Get the AO value of the indicated slot and channel.
// pre   : i_hHandle = driver handler
//         i_iSlot = the slot ID (0~7).
//         i_iChannel = the channel ID (0~).
//         o_fValue = the variable to hold the AO value.
// post  : If getting value succeeded, function returns SUCCESS,
//         and the o_sValue contains AO value.
//         Otherwise, function returns error code.
LONG ADS_API AO_GetValue(LONG i_hHandle, USHORT i_iSlot, USHORT i_iChannel, FLOAT* o_fValue); 

// Method: AO_GetValues
// action: Get the AO values of the indicated slot.
// pre   : i_hHandle = driver handler
//         i_iSlot = the slot ID (0~7).
//         o_fValue = the variables array to hold the AO values. The size of this array must be the channel total.
// post  : If getting value succeeded, function returns SUCCESS,
//         and the o_fValue contains AI value.
//         Otherwise, function returns error code.
LONG ADS_API AO_GetValues(LONG i_hHandle, USHORT i_iSlot, FLOAT* o_fValue);

// Method: AO_SetValue
// action: Set the AO value of the indicated slot and channel.
// pre   : i_hHandle = driver handler
//         i_iSlot = the slot ID (0~7).
//         i_iChannel = the channel ID (0~).
//         i_fValue = the AO value to be set.
// post  : If setting value succeeded, function returns SUCCESS.
//         Otherwise, function returns error code.
LONG ADS_API AO_SetValue(LONG i_hHandle, USHORT i_iSlot, USHORT i_iChannel, FLOAT i_fValue); 

// Method: AO_SetValues
// action: Set the DO values of the indicated slot.
// pre   : i_hHandle = driver handler
//         i_iSlot = the slot ID (0~7).
//         i_fValue = the AO values from channel 0 to the last one..
// post  : If setting values succeeded, function returns SUCCESS.
//         Otherwise, function returns error code.
LONG ADS_API AO_SetValues(LONG i_hHandle, USHORT i_iSlot, FLOAT* i_fValue); 

// ===========================================
// Note: the below functions are for ADAM-5081
// ===========================================
// Method: CNT_GetValue
// action: Get the counter value of the indicated slot and channel.
// pre   : i_hHandle = driver handler
//         i_iSlot = the slot ID (0~7).
//         i_iChannel = the channel ID (0~7).
//         o_ulValue = the variable to hold the counter value.
// post  : If getting value succeeded, function returns SUCCESS,
//         and the o_ulValue contains counter value.
//         Otherwise, function returns error code.
LONG ADS_API CNT_GetValue(LONG i_hHandle, USHORT i_iSlot, USHORT i_iChannel, ULONG *o_ulValue);

// Method: CNT_ClearValue
// action: Clear the counter value to startup values of the indicated slot and channel.
// pre   : i_hHandle = driver handler
//         i_iSlot = the slot ID (0~7).
//         i_iChannel = the channel ID (0~7)
// post  : If clearing value succeeded, function returns SUCCESS.
//         Otherwise, function returns error code.
LONG ADS_API CNT_ClearValue(LONG i_hHandle, USHORT i_iSlot, USHORT i_iChannel);

// Method: CNT_GetRange
// action: Get the range of the indicated slot and channel.
// pre   : i_hHandle = driver handler
//         i_iSlot = the slot ID (0~7).
//         i_iChannel = the channel ID (0~7).
//         o_byRange = the variable to hold the range.
//                     the range definition is as below:
//                     0 : Bi-directory
//                     1 : Up/Down
//                     2 : Up
//                     3 : Frequency
//                     4 : A/B-1X
//                     5 : A/B-2X
//                     6 : A/B-4X
// post  : If getting range succeeded, function returns SUCCESS.
//         Otherwise, function returns error code.
LONG ADS_API CNT_GetRange(LONG i_hHandle, USHORT i_iSlot, USHORT i_iChannel, BYTE *o_byRange);

// Method: CNT_SetRange
// action: Set the range of the indicated slot and channel.
// pre   : i_hHandle = driver handler
//         i_iSlot = the slot ID (0~7).
//         i_iChannel = the channel ID (0~7).
//         i_byRange = the range to be set.
//                     the range definition is as below:
//                     0 : Bi-directory
//                     1 : Up/Down
//                     2 : Up
//                     3 : Frequency
//                     4 : A/B-1X
//                     5 : A/B-2X
//                     6 : A/B-4X
// post  : If setting range succeeded, function returns SUCCESS.
//         Otherwise, function returns error code.
LONG ADS_API CNT_SetRange(LONG i_hHandle, USHORT i_iSlot, USHORT i_iChannel, BYTE i_byRange);

// Method: CNT_GetFilter
// action: Get the counter filter width of the indicated slot.
// pre   : i_hHandle = driver handler
//         i_iSlot = the slot ID (0~7).
//         o_ulFilter = the variable to hold the counter digital filter width.
// post  : If getting filter succeeded, function returns SUCCESS,
//         and the o_ulFilter contains the counter filter width.
//         Otherwise, function returns error code.
LONG ADS_API CNT_GetFilter(LONG i_hHandle, USHORT i_iSlot, ULONG *o_ulFilter);

// Method: CNT_SetFilter
// action: Set the counter filter width of the indicated slot.
// pre   : i_hHandle = driver handler
//         i_iSlot = the slot ID (0~7).
//         i_ulFilter = the counter filter width to be set (1~65000 us).
// post  : If setting filter succeeded, function returns SUCCESS.
//         Otherwise, function returns error code.
LONG ADS_API CNT_SetFilter(LONG i_hHandle, USHORT i_iSlot, ULONG i_ulFilter);

// Method: CNT_GetStartup
// action: Get the counter startup value of the indicated slot and channel.
// pre   : i_hHandle = driver handler
//         i_iSlot = the slot ID (0~7).
//         i_iChannel = the channel ID (0~7).
//         o_ulStartup = the variable to hold the counter startup value.
// post  : If getting value succeeded, function returns SUCCESS,
//         and the o_ulStartup contains counter startup value.
//         Otherwise, function returns error code.
LONG ADS_API CNT_GetStartup(LONG i_hHandle, USHORT i_iSlot, USHORT i_iChannel, ULONG *o_ulStartup);

// Method: CNT_SetStartup
// action: Set the counter startup values of the indicated slot.
// pre   : i_hHandle = driver handler
//         i_iSlot = the slot ID (0~7).
//         i_iChannel = the channel ID (0~7).
//         i_ulStartup = the value  to be set.
// post  : If setting value succeeded, function returns SUCCESS.
//         Otherwise, function returns error code.
LONG ADS_API CNT_SetStartup(LONG i_hHandle, USHORT i_iSlot, USHORT i_iChannel, ULONG i_ulStartup);

// Method: CNT_GetState
// action: Get the counting state of the indicated slot and channel.
// pre   : i_hHandle = driver handler
//         i_iSlot = the slot ID (0~7).
//         i_iChannel = the channel ID (0~7).
//         o_bCounting = the variable to hold the counting state.
// post  : If getting value succeeded, function returns SUCCESS,
//         and the o_bCounting contains counting state (TRUE means counter is counting).
//         Otherwise, function returns error code.
LONG ADS_API CNT_GetState(LONG i_hHandle, USHORT i_iSlot, USHORT i_iChannel, BOOL *o_bCounting);

// Method: CNT_SetState
// action: Set the counting state of the indicated slot and channel.
// pre   : i_hHandle = driver handler
//         i_iSlot = the slot ID (0~7).
//         i_iChannel = the channel ID (0~7).
//         i_bCounting = the counting state to set.
// post  : If setting value succeeded, function returns SUCCESS.
//         Otherwise, function returns error code.
LONG ADS_API CNT_SetState(LONG i_hHandle, USHORT i_iSlot, USHORT i_iChannel, BOOL i_bCounting);

// Method: CNT_GetOverflow
// action: Get the overflow state of the indicated slot and channel.
// pre   : i_hHandle = driver handler
//         i_iSlot = the slot ID (0~7).
//         i_iChannel = the channel ID (0~7).
//         o_bOverflow = the variable to hold the overflow state.
// post  : If getting value succeeded, function returns SUCCESS,
//         and the o_bOverflow contains overflow state (TRUE means counter is overflow).
//         Otherwise, function returns error code.
LONG ADS_API CNT_GetOverflow(LONG i_hHandle, USHORT i_iSlot, USHORT i_iChannel, BOOL *o_bOverflow);

// Method: CNT_ClearOverflow
// action: Clear the overflow state of the indicated slot and channel.
// pre   : i_hHandle = driver handler
//         i_iSlot = the slot ID (0~7).
//         i_iChannel = the channel ID (0~7).
// post  : If setting value succeeded, function returns SUCCESS.
//         Otherwise, function returns error code.
LONG ADS_API CNT_ClearOverflow(LONG i_hHandle, USHORT i_iSlot, USHORT i_iChannel);

// Method: CNT_GetAlarmFlag
// action: Get the alarm flag of the indicated slot and alarm channel.
// pre   : i_hHandle = driver handler
//         i_iSlot = the slot ID (0~7).
//         i_iChannel = the alarm channel ID (0~3).
//         o_bAlarmFlag = the variable to hold the alarm flag.
// post  : If getting value succeeded, function returns SUCCESS,
//         and the o_bAlarmFlag contains alarm flag (TRUE means alarm is ON).
//         Otherwise, function returns error code.
LONG ADS_API CNT_GetAlarmFlag(LONG i_hHandle, USHORT i_iSlot, USHORT i_iChannel, BOOL *o_bAlarmFlag);

// Method: CNT_ClearAlarmFlag
// action: Clear the alarm flag of the indicated slot and alarm channel.
// pre   : i_hHandle = driver handler
//         i_iSlot = the slot ID (0~7).
//         i_iChannel = the alarm channel ID (0~3).
// post  : If setting value succeeded, function returns SUCCESS.
//         Otherwise, function returns error code.
LONG ADS_API CNT_ClearAlarmFlag(LONG i_hHandle, USHORT i_iSlot, USHORT i_iChannel);

// Method: CNT_GetAlarmType
// action: Get the alarm type of the indicated slot and alarm channel.
// pre   : i_hHandle = driver handler
//         i_iSlot = the slot ID (0~7).
//         i_iChannel = the alarm channel ID (0~3).
//         o_byAlarmType = the variable to hold the alarm type.
//                         the alarm type definition is as below:
//                         0 : low alarm
//                         1 : high alarm
// post  : If getting value succeeded, function returns SUCCESS,
//         and the o_byAlarmType contains alarm type.
//         Otherwise, function returns error code.
LONG ADS_API CNT_GetAlarmType(LONG i_hHandle, USHORT i_iSlot, USHORT i_iChannel, BYTE *o_byAlarmType);

// Method: CNT_SetAlarmType
// action: Set the alarm type of the indicated slot and alarm channel.
// pre   : i_hHandle = driver handler
//         i_iSlot = the slot ID (0~7).
//         i_iChannel = the alarm channel ID (0~3).
//         i_byAlarmType = the alarm type to set.
//                         the alarm type definition is as below:
//                         0 : low alarm
//                         1 : high alarm
// post  : If setting value succeeded, function returns SUCCESS.
//         Otherwise, function returns error code.
LONG ADS_API CNT_SetAlarmType(LONG i_hHandle, USHORT i_iSlot, USHORT i_iChannel, BYTE i_byAlarmType);

// Method: CNT_GetAlarmEnable
// action: Get the alarm enabled state of the indicated slot and alarm channel.
//         If the alarm channel is not in alarm mode, it is used as normal DO channel.
// pre   : i_hHandle = driver handler
//         i_iSlot = the slot ID (0~7).
//         i_iChannel = the alarm channel ID (0~3).
//         o_bAlarmEnable = the variable to hold the alarm enabled state.
// post  : If getting value succeeded, function returns SUCCESS,
//         and the o_bAlarmEnable contains alarm enabled state.
//         Otherwise, function returns error code.
LONG ADS_API CNT_GetAlarmEnable(LONG i_hHandle, USHORT i_iSlot, USHORT i_iChannel, BOOL *o_bAlarmEnable);

// Method: CNT_SetAlarmEnable
// action: Set the alarm enabled state of the indicated slot and alarm channel.
// pre   : i_hHandle = driver handler
//         i_iSlot = the slot ID (0~7).
//         i_iChannel = the alarm channel ID (0~3).
//         i_bAlarmEnable = the alarm enabled state to set.
// post  : If setting value succeeded, function returns SUCCESS.
//         Otherwise, function returns error code.
LONG ADS_API CNT_SetAlarmEnable(LONG i_hHandle, USHORT i_iSlot, USHORT i_iChannel, BOOL i_bAlarmEnable);

// Method: CNT_GetAlarmMap
// action: Get the mapped counter channel of the indicated slot and alarm channel.
// pre   : i_hHandle = driver handler
//         i_iSlot = the slot ID (0~7).
//         i_iChannel = the alarm channel ID (0~3).
//         o_byAlarmMap = the variable to hold the counter channel that the alarm mapped to.
// post  : If getting value succeeded, function returns SUCCESS,
//         and the o_byAlarmMap contains counter channel.
//         Otherwise, function returns error code.
LONG ADS_API CNT_GetAlarmMap(LONG i_hHandle, USHORT i_iSlot, USHORT i_iChannel, BYTE *o_byAlarmMap);

// Method: CNT_SetAlarmMap
// action: Set the mapped counter channel of the indicated slot and alarm channel.
// pre   : i_hHandle = driver handler
//         i_iSlot = the slot ID (0~7).
//         i_iChannel = the alarm channel ID (0~3).
//         i_byAlarmMap = the counter channel that the alarm mapped to.
// post  : If setting value succeeded, function returns SUCCESS.
//         Otherwise, function returns error code.
LONG ADS_API CNT_SetAlarmMap(LONG i_hHandle, USHORT i_iSlot, USHORT i_iChannel, BYTE i_byAlarmMap);

// Method: CNT_GetAlarmLimit
// action: Get the alarm limit of the indicated slot and alarm channel.
// pre   : i_hHandle = driver handler
//         i_iSlot = the slot ID (0~7).
//         i_iChannel = the alarm channel ID (0~3).
//         o_ulAlarmLimit = the variable to hold the alarm limit.
// post  : If getting value succeeded, function returns SUCCESS,
//         and the o_ulAlarmLimit contains alarm limit.
//         Otherwise, function returns error code.
LONG ADS_API CNT_GetAlarmLimit(LONG i_hHandle, USHORT i_iSlot, USHORT i_iChannel, ULONG *o_ulAlarmLimit);

// Method: CNT_SetAlarmLimit
// action: Set the alarm limit of the indicated slot and alarm channel.
// pre   : i_hHandle = driver handler
//         i_iSlot = the slot ID (0~7).
//         i_iChannel = the alarm channel ID (0~3).
//         i_ulAlarmLimit = the alarm limit to set.
// post  : If setting value succeeded, function returns SUCCESS.
//         Otherwise, function returns error code.
LONG ADS_API CNT_SetAlarmLimit(LONG i_hHandle, USHORT i_iSlot, USHORT i_iChannel, ULONG i_ulAlarmLimit);

// Method: CNT_GetDoValue
// action: Get the DO state of the indicated slot and channel.
// pre   : i_hHandle = driver handler
//         i_iSlot = the slot ID (0~7).
//         i_iChannel = the DO channel ID (0~3).
//         o_bDO = the variable to hold the DO state.
// post  : If getting value succeeded, function returns SUCCESS,
//         and the o_bDO contains DO state.
//         Otherwise, function returns error code.
LONG ADS_API CNT_GetDoValue(LONG i_hHandle, USHORT i_iSlot, USHORT i_iChannel, BOOL *o_bDO);

// Method: CNT_SetDoValue
// action: Set the DO state of the indicated slot and channel.
// pre   : i_hHandle = driver handler
//         i_iSlot = the slot ID (0~7).
//         i_iChannel = the DO channel ID (0~3).
//         i_bDO = the DO state to set.
// post  : If setting value succeeded, function returns SUCCESS.
//         Otherwise, function returns error code.
LONG ADS_API CNT_SetDoValue(LONG i_hHandle, USHORT i_iSlot, USHORT i_iChannel, BOOL i_bDO);

// Method: CNT_GetDoValues
// action: Get the DO states of the indicated slot.
// pre   : i_hHandle = driver handler
//         i_iSlot = the slot ID (0~7).
//         o_byDOs = the variable to hold the DO states .
//                   For example, the bit-0 = 1 means the DO-0 is ON.
// post  : If getting value succeeded, function returns SUCCESS,
//         and the o_byDOs contains DO states.
//         Otherwise, function returns error code.
LONG ADS_API CNT_GetDoValues(LONG i_hHandle, USHORT i_iSlot, BYTE *o_byDOs);

// Method: CNT_SetDoValues
// action: Set the DO states of the indicated slot.
// pre   : i_hHandle = driver handler
//         i_iSlot = the slot ID (0~7).
//         i_byDOs = the DO states to set.
// post  : If setting value succeeded, function returns SUCCESS.
//         Otherwise, function returns error code.
LONG ADS_API CNT_SetDoValues(LONG i_hHandle, USHORT i_iSlot, BYTE i_byDOs);

// Method: CNT_GetFreqAcqTime
// action: Get the frequency acquisition time period of the indicated slot.
// pre   : i_hHandle = driver handler
//         i_iSlot = the slot ID (0~7).
//         o_ulFreqActTime = the variable to hold the frequency acquisition time period.
// post  : If getting value succeeded, function returns SUCCESS,
//         and the o_ulFreqActTime contains frequency acquisition time period.
//         Otherwise, function returns error code.
LONG ADS_API CNT_GetFreqAcqTime(LONG i_hHandle, USHORT i_iSlot, ULONG *o_ulFreqActTime);

// Method: CNT_SetFreqAcqTime
// action: Set the frequency acquisition time period of the indicated slot.
// pre   : i_hHandle = driver handler
//         i_iSlot = the slot ID (0~7).
//         i_ulFreqActTime = the frequency acquisition time period to set.
// post  : If setting value succeeded, function returns SUCCESS.
//         Otherwise, function returns error code.
LONG ADS_API CNT_SetFreqAcqTime(LONG i_hHandle, USHORT i_iSlot, ULONG i_ulFreqActTime);

// Method: SYS_GetKwMbData
// action: Get the memory data in the KW %M area.
// pre   : i_hHandle = driver handler
//         i_dwStartAddr = the start address of the data.
//         i_dwLength = the length of the data.
//         o_byValues = the variable array to hold the data.
// post  : If getting value succeeded, function returns SUCCESS,
//         and the o_byValues contains data of the memory.
//         Otherwise, function returns error code.
LONG ADS_API SYS_GetKwMbData(LONG i_hHandle, DWORD i_dwStartAddr, DWORD i_dwLength, BYTE *o_byValues);

// Method: SYS_SetKwMbData
// action: Set the memory data in the KW %M area.
// pre   : i_hHandle = driver handler
//         i_dwStartAddr = the start address of the data.
//         i_dwLength = the length of the data.
//         i_byValues = the data array to set.
// post  : If setting value succeeded, function returns SUCCESS.
//         Otherwise, function returns error code.
LONG ADS_API SYS_SetKwMbData(LONG i_hHandle, DWORD i_dwStartAddr, DWORD i_dwLength, BYTE *i_byValues);

// ************************************************************************************************
// ************************************************************************************************
// ===========================================
// Note: the below functions are all ODM using
// ===========================================
// 2008/03/27, Tony Liu start
LONG ADS_API ODM81T_GetFrequency(LONG i_hHandle, USHORT i_iSlot, ULONG *o_iFreq);
LONG ADS_API ODM81T_GetStatus0(LONG i_hHandle, USHORT i_iSlot, BYTE *o_byStatus);
LONG ADS_API ODM81T_GetStatus1(LONG i_hHandle, USHORT i_iSlot, BYTE *o_byStatus);
LONG ADS_API ODM81T_GetPulseHighWidth(LONG i_hHandle, USHORT i_iSlot, USHORT i_iChannel, USHORT *o_iWidth);
LONG ADS_API ODM81T_SetPulseHighWidth(LONG i_hHandle, USHORT i_iSlot, USHORT i_iChannel, USHORT i_iWidth);
LONG ADS_API ODM81T_GetPulseLowWidth(LONG i_hHandle, USHORT i_iSlot, USHORT i_iChannel, USHORT *o_iWidth);
LONG ADS_API ODM81T_SetPulseLowWidth(LONG i_hHandle, USHORT i_iSlot, USHORT i_iChannel, USHORT i_iWidth);
LONG ADS_API ODM81T_GetFilter(LONG i_hHandle, USHORT i_iSlot, USHORT *o_iFilter);
LONG ADS_API ODM81T_SetFilter(LONG i_hHandle, USHORT i_iSlot, USHORT i_iFilter);
LONG ADS_API ODM81T_SetPulseEnable(LONG i_hHandle, USHORT i_iSlot, USHORT i_iChannel, BOOL i_bEnable);
LONG ADS_API ODM81T_SetWDTEnable(LONG i_hHandle, USHORT i_iSlot, BOOL i_bEnable);
LONG ADS_API ODM81T_SetWDTUpdate(LONG i_hHandle, USHORT i_iSlot);
LONG ADS_API ODM81T_GetWDTValue(LONG i_hHandle, USHORT i_iSlot, USHORT *o_iValue);
LONG ADS_API ODM81T_SetWDTValue(LONG i_hHandle, USHORT i_iSlot, USHORT i_iValue);
LONG ADS_API ODM81T_GetTriggerMode(LONG i_hHandle, USHORT i_iSlot, UCHAR *o_iMode);
LONG ADS_API ODM81T_SetTriggerMode(LONG i_hHandle, USHORT i_iSlot, UCHAR i_iMode);
LONG ADS_API ODM81T_GetOutputErrorCount(LONG i_hHandle, USHORT i_iSlot, USHORT *o_iValue);
LONG ADS_API ODM81T_GetOutputError(LONG i_hHandle, USHORT i_iSlot, BOOL *o_bError);
LONG ADS_API ODM81T_ClearOutputError(LONG i_hHandle, USHORT i_iSlot);
LONG ADS_API ODM81T_GetHardwareStop(LONG i_hHandle, USHORT i_iSlot, BOOL *o_bStop);
LONG ADS_API ODM81T_ClearHardwareStop(LONG i_hHandle, USHORT i_iSlot);
// 2008/03/27, Tony Liu end
LONG ADS_API ODM81T_SetCtrl0Flag(LONG i_hHandle, USHORT i_iSlot, USHORT i_iFlagPos, UCHAR i_iFlagEnable);
LONG ADS_API ODM81T_SetCtrl1Flag(LONG i_hHandle, USHORT i_iSlot, USHORT i_iFlagPos, UCHAR i_iFlagEnable);
LONG ADS_API ODM81T_SetCtrl0(LONG i_hHandle, USHORT i_iSlot, UCHAR i_iValue);
LONG ADS_API ODM81T_SetCtrl1(LONG i_hHandle, USHORT i_iSlot, UCHAR i_iValue);
LONG ADS_API ODM81T_GetFun(LONG i_hHandle, USHORT i_iSlot, UCHAR i_iFun, UCHAR i_iTotal,
							 UCHAR *o_iVal0, UCHAR *o_iVal1, UCHAR *o_iVal2, UCHAR *o_iVal3);
LONG ADS_API ODM81T_SetFun(LONG i_hHandle, USHORT i_iSlot, UCHAR i_iFun, UCHAR i_iTotal,
							 UCHAR i_iVal0, UCHAR i_iVal1, UCHAR i_iVal2, UCHAR i_iVal3);

// 2008/04/07, Tony Liu start
LONG ADS_API ODM17S_SetRange(LONG i_hHandle, USHORT i_iSlot, UCHAR i_byRange);
LONG ADS_API ODM17S_GetRange(LONG i_hHandle, USHORT i_iSlot, UCHAR *o_byRange);
LONG ADS_API ODM17S_SetMode(LONG i_hHandle, USHORT i_iSlot, UCHAR i_byMode);
LONG ADS_API ODM17S_GetMode(LONG i_hHandle, USHORT i_iSlot, UCHAR *o_byMode);
LONG ADS_API ODM17S_SetTrigTotal(LONG i_hHandle, USHORT i_iSlot, USHORT i_iTrigTotal);
LONG ADS_API ODM17S_GetTrigTotal(LONG i_hHandle, USHORT i_iSlot, USHORT *o_iTrigTotal);
LONG ADS_API ODM17S_SetSampleRate(LONG i_hHandle, USHORT i_iSlot, USHORT i_iRate);
LONG ADS_API ODM17S_GetSampleRate(LONG i_hHandle, USHORT i_iSlot, USHORT *o_iRate);
LONG ADS_API ODM17S_SetEnableChannelTotal(LONG i_hHandle, USHORT i_iSlot, USHORT i_iTotal);
LONG ADS_API ODM17S_GetEnableChannelTotal(LONG i_hHandle, USHORT i_iSlot, USHORT *o_iTotal);
LONG ADS_API ODM17S_SetStart(LONG i_hHandle, USHORT i_iSlot);
LONG ADS_API ODM17S_SetStop(LONG i_hHandle, USHORT i_iSlot);
LONG ADS_API ODM17S_GetFifoData(LONG i_hHandle, USHORT i_iSlot, USHORT *o_iValues);
// 2008/04/07, Tony Liu end

// 2010/04/15, Tony Liu start
LONG ADS_API ODM17UH_SetStart(LONG i_hHandle, USHORT i_iSlot);
LONG ADS_API ODM17UH_SetStop(LONG i_hHandle, USHORT i_iSlot);
LONG ADS_API ODM17UH_SetConfig(LONG i_hHandle, USHORT i_iSlot, ULONG i_iDataFormat, USHORT i_iAcqNum, ULONG i_iFreq, LONG i_iTrigMode, ULONG i_iFilterMode);
LONG ADS_API ODM17UH_GetConfig(LONG i_hHandle, USHORT i_iSlot, ULONG *o_iDataFormat, USHORT *o_iAcqNum, ULONG *o_iFreq, LONG *o_iTrigMode, ULONG *o_iFilterMode);
LONG ADS_API ODM17UH_GetValues(LONG i_hHandle, USHORT i_iSlot, UCHAR *pValue);
LONG ADS_API ODM17UH_GetVersion(LONG i_hHandle, USHORT i_iSlot, USHORT *o_iVerHigh, USHORT *o_iVerLow);
// 2010/04/15, Tony Liu end

// ==========================================
// Note: the below functions are reserved for internal use
// ==========================================
LONG ADS_API SYS_ResetARM7(LONG i_hHandle);
LONG ADS_API SYS_GetDataFmDPRAM(LONG i_hHandle, ULONG Idx, VOID *src, SHORT size);
LONG ADS_API SYS_MovDataToDPRAM(LONG i_hHandle, ULONG Idx, VOID *src, SHORT size);
LONG ADS_API SYS_SetFWUpgradeMark(LONG i_hHandle);     
LONG ADS_API SYS_ClsFWUpgradeMark(LONG i_hHandle);   
LONG ADS_API SYS_GetCPLDVer(LONG i_hHandle, USHORT *i_usCPLDVer);
LONG ADS_API SYS_Adam5550LocalBusOutput(LONG i_hHandle, USHORT BaseOff, UCHAR o_ucValue);   
LONG ADS_API SYS_Adam5550LocalBusInput(LONG i_hHandle, USHORT BaseOff, UCHAR *i_ucValue);   
LONG ADS_API DEBUG_GetRegValue(LONG i_hHandle, USHORT i_iSlot, USHORT i_iChannel, BYTE *o_byValue);
long ADS_API DEBUG_SetRegValue(LONG i_hHandle, USHORT i_iSlot, USHORT i_iChannel, BYTE i_byValue);


// ==========================================
// Note: the below functions are all obsolete
// ==========================================
LONG ADS_API SYS_WaitForADAM5550IOUpdate(LONG i_hHandle, USHORT i_iSlot, SHORT *o_iflag); 
LONG ADS_API DIO_GetIOConfig(LONG i_hHandle, USHORT i_iSlot, USHORT i_iChannel, BYTE* o_byConfig);
LONG ADS_API DIO_SetIOConfig(LONG i_hHandle, USHORT i_iSlot, USHORT i_iChannel, BYTE i_byConfig);
LONG ADS_API DO_GetPulseOutputWidthAndDelayTime(LONG i_hHandle, USHORT i_iSlot, USHORT i_iChannel,
												LONG *o_lPulseHighWidth,
												LONG *o_lPulseLowWidth,
												LONG *o_lHighToLowDelay,
												LONG *o_lLowToHighDelay);
LONG ADS_API DO_SetPulseOutputWidthAndDelayTime(LONG i_hHandle, USHORT i_iSlot, USHORT i_iChannel,
												LONG i_lPulseHighWidth,
												LONG i_lPulseLowWidth,
												LONG i_lHighToLowDelay,
												LONG i_lLowToHighDelay);
LONG ADS_API DO_SetPulseOutputAbsoluteCounts(LONG i_hHandle, USHORT i_iSlot, USHORT i_iChannel, LONG i_lCounts);
LONG ADS_API DO_GetPulseOutputAbsoluteCounts(LONG i_hHandle, USHORT i_iSlot, USHORT i_iChannel, LONG* o_lCounts);
LONG ADS_API DO_SetPulseOutputIncreaseCounts(LONG i_hHandle, USHORT i_iSlot, USHORT i_iChannel, LONG i_lCounts);
LONG ADS_API DO_GetPulseOutputIncreaseCounts(LONG i_hHandle, USHORT i_iSlot, USHORT i_iChannel, LONG* o_lCounts);
LONG ADS_API DO_SetPulseOutputAbsoluteCounts(LONG i_hHandle, USHORT i_iSlot, USHORT i_iChannel, LONG i_lCounts);
LONG ADS_API DO_GetPulseOutputAbsoluteCounts(LONG i_hHandle, USHORT i_iSlot, USHORT i_iChannel, LONG* o_lCounts);
LONG ADS_API DO_SetLowToHighDelay(LONG i_hHandle, USHORT i_iSlot, USHORT i_iChannel, BOOL i_bValue);
LONG ADS_API DO_SetHighToLowDelay(LONG i_hHandle, USHORT i_iSlot, USHORT i_iChannel, BOOL i_bValue);
LONG ADS_API DO_SetPulseOutputMode(LONG i_hHandle, USHORT i_iSlot, USHORT i_iChannel, BOOL i_bContinue);
LONG ADS_API DO_SetPulseOutputStart(LONG i_hHandle, USHORT i_iSlot, USHORT i_iChannel, BOOL i_bStart);
LONG ADS_API DI_GetDigitalFilterMiniSignalWidth(LONG i_hHandle, USHORT i_iSlot, USHORT i_iChannel, LONG *o_lHigh, LONG *o_lLow);
LONG ADS_API DI_SetDigitalFilterMiniSignalWidth(LONG i_hHandle, USHORT i_iSlot, USHORT i_iChannel, LONG i_lHigh, LONG i_lLow);
LONG ADS_API DI_SetDigitalFilterStart(LONG i_hHandle, USHORT i_iSlot, USHORT i_iChannel, BOOL i_bStart);
LONG ADS_API DI_GetDigitalFilterStart(LONG i_hHandle, USHORT i_iSlot, USHORT i_iChannel, BOOL *o_bStart);
LONG ADS_API DI_GetInvertMask(LONG i_hHandle, USHORT i_iSlot, USHORT i_iChannel, BOOL *o_bInvertMask);
LONG ADS_API DI_SetInvertMask(LONG i_hHandle, USHORT i_iSlot, USHORT i_iChannel, BOOL i_bInvertMask);
LONG ADS_API DI_GetCounterStart(LONG i_hHandle, USHORT i_iSlot, USHORT i_iChannel, BOOL *o_bStart);
LONG ADS_API DI_SetCounterStart(LONG i_hHandle, USHORT i_iSlot, USHORT i_iChannel, BOOL i_bStart);
LONG ADS_API DI_GetCounterOrFrequencyValue(LONG i_hHandle, USHORT i_iSlot, USHORT i_iChannel, LONG *o_lValue);
LONG ADS_API DI_Clear_Counter_Value(LONG i_hHandle, USHORT i_iSlot, USHORT i_iChannel);
LONG ADS_API DI_ReadCounterOverFlowFlag(LONG i_hHandle, USHORT i_iSlot, USHORT i_iChannel, BOOL *o_bOverFlow);
LONG ADS_API DI_ClearCounterOverFlowFlag(LONG i_hHandle, USHORT i_iSlot, USHORT i_iChannel, BOOL i_bOverFlow);
LONG ADS_API AI_GetRangeIntegrationTime(LONG i_hHandle, USHORT i_iSlot, USHORT* o_iIntegrationTime);
LONG ADS_API AI_SetRangeIntegrationTime(LONG i_hHandle, USHORT i_iSlot, USHORT i_iIntegrationTime);
LONG ADS_API AI_SetChannelSpanCalibration(LONG i_hHandle, USHORT i_iSlot);
LONG ADS_API AI_SetChannelZeroCalibration(LONG i_hHandle, USHORT i_iSlot);
LONG ADS_API AI_GetCJCValue(LONG i_hHandle, USHORT i_iSlot, FLOAT* o_fCJCValue); 
LONG ADS_API AI_SetCJCOffset(LONG i_hHandle, USHORT i_iSlot, FLOAT i_fCJCOffset);


#ifdef __cplusplus
}
#endif


