#ifndef _INC_EVENT_H
#define _INC_EVENT_H
// ############################################################################
// ****************************************************************************
//              Copyright (C) 2000-2, Advantech Automation Corp.
//      THIS IS AN UNPUBLISHED WORK CONTAINING CONFIDENTIAL AND PROPRIETARY
//         INFORMATION WHICH IS THE PROHERTY OF ADVANTECH AUTOMATION CORP.
// 
//   ANY DISCLOSURE, USE, OR REPRODUCTION, WITHOUT WRITTEN AUTHORIZATION FROM
//             ADVANTECH AUTOMATION CORP., IS STRICTLY PROHIBITED
// ****************************************************************************
// ############################################################################
//
// File:        EVENT.H
// Created:     11/07/2002
// Description: Event type definition headfile.
// ============================================================================
// VERSION HISTORY
// 11/07/2002  Create
// 12/24/2002  Update for Version 2.0B 
// ============================================================================
// Notes:
// 1. Bit-mapped ID:
//    From 0x0001 to 0x0200 : defined at Driver.h, BIT-mapped Event ID.
//    From 0x0201 to 0x0205 : defined at Driver.h  ID-mapped Event ID.
//    From 0x0206 to 0x0fff : not used
//    From 0x1000 to 0xffff : defined at Event.h   ID-mapped Event ID.
//
// 2. Version 2.0A and before don't use Event.h.
//
// 3. EventID = 0x0000 is reserved for non event or error.
//    EventID = 0xffff is reserved for time out.
//
// 4. The sub event naming standard from 0x1000 to 0x6fff: 
//      0x1000 ~ 0x1fff    for AI Event Group
//         0x1000 ~ 0x17ff for General AI Event ID
//         0x1800 ~ 0x18ff for AI others Event ID
//      0x2000 ~ 0x2fff    for AO Event Group
//         0x2000 ~ 0x27ff for General AO Event ID
//         0x2800 ~ 0x28ff for AO others Event ID
//      0x3000 ~ 0x3fff    for DI Event Group
//         0x3000 ~ 0x30ff for General DI Event ID
//         0x3400 ~ 0x34ff for General IDI Event ID
//         0x3800 ~ 0x3fff for others Event ID
//      0x4000 ~ 0x4fff for DO Event Group
//         0x4000 ~ 0x47ff for DO Gernal Event ID
//         0x4800 ~ 0x48ff for DO others Event ID
//      0x5000 ~ 0x5fff for Counter/Timer Event Group
//         0x5000 ~ 0x50ff for Counter TC Event ID
//         0x5100 ~ 0x51ff for counter OverFlow Event ID
//         0x5200 ~ 0x52ff for counter UnderFlow Event ID
//         0x5300 ~ 0x53ff for counter OverCompare Event ID
//         0x5400 ~ 0x54ff for counter UnderCompare Event ID
//         0x5500 ~ 0x55ff for General Timer Event ID
//         0x5800 ~ 0x58ff for Counter/Timer others Event ID
//      0x6000 ~ 0x6fff not used at Version 2.0B


// ==================================
// 0x0000 and 0xffff
// ----------------------------------
#define  ADS_EVT_NO_EVENT             0x0000
#define  ADS_EVT_TIME_OUT             0xffff

// ==================================
// 0x1000 ~ 0x1fff for AI Group Event
// ----------------------------------
//sub group 0x1800 ~ 0x18ff for AI others Event ID
#define  ADS_EVT_AI_BUFFER1_FULL      0x1800
#define  ADS_EVT_AI_BUFFER2_FULL      0x1801

#define     ADS_EVT_AI_BUFFER1_FULL_NAME	    "ADS_EVT_AI_BUFFER1_FULL"
#define     ADS_EVT_AI_BUFFER2_FULL_NAME	    "ADS_EVT_AI_BUFFER2_FULL"

// ----------------------------------
// 0x2000 ~ 0x2fff for AO Group Event
// ----------------------------------
// sub group 0x2800 ~ 0x28ff for AO oters Event ID
#define  ADS_EVT_AO_BUFFER1_EMPTY     0x2800
#define  ADS_EVT_AO_BUFFER2_EMPTY     0x2801

#define     ADS_EVT_AO_BUFFER1_FULL_NAME	     "ADS_EVT_AO_BUFFER1_FULL"
#define     ADS_EVT_AO_BUFFER2_FULL_NAME	     "ADS_EVT_AO_BUFFER2_FULL"

