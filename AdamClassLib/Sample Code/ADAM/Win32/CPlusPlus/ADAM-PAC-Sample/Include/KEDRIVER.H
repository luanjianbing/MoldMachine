/***************************************************************************
 Module Name: KeDriver.H
 Purpose: Driver-defined structures and other headers.

 Version: 1.00
 Date: 07/28/1997
 Copyright (c) 1997 Advantech Corp. Ltd.
 All rights reserved.
****************************************************************************/

#include <ntddk.h>
#include <string.h>
#include <devioctl.h>
#include "ioctl.h"        // Get IOCTL interface definitions

#define AD_MAX_NAME_LENGTH  100
#define AD_MAX_DEVICES      1000
#define AD_TIMEOUT_VALUE    20
#define AD_MAX_DMA_LENGTH   0x100000

/***************************************************************************
    Define board vendor ID
**************************************************************************/
#define 	AAC 	 0x0000                     //Advantech
#define 	MB   	 0x1000                     //Keithley/MetraByte
#define	 	BB   	 0x2000                     //Burr Brown
#define 	GRAYHILL 0x3000                     //Grayhill
#define 	KGS	     0x4000

/****************************************************************************
    Define DAS I/O Board ID.
****************************************************************************/
#define      NONE           0x00              // not available

//Advantech board ID
#define      BD_DEMO        (AAC | 0x00)     // demo board
#define      BD_PCL711      (AAC | 0x01)     // PCL-711 board
#define      BD_PCL812      (AAC | 0x02)     // PCL-812 board
#define      BD_PCL812PG    (AAC | 0x03)     // PCL-812PG board
#define      BD_PCL718      (AAC | 0x04)     // PCL-718 board
#define      BD_PCL818      (AAC | 0x05)     // PCL-818 board
#define      BD_PCL814      (AAC | 0x06)     // PCL-814 board
#define      BD_PCL720      (AAC | 0x07)     // PCL-722 board
#define      BD_PCL722      (AAC | 0x08)     // PCL-720 board
#define      BD_PCL724      (AAC | 0x09)     // PCL-724 board
#define      BD_AD4011      (AAC | 0x0a)     // ADAM 4011 Module
#define      BD_AD4012      (AAC | 0x0b)     // ADAM 4012 Module
#define      BD_AD4013      (AAC | 0x0c)     // ADAM 4013 Module
#define      BD_AD4021      (AAC | 0x0d)     // ADAM 4021 Module
#define      BD_AD4050      (AAC | 0x0e)     // ADAM 4050 Module
#define      BD_AD4060      (AAC | 0x0f)     // ADAM 4060 Module
#define      BD_PCL711B     (AAC | 0x10)     // PCL-711B
#define      BD_PCL818H     (AAC | 0x11)     // PCL-818H
#define      BD_PCL814B     (AAC | 0x12)     // PCL-814B
#define      BD_PCL816      (AAC | 0x13)     // PCL-816
#define      BD_814_DIO_1   (AAC | 0x14)     // PCL-816/814B 8255 DIO module
#define      BD_814_DA_1    (AAC | 0x15)     // PCL-816/814B 12 bit D/A module
#define      BD_816_DA_1    (AAC | 0x16)     // PCL-816/814B 16 bit D/A module
#define      BD_PCL830      (AAC | 0x17)     // PCL-830 9513A Counter Card
#define      BD_PCL726      (AAC | 0x18)     // PCL-726 D/A card
#define      BD_PCL727      (AAC | 0x19)     // PCL-727 D/A card
#define      BD_PCL728      (AAC | 0x1a)     // PCL-728 D/A card
#define      BD_AD4052      (AAC | 0x1b)     // ADAM 4052 Module
#define      BD_AD4014D     (AAC | 0x1c)     // ADAM 4014D Module
#define      BD_AD4017      (AAC | 0x1d)     // ADAM 4017 Module
#define      BD_AD4080D     (AAC | 0x1e)     // ADAM 4080D Module
#define      BD_PCL721      (AAC | 0x1f)     // PCL-721 32-bit Digital in
#define      BD_PCL723      (AAC | 0x20)     // PCL-723 24-bit Digital in
#define      BD_PCL818L     (AAC | 0x21)     // PCL-818L
#define      BD_PCL818HG    (AAC | 0x22)     // PCL-818HG
#define      BD_PCL1800     (AAC | 0x23)     // PCL-1800
#define      BD_PAD71A      (AAC | 0x24)     // PCIA-71A
#define      BD_PAD71B      (AAC | 0x25)     // PCIA-71B
#define      BD_PCR420      (AAC | 0x26)     // PCR-420
#define      BD_PCL731      (AAC | 0x27)     // PCL-731 48-bit Digital I/O card
#define      BD_PCL730      (AAC | 0x28)     // PCL-730 board
#define      BD_PCL813      (AAC | 0x29)     // PCL-813 32-channel A/D card
#define      BD_PCL813B     (AAC | 0x2a)     // PCL-813B 32-channel A/D card
#define      BD_PCL818HD    (AAC | 0x2b)     // PCL-818HD
#define      BD_PCL725      (AAC | 0x2c)     // PCL-725 digital I/O card
#define      BD_PCL732      (AAC | 0x2d)     // PCL-732 high speed DIO card
#define      BD_AD4018      (AAC | 0x2e)     // ADAM 4018 Module
#define      BD_814_TC_1    (AAC | 0x2f)     // PCL-816/814B 16 bit TC module
#define      BD_PAD71C      (AAC | 0x30)     // PCIA-71C
#define      BD_AD4024      (AAC | 0x31)     // ADAM 4024
#define      BD_AD5017      (AAC | 0x32)     // ADAM 5017
#define      BD_AD5018      (AAC | 0x33)     // ADAM 5018
#define      BD_AD5024      (AAC | 0x34)     // ADAM 5024
#define      BD_AD5051      (AAC | 0x35)     // ADAM 5051
#define      BD_AD5060      (AAC | 0x36)     // ADAM 5060
#define      BD_PCM3718     (AAC | 0x37)     // PCM-3718
#define      BD_PCM3724     (AAC | 0x38)     // PCM-3724
#define      BD_MIC2718     (AAC | 0x39)     // MIC-2718
#define      BD_MIC2728     (AAC | 0x3a)     // MIC-2728
#define      BD_MIC2730     (AAC | 0x3b)     // MIC-2730
#define      BD_MIC2732     (AAC | 0x3c)     // MIC-2732
#define      BD_MIC2750     (AAC | 0x3d)     // MIC-2750
#define      BD_MIC2752     (AAC | 0x3e)     // MIC-2752
#define      BD_PCL733      (AAC | 0x3f)     // PCL-733
#define      BD_PCL734      (AAC | 0x40)     // PCL-734
#define      BD_PCL735      (AAC | 0x41)     // PCL-735
#define      BD_AD4018M     (AAC | 0x42)     // ADAM 4018M Module
#define      BD_AD4080      (AAC | 0x43)     // ADAM 4080 Module
#define      BD_PCL833      (AAC | 0x44)     // PCL-833
#define      BD_PCA6157     (AAC | 0x45)     // PCA-6157
#define      BD_PCA6149     (AAC | 0x46)     // PCA-6149
#define      BD_PCA6147     (AAC | 0x47)     // PCA-6147
#define      BD_PCA6137     (AAC | 0x48)     // PCA-6137
#define      BD_PCA6145     (AAC | 0x49)     // PCA-6145
#define      BD_PCA6144     (AAC | 0x4a)     // PCA-6144
#define      BD_PCA6143     (AAC | 0x4b)     // PCA-6143
#define      BD_PCA6134     (AAC | 0x4c)     // PCA-6134
#define      BD_AD5056      (AAC | 0x4d)     // ADAM 5056
#define      BD_DN5017      (AAC | 0x4e)     // ADAM 5017
#define      BD_DN5018      (AAC | 0x4f)     // ADAM 5018
#define      BD_DN5024      (AAC | 0x50)     // ADAM 5024
#define      BD_DN5051      (AAC | 0x51)     // ADAM 5051
#define      BD_DN5056      (AAC | 0x52)     // ADAM 5056
#define      BD_DN5060      (AAC | 0x53)     // ADAM 5060
#define      BD_PCL836      (AAC | 0x54)     // PCL-836
#define      BD_PCL841      (AAC | 0x55)     // PCL-841
#define      BD_DN5050      (AAC | 0x56)     // ADAM 5050 for DeviceNet
#define      BD_DN5052      (AAC | 0x57)     // ADAM 5052 for DeviceNet
#define      BD_AD5050      (AAC | 0x58)     // ADAM 5050 for RS-485
#define      BD_AD5052      (AAC | 0x59)     // ADAM 5052 for RS-485
#define      BD_PCM3730     (AAC | 0x5a)     // PCM-3730
#define      BD_AD4011D     (AAC | 0x5b)     // ADAM 4011D
#define      BD_AD4016      (AAC | 0x5c)     // ADAM 4016
#define      BD_AD4053      (AAC | 0x5d)     // ADAM 4053
#define      BD_PCI1750     (AAC | 0x5e)     // PCI-1750
#define      BD_PCI1751     (AAC | 0x5f)     // PCI-1751
#define      BD_PCI1710     (AAC | 0x60)     // PCI-1710
#define      BD_PCI1712     (AAC | 0x61)     // PCI-1712
#define      BD_AD5068      (AAC | 0x62)     // ADAM 5068
#define      BD_AD5013      (AAC | 0x63)     // ADAM 5013
#define      BD_AD5017H     (AAC | 0x64)     // ADAM 5017H(unavailable)
#define      BD_AD5080      (AAC | 0x65)     // ADAM 5080(unavailable) 
#define      BD_MIC2760     (AAC | 0x66)     // MIC-2760
#define      BD_PCI1710HG   (AAC | 0x67)     // PCI-1710HG
#define      BD_PCI1711     (AAC | 0x73)     // PCI-1711
#define      BD_PCI1711L    (AAC | 0x75)     // PCI-1711L 
#define      BD_PCI1713		(AAC | 0x68)     // PCI-1713
#define      BD_PCI1753		(AAC | 0x69)     // PCI-1753
#define      BD_PCI1760		(AAC | 0x6a)     // PCI-1760
#define      BD_PCI1720		(AAC | 0x6b)     // PCI-1720
#define      BD_PCL752		(AAC | 0x6c)     // PCL-772
#define      BD_PCM3718H	(AAC | 0x6d)     // PCM-3718H
#define      BD_PCM3718HG	(AAC | 0x6e)     // PCM-3718HG
#define      BD_DN5068      (AAC | 0x6f)     // ADAM 5068 for Device Net
#define      BD_DN5013      (AAC | 0x70)     // ADAM 5013 for Device Net
#define      BD_DN5017H     (AAC | 0x71)     // ADAM 5017H for Device Net
#define      BD_DN5080      (AAC | 0x72)     // ADAM 5080 for Device Net (unavailable)
#define      BD_PCI1716     (AAC | 0x74)     // PCI-1716
#define      BD_PCI1731     (AAC | 0x75)     // PCI-1731
#define      BD_AD5051D     (AAC | 0x76)     // ADAM 5051D 
#define      BD_AD5056D     (AAC | 0x77)     // ADAM 5056D 
#define      BD_DN5051D     (AAC | 0x78)     // ADAM 5051D for Device Net
#define      BD_DN5056D     (AAC | 0x79)     // ADAM 5056D for Device Net
#define      BD_SIMULATE    (AAC | 0x7a)     // Simulate IO
#define      BD_PCI1754     (AAC | 0x7b)     // PCI-1754
#define      BD_PCI1752     (AAC | 0x7c)     // PCI-1752
#define      BD_PCI1756     (AAC | 0x7d)     // PCI-1756
#define      BD_PCL839	    (AAC | 0x7e)     // PCL-839
#define      BD_PCM3725     (AAC | 0x7f)     // PCM-3725
#define      BD_PCI1762     (AAC | 0x80)     // PCI-1762
#define      BD_PCI1721     (AAC | 0x81)     // PCI-1721
#define      BD_PCI1761     (AAC | 0x82)     // PCI-1761
#define      BD_PCI1723     (AAC | 0x83)     // PCI-1723
#define      BD_AD4019      (AAC | 0X84)     // ADAM 4019 Module
#define      BD_AD5055      (AAC | 0X85)     // ADAM 5055 Module
#define      BD_AD4015      (AAC | 0X86)     // ADAM 4015 Module
#define      BD_PCI1730     (AAC | 0x87)     // PCI-1730
#define      BD_PCI1733     (AAC | 0x88)     // PCI-1733
#define      BD_PCI1734     (AAC | 0x89)     // PCI-1734
#define      BD_MIC2750A    (AAC | 0x8A)     // MIC-2750A
#define      BD_MIC2718A    (AAC | 0x8B)     // MIC-2718A
#define      BD_AD4017P     (AAC | 0X8c)     // ADAM 4017P Module
#define      BD_AD4051      (AAC | 0X8d)     // ADAM 4051 Module
#define      BD_AD4055      (AAC | 0X8e)     // ADAM 4055 Module
#define      BD_AD4018P     (AAC | 0x8f)     // ADAM 4018P Module
#define      BD_PCI1710L    (AAC | 0x90)     // PCI-1710L
#define      BD_PCI1710HGL  (AAC | 0x91)     // PCI-1710HGL
#define      BD_AD4068      (AAC | 0x92)     // ADAM-4068
//\\\\\\\\\\\\\\\\\\\\\\ 2.0C /////////////////////
#define      BD_PCM3712     (AAC | 0x93)     // PCM-3712
#define      BD_PCM3723     (AAC | 0x94)     // PCM-3723
#define      BD_PCI1780     (AAC | 0x95)     // PCI-1780
#define      BD_CPCI3756    (AAC | 0x96)     // CPCI-3756
//////////////////////// 2.0C \\\\\\\\\\\\\\\\\\\\\

