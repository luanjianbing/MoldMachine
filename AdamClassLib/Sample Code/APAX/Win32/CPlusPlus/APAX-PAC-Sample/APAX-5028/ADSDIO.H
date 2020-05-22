
#define ADS_API //__declspec(dllexport)

// ===============================================
// Error code definition
// ===============================================
#define ERR_SUCCESS				0
#define ERR_NO_CHANGE		    1

#define DevErrorCode			300
#define ERR_MALLOC_FAILED		(DevErrorCode + 0) 
#define ERR_MAPADDR_FAILED		(DevErrorCode + 1)
#define ERR_HANDLE_INVALID		(DevErrorCode + 2)
#define ERR_MODULE_INVALID		(DevErrorCode + 3)
#define ERR_SLOT_INVALID		(DevErrorCode + 4)
#define ERR_CHANNEL_INVALID		(DevErrorCode + 5)
#define ERR_FUNC_INVALID		(DevErrorCode + 6)
#define ERR_INTRINIT_FAILED		(DevErrorCode + 7)  
#define ERR_FREQMEASU_FAILED 	(DevErrorCode + 8)               
#define ERR_PARAM_INVALID       (DevErrorCode + 9)
#define ERR_FIFO_NOTREADY		(DevErrorCode + 10)
#define ERR_FIFO_FULL			(DevErrorCode + 11)
#define ERR_FIFO_DATAFAILED		(DevErrorCode + 12)
#define ERR_ACQSTOP_FAILED		(DevErrorCode + 13)
#define ERR_FREQ_INVALID		(DevErrorCode + 14)
#define ERR_DUTY_INVALID		(DevErrorCode + 15)


#define ERR_DEVICE_NON			(DevErrorCode + 20)
#define ERR_ACCESS_DENIED		(DevErrorCode + 21)
#define ERR_LENGTH_INVALID		(DevErrorCode + 22)
#define ERR_CONFIG_FAILED		(DevErrorCode + 23)
#define ERR_DSPFLAG_INVALID		(DevErrorCode + 24)
#define ERR_INTERNAL_FAILED		(DevErrorCode + 25)
#define ERR_TIMEOUT				(DevErrorCode + 26)

#define ERR_COMMAND_FAILED		(DevErrorCode + 90)
// ===============================================
// Module ID definition
// ===============================================
#define	A5013_ID		0x50130000
#define	A5017_ID		0x50170000
#define	A5017H_ID		0x50174800
#define	A5018_ID		0x50180000
#define	A5028_ID		0x50280000
#define	A5040_ID		0x50400000
#define	A5041_ID		0x50410000
#define	A5045_ID		0x50450000
#define	A5046_ID		0x50460000
#define	A5047_ID		0x50470000
#define	A5060_ID		0x50600000
#define	A5061_ID		0x50610000
#define	A5080_ID		0x50800000
#define	A5081PG_ID		0x50815047
#define	A5017PG_ID		0x50175047
#define	A5082_ID		0x50820000


#pragma pack(1)
// ===============================================
// Slot information definition
// ===============================================
typedef struct SlotInfo
{
	BYTE	byUID;
	WORD	wSeqNo;
	WORD	wPktVer;
	WORD	wMsgType;
	WORD	wFwVerNo;
	BYTE	byFwVerBld;
	WORD	wDevType;
	DWORD	dwModName;
	DWORD	dwActPeriod;
	BYTE	byCOS;
	BYTE	byChTotal;
	WORD	wHwVer;
	BYTE	byEthSpeed;
	BYTE	byMaxLoadShare;
	BYTE	byHwIoType_0;
	BYTE	byHwIoTotal_0;
	BYTE	byHwIoType_1;
	BYTE	byHwIoTotal_1;
	BYTE	byHwIoType_2;
	BYTE	byHwIoTotal_2;
	BYTE	byHwIoType_3;
	BYTE	byHwIoTotal_3;
	BYTE	byHwIoType_4;
	BYTE	byHwIoTotal_4;
	BYTE	byFunType_0;
	DWORD	dwFunMask_0;
	DWORD	dwFunParam_0;
	BYTE	byFunType_1;
	DWORD	dwFunMask_1;
	DWORD	dwFunParam_1;
	BYTE	byFunType_2;
	DWORD	dwFunMask_2;
	DWORD	dwFunParam_2;
	BYTE	byFunType_3;
	DWORD	dwFunMask_3;
	DWORD	dwFunParam_3;
	BYTE	byFunType_4;
	DWORD	dwFunMask_4;
	DWORD	dwFunParam_4;
	WORD	wHwIoType_0_Start;
	WORD	wHwIoType_0_End;
	WORD	wHwIoType_1_Start;
	WORD	wHwIoType_1_End;
	WORD	wHwIoType_2_Start;
	WORD	wHwIoType_2_End;
	WORD	wHwIoType_3_Start;
	WORD	wHwIoType_3_End;
	WORD	wHwIoType_4_Start;
	WORD	wHwIoType_4_End;
	BYTE	wHwIoType_0_Resolution;
	BYTE	wHwIoType_1_Resolution;
	BYTE	wHwIoType_2_Resolution;
	BYTE	wHwIoType_3_Resolution;
	BYTE	wHwIoType_4_Resolution;
	BYTE	wHwIoType_0_TotalRange;
	BYTE	wHwIoType_1_TotalRange;
	BYTE	wHwIoType_2_TotalRange;
	BYTE	wHwIoType_3_TotalRange;
	BYTE	wHwIoType_4_TotalRange;
	WORD	wHwIoType_0_Range[36];
	WORD	wHwIoType_1_Range[36];
	WORD	wHwIoType_2_Range[36];
	WORD	wHwIoType_3_Range[36];
	WORD	wHwIoType_4_Range[36];
	WORD	wChRange[32];
	DWORD	dwAlarmMask;
	DWORD	dwChMask;
	BYTE	bySizeOfReg;
	WORD	wProtoVer;
	BYTE	byMacAddr[6];
	BYTE	byIpAddr[4];
	WORD	wSupportFwVer;
	BYTE	byExtUsed;
	WORD	wExtLength;
//	BYTE	byExtBuf[639];
}SlotInfo, *LPSlotInfo;