// ----------------------------------
// 0x3000 ~ 0x3fff for DI Group Event
// ----------------------------------
// sub group 0x3000 ~ 0x30ff for General DI Event ID
#define  ADS_EVT_INTERRUPT_DI0        0x3000
#define  ADS_EVT_INTERRUPT_DI1        (ADS_EVT_INTERRUPT_DI0 + 1)
#define  ADS_EVT_INTERRUPT_DI2        (ADS_EVT_INTERRUPT_DI0 + 2)
#define  ADS_EVT_INTERRUPT_DI3        (ADS_EVT_INTERRUPT_DI0 + 3)
#define  ADS_EVT_INTERRUPT_DI4        (ADS_EVT_INTERRUPT_DI0 + 4)
#define  ADS_EVT_INTERRUPT_DI5        (ADS_EVT_INTERRUPT_DI0 + 5)
#define  ADS_EVT_INTERRUPT_DI6        (ADS_EVT_INTERRUPT_DI0 + 6)
#define  ADS_EVT_INTERRUPT_DI7        (ADS_EVT_INTERRUPT_DI0 + 7)
//  ...  ...
#define     ADS_EVT_INTERRUPT_DI0_NAME		   "ADS_EVT_INTERRUPT_DI0"
#define     ADS_EVT_INTERRUPT_DI1_NAME		   "ADS_EVT_INTERRUPT_DI1"
#define     ADS_EVT_INTERRUPT_DI2_NAME		   "ADS_EVT_INTERRUPT_DI2"
#define     ADS_EVT_INTERRUPT_DI3_NAME		   "ADS_EVT_INTERRUPT_DI3"
#define     ADS_EVT_INTERRUPT_DI4_NAME		   "ADS_EVT_INTERRUPT_DI4"
#define     ADS_EVT_INTERRUPT_DI5_NAME		   "ADS_EVT_INTERRUPT_DI5"
#define     ADS_EVT_INTERRUPT_DI6_NAME		   "ADS_EVT_INTERRUPT_DI6"
#define     ADS_EVT_INTERRUPT_DI7_NAME		   "ADS_EVT_INTERRUPT_DI7"

// sub group 0x3400 ~ 0x37ff for General IDI Event ID
#define  ADS_EVT_INTERRUPT_IDI0       0x3400
#define  ADS_EVT_INTERRUPT_IDI1       (ADS_EVT_INTERRUPT_IDI0 + 1)
#define  ADS_EVT_INTERRUPT_IDI2       (ADS_EVT_INTERRUPT_IDI0 + 2)
#define  ADS_EVT_INTERRUPT_IDI3       (ADS_EVT_INTERRUPT_IDI0 + 3)
#define  ADS_EVT_INTERRUPT_IDI4       (ADS_EVT_INTERRUPT_IDI0 + 4)
#define  ADS_EVT_INTERRUPT_IDI5       (ADS_EVT_INTERRUPT_IDI0 + 5)
#define  ADS_EVT_INTERRUPT_IDI6       (ADS_EVT_INTERRUPT_IDI0 + 6)
#define  ADS_EVT_INTERRUPT_IDI7       (ADS_EVT_INTERRUPT_IDI0 + 7)
#define  ADS_EVT_INTERRUPT_IDI16      (ADS_EVT_INTERRUPT_IDI0 + 16)
#define  ADS_EVT_INTERRUPT_IDI17      (ADS_EVT_INTERRUPT_IDI0 + 17)
//  ...  ...
#define     ADS_EVT_INTERRUPT_IDI0_NAME		    "ADS_EVT_INTERRUPT_IDI0"
#define     ADS_EVT_INTERRUPT_IDI1_NAME		    "ADS_EVT_INTERRUPT_IDI1"
#define     ADS_EVT_INTERRUPT_IDI2_NAME		    "ADS_EVT_INTERRUPT_IDI2"
#define     ADS_EVT_INTERRUPT_IDI3_NAME		    "ADS_EVT_INTERRUPT_IDI3"
#define     ADS_EVT_INTERRUPT_IDI4_NAME		    "ADS_EVT_INTERRUPT_IDI4"
#define     ADS_EVT_INTERRUPT_IDI5_NAME		    "ADS_EVT_INTERRUPT_IDI5"
#define     ADS_EVT_INTERRUPT_IDI6_NAME		    "ADS_EVT_INTERRUPT_IDI6"
#define     ADS_EVT_INTERRUPT_IDI7_NAME		    "ADS_EVT_INTERRUPT_IDI7"
#define     ADS_EVT_INTERRUPT_IDI16_NAME	    "ADS_EVT_INTERRUPT_IDI16"
#define     ADS_EVT_INTERRUPT_IDI17_NAME	    "ADS_EVT_INTERRUPT_IDI17"