//\\\\\\\\\\\\\\\\\\\\\\ 2.0C /////////////////////
#define      BD_PCI1755     (AAC | 0x97)     // PCI-1755
#define      BD_PCI1714     (AAC | 0x98)     // PCI-1714
//////////////////////// 2.0C \\\\\\\\\\\\\\\\\\\\\/

//\\\\\\\\\\\\\\\\\\\\\\ 2.1 /////////////////////
#define      BD_PCI1757     (AAC | 0x99)     // PCI-1757
//////////////////////// 2.1 \\\\\\\\\\\\\\\\\\\\\/

//\\\\\\\\\\\\\\\\\\\\\\ 2.1a /////////////////////
#define      BD_MIC3716    (AAC | 0x9A)     // MIC-3716
#define      BD_MIC3761    (AAC | 0x9B)     // MIC-3761
#define      BD_MIC3753    (AAC | 0x9C)     // MIC-3753
#define      BD_MIC3780    (AAC | 0x9D)     // MIC-3780
//////////////////////// 2.1a \\\\\\\\\\\\\\\\\\\\\/


/****************************************************************************
    define event type for interrupt and DMA transfer
*****************************************************************************/
#define     ADS_EVT_INTERRUPT           0x1     // interrupt
#define     ADS_EVT_BUFCHANGE           0x2     // buffer change
#define     ADS_EVT_TERMINATED          0x4     // termination
#define     ADS_EVT_OVERRUN             0x8     // overrun
#define     ADS_EVT_WATCHDOG            0x10    // watchdog actived
#define     ADS_EVT_PORT0               0x80    // port0 interrupt
#define     ADS_EVT_PORT1               0x100   // port1 interrupt
#define     ADS_EVT_PATTERNMATCH        0x200   // Pattern Match for DI
#define     ADS_EVT_COUNTER             0x201   // Persudo event for COUNTERMATCH and COUNTEROVERFLOW
#define     ADS_EVT_COUNTERMATCH        0x202   // Counter Match setting NO. for DI
#define     ADS_EVT_COUNTEROVERFLOW     0x203   // Counter Overflow for DI
#define     ADS_EVT_STATUSCHANGE        0x204   // Status Change for DI
#define     ADS_EVT_FILTER              0x205   // Filter Event

