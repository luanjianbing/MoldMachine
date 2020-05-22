#ifndef _INC_PARAS_H
#define _INC_PARAS_H
// ############################################################################
// ****************************************************************************
//              Copyright (C) 2000-3, Advantech Automation Corp.
//      THIS IS AN UNPUBLISHED WORK CONTAINING CONFIDENTIAL AND PROPRIETARY
//         INFORMATION WHICH IS THE PROHERTY OF ADVANTECH AUTOMATION CORP.
// 
//   ANY DISCLOSURE, USE, OR REPRODUCTION, WITHOUT WRITTEN AUTHORIZATION FROM
//             ADVANTECH AUTOMATION CORP., IS STRICTLY PROHIBITED
// ****************************************************************************
// ############################################################################
//
// File:        PARAS.H
// Created:     01/03/2003
// Description: Get parameter definition headfile.
// ============================================================================
// VERSION HISTORY
// 01/03/2003  Create
// ============================================================================
// Notes:
// 1. From 0x0000 to 0x0FFF : General definition
/**/
#define CFG_DeviceNumber                 0x0000
#define CFG_BoardID                      0x0001
#define CFG_SwitchID                     0x0002
#define CFG_BaseAddress                  0x0003
#define CFG_Interrupt                    0x0004
#define CFG_BusNumber                    0x0005
#define CFG_SlotNumber                   0x0006
#define CFG_OnSystem                     0x0007


#define     CFG_DeviceNumber_Name           "DeviceNumber"
#define     CFG_BoardID_Name                "BoardID"
#define     CFG_SwitchID_Name               "SwitchID"
#define     CFG_BaseAddress_Name            "BaseAddress"
#define     CFG_Interrupt_Name              "Interrupt"
#define     CFG_BusNumber_Name              "BusNumber"
#define     CFG_SlotNumber_Name             "SlotNumber"      // slot number
#define     CFG_OnSystem_Name               "OnSystem"        // This device on system or not



//
// 2. From 0x1000 to 0x1FFF : AI related 
//
// 3. From 0x2000 to 0x2FFF : AO related
//
// 4. From 0x3000 to 0x37FF : DIO Configuration related
//
// 5. From 0x3700 to 0x3FFF : DI related
//
// 6. From 0x4000 to 0x4FFF : DO related
//
// 7. From 0x5000 to 0x5FFF : Counter/Timer related
//
// 8. From 0x6000 to 0x6FFF : Other function related


// ==================================
// 0x1000 ~ 0x1fff for AI Group 
// ----------------------------------

// ----------------------------------
// 0x2000 ~ 0x2fff for AO Group 
// ----------------------------------
// sub group 0x2000 ~ 0x27ff for AO General ID
#define  AO_RANGE_SETTING                  0x2000

#define     AO_RANGE_SETTINGL_NAME		       "AO_RANGE_SETTING"
// sub group 0x2800 ~ 0x2fff for AO other ID


// ----------------------------------
// 0x3000 ~ 0x37ff for DIO Configuration Group 
// ----------------------------------
// sub group 0x3000 ~ 0x37ff for DIO Configuration ID
#define  CFG_DioDirection                  0x3000     // each bit for one Auxiliary DIO channel for PCI-1755.
#define  CFG_DioFdioDirection              0x3001     // 32DI(0)/32DO(1)/ 16 DIO(2) / 8DIO(3) for PCI-1755
#define  CFG_DioTerminator                 0x3002     // Bit 0: DI terminator (DI_TERM),ON (0) or OFF(1) for PCI-1755
                                                      // Bit 1: DO terminator (DI_TERM) ON (0) or OFF(1) for PCI-1755
#define  CFG_DiOperationMode               0x3003     // normal mode (0), 8255 handshaking(1), Burst handshaking(2) for PCI-1755


#define CFG_DioDirection_Name      "DioDirection"      // each bit for one Auxiliary DIO channel.
#define CFG_DioFdioDirection_Name  "DioFdioDirection"  // 32DI(0)/32DO(1)/ 16 DIO(2) / 8DIO(3)
#define CFG_DioTerminator_Name     "DioTerminator"     // Bit 0: DI terminator (DI_TERM),ON (0) or OFF(1)
                                                  // Bit 1: DO terminator (DI_TERM) ON (0) or OFF(1)