// sub group 0x3800 ~ 0x38ff for DI others Event ID
#define  ADS_EVT_FIFO_OVERFLOW_DI     0x3800
#define  ADS_EVT_FIFO_UNDERFLOW_DI    0x3801
#define  ADS_EVT_BUFFER1_FULL_DI      0x3802
#define  ADS_EVT_BUFFER2_FULL_DI      0x3803

//\\\\\\\\\\\\\\\\\\\\ 2.0C ///////////////////
#define  ADS_EVT_DI_LOBUFREADY        0x3804   
#define  ADS_EVT_DI_HIBUFREADY        0x3805   
#define  ADS_EVT_DI_TERMINATED        0x3810   
#define  ADS_EVT_DI_OVERRUN           0x3811   
#define  ADS_EVT_DI_PATTERNMATCH      0x3812   
#define  ADS_EVT_DI_STATUSCHANGE      0x3813 
////////////////////// 2.0C \\\\\\\\\\\\\\\\\\


#define     ADS_EVT_FIFO_OVERFLOW_DI_NAME	    "ADS_EVT_FIFO_OVERFLOW_DI"
#define     ADS_EVT_FIFO_UNDERFLOW_DI_NAME	    "ADS_EVT_FIFO_UNDERFLOW_DI"
#define     ADS_EVT_BUFFER1_FULL_DI_NAME	    "ADS_EVT_BUFFER1_FULL_DI"
#define     ADS_EVT_BUFFER2_FULL_DI_NAME	    "ADS_EVT_BUFFER2_FULL_DI"
#define     ADS_EVT_DI_LOBUFREADY_NAME        "ADS_EVT_DI_LOBUFREADY"
#define     ADS_EVT_DI_HIBUFREADY_NAME        "ADS_EVT_DI_HIBUFREADY"
#define     ADS_EVT_DI_TERMINATED_NAME        "ADS_EVT_DI_TERMINATED"
#define     ADS_EVT_DI_OVERRUN_NAME           "ADS_EVT_DI_OVERRUN"
#define     ADS_EVT_DI_PATTERNMATCH_NAME      "ADS_EVT_DI_PATTERNMATCH"
#define     ADS_EVT_DI_STATUSCHANGE_NAME      "ADS_EVT_DI_STATUSCHANGE"

// ----------------------------------
// 0x4000 ~ 0x4fff for DO Group Event
// ----------------------------------
// sub group 0x4000 ~ 0x47ff for DO General Event ID

// sub group 0x4800 ~ 0x48ff for DO others Event ID
#define  ADS_EVT_FIFO_OVERFLOW_DO     0x4800
#define  ADS_EVT_FIFO_UNDERFLOW_DO    0x4801
#define  ADS_EVT_BUFFER1_EMPTY_DO     0x4802
#define  ADS_EVT_BUFFER2_EMPTY_DO     0x4803
//\\\\\\\\\\\\\\\\\\ 2.0C /////////////////
#define ADS_EVT_DO_LOBUFTRANS         0x4804
#define ADS_EVT_DO_HIBUFTRANS         0x4805
#define ADS_EVT_DO_TERMINATED         0x4810
#define ADS_EVT_DO_UNDERRUN           0x4811
//////////////////// 2.0C \\\\\\\\\\\\\\\\\/

#define     ADS_EVT_FIFO_OVERFLOW_DO_NAME	    "ADS_EVT_FIFO_OVERFLOW_DO"
#define     ADS_EVT_FIFO_UNDERFLOW_DO_NAME	    "ADS_EVT_FIFO_UNDERFLOW_DO"
#define     ADS_EVT_BUFFER1_EMPTY_DO_NAME	    "ADS_EVT_BUFFER1_EMPTY_DO"
#define     ADS_EVT_BUFFER2_EMPTY_DO_NAME	    "ADS_EVT_BUFFER2_EMPTY_DO"
#define     ADS_EVT_DO_LOBUFTRANS_NAME	       "ADS_EVT_DO_LOBUFTRANS"
#define     ADS_EVT_DO_HIBUFTRANS_NAME	       "ADS_EVT_DO_HIBUFTRANS"
#define     ADS_EVT_DO_TERMINATED_NAME	       "ADS_EVT_DO_TERMINATED"
#define     ADS_EVT_DO_UNDERRUN_NAME	       "ADS_EVT_DO_UNDERRUN"

