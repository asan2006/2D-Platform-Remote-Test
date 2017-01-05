Option Strict Off
Option Explicit On
Module D2K_DASK
	
	'ADLink PCI Card Type
	Public Const DAQ_2010 As Short = 1
	Public Const DAQ_2205 As Short = 2
	Public Const DAQ_2206 As Short = 3
	Public Const DAQ_2005 As Short = 4
	Public Const DAQ_2204 As Short = 5
	Public Const DAQ_2006 As Short = 6
	Public Const DAQ_2501 As Short = 7
	Public Const DAQ_2502 As Short = 8
	Public Const DAQ_2208 As Short = 9
	public const DAQ_2213 As Short = 10
	public const DAQ_2214 As Short = 11
	public const DAQ_2016 As Short = 12
    Public Const DAQ_2020 As Short = 13
    Public Const DAQ_2022 As Short = 14

	Public Const MAX_CARD As Short = 32
	
	'Error Code
	Public Const NoError As Short = 0
	Public Const ErrorUnknownCardType As Short = -1
	Public Const ErrorInvalidCardNumber As Short = -2
	Public Const ErrorTooManyCardRegistered As Short = -3
	Public Const ErrorCardNotRegistered As Short = -4
	Public Const ErrorFuncNotSupport As Short = -5
	Public Const ErrorInvalidIoChannel As Short = -6
	Public Const ErrorInvalidAdRange As Short = -7
	Public Const ErrorContIoNotAllowed As Short = -8
	Public Const ErrorDiffRangeNotSupport As Short = -9
	Public Const ErrorLastChannelNotZero As Short = -10
	Public Const ErrorChannelNotDescending As Short = -11
	Public Const ErrorChannelNotAscending As Short = -12
	Public Const ErrorOpenDriverFailed As Short = -13
	Public Const ErrorOpenEventFailed As Short = -14
	Public Const ErrorTransferCountTooLarge As Short = -15
	Public Const ErrorNotDoubleBufferMode As Short = -16
	Public Const ErrorInvalidSampleRate As Short = -17
	Public Const ErrorInvalidCounterMode As Short = -18
	Public Const ErrorInvalidCounter As Short = -19
	Public Const ErrorInvalidCounterState As Short = -20
	Public Const ErrorInvalidBinBcdParam As Short = -21
	Public Const ErrorBadCardType As Short = -22
	Public Const ErrorInvalidDaRange As Short = -23
	Public Const ErrorAdTimeOut As Short = -24
	Public Const ErrorNoAsyncAI As Short = -25
	Public Const ErrorNoAsyncAO As Short = -26
	Public Const ErrorNoAsyncDI As Short = -27
	Public Const ErrorNoAsyncDO As Short = -28
	Public Const ErrorNotInputPort As Short = -29
	Public Const ErrorNotOutputPort As Short = -30
	Public Const ErrorInvalidDioPort As Short = -31
	Public Const ErrorInvalidDioLine As Short = -32
	Public Const ErrorContIoActive As Short = -33
	Public Const ErrorDblBufModeNotAllowed As Short = -34
	Public Const ErrorConfigFailed As Short = -35
	Public Const ErrorInvalidPortDirection As Short = -36
	Public Const ErrorBeginThreadError As Short = -37
	Public Const ErrorInvalidPortWidth As Short = -38
	Public Const ErrorInvalidCtrSource As Short = -39
	Public Const ErrorOpenFile As Short = -40
	Public Const ErrorAllocateMemory As Short = -41
	Public Const ErrorDaVoltageOutOfRange As Short = -42
	Public Const ErrorInvalidSyncMode As Short = -43
	Public Const ErrorInvalidBufferID As Short = -44
	Public Const ErrorInvalidCNTInterval As Short = -45
	Public Const ErrorReTrigModeNotAllowed As Short = -46
	Public Const ErrorResetBufferNotAllowed As Short = -47
	Public Const ErrorAnaTriggerLevel As Short = -48
    Public Const ErrorDAQEvent As Short = -49
	Public Const ErrorInvalidCounterValue As Short = -50 
	Public Const ErrorOffsetCalibration As Short  = -51
	Public Const ErrorGainCalibration As Short    =  -52
	Public Const ErrorCountOutofSDRAMSize As Short =  -53
	Public Const ErrorNotStartTriggerModule As Short = -54
	Public Const ErrorInvalidRouteLine As Short = -55
	Public Const ErrorInvalidSignalCode As Short = -56
	Public Const ErrorInvalidSignalDirection As Short = -57
	Public Const ErrorTRGOSCalibration As Short = -58
	Public Const ErrorNoSDRAM As Short = -59
	Public Const ErrorIntegrationGain As Short = -60
	Public Const ErrorAcquisitionTiming As Short = -61
	Public Const ErrorIntegrationTiming As Short = -62
	Public Const ErrorInvalidTimeBase As Short = -70
	Public Const ErrorUndefinedParameter As Short = -71
	'Error number for calibration API
	Public Const ErrorCalAddress As Short = -110
	Public Const ErrorInvalidCalBank As Short = -111	
	'Error code for driver API
	Public Const ErrorConfigIoctl As Short = -201
	Public Const ErrorAsyncSetIoctl As Short = -202
	Public Const ErrorDBSetIoctl As Short = -203
	Public Const ErrorDBHalfReadyIoctl As Short = -204
	Public Const ErrorContOPIoctl As Short = -205
	Public Const ErrorContStatusIoctl As Short = -206
	Public Const ErrorPIOIoctl As Short = -207
	Public Const ErrorDIntSetIoctl As Short = -208
	Public Const ErrorWaitEvtIoctl As Short = -209
	Public Const ErrorOpenEvtIoctl As Short = -210
	Public Const ErrorCOSIntSetIoctl As Short = -211
	Public Const ErrorMemMapIoctl As Short = -212
	Public Const ErrorMemUMapSetIoctl As Short = -213
	Public Const ErrorCTRIoctl As Short = -214
	Public Const ErrorGetResIoctl As Short = -215
	
	'Synchronous Mode
	Public Const SYNCH_OP As Short = 1
	Public Const ASYNCH_OP As Short = 2
	
	'AD Range
	Public Const AD_B_10_V As Short = 1
	Public Const AD_B_5_V As Short = 2
	Public Const AD_B_2_5_V As Short = 3
	Public Const AD_B_1_25_V As Short = 4
	Public Const AD_B_0_625_V As Short = 5
	Public Const AD_B_0_3125_V As Short = 6
	Public Const AD_B_0_5_V As Short = 7
	Public Const AD_B_0_05_V As Short = 8
	Public Const AD_B_0_005_V As Short = 9
	Public Const AD_B_1_V As Short = 10
	Public Const AD_B_0_1_V As Short = 11
	Public Const AD_B_0_01_V As Short = 12
	Public Const AD_B_0_001_V As Short = 13
	Public Const AD_U_20_V As Short = 14
	Public Const AD_U_10_V As Short = 15
	Public Const AD_U_5_V As Short = 16
	Public Const AD_U_2_5_V As Short = 17
	Public Const AD_U_1_25_V As Short = 18
	Public Const AD_U_1_V As Short = 19
	Public Const AD_U_0_1_V As Short = 20
	Public Const AD_U_0_01_V As Short = 21
	Public Const AD_U_0_001_V As Short = 22
	Public Const AD_B_2_V As Short = 23
	Public Const AD_B_0_25_V As Short = 24
	Public Const AD_B_0_2_V As Short = 25
	Public Const AD_U_4_V As Short = 26
	Public Const AD_U_2_V As Short = 27
	Public Const AD_U_0_5_V As Short = 28
	Public Const AD_U_0_4_V As Short = 29
	
	'Constants for DAQ2000
	Public Const All_Channels As Short = -1
	Public Const BufferNotUsed As Short = -1
	
	Public Const DAQ2K_AI_ADCONVSRC_Int As Short = &H0s
	Public Const DAQ2K_AI_ADCONVSRC_AFI0 As Short = &H4s
	Public Const DAQ2K_AI_ADCONVSRC_SSI As Short = &H8s
	Public Const DAQ2K_AI_ADCONVSRC_AFI1 As Short = &HCs
	Public Const DAQ2K_AI_ADCONVSRC_AFI2 As Short = &H100s
	Public Const DAQ2K_AI_ADCONVSRC_AFI3 As Short = &H200s
	Public Const DAQ2K_AI_ADCONVSRC_AFI4 As Short = &H300s
	Public Const DAQ2K_AI_ADCONVSRC_AFI5 As Short = &H400s
	Public Const DAQ2K_AI_ADCONVSRC_AFI6 As Short = &H500s
	Public Const DAQ2K_AI_ADCONVSRC_AFI7 As Short = &H600s
	
	'Constants for AI Delay Counter SRC: only available for DAQ-250X
	Public Const DAQ2K_AI_DTSRC_Int As Short = &H0s
	Public Const DAQ2K_AI_DTSRC_AFI1 As Short = &H10s
	Public Const DAQ2K_AI_DTSRC_GPTC0 As Short = &H20s
	Public Const DAQ2K_AI_DTSRC_GPTC1 As Short = &H30s
	
	Public Const DAQ2K_AI_TRGSRC_SOFT As Short = &H0s
	Public Const DAQ2K_AI_TRGSRC_ANA As Short = &H1s
	Public Const DAQ2K_AI_TRGSRC_ExtD As Short = &H2s
	Public Const DAQ2K_AI_TRSRC_SSI As Short = &H3s
	Public Const DAQ2K_AI_TRGMOD_POST As Short = &H0s 'Post Trigger Mode
	Public Const DAQ2K_AI_TRGMOD_DELAY As Short = &H8s 'Delay Trigger Mode
	Public Const DAQ2K_AI_TRGMOD_PRE As Short = &H10s 'Pre-Trigger Mode
	Public Const DAQ2K_AI_TRGMOD_MIDL As Short = &H18s 'Middle Trigger Mode
	Public Const DAQ2K_AI_ReTrigEn As Short = &H80s
	Public Const DAQ2K_AI_Dly1InSamples As Short = &H100s
	Public Const DAQ2K_AI_Dly1InTimebase As Short = &H0s
	Public Const DAQ2K_AI_MCounterEn As Short = &H400s
	Public Const DAQ2K_AI_TrgPositive As Short = &H0s
	Public Const DAQ2K_AI_TrgNegative As Short = &H1000s

	Public Const DAQ2K_AI_TRGSRC_AFI0 As Integer = &H10000
	Public Const DAQ2K_AI_TRGSRC_AFI1 As Integer = &H20000
	Public Const DAQ2K_AI_TRGSRC_AFI2 As Integer = &H30000
	Public Const DAQ2K_AI_TRGSRC_AFI3 As Integer = &H40000
	Public Const DAQ2K_AI_TRGSRC_AFI4 As Integer = &H50000
	Public Const DAQ2K_AI_TRGSRC_AFI5 As Integer = &H60000
	Public Const DAQ2K_AI_TRGSRC_AFI6 As Integer = &H70000
	Public Const DAQ2K_AI_TRGSRC_AFI7 As Integer = &H80000
	Public Const DAQ2K_AI_TRGSRC_PXIStar As Integer = &Ha0000
	Public Const DAQ2K_AI_TRGSRC_SMB As Integer = &Hb0000
	
	'AI Reference Ground (input mode)
	Public Const AI_RSE As Short = &H0s
	Public Const AI_DIFF As Short = &H100s
	Public Const AI_NRSE As Short = &H200s
	
	Public Const DAQ2K_DA_BiPolar As Short = &H1s
	Public Const DAQ2K_DA_UniPolar As Short = &H0s
	Public Const DAQ2K_DA_Int_REF As Short = &H0s
	Public Const DAQ2K_DA_Ext_REF As Short = &H1s
	
	Public Const DAQ2K_DA_WRSRC_Int As Short = &H0s
	Public Const DAQ2K_DA_WRSRC_AFI0 As Short = &H1s
	Public Const DAQ2K_DA_WRSRC_AFI1 As Short = &H1s
	Public Const DAQ2K_DA_WRSRC_SSI As Short = &H2s
	
	'DA group
	Public Const DA_Group_A As Short = &H0s
	Public Const DA_Group_B As Short = &H4s
	Public Const DA_Group_AB As Short = &H8s
	'DA TD Counter SRC: only available for DAQ-250X
	Public Const DAQ2K_DA_TDSRC_Int As Short = &H0s
	Public Const DAQ2K_DA_TDSRC_AFI0 As Short = &H10s
	Public Const DAQ2K_DA_TDSRC_GPTC0 As Short = &H20s
	Public Const DAQ2K_DA_TDSRC_GPTC1 As Short = &H30s
	'DA BD Counter SRC: only available for DAQ-250X
	Public Const DAQ2K_DA_BDSRC_Int As Short = &H0s
	Public Const DAQ2K_DA_BDSRC_AFI0 As Short = &H40s
	Public Const DAQ2K_DA_BDSRC_GPTC0 As Short = &H80s
	Public Const DAQ2K_DA_BDSRC_GPTC1 As Short = &HC0s
	'DA trigger constant
	Public Const DAQ2K_DA_TRGSRC_SOFT As Short = &H0s 'Software Trigger Mode
	Public Const DAQ2K_DA_TRGSRC_ANA As Short = &H1s 'Post Trigger Mode
	Public Const DAQ2K_DA_TRGSRC_ExtD As Short = &H2s 'Delay Trigger Mode
	Public Const DAQ2K_DA_TRGSRC_SSI As Short = &H3s
	Public Const DAQ2K_DA_TRGMOD_POST As Short = &H0s
	Public Const DAQ2K_DA_TRGMOD_DELAY As Short = &H4s
	Public Const DAQ2K_DA_ReTrigEn As Short = &H20s
	Public Const DAQ2K_DA_Dly1InUI As Short = &H40s
	Public Const DAQ2K_DA_Dly1InTimebase As Short = &H0s
	Public Const DAQ2K_DA_Dly2InUI As Short = &H80s
	Public Const DAQ2K_DA_Dly2InTimebase As Short = &H0s
	Public Const DAQ2K_DA_DLY2En As Short = &H100s
	Public Const DAQ2K_DA_TrgPositive As Short = &H0s
	Public Const DAQ2K_DA_TrgNegative As Short = &H200s
	'DA stop mode
	Public Const DAQ2K_DA_TerminateImmediate As Short = 0
	Public Const DAQ2K_DA_TerminateUC As Short = 1
	Public Const DAQ2K_DA_TerminateFIFORC As Short = 2
	Public Const DAQ2K_DA_TerminateIC As Short = 2
	'DA stop source : only available for DAQ-250X
	Public Const DAQ2K_DA_STOPSRC_SOFT As Short = 0
	Public Const DAQ2K_DA_STOPSRC_AFI0 As Short = 1
	Public Const DAQ2K_DA_STOPSRC_ATrig As Short = 2
	Public Const DAQ2K_DA_STOPSRC_AFI1 As Short = 3
	
	'DIO Port Direction
	Public Const INPUT_PORT As Short = 1
	Public Const OUTPUT_PORT As Short = 2
	
	'Channel&Port
	Public Const Channel_P1A As Short = 0
	Public Const Channel_P1B As Short = 1
	Public Const Channel_P1C As Short = 2
	Public Const Channel_P1CL As Short = 3
	Public Const Channel_P1CH As Short = 4
	Public Const Channel_P1AE As Short = 10
	Public Const Channel_P1BE As Short = 11
	Public Const Channel_P1CE As Short = 12
	Public Const Channel_P2A As Short = 5
	Public Const Channel_P2B As Short = 6
	Public Const Channel_P2C As Short = 7
	Public Const Channel_P2CL As Short = 8
	Public Const Channel_P2CH As Short = 9
	Public Const Channel_P2AE As Short = 15
	Public Const Channel_P2BE As Short = 16
	Public Const Channel_P2CE As Short = 17
	Public Const Channel_P3A As Short = 10
	Public Const Channel_P3B As Short = 11
	Public Const Channel_P3C As Short = 12
	Public Const Channel_P3CL As Short = 13
	Public Const Channel_P3CH As Short = 14
	Public Const Channel_P4A As Short = 15
	Public Const Channel_P4B As Short = 16
	Public Const Channel_P4C As Short = 17
	Public Const Channel_P4CL As Short = 18
	Public Const Channel_P4CH As Short = 19
	Public Const Channel_P5A As Short = 20
	Public Const Channel_P5B As Short = 21
	Public Const Channel_P5C As Short = 22
	Public Const Channel_P5CL As Short = 23
	Public Const Channel_P5CH As Short = 24
	Public Const Channel_P6A As Short = 25
	Public Const Channel_P6B As Short = 26
	Public Const Channel_P6C As Short = 27
	Public Const Channel_P6CL As Short = 28
	Public Const Channel_P6CH As Short = 29
	Public Const Channel_P1 As Short = 30
	Public Const Channel_P2 As Short = 31
	Public Const Channel_P3 As Short = 32
	Public Const Channel_P4 As Short = 33
	Public Const Channel_P1E As Short = 34
	Public Const Channel_P2E As Short = 35
	Public Const Channel_P3E As Short = 36
	Public Const Channel_P4E As Short = 37
	
	'--------- Constants for Timer/Counter --------------
	'Counter Mode (8254)
	Public Const TOGGLE_OUTPUT As Short = 0 'Toggle output from low to high on terminal count
	Public Const PROG_ONE_SHOT As Short = 1 'Programmable one-shot
	Public Const RATE_GENERATOR As Short = 2 'Rate generator
	Public Const SQ_WAVE_RATE_GENERATOR As Short = 3 'Square wave rate generator
	Public Const SOFT_TRIG As Short = 4 'Software-triggered strobe
	Public Const HARD_TRIG As Short = 5 'Hardware-triggered strobe
	
	'---------- Constants for Analog trigger ------------
	'define analog trigger condition constants
	Public Const Below_Low_level As Short = &H0s
	Public Const Above_High_Level As Short = &H100s
	Public Const Inside_Region As Short = &H200s
	Public Const High_Hysteresis As Short = &H300s
	Public Const Low_Hysteresis As Short = &H400s
	'define analog trigger Dedicated Channel
	Public Const CH0ATRIG As Short = &H0s
	Public Const CH1ATRIG As Short = &H2s
	Public Const CH2ATRIG As Short = &H4s
	Public Const CH3ATRIG As Short = &H6s
	Public Const EXTATRIG As Short = &H1s
	Public Const ADCATRIG As Short = &H0s
	'----------- Time Base -------------------
	Public Const DAQ2K_IntTimeBase As Short = &H0s
	Public Const DAQ2K_ExtTimeBase As Short = &H1s
	Public Const DAQ2K_SSITimeBase As Short = &H2s
	Public Const DAQ2K_ExtTimeBase_AFI0 As Short = &H3s
	Public Const DAQ2K_ExtTimeBase_AFI1 As Short = &H4s
	Public Const DAQ2K_ExtTimeBase_AFI2 As Short = &H5s
	Public Const DAQ2K_ExtTimeBase_AFI3 As Short = &H6s
	Public Const DAQ2K_ExtTimeBase_AFI4 As Short = &H7s
	Public Const DAQ2K_ExtTimeBase_AFI5 As Short = &H8s
	Public Const DAQ2K_ExtTimeBase_AFI6 As Short = &H9s
	Public Const DAQ2K_ExtTimeBase_AFI7 As Short = &HAs
	Public Const DAQ2K_PXI_CLK As Short = &HCs
	Public Const DAQ2K_StarTimeBase As Short = &HDs
	Public Const DAQ2K_SMBTimeBase As Short = &HEs
	
	'------- General Purpose Timer/Counter -----------------
	'Counter Mode
	Public Const SimpleGatedEventCNT As Short = 1
	Public Const SinglePeriodMSR As Short = 2
	Public Const SinglePulseWidthMSR As Short = 3
	Public Const SingleGatedPulseGen As Short = 4
	Public Const SingleTrigPulseGen As Short = 5
	Public Const RetrigSinglePulseGen As Short = 6
	Public Const SingleTrigContPulseGen As Short = 7
	Public Const ContGatedPulseGen As Short = 8
	'GPTC clock source
	Public Const GPTC_GATESRC_EXT As Short = &H4s
	Public Const GPTC_GATESRC_INT As Short = &H0s
	Public Const GPTC_CLKSRC_EXT As Short = &H8s
	Public Const GPTC_CLKSRC_INT As Short = &H0s
	Public Const GPTC_UPDOWN_SEL_EXT As Short = &H10s
	Public Const GPTC_UPDOWN_SEL_INT As Short = &H0s
	'GPTC clock polarity
	Public Const GPTC_CLKEN_LACTIVE As Short = &H1s
	Public Const GPTC_CLKEN_HACTIVE As Short = &H0s
	Public Const GPTC_GATE_LACTIVE As Short = &H2s
	Public Const GPTC_GATE_HACTIVE As Short = &H0s
	Public Const GPTC_UPDOWN_LACTIVE As Short = &H4s
	Public Const GPTC_UPDOWN_HACTIVE As Short = &H0s
	Public Const GPTC_OUTPUT_LACTIVE As Short = &H8s
	Public Const GPTC_OUTPUT_HACTIVE As Short = &H0s
	Public Const GPTC_INT_LACTIVE As Short = &H10s
	Public Const GPTC_INT_HACTIVE As Short = &H0s
	'GPTC paramID
	Public Const GPTC_IntGATE As Short = &H0s
	Public Const GPTC_IntUpDnCTR As Short = &H1s
	Public Const GPTC_IntENABLE As Short = &H2s
	
	'SSI signal code
	Public Const SSI_TIME As Short = 1
	Public Const SSI_CONV As Short = 2
	Public Const SSI_WR As Short = 4
	Public Const SSI_ADTRIG As Short = &H20s
	Public Const SSI_DATRIG As Short = &H40s

	'signal code for GPTC
	Public Const GPTC_CLK_0 As Short  = &H100s 
	Public Const GPTC_GATE_0 As Short = &H200s 
	Public Const GPTC_OUT_0 As Short  = &H300s 
	Public Const GPTC_CLK_1 As Short  = &H400s 
	Public Const GPTC_GATE_1 As Short = &H500s 
	Public Const GPTC_OUT_1 As Short  = &H600s 
	'signal code for clockoutToSMB source
	Public Const PXI_CLK_10_M As Short = &H1000s 
	Public Const CLK_20_M As Short  = &H2000s 
	Public Const SMB_CLK_IN As Short = &H3000s

	'signal route lines
	Public Const PXI_TRIG_0 = 0
	Public Const PXI_TRIG_1 = 1
	Public Const PXI_TRIG_2 = 2
	Public Const PXI_TRIG_3 = 3
	Public Const PXI_TRIG_4 = 4
	Public Const PXI_TRIG_5 = 5
	Public Const PXI_TRIG_6 = 6
	Public Const PXI_TRIG_7 = 7
	Public Const PXI_STAR_TRIG = 8
	Public Const TRG_IO = 9
	Public Const SMB_CLK_OUT = 10
	Public Const AFI0 = &H10
	Public Const AFI1 = &H11
	Public Const AFI2 = &H12
	Public Const AFI3 = &H13
	Public Const AFI4 = &H14
	Public Const AFI5 = &H15
	Public Const AFI6 = &H16
	Public Const AFI7 = &H17
	Public Const PXI_CLK = &H18

	'export signal plarity
	Public Const Signal_ActiveHigh = &H0
	Public Const Signal_ActiveLow  = &H1
	
	'DAQ Event type for the event message  
	Public Const DAQEnd As Short = 0
	Public Const DBEvent As Short = 1
	Public Const DAQEnd_A As Short = 0
	Public Const DAQEnd_B As Short = 2
	Public Const DAQEnd_AB As Short = 3
	
	'16-bit binary or 4-decade BCD counter
	Public Const BIN As Short = 0
	Public Const BCD As Short = 1
	
	Declare Function WaitForSingleObject Lib "kernel32" (ByVal hHandle As Integer, ByVal dwMilliseconds As Integer) As Integer
	Public Delegate Sub CallbackDelegate()

	'-------------------------------------------------------------------
	'  D2K-DASK Function prototype
	'-----------------------------------------------------------------*/
	Declare Function D2K_Register_Card Lib "D2K-Dask.dll" (ByVal CardType As Short, ByVal card_num As Short) As Short
	Declare Function D2K_Register_Card_By_PXISlot_GA Lib "D2K-Dask.dll" (ByVal CardType As Short, ByVal geo_addr As Short) As Short	
	Declare Function D2K_Release_Card Lib "D2K-Dask.dll" (ByVal CardNumber As Short) As Short
	Declare Function D2K_AIO_Config Lib "D2K-Dask.dll" (ByVal CardNumber As Short, ByVal TimerBase As Short, ByVal AnaTrigCtrl As Short, ByVal H_TrgLevel As Short, ByVal L_TrgLevel As Short) As Short
	Declare Function D2K_GetPXISlotGeographAddr Lib "D2K-Dask.dll" (ByVal CardNumber As Short, ByRef geo_addr As Byte) As Short
	Declare Function D2K_SoftTrigGen Lib "D2K-Dask.dll" (ByVal CardNumber As Short, ByRef op As Byte) As Short
	'AI Functions
	Declare Function D2K_AI_CH_Config Lib "D2K-Dask.dll" (ByVal CardNumber As Short, ByVal channel As Short, ByVal AdRange_RefGnd As Short) As Short
	Declare Function D2K_AI_Config Lib "D2K-Dask.dll" (ByVal CardNumber As Short, ByVal ConfigCtrl As Short, ByVal TrigCtrl As Integer, ByVal MidOrDlyScans As Integer, ByVal MCnt As Short, ByVal ReTrgCnt As Short, ByVal AutoResetBuf As Byte) As Short
	Declare Function D2K_AI_ConfigEx Lib "D2K-Dask.dll" (ByVal CardNumber As Short, ByVal ConfigCtrl As Short, ByVal TrigCtrl As Integer, ByVal MidOrDlyScans As Integer, ByVal MCnt As Integer, ByVal ReTrgCnt As Integer, ByVal AutoResetBuf As Byte) As Short		
	Declare Function D2K_AI_PostTrig_Config Lib "D2K-Dask.dll" (ByVal CardNumber As Short, ByVal ClkSrc As Short, ByVal TrigSrcCtrl As Integer, ByVal ReTrgEn As Short, ByVal ReTrgCnt As Short, ByVal AutoResetBuf As Byte) As Short
	Declare Function D2K_AI_PostTrig_ConfigEx Lib "D2K-Dask.dll" (ByVal CardNumber As Short, ByVal ClkSrc As Short, ByVal TrigSrcCtrl As Integer, ByVal ReTrgEn As Short, ByVal ReTrgCnt As Integer, ByVal AutoResetBuf As Byte) As Short	
	Declare Function D2K_AI_DelayTrig_Config Lib "D2K-Dask.dll" (ByVal CardNumber As Short, ByVal ClkSrc As Short, ByVal TrigSrcCtrl As Integer, ByVal DlyScans As Integer, ByVal ReTrgEn As Short, ByVal ReTrgCnt As Short, ByVal AutoResetBuf As Byte) As Short
	Declare Function D2K_AI_DelayTrig_ConfigEx Lib "D2K-Dask.dll" (ByVal CardNumber As Short, ByVal ClkSrc As Short, ByVal TrigSrcCtrl As Integer, ByVal DlyScans As Integer, ByVal ReTrgEn As Short, ByVal ReTrgCnt As Integer, ByVal AutoResetBuf As Byte) As Short		
	Declare Function D2K_AI_PreTrig_Config Lib "D2K-Dask.dll" (ByVal CardNumber As Short, ByVal ClkSrc As Short, ByVal TrigSrcCtrl As Integer, ByVal MCtrEn As Short, ByVal MCnt As Short, ByVal AutoResetBuf As Byte) As Short
	Declare Function D2K_AI_PreTrig_ConfigEx Lib "D2K-Dask.dll" (ByVal CardNumber As Short, ByVal ClkSrc As Short, ByVal TrigSrcCtrl As Integer, ByVal MCtrEn As Short, ByVal MCnt As Integer, ByVal AutoResetBuf As Byte) As Short	
	Declare Function D2K_AI_MiddleTrig_Config Lib "D2K-Dask.dll" (ByVal CardNumber As Short, ByVal ClkSrc As Short, ByVal TrigSrcCtrl As Integer, ByVal MiddleScans As Integer, ByVal MCtrEn As Short, ByVal MCnt As Short, ByVal AutoResetBuf As Byte) As Short
	Declare Function D2K_AI_MiddleTrig_ConfigEx Lib "D2K-Dask.dll" (ByVal CardNumber As Short, ByVal ClkSrc As Short, ByVal TrigSrcCtrl As Integer, ByVal MiddleScans As Integer, ByVal MCtrEn As Short, ByVal MCnt As Integer, ByVal AutoResetBuf As Byte) As Short		
	Declare Function D2K_AI_AsyncCheck Lib "D2K-Dask.dll" (ByVal CardNumber As Short, ByRef Stopped As Byte, ByRef AccessCnt As Integer) As Short
	Declare Function D2K_AI_AsyncClear Lib "D2K-Dask.dll" (ByVal CardNumber As Short, ByRef startPos As Integer, ByRef AccessCnt As Integer) As Short
	Declare Function D2K_AI_AsyncClearEx Lib "D2K-Dask.dll" (ByVal CardNumber As Short, ByRef startPos As Integer, ByRef AccessCnt As Integer, ByVal NoWait As Integer) As Short
	Declare Function D2K_AI_AsyncDblBufferHalfReady Lib "D2K-Dask.dll" (ByVal CardNumber As Short, ByRef HalfReady As Byte, ByRef StopFlag As Byte) As Short
	Declare Function D2K_AI_AsyncDblBufferMode Lib "D2K-Dask.dll" (ByVal CardNumber As Short, ByVal enable As Byte) As Short
	Declare Function D2K_AI_AsyncDblBufferToFile Lib "D2K-Dask.dll" (ByVal CardNumber As Short) As Short
	Declare Function D2K_AI_ContReadChannel Lib "D2K-Dask.dll" (ByVal CardNumber As Short, ByVal channel As Short, ByVal BufId As Short, ByVal ReadScans As Integer, ByVal ScanIntrv As Integer, ByVal SampIntrv As Integer, ByVal SyncMode As Short) As Short
	Declare Function D2K_AI_ContScanChannels Lib "D2K-Dask.dll" (ByVal wCardNumber As Short, ByVal wChannel As Short, ByVal BufId As Short, ByVal ReadScans As Integer, ByVal ScanIntrv As Integer, ByVal SampIntrv As Integer, ByVal SyncMode As Short) As Short
    Declare Function D2K_AI_ContReadMultiChannels Lib "D2K-Dask.dll" (ByVal CardNumber As Short, ByVal NumChans As Short, ByRef chans As Short, ByVal BufId As Short, ByVal ReadScans As Integer, ByVal ScanIntrv As Integer, ByVal SampIntrv As Integer, ByVal SyncMode As Short) As Short
    Declare Function D2K_AI_ContReadMultiChannels Lib "D2K-Dask.dll" (ByVal CardNumber As Short, ByVal NumChans As Short, ByVal chans As IntPtr, ByVal BufId As Short, ByVal ReadScans As Integer, ByVal ScanIntrv As Integer, ByVal SampIntrv As Integer, ByVal SyncMode As Short) As Short

	Declare Function D2K_AI_ContReadChannelToFile Lib "D2K-Dask.dll" (ByVal CardNumber As Short, ByVal channel As Short, ByVal BufId As Short, ByVal FileName As String, ByVal ReadScans As Integer, ByVal ScanIntrv As Integer, ByVal SampIntrv As Integer, ByVal SyncMode As Short) As Short
	Declare Function D2K_AI_ContScanChannelsToFile Lib "D2K-Dask.dll" (ByVal wCardNumber As Short, ByVal wChannel As Short, ByVal BufId As Short, ByVal FileName As String, ByVal dwReadScans As Integer, ByVal ScanIntrv As Integer, ByVal SampIntrv As Integer, ByVal SyncMode As Short) As Short
    Declare Function D2K_AI_ContReadMultiChannelsToFile Lib "D2K-Dask.dll" (ByVal CardNumber As Short, ByVal NumChans As Short, ByRef chans As Short, ByVal BufId As Short, ByVal FileName As String, ByVal ReadScans As Integer, ByVal ScanIntrv As Integer, ByVal SampIntrv As Integer, ByVal SyncMode As Short) As Short
    Declare Function D2K_AI_ContReadMultiChannelsToFile Lib "D2K-Dask.dll" (ByVal CardNumber As Short, ByVal NumChans As Short, ByVal chans As IntPtr, ByVal BufId As Short, ByVal FileName As String, ByVal ReadScans As Integer, ByVal ScanIntrv As Integer, ByVal SampIntrv As Integer, ByVal SyncMode As Short) As Short

	Declare Function D2K_AI_ContStatus Lib "D2K-Dask.dll" (ByVal CardNumber As Short, ByRef status As Short) As Short
	Declare Function D2K_AI_InitialMemoryAllocated Lib "D2K-Dask.dll" (ByVal CardNumber As Short, ByRef MemSize As Integer) As Short
	Declare Function D2K_AI_ReadChannel Lib "D2K-Dask.dll" (ByVal CardNumber As Short, ByVal channel As Short, ByRef Value As Short) As Short
	Declare Function D2K_AI_VReadChannel Lib "D2K-Dask.dll" (ByVal CardNumber As Short, ByVal channel As Short, ByRef Voltage As Double) As Short
    Declare Function D2K_AI_SimuReadChannel Lib "D2K-Dask.dll" (ByVal CardNumber As Short, ByVal NumChans As Short, ByRef chans As Short, ByRef Buffer As Short) As Short
    Declare Function D2K_AI_SimuReadChannel Lib "D2K-Dask.dll" (ByVal CardNumber As Short, ByVal NumChans As Short, ByRef chans As Short, ByVal Buffer As IntPtr) As Short
    Declare Function D2K_AI_SimuReadChannel Lib "D2K-Dask.dll" (ByVal CardNumber As Short, ByVal NumChans As Short, ByVal chans As IntPtr, ByVal Buffer As IntPtr) As Short

    Declare Function D2K_AI_ScanReadChannels Lib "D2K-Dask.dll" (ByVal CardNumber As Short, ByVal NumChans As Short, ByRef chans As Short, ByRef Buffer As Short) As Short
    Declare Function D2K_AI_ScanReadChannels Lib "D2K-Dask.dll" (ByVal CardNumber As Short, ByVal NumChans As Short, ByRef chans As Short, ByVal Buffer As IntPtr) As Short
    Declare Function D2K_AI_ScanReadChannels Lib "D2K-Dask.dll" (ByVal CardNumber As Short, ByVal NumChans As Short, ByVal chans As IntPtr, ByVal Buffer As IntPtr) As Short

    Declare Function D2K_AI_VoltScale Lib "D2K-Dask.dll" (ByVal CardNumber As Short, ByVal AdRange As Short, ByVal reading As UShort, ByRef Voltage As Double) As Short
    Declare Function D2K_AI_ContVScale Lib "D2K-Dask.dll" (ByVal CardNumber As Short, ByVal AdRange As Short, ByRef readingArray As UShort, ByRef voltageArray As Double, ByVal count As Integer) As Short
    Declare Function D2K_AI_ContVScale Lib "D2K-Dask.dll" (ByVal CardNumber As Short, ByVal AdRange As Short, ByVal readingArray As IntPtr, ByRef voltageArray As Double, ByVal count As Integer) As Short
    Declare Function D2K_AI_ContVScale Lib "D2K-Dask.dll" (ByVal CardNumber As Short, ByVal AdRange As Short, ByVal readingArray As IntPtr, ByVal voltageArray As IntPtr, ByVal count As Integer) As Short

    Declare Function D2K_AI_ContBufferSetup Lib "D2K-Dask.dll" (ByVal CardNumber As Short, ByRef Buffer As UShort, ByVal ReadCount As Integer, ByRef BufferId As Short) As Short
    Declare Function D2K_AI_ContBufferSetup Lib "D2K-Dask.dll" (ByVal CardNumber As Short, ByVal Buffer As IntPtr, ByVal ReadCount As Integer, ByRef BufferId As Short) As Short

	Declare Function D2K_AI_ContBufferReset Lib "D2K-Dask.dll" (ByVal CardNumber As Short) As Short
    Declare Function D2K_AI_MuxScanSetup Lib "D2K-Dask.dll" (ByVal CardNumber As Short, ByVal wNumChans As Short, ByRef chans As Short, ByRef AdRange_RefGnds As Short) As Short
    Declare Function D2K_AI_MuxScanSetup Lib "D2K-Dask.dll" (ByVal CardNumber As Short, ByVal wNumChans As Short, ByVal chans As IntPtr, ByVal AdRange_RefGnds As IntPtr) As Short

    Declare Function D2K_AI_ReadMuxScan Lib "D2K-Dask.dll" (ByVal CardNumber As Short, ByRef Buffer As Short) As Short
    Declare Function D2K_AI_ReadMuxScan Lib "D2K-Dask.dll" (ByVal CardNumber As Short, ByVal Buffer As IntPtr) As Short

	Declare Function D2K_AI_ContMuxScan Lib "D2K-Dask.dll" (ByVal CardNumber As Short, ByVal BufId As Short, ByVal ReadScans As Integer, ByVal ScanIntrv As Integer, ByVal SampIntrv As Integer, ByVal SyncMode As Short) As Short
	Declare Function D2K_AI_ContMuxScanToFile Lib "D2K-Dask.dll" (ByVal CardNumber As Short, ByVal BufId As Short, ByVal FileName As String, ByVal ReadScans As Integer, ByVal ScanIntrv As Integer, ByVal SampIntrv As Integer, ByVal SyncMode As Short) As Short
    Declare Function D2K_AI_EventCallBack Lib "D2K-Dask.dll" (ByVal CardNumber As Short, ByVal Mode As Short, ByVal EventType As Short, ByVal callbackAddr As CallbackDelegate) As Short
	Declare Function D2K_AI_SetTimeout Lib "D2K-Dask.dll" (ByVal CardNumber As Short, ByVal msec As Integer) As Integer
	Declare Function D2K_AI_CounterInterval Lib "D2K-Dask.dll" (ByVal CardNumber As Short, ByVal ScanIntrv As Integer, ByVal SampIntrv As Integer) As Short	
	Declare Function D2K_AI_AsyncDblBufferHandled Lib "D2K-Dask.dll" (ByVal CardNumber As Short) As Short
	Declare Function D2K_AI_AsyncDblBufferOverrun Lib "D2K-Dask.dll" (ByVal CardNumber As Short, ByVal op As Short, ByRef overrunFlag As Short) As Short	
	Declare Function D2K_AI_AsyncReTrigNextReady Lib "D2K-Dask.dll" (ByVal CardNumber As Short, ByRef trgReady As Byte, ByRef StopFlag As Byte, ByRef RdyTrigCnt As Short) As Short
	Declare Function D2K_AI_AsyncReTrigNextReadyEx Lib "D2K-Dask.dll" (ByVal CardNumber As Short, ByRef trgReady As Byte, ByRef StopFlag As Byte, ByRef RdyTrigCnt As Integer) As Short		
	'AO Function
	Declare Function D2K_AO_CH_Config Lib "D2K-Dask.dll" (ByVal CardNumber As Short, ByVal channel As Short, ByVal OutputPolarity As Short, ByVal wIntOrExtRef As Short, ByVal refVoltage As Double) As Short
	Declare Function D2K_AO_Config Lib "D2K-Dask.dll" (ByVal CardNumber As Short, ByVal ConfigCtrl As Short, ByVal TrigCtrl As Short, ByVal ReTrgCnt As Short, ByVal DLY1Cnt As Short, ByVal DLY2Cnt As Short, ByVal AutoResetBuf As Byte) As Short
	Declare Function D2K_AO_PostTrig_Config Lib "D2K-Dask.dll" (ByVal CardNumber As Short, ByVal ClkSrc As Short, ByVal TrigSrcCtrl As Short, ByVal DLY2Ctrl As Short, ByVal DLY2Cnt As Short, ByVal ReTrgEn As Short, ByVal ReTrgCnt As Short, ByVal AutoResetBuf As Byte) As Short
	Declare Function D2K_AO_DelayTrig_Config Lib "D2K-Dask.dll" (ByVal CardNumber As Short, ByVal ClkSrc As Short, ByVal TrigSrcCtrl As Short, ByVal DLY1Cnt As Short, ByVal DLY2Ctrl As Short, ByVal DLY2Cnt As Short, ByVal ReTrgEn As Short, ByVal ReTrgCnt As Short, ByVal AutoResetBuf As Byte) As Short
	Declare Function D2K_AO_InitialMemoryAllocated Lib "D2K-Dask.dll" (ByVal CardNumber As Short, ByRef MemSize As Integer) As Short
	Declare Function D2K_AO_AsyncCheck Lib "D2K-Dask.dll" (ByVal CardNumber As Short, ByRef Stopped As Byte, ByRef WriteCnt As Integer) As Short
	Declare Function D2K_AO_AsyncClear Lib "D2K-Dask.dll" (ByVal CardNumber As Short, ByRef WriteCnt As Integer, ByVal stop_mode As Short) As Short
	Declare Function D2K_AO_AsyncClearEx Lib "D2K-Dask.dll" (ByVal CardNumber As Short, ByRef WriteCnt As Integer, ByVal stop_mode As Short, ByVal NoWait As Integer) As Short
	Declare Function D2K_AO_AsyncDblBufferHalfReady Lib "D2K-Dask.dll" (ByVal CardNumber As Short, ByRef HalfReady As Byte) As Short
	Declare Function D2K_AO_AsyncDblBufferMode Lib "D2K-Dask.dll" (ByVal CardNumber As Short, ByVal enable As Byte) As Short
	Declare Function D2K_AO_ContWriteChannel Lib "D2K-Dask.dll" (ByVal CardNumber As Short, ByVal channel As Short, ByVal BufId As Short, ByVal UpdateCount As Integer, ByVal Iterations As Integer, ByVal CHUI As Integer, ByVal definite As Short, ByVal SyncMode As Short) As Short
    Declare Function D2K_AO_ContReadMultiChannels Lib "D2K-Dask.dll" (ByVal CardNumber As Short, ByVal NumChans As Short, ByRef chans As Short, ByVal BufId As Short, ByVal UpdateCount As Integer, ByVal Iterations As Integer, ByVal CHUI As Integer, ByVal definite As Short, ByVal SyncMode As Short) As Short
    Declare Function D2K_AO_ContReadMultiChannels Lib "D2K-Dask.dll" (ByVal CardNumber As Short, ByVal NumChans As Short, ByVal chans As IntPtr, ByVal BufId As Short, ByVal UpdateCount As Integer, ByVal Iterations As Integer, ByVal CHUI As Integer, ByVal definite As Short, ByVal SyncMode As Short) As Short

    Declare Function D2K_AO_SimuWriteChannel Lib "D2K-Dask.dll" (ByVal CardNumber As Short, ByVal NumChans As Short, ByRef Buffer As Short) As Short
    Declare Function D2K_AO_SimuWriteChannel Lib "D2K-Dask.dll" (ByVal CardNumber As Short, ByVal NumChans As Short, ByVal Buffer As IntPtr) As Short

    Declare Function D2K_AO_ContBufferSetup Lib "D2K-Dask.dll" (ByVal CardNumber As Short, ByRef Buffer As Short, ByVal WriteCount As Integer, ByRef BufferId As Short) As Short
    Declare Function D2K_AO_ContBufferSetup Lib "D2K-Dask.dll" (ByVal CardNumber As Short, ByVal Buffer As IntPtr, ByVal WriteCount As Integer, ByRef BufferId As Short) As Short

	Declare Function D2K_AO_ContBufferReset Lib "D2K-Dask.dll" (ByVal CardNumber As Short) As Short
	Declare Function D2K_AO_WriteChannel Lib "D2K-Dask.dll" (ByVal CardNumber As Short, ByVal channel As Short, ByVal Value As Short) As Short
	Declare Function D2K_AO_VWriteChannel Lib "D2K-Dask.dll" (ByVal CardNumber As Short, ByVal channel As Short, ByVal Voltage As Double) As Short
	Declare Function D2K_AO_VoltScale Lib "D2K-Dask.dll" (ByVal CardNumber As Short, ByVal channel As Short, ByVal Voltage As Double, ByRef binValue As Short) As Short
    Declare Function D2K_AO_ContBufferComposeAll Lib "D2K-Dask.dll" (ByVal CardNumber As Short, ByVal group As Short, ByVal UpdateCount As Integer, ByRef ConBuffer As Short, ByRef Buffer As Short, ByVal fifoload As Byte) As Short
    Declare Function D2K_AO_ContBufferComposeAll Lib "D2K-Dask.dll" (ByVal CardNumber As Short, ByVal group As Short, ByVal UpdateCount As Integer, ByVal ConBuffer As IntPtr, ByVal Buffer As IntPtr, ByVal fifoload As Byte) As Short

    Declare Function D2K_AO_ContBufferCompose Lib "D2K-Dask.dll" (ByVal CardNumber As Short, ByVal group As Short, ByVal channel As Short, ByVal UpdateCount As Integer, ByRef ConBuffer As Short, ByRef Buffer As Short, ByVal fifoload As Byte) As Short
    Declare Function D2K_AO_ContBufferCompose Lib "D2K-Dask.dll" (ByVal CardNumber As Short, ByVal group As Short, ByVal channel As Short, ByVal UpdateCount As Integer, ByVal ConBuffer As IntPtr, ByVal Buffer As IntPtr, ByVal fifoload As Byte) As Short


	Declare Function D2K_AO_EventCallBack Lib "D2K-Dask.dll" (ByVal CardNumber As Short, ByVal Mode As Short, ByVal EventType As Short, ByVal callbackAddr As Integer) As Short
	Declare Function D2K_AO_SetTimeout Lib "D2K-Dask.dll" (ByVal CardNumber As Short, ByVal msec As Integer) As Integer
	Declare Function D2K_A0_CounterInterval Lib "D2K-Dask.dll" (ByVal CardNumber As Short, ByVal CHUI As Integer) As Short
	'AO Group Functions
    Declare Function D2K_AO_Group_Setup Lib "D2K-Dask.dll" (ByVal CardNumber As Short, ByVal group As Short, ByVal wNumChans As Short, ByRef wChans As Short) As Short
    Declare Function D2K_AO_Group_Setup Lib "D2K-Dask.dll" (ByVal CardNumber As Short, ByVal group As Short, ByVal wNumChans As Short, ByVal wChans As IntPtr) As Short

    Declare Function D2K_AO_Group_Update Lib "D2K-Dask.dll" (ByVal CardNumber As Short, ByVal group As Short, ByRef wBuffer As Short) As Short
    Declare Function D2K_AO_Group_Update Lib "D2K-Dask.dll" (ByVal CardNumber As Short, ByVal group As Short, ByVal wBuffer As IntPtr) As Short

    Declare Function D2K_AO_Group_VUpdate Lib "D2K-Dask.dll" (ByVal CardNumber As Short, ByVal group As Short, ByRef Voltage As Double) As Short
    Declare Function D2K_AO_Group_VUpdate Lib "D2K-Dask.dll" (ByVal CardNumber As Short, ByVal group As Short, ByVal Voltage As IntPtr) As Short

    Declare Function D2K_AO_Group_FIFOLoad Lib "D2K-Dask.dll" (ByVal CardNumber As Short, ByVal group As Short, ByVal BufId As Short, ByVal dwWriteCount As Integer) As Short
	Declare Function D2K_AO_Group_WFM_StopConfig Lib "D2K-Dask.dll" (ByVal CardNumber As Short, ByVal group As Short, ByVal stopSrc As Short, ByVal stopMode As Short) As Short
	Declare Function D2K_AO_Group_WFM_Start Lib "D2K-Dask.dll" (ByVal CardNumber As Short, ByVal group As Short, ByVal fstBufIdOrNotUsed As Short, ByVal sndBufId As Short, ByVal UpdateCount As Integer, ByVal Iterations As Integer, ByVal CHUI As Integer, ByVal definite As Short) As Short
	Declare Function D2K_AO_Group_WFM_AsyncCheck Lib "D2K-Dask.dll" (ByVal CardNumber As Short, ByVal group As Short, ByRef Stopped As Byte, ByRef WriteCnt As Integer) As Short
	Declare Function D2K_AO_Group_WFM_AsyncClear Lib "D2K-Dask.dll" (ByVal CardNumber As Short, ByVal group As Short, ByRef WriteCnt As Integer, ByVal stop_mode As Short) As Short
	'DI Functions
	Declare Function D2K_DI_ReadPort Lib "D2K-Dask.dll" (ByVal CardNumber As Short, ByVal Port As Short, ByRef Value As Integer) As Short
	Declare Function D2K_DI_ReadLine Lib "D2K-Dask.dll" (ByVal CardNumber As Short, ByVal Port As Short, ByVal Line As Short, ByRef Value As Short) As Short
	
	'DO Functions
	Declare Function D2K_DO_WritePort Lib "D2K-Dask.dll" (ByVal CardNumber As Short, ByVal Port As Short, ByVal Value As Integer) As Short
	Declare Function D2K_DO_WriteLine Lib "D2K-Dask.dll" (ByVal CardNumber As Short, ByVal Port As Short, ByVal Line As Short, ByVal Value As Short) As Short
	Declare Function D2K_DO_ReadLine Lib "D2K-Dask.dll" (ByVal CardNumber As Short, ByVal Port As Short, ByVal Line As Short, ByRef Value As Short) As Short
	Declare Function D2K_DO_ReadPort Lib "D2K-Dask.dll" (ByVal CardNumber As Short, ByVal Port As Short, ByRef Value As Integer) As Short
	
	'DIO Functions
	Declare Function D2K_DIO_PortConfig Lib "D2K-Dask.dll" (ByVal CardNumber As Short, ByVal Port As Short, ByVal Direction As Short) As Short
	Declare Function D2K_DIO_LineConfig Lib "D2K-Dask.dll" (ByVal CardNumber As Short, ByVal Port As Short, ByVal wLine As Integer , ByVal Direction As Short) As Short
	Declare Function D2K_DIO_LinesConfig Lib "D2K-Dask.dll" (ByVal CardNumber As Short, ByVal Port As Short, ByVal wLinesdirmap As Integer) As Short
			
	'Counter Functions
	Declare Function D2K_GCTR_Setup Lib "D2K-Dask.dll" (ByVal CardNumber As Short, ByVal wGCtr As Short, ByVal wMode As Short, ByVal SrcCtrl As Byte, ByVal PolCtrl As Byte, ByVal LReg1_Val As Short, ByVal LReg2_Val As Short) As Short
	Declare Function D2K_GCTR_SetupEx Lib "D2K-Dask.dll" (ByVal CardNumber As Short, ByVal wGCtr As Short, ByVal wMode As Short, ByVal SrcCtrl As Byte, ByVal PolCtrl As Byte, ByVal LReg1_Val As Integer, ByVal LReg2_Val As Integer) As Short
	Declare Function D2K_GCTR_Control Lib "D2K-Dask.dll" (ByVal CardNumber As Short, ByVal wGCtr As Short, ByVal ParamID As Short, ByVal Value As Short) As Short
	Declare Function D2K_GCTR_Reset Lib "D2K-Dask.dll" (ByVal CardNumber As Short, ByVal wGCtr As Short) As Short
	Declare Function D2K_GCTR_Read Lib "D2K-Dask.dll" (ByVal CardNumber As Short, ByVal wGCtr As Short, ByRef pValue As Integer) As Short
	Declare Function D2K_GCTR_Status Lib "D2K-Dask.dll" (ByVal CardNumber As Short, ByVal wGCtr As Short, ByRef pValue As Short) As Short
	
	'SSI Functions
	Declare Function D2K_SSI_SourceConn Lib "D2K-Dask.dll" (ByVal CardNumber As Short, ByVal sigCode As Short) As Short
	Declare Function D2K_SSI_SourceDisConn Lib "D2K-Dask.dll" (ByVal CardNumber As Short, ByVal sigCode As Short) As Short
	Declare Function D2K_SSI_SourceClear Lib "D2K-Dask.dll" (ByVal CardNumber As Short) As Short
    	Declare Function D2K_Route_Signal Lib "WD-Dask.dll" (ByVal CardNumber As Short, ByVal signal As Short, ByVal polarity As Short, ByVal Line As Short, ByVal direct As Short) As Short
	Declare Function D2K_Signal_DisConn Lib "WD-Dask.dll" (ByVal CardNumber As Short, ByVal signal As Short, ByVal polarity As Short, ByVal Line As Short) As Short
		
	'Calibration Functions
	Declare Function DAQ2204_Acquire_AD_Error Lib "D2K-Dask.dll" (ByVal wCardNumber As Short, ByRef gain_err As Single, ByRef bioffset_err As Single, ByRef unioffset_err As Single, ByRef hg_bios_err As Single) As Short
	Declare Function DAQ2204_Acquire_DA_Error Lib "D2K-Dask.dll" (ByVal wCardNumber As Short, ByVal channel As Short, ByVal polarity As Short, ByRef da0v_err As Single, ByRef da5v_err As Single) As Short
	Declare Function DAQ2205_Acquire_AD_Error Lib "D2K-Dask.dll" (ByVal wCardNumber As Short, ByRef gain_err As Single, ByRef bioffset_err As Single, ByRef unioffset_err As Single, ByRef hg_bios_err As Single) As Short
	Declare Function DAQ2205_Acquire_DA_Error Lib "D2K-Dask.dll" (ByVal wCardNumber As Short, ByVal channel As Short, ByVal polarity As Short, ByRef da0v_err As Single, ByRef da5v_err As Single) As Short
	Declare Function DAQ2206_Acquire_AD_Error Lib "D2K-Dask.dll" (ByVal wCardNumber As Short, ByRef gain_err As Single, ByRef bioffset_err As Single, ByRef unioffset_err As Single, ByRef hg_bios_err As Single) As Short
	Declare Function DAQ2206_Acquire_DA_Error Lib "D2K-Dask.dll" (ByVal wCardNumber As Short, ByVal channel As Short, ByVal polarity As Short, ByRef da0v_err As Single, ByRef da5v_err As Single) As Short
	Declare Function DAQ2010_Acquire_AD_Error Lib "D2K-Dask.dll" (ByVal wCardNumber As Short, ByVal channel As Short, ByVal polarity As Short, ByRef gain_err As Single, ByRef offset_err As Single) As Short
	Declare Function DAQ2010_Acquire_DA_Error Lib "D2K-Dask.dll" (ByVal wCardNumber As Short, ByVal channel As Short, ByVal polarity As Short, ByRef gain_err As Single, ByRef offset_err As Single) As Short
	Declare Function DAQ2005_Acquire_AD_Error Lib "D2K-Dask.dll" (ByVal wCardNumber As Short, ByVal channel As Short, ByVal polarity As Short, ByRef gain_err As Single, ByRef offset_err As Single) As Short
	Declare Function DAQ2005_Acquire_DA_Error Lib "D2K-Dask.dll" (ByVal wCardNumber As Short, ByVal channel As Short, ByVal polarity As Short, ByRef gain_err As Single, ByRef offset_err As Single) As Short
	Declare Function DAQ2006_Acquire_AD_Error Lib "D2K-Dask.dll" (ByVal wCardNumber As Short, ByVal channel As Short, ByVal polarity As Short, ByRef gain_err As Single, ByRef offset_err As Single) As Short
	Declare Function DAQ2006_Acquire_DA_Error Lib "D2K-Dask.dll" (ByVal wCardNumber As Short, ByVal channel As Short, ByVal polarity As Short, ByRef gain_err As Single, ByRef offset_err As Single) As Short
	Declare Function DAQ2208_Acquire_AD_Error Lib "D2K-Dask.dll" (ByVal wCardNumber As Short, ByRef gain_err As Single, ByRef bioffset_err As Single, ByRef unioffset_err As Single, ByRef hg_bios_err As Single) As Short
	Declare Function DAQ250X_Acquire_AD_Error Lib "D2K-Dask.dll" (ByVal wCardNumber As Short, ByVal polarity As Short, ByRef gain_err As Single, ByRef offset_err As Single) As Short
	Declare Function DAQ250X_Acquire_DA_Error Lib "D2K-Dask.dll" (ByVal wCardNumber As Short, ByVal channel As Short, ByVal polarity As Short, ByRef gain_err As Single, ByRef offset_err As Single) As Short
	Declare Function D2K_DB_Auto_Calibration_ALL Lib "D2K-Dask.dll" (ByVal wCardNumber As Short) As Short
	Declare Function D2K_EEPROM_CAL_Constant_Update Lib "D2K-Dask.dll" (ByVal wCardNumber As Short, ByVal bank As Short) As Short
	Declare Function D2K_Load_CAL_Data Lib "D2K-Dask.dll" (ByVal wCardNumber As Short, ByVal bank As Short) As Short
	Declare Function D2K_Set_Default_Load_Area Lib "D2K-Dask.dll" (ByVal CardNumber As Short, ByVal bank As Short) As Short
	Declare Function D2K_Get_Default_Load_Area Lib "D2K-Dask.dll" (ByVal CardNumber As Short) As Short	
End Module