#define     FREE_RUN             0
#define     PRE_TRIG             1
#define     POST_TRIG            2
#define     POSITION_TRIG        3

// define the wSubMessage in user window message
#define AD_NONE                  0  //AD Section
#define AD_TERMINATE             1
#define AD_INT                   2
#define AD_BUFFERCHANGE          3
#define AD_OVERRUN               4
#define AD_BUFFERHALF            5
#define AD_BUFFERFULL            6
#define AD_WATCHDOGACT           7

#define AD_TIMEOUT               10

// define error code
#define KeErrorCode              100

#define KeInvalidHandleValue     (KeErrorCode + 0)
#define KeFileNotFound           (KeErrorCode + 1)
#define KeInvalidHandle          (KeErrorCode + 2)
#define KeTooManyCmds            (KeErrorCode + 3)
#define KeInvalidParameter       (KeErrorCode + 4)
#define KeNoAccess               (KeErrorCode + 5)
#define KeUnsuccessful           (KeErrorCode + 6)
#define KeConInterruptFailure    (KeErrorCode + 7)
#define KeCreateNoteFailure      (KeErrorCode + 8)
#define KeInsufficientResources  (KeErrorCode + 9)
#define KeHalGetAdapterFailure   (KeErrorCode +10)
#define KeOpenEventFailure       (KeErrorCode +11)
#define KeAllocCommBufFailure    (KeErrorCode +12)
#define KeAllocMdlFailure        (KeErrorCode +13)
#define KeBufferSizeTooSmall     (KeErrorCode +14)