// ---------------------------------------
// 0x5000 ~ 0x5fff for Counter/Timer Event 
// ---------------------------------------
// sub group 0x5000 ~ 0x50ff for Counter terminal count Event ID
#define  ADS_EVT_TERMINATE_CNT0       0x5000
#define  ADS_EVT_TERMINATE_CNT1       (ADS_EVT_TERMINATE_CNT0 + 1)
#define  ADS_EVT_TERMINATE_CNT2       (ADS_EVT_TERMINATE_CNT0 + 2)
#define  ADS_EVT_TERMINATE_CNT3       (ADS_EVT_TERMINATE_CNT0 + 3)
#define  ADS_EVT_TERMINATE_CNT4       (ADS_EVT_TERMINATE_CNT0 + 4)
#define  ADS_EVT_TERMINATE_CNT5       (ADS_EVT_TERMINATE_CNT0 + 5)
#define  ADS_EVT_TERMINATE_CNT6       (ADS_EVT_TERMINATE_CNT0 + 6)
#define  ADS_EVT_TERMINATE_CNT7       (ADS_EVT_TERMINATE_CNT0 + 7)
//  ...  ...
#define     ADS_EVT_TERMINATE_CNT0_NAME             "ADS_EVT_TERMINATE_CNT0"
#define     ADS_EVT_TERMINATE_CNT1_NAME             "ADS_EVT_TERMINATE_CNT1"
#define     ADS_EVT_TERMINATE_CNT2_NAME             "ADS_EVT_TERMINATE_CNT2"
#define     ADS_EVT_TERMINATE_CNT3_NAME             "ADS_EVT_TERMINATE_CNT3"
#define     ADS_EVT_TERMINATE_CNT4_NAME             "ADS_EVT_TERMINATE_CNT4"
#define     ADS_EVT_TERMINATE_CNT5_NAME             "ADS_EVT_TERMINATE_CNT5"
#define     ADS_EVT_TERMINATE_CNT6_NAME             "ADS_EVT_TERMINATE_CNT6"
#define     ADS_EVT_TERMINATE_CNT7_NAME             "ADS_EVT_TERMINATE_CNT7"

// sub group 0x5100 ~ 0x51ff for counter overflow Event ID
#define  ADS_EVT_OVERFLOW_CNT0        0x5100
#define  ADS_EVT_OVERFLOW_CNT1        (ADS_EVT_OVERFLOW_CNT0 + 1)
#define  ADS_EVT_OVERFLOW_CNT2        (ADS_EVT_OVERFLOW_CNT0 + 2)
#define  ADS_EVT_OVERFLOW_CNT3        (ADS_EVT_OVERFLOW_CNT0 + 3)
#define  ADS_EVT_OVERFLOW_CNT4        (ADS_EVT_OVERFLOW_CNT0 + 4)
#define  ADS_EVT_OVERFLOW_CNT5        (ADS_EVT_OVERFLOW_CNT0 + 5)
#define  ADS_EVT_OVERFLOW_CNT6        (ADS_EVT_OVERFLOW_CNT0 + 6)
#define  ADS_EVT_OVERFLOW_CNT7        (ADS_EVT_OVERFLOW_CNT0 + 7)
//  ...  ...
#define     ADS_EVT_OVERFLOW_CNT0_NAME              "ADS_EVT_OVERFLOW_CNT0"
#define     ADS_EVT_OVERFLOW_CNT1_NAME              "ADS_EVT_OVERFLOW_CNT1"
#define     ADS_EVT_OVERFLOW_CNT2_NAME              "ADS_EVT_OVERFLOW_CNT2"
#define     ADS_EVT_OVERFLOW_CNT3_NAME              "ADS_EVT_OVERFLOW_CNT3"
#define     ADS_EVT_OVERFLOW_CNT4_NAME              "ADS_EVT_OVERFLOW_CNT4"
#define     ADS_EVT_OVERFLOW_CNT5_NAME              "ADS_EVT_OVERFLOW_CNT5"
#define     ADS_EVT_OVERFLOW_CNT6_NAME              "ADS_EVT_OVERFLOW_CNT6"
#define     ADS_EVT_OVERFLOW_CNT7_NAME              "ADS_EVT_OVERFLOW_CNT7"

