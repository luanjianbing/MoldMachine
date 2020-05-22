#ifdef __cplusplus
extern "C"
{
#endif

// define the event callback functions
typedef void (*OnAioChangeEvent)(int i_iSlot, DWORD i_dwChannelChangedMask, FLOAT *i_fValues, SYSTEMTIME *i_timeStamp);
typedef void (*OnDioChangeEvent)(int i_iSlot, DWORD i_dwChannelChangedMask, DWORD i_dwValues, SYSTEMTIME *i_timeStamp);

// Method: AutoPolling_StartPolling
// action: Start the auto polling thread
// pre   : i_hHandle = driver handler
//         i_aioEventHandle = AIO changed callback function.
//         i_iAioRate = AIO polling rate
//         i_dioEventHandl = DIO changed callback function.
//         i_iDioRate = DIO polling rate
// post  : If starting succeeded, function returns TRUE.
//         Otherwise, function returns FALSE.
BOOL AutoPolling_StartPolling(LONG i_lHandle, OnAioChangeEvent i_aioEventHandle, int i_iAioRate, OnDioChangeEvent i_dioEventHandl, int i_iDioRate);

// Method: AutoPolling_StopPolling
// action: Stop the auto polling thread
// pre   :
// post  :
void AutoPolling_StopPolling();

#ifdef __cplusplus
}
#endif
