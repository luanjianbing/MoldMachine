// #############################################################################
// *****************************************************************************
//                  Copyright (c) 2003, Advantech Automation Corp.
//      THIS IS AN UNPUBLISHED WORK CONTAINING CONFIDENTIAL AND PROPRIETARY
//               INFORMATION WHICH IS THE PROPERTY OF ADVANTECH AUTOMATION CORP.
//
//    ANY DISCLOSURE, USE, OR REPRODUCTION, WITHOUT WRITTEN AUTHORIZATION FROM
//               ADVANTECH AUTOMATION CORP., IS STRICTLY PROHIBITED.
// *****************************************************************************
// #############################################################################
//
// File:    wdtdrv.h
// Author:  Yuehua.Yu
// Created: 12/2/2003
// 12/22/2003 - Po-Cheng Chen
//            - Modify IOCTL code according to Microsoft specification
//
// Description: 
// -----------------------------------------------------------------------------
#include <winioctl.h>
#define WDT_CHIPSET_TYPE_UNKNOWN        0
#define WDT_CHIPSET_TYPE_443            1
#define WDT_CHIPSET_TYPE_W83977AF       2
#define WDT_CHIPSET_TYPE_S3C24X0        3
#define WDT_CHIPSET_TYPE_W83627HF       4
#define WDT_CHIPSET_TYPE_ADAM5550       5
#define WDT_CHIPSET_TYPE_XSC            7

#define WDT_CHIPSET_TYPE_F75111R        6
#define WDT_CHIPSET_TYPE_SCH311X        8


#define FILE_DEVICE_WATCHDOG            FILE_DEVICE_UNKNOWN
#define IOCTL_WDT_ENABLE                CTL_CODE(FILE_DEVICE_WATCHDOG,  0x900, METHOD_BUFFERED, FILE_ANY_ACCESS)
#define IOCTL_WDT_DISABLE               CTL_CODE(FILE_DEVICE_WATCHDOG,  0x901, METHOD_BUFFERED, FILE_ANY_ACCESS)
#define IOCTL_WDT_STROBE                CTL_CODE(FILE_DEVICE_WATCHDOG,  0x902, METHOD_BUFFERED, FILE_ANY_ACCESS)
#define IOCTL_WDT_GET_TIMEOUT           CTL_CODE(FILE_DEVICE_WATCHDOG,  0x903, METHOD_BUFFERED, FILE_ANY_ACCESS)
#define IOCTL_WDT_SET_TIMEOUT           CTL_CODE(FILE_DEVICE_WATCHDOG,  0x904, METHOD_BUFFERED, FILE_ANY_ACCESS)
#define IOCTL_WDT_REBOOT                CTL_CODE(FILE_DEVICE_WATCHDOG,  0x905, METHOD_BUFFERED, FILE_ANY_ACCESS)
#define IOCTL_WDT_GET_CHIPSET_TYPE      CTL_CODE(FILE_DEVICE_WATCHDOG,  0x906, METHOD_BUFFERED, FILE_ANY_ACCESS)
#define IOCTL_WDT_GET_ENABLE_STATUS     CTL_CODE(FILE_DEVICE_WATCHDOG,  0x907, METHOD_BUFFERED, FILE_ANY_ACCESS)
#define IOCTL_WDT_GET_REBOOT_STATUS     CTL_CODE(FILE_DEVICE_WATCHDOG,  0x908, METHOD_BUFFERED, FILE_ANY_ACCESS)

#define WATCHDOG_ENABLED 1
#define WATCHDOG_DISABLED 0