// sub group 0x5200 ~ 0x52ff for counter underflow Event ID
#define  ADS_EVT_UNDERFLOW_CNT0       0x5200
#define  ADS_EVT_UNDERFLOW_CNT1       (ADS_EVT_UNDERFLOW_CNT0 + 1)
#define  ADS_EVT_UNDERFLOW_CNT2       (ADS_EVT_UNDERFLOW_CNT0 + 2)
#define  ADS_EVT_UNDERFLOW_CNT3       (ADS_EVT_UNDERFLOW_CNT0 + 3)
#define  ADS_EVT_UNDERFLOW_CNT4       (ADS_EVT_UNDERFLOW_CNT0 + 4)
#define  ADS_EVT_UNDERFLOW_CNT5       (ADS_EVT_UNDERFLOW_CNT0 + 5)
#define  ADS_EVT_UNDERFLOW_CNT6       (ADS_EVT_UNDERFLOW_CNT0 + 6)
#define  ADS_EVT_UNDERFLOW_CNT7       (ADS_EVT_UNDERFLOW_CNT0 + 7)
//  ...  ...
#define     ADS_EVT_UNDERFLOW_CNT0_NAME             "ADS_EVT_UNDERFLOW_CNT0"
#define     ADS_EVT_UNDERFLOW_CNT1_NAME             "ADS_EVT_UNDERFLOW_CNT1"
#define     ADS_EVT_UNDERFLOW_CNT2_NAME             "ADS_EVT_UNDERFLOW_CNT2"
#define     ADS_EVT_UNDERFLOW_CNT3_NAME             "ADS_EVT_UNDERFLOW_CNT3"
#define     ADS_EVT_UNDERFLOW_CNT4_NAME             "ADS_EVT_UNDERFLOW_CNT4"
#define     ADS_EVT_UNDERFLOW_CNT5_NAME             "ADS_EVT_UNDERFLOW_CNT5"
#define     ADS_EVT_UNDERFLOW_CNT6_NAME             "ADS_EVT_UNDERFLOW_CNT6"
#define     ADS_EVT_UNDERFLOW_CNT7_NAME             "ADS_EVT_UNDERFLOW_CNT7"

// sub group 0x5300 ~ 0x53ff for counter OVER COMPARE Event ID
//  ...  ...
// sub group 0x5400 ~ 0x54ff for counter UNDER COMPARE Event ID
//  ...  ...
// sub group 0x5500 ~ 0x55ff for GENERAL TIMER Event ID
#define  ADS_EVT_INTERRUPT_TIMER0     0x5500       
#define  ADS_EVT_INTERRUPT_TIMER1     (ADS_EVT_INTERRUPT_TIMER0 + 1)
#define  ADS_EVT_INTERRUPT_TIMER2     (ADS_EVT_INTERRUPT_TIMER0 + 2)
#define  ADS_EVT_INTERRUPT_TIMER3     (ADS_EVT_INTERRUPT_TIMER0 + 3)
#define  ADS_EVT_INTERRUPT_TIMER4     (ADS_EVT_INTERRUPT_TIMER0 + 4)
#define  ADS_EVT_INTERRUPT_TIMER5     (ADS_EVT_INTERRUPT_TIMER0 + 5)
#define  ADS_EVT_INTERRUPT_TIMER6     (ADS_EVT_INTERRUPT_TIMER0 + 6)
#define  ADS_EVT_INTERRUPT_TIMER7     (ADS_EVT_INTERRUPT_TIMER0 + 7)
//\\\\\\\\\\\\\\\\\ 2.0C ////////////////
#define  ADS_EVT_TC_TIMER             0x5200    
/////////////////// 2.0C \\\\\\\\\\\\\\\\


//  ...  ...
#define     ADS_EVT_INTERRUPT_TIMER0_NAME          "ADS_EVT_INTERRUPT_TIMER0"
#define     ADS_EVT_INTERRUPT_TIMER1_NAME          "ADS_EVT_INTERRUPT_TIMER1"
#define     ADS_EVT_INTERRUPT_TIMER2_NAME          "ADS_EVT_INTERRUPT_TIMER2"
#define     ADS_EVT_INTERRUPT_TIMER3_NAME          "ADS_EVT_INTERRUPT_TIMER3"
#define     ADS_EVT_INTERRUPT_TIMER4_NAME          "ADS_EVT_INTERRUPT_TIMER4"
#define     ADS_EVT_INTERRUPT_TIMER5_NAME          "ADS_EVT_INTERRUPT_TIMER5"
#define     ADS_EVT_INTERRUPT_TIMER6_NAME          "ADS_EVT_INTERRUPT_TIMER6"
#define     ADS_EVT_INTERRUPT_TIMER7_NAME          "ADS_EVT_INTERRUPT_TIMER7"
#define     ADS_EVT_TC_TIMERNAME                   "ADS_EVT_TC_TIMER"

// sub group 0x5800 ~ 0x58ff for COUNTER/TIMER others Event ID

#endif