#ifdef __cplusplus
extern "C"
{
#endif

// Method: ADAMDrvOpen
// action: Initialize the driver
// pre   : handle = driver handler
// post  : If driver initialization succeeded, function returns ERR_SUCCESS,
//         and the handle will be used for rest of the functions.
//         Otherwise, function returns error code.
//         If the error code is ERR_INTERNAL_FAILED, call GetLastError to get extended error information.
LONG ADS_API ADAMDrvOpen(LONG* handle);

// Method: ADAMDrvClose
// action: Terminate the driver
// pre   : handle = driver handler
// post  : If driver termination succeeded, function returns ERR_SUCCESS,
//         and the handle has value which will be used for rest of the functions.
//         Otherwise, function returns error code.
//         If the error code is ERR_INTERNAL_FAILED, call GetLastError to get extended error information.
LONG ADS_API ADAMDrvClose(LONG* handle);

// Method: SYS_GetVersion
// action: Get the ADSDIO library version
// pre   : handle = driver handler
// post  : If getting version succeeded, function returns ERR_SUCCESS,
//         and the o_dwVersion contains version number.
//         Otherwise, function returns error code.
//         If the error code is ERR_INTERNAL_FAILED, call GetLastError to get extended error information.
LONG ADS_API SYS_GetVersion(LONG handle, DWORD* o_dwVersion);

// Method: SYS_SetInnerTimeout
// action: Set the inner-timeout of the configuration functions that use internal communication channel.
// pre   : handle = driver handler
//         i_wTimeout = inner-timeout, in millisecond. Default is 500 milliseconds.
// post  : If setting timeout succeeded, function returns ERR_SUCCESS.
//         Otherwise, function returns error code.
//         If the error code is ERR_INTERNAL_FAILED, call GetLastError to get extended error information.
LONG ADS_API SYS_SetInnerTimeout(LONG handle, WORD i_wTimeout);

// Method: SYS_GetModuleID
// action: Get the module ID of the indicated slot.
// pre   : handle = driver handler
//         i_wSlot = the slot ID which is ranged from 0 to 31.
// post  : If getting ID succeeded, function returns ERR_SUCCESS,
//         and the o_dwModuleID contains module ID.
//         Otherwise, function returns error code.
//         If the error code is ERR_INTERNAL_FAILED, call GetLastError to get extended error information.
LONG ADS_API SYS_GetModuleID(LONG handle, WORD i_wSlot, DWORD* o_dwModuleID);

// Method: SYS_GetControllerID
// action: Get the controller ID of the indicated slot.
// pre   : handle = driver handler
// post  : If getting the controller ID succeeded, function returns ERR_SUCCESS,
//         and the o_dwControllerID contains controller ID.
//         Otherwise, function returns error code.
//         If the error code is ERR_INTERNAL_FAILED, call GetLastError to get extended error information.
LONG ADS_API SYS_GetControllerID(LONG handle, DWORD* o_dwControllerID);

// Method: SYS_GetSlotInfo
// action: Get the module information of the indicated slot.
// pre   : handle = driver handler
//         i_wSlot = the slot ID which is ranged from 0 to 31.
//         o_stSlotInfo = the SlotInfo structure to put the information.
// post  : If getting information succeeded, function returns ERR_SUCCESS,
//         and the o_stSlotInfo contains slot information.
//         Otherwise, function returns error code.
//         If the error code is ERR_INTERNAL_FAILED, call GetLastError to get extended error information.
LONG ADS_API SYS_GetSlotInfo(LONG handle, WORD i_wSlot, struct SlotInfo* o_stSlotInfo);

// Method: AIO_GetValue
// action: Get the AIO value of the indicated slot and channel.
// pre   : handle = driver handler
//         i_wSlot = the slot ID which is ranged from 0 to 15.
//         i_wChannel = the channel ID which is ranged from 0 to 31.
//         o_wValue = the variable to hold the AIO value.
// post  : If getting value succeeded, function returns ERR_SUCCESS,
//         and the o_wValue contains AIO value.
//         Otherwise, function returns error code.
//         If the error code is ERR_INTERNAL_FAILED, call GetLastError to get extended error information.
LONG ADS_API AIO_GetValue(LONG handle, WORD i_wSlot, WORD i_wChannel, WORD* o_wValue);

// Method: AIO_GetValues
// action: Get the all AIO values of the indicated slot.
// pre   : handle = driver handler
//         i_wSlot = the slot ID which is ranged from 0 to 15.
//         o_wValues = the variables array to hold the AIO values. The size of this array must be at least 32 WORDs.
// post  : If getting values succeeded, function returns ERR_SUCCESS,
//         and the o_wValues contains AIO values from channel-0 to the last channel.
//         Otherwise, function returns error code.
//         If the error code is ERR_INTERNAL_FAILED, call GetLastError to get extended error information.
LONG ADS_API AIO_GetValues(LONG handle, WORD i_wSlot, WORD* o_wValues);

// Method: AIO_SetRanges
// action: Set the channel ranges of the indicated slot.
// pre   : handle = driver handler
//         i_wSlot = the slot ID which is ranged from 0 to 15.
//         i_wChannelTotal = the channel total of the module in the indicated slot.
//         i_wRanges = the ranges to be set. The size of this array must be i_wChannelTotal WORDs.
// post  : If setting ranges succeeded, function returns ERR_SUCCESS.
//         Otherwise, function returns error code.
//         If the error code is ERR_INTERNAL_FAILED, call GetLastError to get extended error information.
LONG ADS_API AIO_SetRanges(LONG handle, WORD i_wSlot, WORD i_wChannelTotal, WORD* i_wRanges);

// Method: AIO_SetZeroCalibration
// action: Set to run the zero calibraion of the indicated slot and channel.
// pre   : handle = driver handler
//         i_wSlot = the slot ID which is ranged from 0 to 15.
//         i_wChannel = the channel ID which is ranged from 0 to 31.
//         i_wType = the type value to be set. Currently, it is ingnored.
// post  : If setting zero calibration succeeded, function returns ERR_SUCCESS.
//         Otherwise, function returns error code.
//         If the error code is ERR_INTERNAL_FAILED, call GetLastError to get extended error information.
LONG ADS_API AIO_SetZeroCalibration(LONG handle, WORD i_wSlot, WORD i_wChannel, WORD i_wType);

// Method: AIO_SetSpanCalibration
// action: Set to run the span calibraion of the indicated slot and channel.
// pre   : handle = driver handler
//         i_wSlot = the slot ID which is ranged from 0 to 15.
//         i_wChannel = the channel ID which is ranged from 0 to 31.
//         i_wType = the type value to be set. Currently, it is ingnored.
// post  : If setting span calibration succeeded, function returns ERR_SUCCESS.
//         Otherwise, function returns error code.
//         If the error code is ERR_INTERNAL_FAILED, call GetLastError to get extended error information.
LONG ADS_API AIO_SetSpanCalibration(LONG handle, WORD i_wSlot, WORD i_wChannel, WORD i_wType);

// Method: AIO_GetChannelStatus
// action: Get all channels status of the indicated slot.
// pre   : handle = driver handler
//         i_wSlot = the slot ID which is ranged from 0 to 15.
//         o_byStatus = the variables array to hold the channels status. The size of this array must be at least 32 BYTEs.
// post  : If getting channel status succeeded, function returns ERR_SUCCESS.
//         The value of o_byStatus indicates:
//         0: None
//         1: Normal
//         2: Over current
//         3: Under current
//         4: Burn out
//         5: Open loop
//         6: Not ready
//         Otherwise, function returns error code.
//         If the error code is ERR_INTERNAL_FAILED, call GetLastError to get extended error information.
LONG ADS_API AIO_GetChannelStatus(LONG handle, WORD i_wSlot, BYTE* o_byStatus);

// Method: AI_SetChannelMask
// action: Set enabled AI channel mask of the indicated slot.
// pre   : handle = driver handler
//         i_wSlot = the slot ID which is ranged from 0 to 15.
//         i_dwMask = the enabled AI channel mask to be set. From LSB to MSB of the value indicate
//         the channel-0 to channel-31 enabled mask. If the bit is 1, it means that the channel is enabled.
// post  : If setting channel mask succeeded, function returns ERR_SUCCESS.
//         Otherwise, function returns error code.
//         If the error code is ERR_INTERNAL_FAILED, call GetLastError to get extended error information.
LONG ADS_API AI_SetChannelMask(LONG handle, WORD i_wSlot, DWORD i_dwMask);

// Method: AI_SetIntegrationTime
// action: Set AI integration time of the indicated slot.
// pre   : handle = driver handler
//         i_wSlot = the slot ID which is ranged from 0 to 15.
//         i_dwIntegration = the AI integration time to be set.
// post  : If setting integration time succeeded, function returns ERR_SUCCESS.
//         Otherwise, function returns error code.
//         If the error code is ERR_INTERNAL_FAILED, call GetLastError to get extended error information.
LONG ADS_API AI_SetIntegrationTime(LONG handle, WORD i_wSlot, DWORD i_dwIntegration);

// Method: AI_SetAutoCalibration
// action: Set to run the auto calibraion of the indicated slot.
// pre   : handle = driver handler
//         i_wSlot = the slot ID which is ranged from 0 to 15.
// post  : If setting auto calibration succeeded, function returns ERR_SUCCESS.
//         Otherwise, function returns error code.
//         If the error code is ERR_INTERNAL_FAILED, call GetLastError to get extended error information.
LONG ADS_API AI_SetAutoCalibration(LONG handle, WORD i_wSlot);

// Method: AI_SetChValOffset
// action: Set the channel value offset of the indicated slot.
// pre   : handle = driver handler
//         i_wSlot = the slot ID which is ranged from 0 to 15.
//         i_wChannel = the channel ID which is ranged from 0 to 31 for normal value offset.
//                      Set this value to 0xFE indicates the value offset is for CJC offset.
//         i_dwOffset = the offset value to be set.
// post  : If setting value offset succeeded, function returns ERR_SUCCESS.
//         Otherwise, function returns error code.
//         If the error code is ERR_INTERNAL_FAILED, call GetLastError to get extended error information.
LONG ADS_API AI_SetChValOffset(LONG handle, WORD i_wSlot, WORD i_wChannel, DWORD i_dwOffset);

// Method: AI_GetChValOffset
// action: Get the channel value offset of the indicated slot.
// pre   : handle = driver handler
//         i_wSlot = the slot ID which is ranged from 0 to 15.
//         i_wChannel = the channel ID which is ranged from 0 to 31 for normal value offset.
//                      Set this value to 0xFE indicates the value offset is for CJC offset.
//         o_dwOffset = the variable to hold the offset value.
// post  : If getting value offset succeeded, function returns ERR_SUCCESS,
//         the o_dwOffset contains the offset value.
//         Otherwise, function returns error code.
//         If the error code is ERR_INTERNAL_FAILED, call GetLastError to get extended error information.
LONG ADS_API AI_GetChValOffset(LONG handle, WORD i_wSlot, WORD i_wChannel, DWORD* o_dwOffset);

// Method: AI_GetCjcValue
// action: Get the CJC value of the indicated slot.
// pre   : handle = driver handler
//         i_wSlot = the slot ID which is ranged from 0 to 15.
//         o_dwValue = the variable to hold the CJC value.
//         o_byStatus = the CJC setting status
// post  : If getting CJC value succeeded, function returns ERR_SUCCESS,
//         the o_dwValue contains the variable to hold the CJC value and
//         the o_byStatus contains the CJC setting status.
//         Otherwise, function returns error code.
//         If the error code is ERR_INTERNAL_FAILED, call GetLastError to get extended error information.
LONG ADS_API AI_GetCjcValue(LONG handle, WORD i_wSlot, DWORD* o_dwValue, BYTE* o_byStatus);

// Method: AI_SetBurnoutFunEnable
// action: Set to enable/disable burnout function for each channel.
// pre   : handle = driver handler
//         i_wSlot = the slot ID which is ranged from 0 to 15.
//         i_dwEnableMask = the enable mask; each bit indicates one channel, bit = 1 enable burnout function for that channel
// post  : If setting burnout function succeeded, function returns ERR_SUCCESS.
//         Otherwise, function returns error code.
//         If the error code is ERR_INTERNAL_FAILED, call GetLastError to get extended error information.
LONG ADS_API AI_SetBurnoutFunEnable(LONG handle, WORD i_wSlot, DWORD i_dwEnableMask);

// Method: AI_GetBurnoutFunEnable
// action: Get the burnout function enable/disable for each channel.
// pre   : handle = driver handler
//         i_wSlot = the slot ID which is ranged from 0 to 15.
//         o_dwEnableMask = the variables to hold the enabled mask.
// post  : If getting burnout function succeeded, function returns ERR_SUCCESS,
//         the o_dwEnableMask contains the enable mask.
//         Otherwise, function returns error code.
//         If the error code is ERR_INTERNAL_FAILED, call GetLastError to get extended error information.
LONG ADS_API AI_GetBurnoutFunEnable(LONG handle, WORD i_wSlot, DWORD* o_dwEnableMask);

// Method: AI_SetCjcInitValRecord
// action: Set to record the CJC initial value
// pre   : handle = driver handler
//         i_wSlot = the slot ID which is ranged from 0 to 15.
// post  : If setting CJC initial value succeeded, function returns ERR_SUCCESS.
//         Otherwise, function returns error code.
//         If the error code is ERR_INTERNAL_FAILED, call GetLastError to get extended error information.
LONG ADS_API AI_SetCjcInitValRecord(LONG handle, WORD i_wSlot);

// Method: AI_SetThermoCalibration
// action: Set to calibrate the thermocouple
// pre   : handle = driver handler
//         i_wSlot = the slot ID which is ranged from 0 to 15.
// post  : If setting thermocouple calibration succeeded, function returns ERR_SUCCESS.
//         Otherwise, function returns error code.
//         If the error code is ERR_INTERNAL_FAILED, call GetLastError to get extended error information.
LONG ADS_API AI_SetThermoCalibration(LONG handle, WORD i_wSlot);

// Method: AI_SetBurnoutValue
// action: Set the burnout value
// pre   : handle = driver handler
//         i_wSlot = the slot ID which is ranged from 0 to 15.
//         i_dwValue = the burnout value; when input value exceeds this value, the burnout status will on
// post  : If setting burnout value succeeded, function returns ERR_SUCCESS.
//         Otherwise, function returns error code.
//         If the error code is ERR_INTERNAL_FAILED, call GetLastError to get extended error information.
LONG ADS_API AI_SetBurnoutValue(LONG handle, WORD i_wSlot, DWORD i_dwValue);

// Method: AI_GetBurnoutValue
// action: Get the burnout value
// pre   : handle = driver handler
//         i_wSlot = the slot ID which is ranged from 0 to 15.
//         o_dwValue = the variables to hold the burnout value.
// post  : If getting burnout value succeeded, function returns ERR_SUCCESS,
//         the o_dwValue contains the burnout value.
//         Otherwise, function returns error code.
//         If the error code is ERR_INTERNAL_FAILED, call GetLastError to get extended error information.
LONG ADS_API AI_GetBurnoutValue(LONG handle, WORD i_wSlot, DWORD* o_dwValue);

// Method: AI_SetSampleRate
// action: Set the sample rate
// pre   : handle = driver handler
//         i_wSlot = the slot ID which is ranged from 0 to 15.
//         i_dwSampleRate = the sample rate(Hz) to be set.
// post  : If setting sample rate succeeded, function returns ERR_SUCCESS.
//         Otherwise, function returns error code.
//         If the error code is ERR_INTERNAL_FAILED, call GetLastError to get extended error information.
LONG ADS_API AI_SetSampleRate(LONG handle, WORD i_wSlot, DWORD i_dwSampleRate);

// Method: AI_GetSampleRate
// action: Get the sample rate
// pre   : handle = driver handler
//         i_wSlot = the slot ID which is ranged from 0 to 15.
//         o_dwSampleRate = the variable to hold the sample rate(Hz).
// post  : If getting sample rate succeeded, function returns ERR_SUCCESS.
//         Otherwise, function returns error code.
//         If the error code is ERR_INTERNAL_FAILED, call GetLastError to get extended error information.
LONG ADS_API AI_GetSampleRate(LONG handle, WORD i_wSlot, DWORD* o_dwSampleRate);

// Method: AO_SetCalibrationMode
// action: Set to switch to the AO calibraion mode of the indicated slot.
// pre   : handle = driver handler
//         i_wSlot = the slot ID which is ranged from 0 to 15.
// post  : If setting calibration mode succeeded, function returns ERR_SUCCESS.
//         Otherwise, function returns error code.
//         If the error code is ERR_INTERNAL_FAILED, call GetLastError to get extended error information.
LONG ADS_API AO_SetCalibrationMode(LONG handle, WORD i_wSlot);

// Method: AO_GetStartupValues
// action: Get the AO startup values of the indicated slot.
// pre   : handle = driver handler
//         i_wSlot = the slot ID which is ranged from 0 to 15.
//         i_wChannelTotal = the channel total of the module in the indicated slot.
//         o_wValues = the variables array to hold the AO startup values. The size of this array must be at least 32 WORDs.
// post  : If getting values succeeded, function returns ERR_SUCCESS,
//         and the o_wValues contains AO startup values from channel-0 to the last channel.
//         Otherwise, function returns error code.
//         If the error code is ERR_INTERNAL_FAILED, call GetLastError to get extended error information.
LONG ADS_API AO_GetStartupValues(LONG handle, WORD i_wSlot, WORD i_wChannelTotal, WORD* o_wValues);

// Method: AO_SetStartupValues
// action: Set the AO startup values of the indicated slot.
// pre   : handle = driver handler
//         i_wSlot = the slot ID which is ranged from 0 to 15.
//         i_wChannelTotal = the channel total of the module in the indicated slot.
//         i_wValues = the values array to be set. The size of this array must be i_wChannelTotal WORDs.
// post  : If setting values succeeded, function returns ERR_SUCCESS.
//         Otherwise, function returns error code.
//         If the error code is ERR_INTERNAL_FAILED, call GetLastError to get extended error information.
LONG ADS_API AO_SetStartupValues(LONG handle, WORD i_wSlot, WORD i_wChannelTotal, WORD* i_wValues);

// Method: AO_SetValue
// action: Set the AO value of the indicated slot and channel.
// pre   : handle = driver handler
//         i_wSlot = the slot ID which is ranged from 0 to 15.
//         i_wChannel = the channel ID which is ranged from 0 to 31.
//         i_wValue = the AO value to be set.
// post  : If setting value succeeded, function returns ERR_SUCCESS.
//         Otherwise, function returns error code.
//         If the error code is ERR_INTERNAL_FAILED, call GetLastError to get extended error information.
LONG ADS_API AO_SetValue(LONG handle, WORD i_wSlot, WORD i_wChannel, WORD i_wValue);

// Method: AO_SetValues
// action: Set the AO values of the indicated slot.
// pre   : handle = driver handler
//         i_wSlot = the slot ID which is ranged from 0 to 15.
//         i_dwMask = the channels mask. From LSB to MSB of the value indicate
//         the channel-0 to channel-31 mask. If the bit is 1, it means that the channel must change value.
//         i_wValues = the AO values to be set.
// post  : If setting values succeeded, function returns ERR_SUCCESS.
//         Otherwise, function returns error code.
//         If the error code is ERR_INTERNAL_FAILED, call GetLastError to get extended error information.
LONG ADS_API AO_SetValues(LONG handle, WORD i_wSlot, DWORD i_dwMask, WORD* i_wValues);

// Method: AO_BufValues
// action: Buffer the AO values of the indicated slot.
// pre   : handle = driver handler
//         i_wSlot = the slot ID which is ranged from 0 to 15.
//         i_dwMask = the channels mask. From LSB to MSB of the value indicate
//         the channel-0 to channel-31 mask. If the bit is 1, it means that the channel must buffer value.
//         i_wValues = the AO values to be bufferred.
// post  : If bufferring values succeeded, function returns ERR_SUCCESS.
//         Otherwise, function returns error code.
//         If the error code is ERR_INTERNAL_FAILED, call GetLastError to get extended error information.
LONG ADS_API AO_BufValues(LONG handle, WORD i_wSlot, DWORD i_dwMask, WORD* i_wValues);

// Method: DIO_GetValue
// action: Get the DIO value of the indicated slot and channel.
// pre   : handle = driver handler
//         i_wSlot = the slot ID which is ranged from 0 to 31.
//         i_wChannel = the channel ID which is ranged from 0 to 63.
//         o_bValue = the variable to hold the DIO value.
// post  : If getting value succeeded, function returns ERR_SUCCESS,
//         and the o_bValue contains DIO value.
//         Otherwise, function returns error code.
//         If the error code is ERR_INTERNAL_FAILED, call GetLastError to get extended error information.
LONG ADS_API DIO_GetValue(LONG handle, WORD i_wSlot, WORD i_wChannel, BOOL* o_bValue);

// Method: DIO_GetValues
// action: Get the all DIO values of the indicated slot.
// pre   : handle = driver handler
//         i_wSlot = the slot ID which is ranged from 0 to 31.
//         o_dwHighValue = the variable to hold the DIO values from channel 32 to 63. The LSB indicates the channel-32.
//         o_dwLowValue = the variable to hold the DIO values from channel 0 to 31. The LSB indicates the channel-0.
// post  : If getting values succeeded, function returns ERR_SUCCESS,
//         and the o_dwHighValue and o_dwLowValue contain DIO values from channel-0 to the last channel.
//         Otherwise, function returns error code.
//         If the error code is ERR_INTERNAL_FAILED, call GetLastError to get extended error information.
LONG ADS_API DIO_GetValues(LONG handle, WORD i_wSlot, DWORD* o_dwHighValue, DWORD* o_dwLowValue);

// Method: DI_GetFilters
// action: Get the DI filter mask and width of the indicated slot.
// pre   : handle = driver handler
//         i_wSlot = the slot ID which is ranged from 0 to 31.
//         o_dwHighMask = the variable to hold the DI filter mask from channel 32 to 63. The LSB indicates the channel-32.
//         o_dwLowMask = the variable to hold the DI filter mask from channel 0 to 31. The LSB indicates the channel-0.
//         o_dwWidth = the variable to hold the DI filter width.
// post  : If getting filter succeeded, function returns ERR_SUCCESS,
//         and the o_dwHighMask and o_dwLowMask contain DI filter mask from channel-0 to the last channel, 
//         and the o_dwWidth contains the DI filter width.
//         Otherwise, function returns error code.
//         If the error code is ERR_INTERNAL_FAILED, call GetLastError to get extended error information.
LONG ADS_API DI_GetFilters(LONG handle, WORD i_wSlot, DWORD* o_dwHighMask, DWORD* o_dwLowMask, DWORD* o_dwWidth);

// Method: DI_SetFilters
// action: Set the DI filter mask and width of the indicated slot.
// pre   : handle = driver handler
//         i_wSlot = the slot ID which is ranged from 0 to 31.
//         i_dwHighMask = the DI filter mask from channel 32 to 63 to be set. The LSB indicates the channel-32.
//         i_dwLowMask = the DI filter mask from channel 0 to 31 to be set. The LSB indicates the channel-0.
//         i_dwWidth = the variable to hold the DI filter width.
// post  : If setting filter succeeded, function returns ERR_SUCCESS.
//         Otherwise, function returns error code.
//         If the error code is ERR_INTERNAL_FAILED, call GetLastError to get extended error information.
LONG ADS_API DI_SetFilters(LONG handle, WORD i_wSlot, DWORD i_dwHighMask, DWORD i_dwLowMask, DWORD i_dwWidth);

// Method: DO_SetValue
// action: Set the DO value of the indicated slot and channel.
// pre   : handle = driver handler
//         i_wSlot = the slot ID which is ranged from 0 to 31.
//         i_wChannel = the channel ID which is ranged from 0 to 63.
//         i_bValue = the DO value to be set.
// post  : If setting value succeeded, function returns ERR_SUCCESS.
//         Otherwise, function returns error code.
//         If the error code is ERR_INTERNAL_FAILED, call GetLastError to get extended error information.
LONG ADS_API DO_SetValue(LONG handle, WORD i_wSlot, WORD i_wChannel, BOOL i_bValue);

// Method: DO_SetValues
// action: Set the DO values of the indicated slot.
// pre   : handle = driver handler
//         i_wSlot = the slot ID which is ranged from 0 to 31.
//         i_dwHighValue = the DO values from channel 32 to 63 to be set. The LSB indicates the channel-32.
//         i_dwLowValue = the DO values from channel 0 to 31 to be set. The LSB indicates the channel-0.
// post  : If setting values succeeded, function returns ERR_SUCCESS.
//         Otherwise, function returns error code.
//         If the error code is ERR_INTERNAL_FAILED, call GetLastError to get extended error information.
LONG ADS_API DO_SetValues(LONG handle, WORD i_wSlot, DWORD i_dwHighValue, DWORD i_dwLowValue);  

// Method: DO_BufValues
// action: Buffer the DO values of the indicated slot.
// pre   : handle = driver handler
//         i_wSlot = the slot ID which is ranged from 0 to 31.
//         i_dwHighValue = the DO values from channel 32 to 63 to be bufferred. The LSB indicates the channel-32.
//         i_dwLowValue = the DO values from channel 0 to 31 to be bufferred. The LSB indicates the channel-0.
// post  : If bufferring values succeeded, function returns ERR_SUCCESS.
//         Otherwise, function returns error code.
//         If the error code is ERR_INTERNAL_FAILED, call GetLastError to get extended error information.
LONG ADS_API DO_BufValues(LONG handle, WORD i_wSlot, DWORD i_dwHighValue, DWORD i_dwLowValue);

// Method: OUT_FlushBufValues
// action: Flush the bufferred values.
// pre   : handle = driver handler
//         i_dwSlotMask = the flush slot enable mask. The LSB indicates the slot-0.
// post  : If flushing values succeeded, function returns ERR_SUCCESS.
//         Otherwise, function returns error code.
//         If the error code is ERR_INTERNAL_FAILED, call GetLastError to get extended error information.
LONG ADS_API OUT_FlushBufValues(LONG handle, DWORD i_dwSlotMask);

// Method: CNT_GetValue
// action: Get the counter value of the indicated slot and channel.
// pre   : handle = driver handler
//         i_wSlot = the slot ID which is ranged from 0 to 15.
//         i_wChannel = the channel ID which is ranged from 0 to 7.
//         o_dwValue = the variable to hold the counter value.
// post  : If getting value succeeded, function returns ERR_SUCCESS,
//         and the o_dwValue contains counter value.
//         Otherwise, function returns error code.
//         If the error code is ERR_INTERNAL_FAILED, call GetLastError to get extended error information.
LONG ADS_API CNT_GetValue(LONG handle, WORD i_wSlot, WORD i_wChannel, DWORD* o_dwValue);

// Method: CNT_GetValues
// action: Get the all counter values of the indicated slot.
// pre   : handle = driver handler
//         i_wSlot = the slot ID which is ranged from 0 to 15.
//         o_dwValues = the variables array to hold the counter values. The size of this array must be at least 8 DWORDs.
// post  : If getting values succeeded, function returns ERR_SUCCESS,
//         and the o_dwValues contains counter values from channel-0 to the last channel.
//         Otherwise, function returns error code.
//         If the error code is ERR_INTERNAL_FAILED, call GetLastError to get extended error information.
LONG ADS_API CNT_GetValues(LONG handle, WORD i_wSlot, DWORD* o_dwValues);

// Method: CNT_ClearValues
// action: Clear the masked counter values to startup values of the indicated slot.
// pre   : handle = driver handler
//         i_wSlot = the slot ID which is ranged from 0 to 15.
//         i_dwMask = the channels mask. From LSB to MSB of the value indicate
//         the channel-0 to channel-31 mask. If the bit is 1, it means that the channel must set to startup value.
// post  : If clearing values succeeded, function returns ERR_SUCCESS.
//         Otherwise, function returns error code.
//         If the error code is ERR_INTERNAL_FAILED, call GetLastError to get extended error information.
LONG ADS_API CNT_ClearValues(LONG handle, WORD i_wSlot, DWORD i_dwMask);

// Method: CNT_SetRanges
// action: Set the channel ranges of the indicated slot.
// pre   : handle = driver handler
//         i_wSlot = the slot ID which is ranged from 0 to 15.
//         i_wChannelTotal = the channel total of the module in the indicated slot.
//         i_wRanges = the ranges to be set. The size of this array must be i_wChannelTotal WORDs.
//                     the range definition is as below:
//                     0x01C0 : Bi-directory
//                     0x01C1 : Up/Down
//                     0x01C2 : Up
//                     0x01C3 : High Frequency
//                     0x01C4 : A/B-1X
//                     0x01C5 : A/B-2X
//                     0x01C6 : A/B-4X
//                     0x01C7 : Low Frequency
//                     0x01C8 : Wave Width
// post  : If setting ranges succeeded, function returns ERR_SUCCESS.
//         Otherwise, function returns error code.
//         If the error code is ERR_INTERNAL_FAILED, call GetLastError to get extended error information.
LONG ADS_API CNT_SetRanges(LONG handle, WORD i_wSlot, WORD i_wChannelTotal, WORD* i_wRanges);

// Method: CNT_SetChannelMask
// action: Set enabled counter channel mask of the indicated slot.
// pre   : handle = driver handler
//         i_wSlot = the slot ID which is ranged from 0 to 15.
//         i_dwMask = the enabled counter channel mask to be set. From LSB to MSB of the value indicate
//         the channel-0 to channel-31 enabled mask. If the bit is 1, it means that the channel started.
// post  : If setting channel mask succeeded, function returns ERR_SUCCESS.
//         Otherwise, function returns error code.
//         If the error code is ERR_INTERNAL_FAILED, call GetLastError to get extended error information.
LONG ADS_API CNT_SetChannelMask(LONG handle, WORD i_wSlot, DWORD i_dwMask);

// Method: CNT_GetChannelMask
// action: Get enabled counter channel mask of the indicated slot.
// pre   : handle = driver handler
//         i_wSlot = the slot ID which is ranged from 0 to 15.
//         o_dwMask = a variable to hold the enabled counter channel mask. From LSB to MSB of the value indicate
//         the channel-0 to channel-31 enabled mask. 
//         If the bit is 1, it means that the counter channel start to count. Otherwise, stop counting.
// post  : If getting channel mask succeeded, function returns ERR_SUCCESS.
//         Otherwise, function returns error code.
//         If the error code is ERR_INTERNAL_FAILED, call GetLastError to get extended error information.
LONG ADS_API CNT_GetChannelMask(LONG handle, WORD i_wSlot, DWORD* o_dwMask);

// Method: CNT_GetFilter
// action: Get the counter filter width of the indicated slot.
// pre   : handle = driver handler
//         i_wSlot = the slot ID which is ranged from 0 to 15.
//         o_dwWidth = the variable to hold the counter digital filter width.
// post  : If getting filter succeeded, function returns ERR_SUCCESS,
//         and the o_dwWidth contains the counter filter width.
//         Otherwise, function returns error code.
//         If the error code is ERR_INTERNAL_FAILED, call GetLastError to get extended error information.
LONG ADS_API CNT_GetFilter(LONG handle, WORD i_wSlot, DWORD* o_dwWidth);

// Method: CNT_SetFilter
// action: Set the counter filter width of the indicated slot.
// pre   : handle = driver handler
//         i_wSlot = the slot ID which is ranged from 0 to 15.
//         i_dwWidth = the counter filter width to be set.
// post  : If setting filter succeeded, function returns ERR_SUCCESS.
//         Otherwise, function returns error code.
//         If the error code is ERR_INTERNAL_FAILED, call GetLastError to get extended error information.
LONG ADS_API CNT_SetFilter(LONG handle, WORD i_wSlot, DWORD i_dwWidth);

// Method: CNT_GetStartupValues
// action: Get the counter startup values of the indicated slot.
// pre   : handle = driver handler
//         i_wSlot = the slot ID which is ranged from 0 to 15.
//         i_wChannelTotal = the channel total of the module in the indicated slot. The maximum value is 8.
//         o_dwValues = the variables array to hold the counter startup values. The size of this array must be at least 8 DWORDs.
// post  : If getting values succeeded, function returns ERR_SUCCESS,
//         and the o_dwValues contains counter startup values from channel-0 to the last channel.
//         Otherwise, function returns error code.
//         If the error code is ERR_INTERNAL_FAILED, call GetLastError to get extended error information.
LONG ADS_API CNT_GetStartupValues(LONG handle, WORD i_wSlot, WORD i_wChannelTotal, DWORD* o_dwValues);

// Method: CNT_SetStartupValues
// action: Set the counter startup values of the indicated slot.
// pre   : handle = driver handler
//         i_wSlot = the slot ID which is ranged from 0 to 15.
//         i_wChannelTotal = the channel total of the module in the indicated slot.
//         i_dwValues = the values array to be set. The size of this array must be i_wChannelTotal DWORDs.
// post  : If setting values succeeded, function returns ERR_SUCCESS.
//         Otherwise, function returns error code.
//         If the error code is ERR_INTERNAL_FAILED, call GetLastError to get extended error information.
LONG ADS_API CNT_SetStartupValues(LONG handle, WORD i_wSlot, WORD i_wChannelTotal, DWORD* i_dwValues);

// Method: CNT_ClearOverflows
// action: Clear the counter overflow of the indicated slot.
// pre   : handle = driver handler
//         i_wSlot = the slot ID which is ranged from 0 to 15.
//         i_dwMask = the counter channel mask to be set. From LSB to MSB of the value indicate
//         the channel-0 to channel-31 mask. If the bit is 1, it means that the overflow of the channel must be cleared.
// post  : If clearing overflows succeeded, function returns ERR_SUCCESS.
//         Otherwise, function returns error code.
//         If the error code is ERR_INTERNAL_FAILED, call GetLastError to get extended error information.
LONG ADS_API CNT_ClearOverflows(LONG handle, WORD i_wSlot, DWORD i_dwMask);

// Method: CNT_GetAlarmFlags
// action: Get the counter alarm of the indicated slot.
// pre   : handle = driver handler
//         i_wSlot = the slot ID which is ranged from 0 to 15.
//         o_dwFlags = the variable to hold the counter alarm flags.
// post  : If getting alarm flags succeeded, function returns ERR_SUCCESS.
//         Otherwise, function returns error code.
//         If the error code is ERR_INTERNAL_FAILED, call GetLastError to get extended error information.
LONG ADS_API CNT_GetAlarmFlags(LONG handle, WORD i_wSlot, DWORD* o_dwFlags);

// Method: CNT_ClearAlarmFlags
// action: Clear the counter alarm of the indicated slot.
// pre   : handle = driver handler
//         i_wSlot = the slot ID which is ranged from 0 to 15.
//         i_dwMask = the alarm flags mask.
// post  : If clearing alarm flags succeeded, function returns ERR_SUCCESS.
//         Otherwise, function returns error code.
//         If the error code is ERR_INTERNAL_FAILED, call GetLastError to get extended error information.
LONG ADS_API CNT_ClearAlarmFlags(LONG handle, WORD i_wSlot, DWORD i_dwMask);

// Method: CNT_GetAlarmConfig
// action: Get the counter alarm configuration of the indicated slot.
// pre   : handle = driver handler
//         i_wSlot = the slot ID which is ranged from 0 to 15.
//         i_wAlarmIndex = the alarm index
//         o_bEnable = the variable to hold the alarm enabled status.
//         o_bAutoReload = the variable to hold the alarm auto reload status.
//         o_byType = the variable to hold the alarm type.
//                    0 : Low alarm
//                    1 : High alarm
//         o_byMapChannel = the variable to hold the counter channel that the alarm mapped to.
//         o_dwLimit = the variable to hold the counter limit which will fire the alarm.
//         o_byDoType = the variable to hold the DO type.
//                      0 : Low level
//                      1 : High level
//                      2 : Low pulse
//                      3 : High pulse
//         o_dwDoPulseWidth = the variable to hold the DO pulse width.
// post  : If getting alarm configuration succeeded, function returns ERR_SUCCESS.
//         Otherwise, function returns error code.
//         If the error code is ERR_INTERNAL_FAILED, call GetLastError to get extended error information.
LONG ADS_API CNT_GetAlarmConfig(LONG handle, WORD i_wSlot, WORD i_wAlarmIndex, BOOL* o_bEnable, BOOL* o_bAutoReload, BYTE* o_byType, BYTE* o_byMapChannel, DWORD* o_dwLimit, BYTE* o_byDoType, DWORD* o_dwDoPulseWidth);

// Method: CNT_SetAlarmConfig
// action: Set the counter alarm configuration of the indicated slot.
// pre   : handle = driver handler
//         i_wSlot = the slot ID which is ranged from 0 to 15.
//         i_wAlarmIndex = the alarm index
//         i_bEnable = the alarm enabled status to be set.
//         i_bAutoReload = the alarm auto reload status to be set.
//         i_byType = the alarm type to be set.
//                    0 : Low alarm
//                    1 : High alarm
//         i_byMapChannel = the counter channel that the alarm mapped to.
//         i_dwLimit = the counter limit which will fire the alarm.
//         i_byDoType = the DO type to be set.
//                      0 : Low level
//                      1 : High level
//                      2 : Low pulse
//                      3 : High pulse
//         i_dwDoPulseWidth = the DO pulse width to be set.
// post  : If setting alarm configuration succeeded, function returns ERR_SUCCESS.
//         Otherwise, function returns error code.
//         If the error code is ERR_INTERNAL_FAILED, call GetLastError to get extended error information.
LONG ADS_API CNT_SetAlarmConfig(LONG handle, WORD i_wSlot, WORD i_wAlarmIndex, BOOL i_bEnable, BOOL i_bAutoReload, BYTE i_byType, BYTE i_byMapChannel, DWORD i_dwLimit, BYTE i_byDoType, DWORD i_dwDoPulseWidth);

// Method: CNT_GetGateConfig
// action: Get the counter gate configuration of the indicated slot.
// pre   : handle = driver handler
//         i_wSlot = the slot ID which is ranged from 0 to 15.
//         i_wChannel = the counter index
//         o_bEnable = the variable to hold the gate enabled status.
//         o_byTriggerMode = the variable to hold the trigger mode.
//                           0 : Non re-trigger
//                           1 : Re-trigger
//                           2 : Edge start
//         o_byGateActiveType = the variable to hold the gate active type.
//                           0 : Low level
//                           1 : Falling edge
//                           2 : High level
//                           3 : Rising edge
//         o_byMapGate = the variable to hold the gate that the counter mapped to.
// post  : If getting gate configuration succeeded, function returns ERR_SUCCESS.
//         Otherwise, function returns error code.
//         If the error code is ERR_INTERNAL_FAILED, call GetLastError to get extended error information.
LONG ADS_API CNT_GetGateConfig(LONG handle, WORD i_wSlot, WORD i_wChannel, BOOL* o_bEnable, BYTE* o_byTriggerMode, BYTE* o_byGateActiveType, BYTE* o_byMapGate);

// Method: CNT_SetGateConfig
// action: Set the counter gate configuration of the indicated slot.
// pre   : handle = driver handler
//         i_wSlot = the slot ID which is ranged from 0 to 15.
//         i_wChannel = the counter index
//         i_bEnable = the gate enabled status.
//         i_byTriggerMode = the trigger mode.
//                           0 : Non re-trigger
//                           1 : Re-trigger
//                           2 : Edge start
//         i_byGateActiveType = the gate active type.
//                           0 : Low level
//                           1 : Falling edge
//                           2 : High level
//                           3 : Rising edge
//         i_byMapGate = the gate that the counter mapped to.
// post  : If setting gate configuration succeeded, function returns ERR_SUCCESS.
//         Otherwise, function returns error code.
//         If the error code is ERR_INTERNAL_FAILED, call GetLastError to get extended error information.
LONG ADS_API CNT_SetGateConfig(LONG handle, WORD i_wSlot, WORD i_wChannel, BOOL i_bEnable, BYTE i_byTriggerMode, BYTE i_byGateActiveType, BYTE i_byMapGate);

// Method: CNT_GetCntTypeConfig
// action: Get the counter counting type of the indicated slot.
// pre   : handle = driver handler
//         i_wSlot = the slot ID which is ranged from 0 to 15.
//         i_wChannel = the counter index
//         o_bRepeat = the variable to hold the repeat enabled status.
//         o_bReload = the variable to hold the reload to startup enabled status.
// post  : If setting counting type succeeded, function returns ERR_SUCCESS.
//         Otherwise, function returns error code.
//         If the error code is ERR_INTERNAL_FAILED, call GetLastError to get extended error information.
LONG ADS_API CNT_GetCntTypeConfig(LONG handle, WORD i_wSlot, WORD i_wChannel, BOOL* o_bRepeat, BOOL* o_bReload);

// Method: CNT_SetCntTypeConfig
// action: Set the counter counting type of the indicated slot.
// pre   : handle = driver handler
//         i_wSlot = the slot ID which is ranged from 0 to 15.
//         i_wChannel = the counter index
//         i_bRepeat = the repeat enabled status.
//         i_bReload = the reload to startup enabled status.
// post  : If getting counting type succeeded, function returns ERR_SUCCESS.
//         Otherwise, function returns error code.
//         If the error code is ERR_INTERNAL_FAILED, call GetLastError to get extended error information.
LONG ADS_API CNT_SetCntTypeConfig(LONG handle, WORD i_wSlot, WORD i_wChannel, BOOL i_bRepeat, BOOL i_bReload);

// Method: CNT_GetChannelStatus
// action: Get all channels status of the indicated slot.
// pre   : handle = driver handler
//         i_wSlot = the slot ID which is ranged from 0 to 15.
//         o_byStatus = the variables array to hold the channels status. The size of this array must be at least 8 BYTEs.
// post  : If getting channel status succeeded, function returns ERR_SUCCESS.
//         The value of o_byStatus indicates:
//         1  : Normal
//         8  : Over flow
//         9  : Under flow
//         10 : Over and Under flow
//         Otherwise, function returns error code.
//         If the error code is ERR_INTERNAL_FAILED, call GetLastError to get extended error information.
LONG ADS_API CNT_GetChannelStatus(LONG handle, WORD i_wSlot, BYTE* o_byStatus);

// Method: CNT_SetFreqAcqTime
// action: Set the counter frequency acquisition time of the indicated slot.
// pre   : handle = driver handler
//         i_wSlot = the slot ID which is ranged from 0 to 15.
//         i_dwFreqAcqTime = the frequency acquisition time
// post  : If setting frequency acquisition time succeeded, function returns ERR_SUCCESS.
//         Otherwise, function returns error code.
//         If the error code is ERR_INTERNAL_FAILED, call GetLastError to get extended error information.
LONG ADS_API CNT_SetFreqAcqTime(LONG handle, WORD i_wSlot, DWORD i_dwFreqAcqTime);

// 5081PG
LONG ADS_API CNT_GetCntConfig(LONG handle, WORD i_wSlot, WORD i_wChannel, BYTE* o_byFilterWidth, BYTE* o_byPulseWidth, WORD* o_wDelayWidth, BYTE* o_byConfig);
LONG ADS_API CNT_SetCntConfig(LONG handle, WORD i_wSlot, WORD i_wChannel, BYTE i_byFilterWidth, BYTE i_byPulseWidth, WORD i_wDelayWidth, BYTE i_byConfig);
LONG ADS_API CNT_GetFunConfig(LONG handle, WORD i_wSlot, BYTE* o_byEnableConfig, WORD* o_wErrorValue, BYTE* o_byWdtValue);
LONG ADS_API CNT_SetFunConfig(LONG handle, WORD i_wSlot, BYTE i_byEnableConfig, WORD i_wErrorValue, BYTE i_byWdtValue);
LONG ADS_API CNT_GetFunStatus(LONG handle, WORD i_wSlot, BYTE* o_byStatus1, BYTE* o_byStatus2);
LONG ADS_API CNT_SetFunStatus(LONG handle, WORD i_wSlot, BYTE i_byStatus1, BYTE i_byStatus2);

// Method: DIO_SetSaftyValues
// action: Set the DO safty values of the indicated slot.
// pre   : handle = driver handler
//         i_wSlot = the slot ID which is ranged from 0 to 31.
//         i_dwHighValue = the DO safty values from channel 32 to 63 to be set. The LSB indicates the channel-32.
//         i_dwLowValue = the DO safty values from channel 0 to 31 to be set. The LSB indicates the channel-0.
// post  : If setting safty values succeeded, function returns ERR_SUCCESS.
//         Otherwise, function returns error code.
//         If the error code is ERR_INTERNAL_FAILED, call GetLastError to get extended error information.
LONG ADS_API DIO_SetSaftyValues(LONG handle, WORD i_wSlot, DWORD i_dwHighValue, DWORD i_dwLowValue);

// Method: DIO_GetValues
// action: Get the all DIO safty values of the indicated slot.
// pre   : handle = driver handler
//         i_wSlot = the slot ID which is ranged from 0 to 31.
//         o_dwHighValue = the variable to hold the DIO safty values from channel 32 to 63. The LSB indicates the channel-32.
//         o_dwLowValue = the variable to hold the DIO safty values from channel 0 to 31. The LSB indicates the channel-0.
// post  : If getting values succeeded, function returns ERR_SUCCESS,
//         and the o_dwHighValue and o_dwLowValue contain DIO values from channel-0 to the last channel.
//         Otherwise, function returns error code.
//         If the error code is ERR_INTERNAL_FAILED, call GetLastError to get extended error information.
LONG ADS_API DIO_GetSaftyValues(LONG handle, WORD i_wSlot, DWORD* o_dwHighValue, DWORD* o_dwLowValue);

// Method: AO_SetSaftyValues
// action: Set the AO safty values of the indicated slot.
// pre   : handle = driver handler
//         i_wSlot = the slot ID which is ranged from 0 to 15.
//         i_wChannelTotal = the channel total of the module in the indicated slot.
//         i_wValues = the AO safty values to be set.
// post  : If setting values succeeded, function returns ERR_SUCCESS.
//         Otherwise, function returns error code.
//         If the error code is ERR_INTERNAL_FAILED, call GetLastError to get extended error information.
LONG ADS_API AO_SetSaftyValues(LONG handle, WORD i_wSlot, WORD i_wChannelTotal, WORD* i_wValues);

// Method: AO_GetSaftyValues
// action: Get the all AIO safty values of the indicated slot.
// pre   : handle = driver handler
//         i_wSlot = the slot ID which is ranged from 0 to 15.
//         i_wChannelTotal = the channel total of the module in the indicated slot.
//         o_wValues = the variables array to hold the AIO safty values. The size of this array must be at least 32 WORDs.
// post  : If getting values succeeded, function returns ERR_SUCCESS,
//         and the o_wValue contains AIO values from channel-0 to the last channel.
//         Otherwise, function returns error code.
//         If the error code is ERR_INTERNAL_FAILED, call GetLastError to get extended error information.
LONG ADS_API AO_GetSaftyValues(LONG handle, WORD i_wSlot, WORD i_wChannelTotal, WORD* o_wValues);

// Method: OUT_SetSaftyEnable
// action: Set the safty value enabled status of the indicated slot.
// pre   : handle = driver handler
//         i_wSlot = the slot ID which is ranged from 0 to 15.
//         i_bEnable = the safty value enabled status.
// post  : If setting enabled status succeeded, function returns ERR_SUCCESS.
//         Otherwise, function returns error code.
//         If the error code is ERR_INTERNAL_FAILED, call GetLastError to get extended error information.
LONG ADS_API OUT_SetSaftyEnable(LONG handle, WORD i_wSlot, BOOL i_bEnable);

// Method: OUT_GetSaftyEnable
// action: Get the safty value enabled status of the indicated slot.
// pre   : handle = driver handler
//         i_wSlot = the slot ID which is ranged from 0 to 15.
//         o_bEnable = the varibale hold the safty value enabled status.
// post  : If getting enabled status succeeded, function returns ERR_SUCCESS.
//         Otherwise, function returns error code.
//         If the error code is ERR_INTERNAL_FAILED, call GetLastError to get extended error information.
LONG ADS_API OUT_GetSaftyEnable(LONG handle, WORD i_wSlot, BOOL* o_bEnable);

// Method: SYS_SetLocateModule
// action: Set the LED light flashing of the indicated slot.
// pre   : handle = driver handler
//         i_wSlot = the slot ID which is ranged from 0 to 15.
//         i_wTimes = the LED flashing time.
// post  : If setting succeeded, function returns ERR_SUCCESS.
//         Otherwise, function returns error code.
//         If the error code is ERR_INTERNAL_FAILED, call GetLastError to get extended error information.
LONG ADS_API SYS_SetLocateModule(LONG handle, WORD i_wSlot, WORD i_wTimes);

// Method: PWM_SetChannelMask
// action: Set enabled PWM channel mask of the indicated slot.
// pre   : handle = driver handler
//         i_wSlot = the slot ID which is ranged from 0 to 15.
//         i_dwMask = the enabled PWM channel mask to be set. From LSB to MSB of the value indicate
//         the channel-0 to channel-31 enabled mask. 
//         If the bit is 1, it means that the PWM channel start to output. Otherwise, stop outputting.
// post  : If setting channel mask succeeded, function returns ERR_SUCCESS.
//         Otherwise, function returns error code.
//         If the error code is ERR_INTERNAL_FAILED, call GetLastError to get extended error information.
LONG ADS_API PWM_SetChannelMask(LONG handle, WORD i_wSlot, DWORD i_dwMask);

// Method: PWM_GetChannelMask
// action: Get enabled PWM channel mask of the indicated slot.
// pre   : handle = driver handler
//         i_wSlot = the slot ID which is ranged from 0 to 15.
//         o_dwMask = a variable to hold the enabled PWM channel mask. From LSB to MSB of the value indicate
//         the channel-0 to channel-31 enabled mask. 
//         If the bit is 1, it means that the PWM channel start to output. Otherwise, stop outputting.
// post  : If getting channel mask succeeded, function returns ERR_SUCCESS.
//         Otherwise, function returns error code.
//         If the error code is ERR_INTERNAL_FAILED, call GetLastError to get extended error information.
LONG ADS_API PWM_GetChannelMask(LONG handle, WORD i_wSlot, DWORD* o_dwMask);

// Method: PWM_GetConfig
// action: Get the channel configuration of the indicated slot.
// pre   : handle = driver handler
//         i_wSlot = the slot ID which is ranged from 0 to 15.
//         i_wChannel = the channel index
//         o_dwFreq = a variable to hold the channel's frequency. [1 ~ 30K Hz]
//         o_fDuty = a variable to hold the channel's duty cycle. [0.1 ~ 99.9 %]
// post  : If Getting configuration succeeded, function returns ERR_SUCCESS.
//         Otherwise, function returns error code.
//         If the error code is ERR_INTERNAL_FAILED, call GetLastError to get extended error information.
LONG ADS_API PWM_GetConfig(LONG handle, WORD i_wSlot, WORD i_wChannel, DWORD *o_dwFreq, float *o_fDuty);

// Method: PWM_SetConfig
// action: Set the channel configuration of the indicated slot.
// pre   : handle = driver handler
//         i_wSlot = the slot ID which is ranged from 0 to 15.
//         i_wChannel = the channel index
//         i_dwFreq = the frequency of the channel. [1 ~ 30K Hz]
//         i_fDuty = the duty cycle of the channel. [0.1 ~ 99.9 %]
// post  : If Setting configuration succeeded, function returns ERR_SUCCESS.
//         Otherwise, function returns error code.
//         If the error code is ERR_INTERNAL_FAILED, call GetLastError to get extended error information.
LONG ADS_API PWM_SetConfig(LONG handle, WORD i_wSlot, WORD i_wChannel, DWORD i_dwFreq, float i_fDuty);


#ifdef __cplusplus
}
#endif