#define adInp(pDevExt, usPort )      \
   (READ_PORT_UCHAR((PUCHAR)((ULONG)pDevExt->PortBase + usPort)) )

#define adInpw(pDevExt, usPort )      \
   (READ_PORT_USHORT((PUSHORT)((ULONG)pDevExt->PortBase + usPort)) )

#define adInpdw(pDevExt, usPort )      \
   (READ_PORT_ULONG((PULONG)((ULONG)pDevExt->PortBase + usPort)) )

#define adOutp(pDevExt, usPort, usData )  \
   (WRITE_PORT_UCHAR((PUCHAR)((ULONG)pDevExt->PortBase + usPort), usData))

#define adOutpw(pDevExt, usPort, usData )  \
   (WRITE_PORT_USHORT((PUSHORT)((ULONG)pDevExt->PortBase + usPort), usData))

#define adOutpdw(pDevExt, usPort, ulData )  \
   (WRITE_PORT_ULONG((PULONG)((ULONG)pDevExt->PortBase + usPort), ulData))

typedef struct  _AD_WRITE_INPUT {
    ULONG   PortNumber;     // Port # to write to
    union   {               // Data to be output to port
        ULONG   LongData;
        USHORT  ShortData;
        UCHAR   CharData;
    };
}   AD_WRITE_INPUT;
/********************* function prototypes ***********************************/