// Fast DI functions
#define CFG_DiOperationMode_Name   "DiOperationMode"   // normal mode (0), 8255 handshaking(1), Burst handshaking(2)


// sub group 0x3800 ~ 0x3fff for DI General and others ID
#define CFG_DiStartMethod     0x3800     // Software(1), External trigger(2), Pattern match(3)
#define CFG_DiStopMethod      0x3801     // Software(1), External trigger(2), Pattern match(3)
#define CFG_DiPacerSource     0x3802     // 30MHz(1), 15Mhz(2), 10MHz(3), Counter 0 OUT (4), External (5).
#define CFG_DiControlSignals  0x3803     // Bit 0: External DI start signal control (STRRF), 0 rising edge, 1 falling edge. 
                                         // Bit 1: External DI stop signal control (STPRF), 0 rising edge, 1 falling edge.
                                         // Bit 2: DI request signal control (REQRF), 0 rising edge, 1 falling edge.
                                         // Bit 3: DI acknowledge signal control (ACKRF), 0 rising edge, 1 falling edge.
                                         // Bit 4: DI sampling clock signal control (CLKRF), 0 rising edge, 1 falling edge
#define CFG_DiPatternMatchValue 0x3804

#define    CFG_DiStartMethod_Name        "DiStartMethod"
#define    CFG_DiStopMethod_Name         "DiStopMethod"      
#define    CFG_DiPacerSource_Name        "DiPacerSource"  
#define    CFG_DiControlSignals_Name     "DiControlSignals" 
#define    CFG_DiPatternMatchValue_Name  "DiPatternMatchValue"  



// ----------------------------------
// 0x4000 ~ 0x4fff for DO Group 
// ----------------------------------
// sub group 0x4000 ~ 0x47ff for DO General ID

// sub group 0x4800 ~ 0x4fff for DO others ID
// Fast DO functions paramaters
#define CFG_DoOperationMode   0x4800     // Normal (0), Handahaking (1), Burst handshaking(2)
#define CFG_DoStartMethod     0x4801     // Software(1), External signal(2)
#define CFG_DoStopMethod      0x4802     // Software(1), External signal(2)
#define CFG_DoPacerSource     0x4803     // 30, 15, 10 Mhz, Counter1, External signal (value range 1-5)
#define CFG_DoControlSignals  0x4804     // Control signals 
                                         //   Bit 0: External DO start signal control (STRRF), 0 rising edge, 1 falling edge. 
                                         //   Bit 1: External DO stop signal control (STPRF), 0 rising edge, 1 falling edge.
                                         //   Bit 2: DO request signal control (REQRF), 0 rising edge, 1 falling edge.
                                         //   Bit 3: DO acknowledge signal control (ACKRF), 0 rising edge, 1 falling edge.
                                         //   Bit 4: DO sampling clock signal control (CLKRF), 0 rising edge, 1 falling edge
#define CFG_DoPresetValue     0x4805     // DO status before transfering. 

#define CFG_DoOperationMode_Name   "DoOperationMode"  
#define CFG_DoStartMethod_Name     "DoStartMethod"     
#define CFG_DoStopMethod_Name      "DoStopMethod"      
#define CFG_DoPacerSource_Name     "DoPacerSource"     
#define CFG_DoControlSignals_Name  "DoControlSignals"
#define CFG_DoPresetValue_Name     "DoPresetValue"    


// ---------------------------------------
// 0x5000 ~ 0x5fff for Counter/Timer  
// ---------------------------------------
// sub group 0x5000 ~ 0x57ff for Counter/Timer general ID
// Counter functions
#define CFG_CounterCountValue 0x5000 // 82C54 Counter 0-2 value

#define    CFG_CounterCountValue_Name "CounterCountValue" 


// sub group 0x5800 ~ 0x5fff for counter/Timer general ID

// ---------------------------------------
// 0x6000 ~ 0x6fff for Other function related
// ---------------------------------------
// sub group 0x6000 ~ 0x6fff for Other function related ID
// Interrupt functions
#define CFG_IrqDiChangeStatusChannel  0x6000       // Change status channel number.
#define CFG_IrqDiTriggerSignals       0x6001       // Each bit for each Auxiliary DIO channel

#define CFG_IrqDiChangeStatusChannel_Name  "IrqDiChangeStatusChannel"  
#define CFG_IrqDiTriggerSignals_Name       "IrqDiTriggerSignals"       


#endif
