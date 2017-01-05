Option Strict Off
Option Explicit On
Module Module1
	
	'  System Section 6.3
	Declare Function B_8158_initial Lib "8158.dll"  Alias "_8158_initial"(ByRef CardID_InBit As Short, ByVal Manual_ID As Short) As Short
	Declare Function B_8158_close Lib "8158.dll"  Alias "_8158_close"() As Short
	Declare Function B_8158_get_version Lib "8158.dll"  Alias "_8158_get_version"(ByVal CardId As Short, ByRef firmware_ver As Short, ByRef driver_ver As Integer, ByRef dll_ver As Integer) As Short
	Declare Function B_8158_set_security_key Lib "8158.dll"  Alias "_8158_set_security_key"(ByVal CardId As Short, ByVal old_secu_code As Short, ByVal new_secu_code As Short) As Short
	Declare Function B_8158_check_security_key Lib "8158.dll"  Alias "_8158_check_security_key"(ByVal CardId As Short, ByVal secu_code As Short) As Short
	Declare Function B_8158_reset_security_key Lib "8158.dll"  Alias "_8158_reset_security_key"(ByVal CardId As Short) As Short
	Declare Function B_8158_config_from_file Lib "8158.dll"  Alias "_8158_config_from_file"() As Short
	'
	' Pulse Input/Output Configuration Section 6.4
	Declare Function B_8158_set_pls_outmode Lib "8158.dll"  Alias "_8158_set_pls_outmode"(ByVal AxisNo As Short, ByVal pls_outmode As Short) As Short
	Declare Function B_8158_set_pls_iptmode Lib "8158.dll"  Alias "_8158_set_pls_iptmode"(ByVal AxisNo As Short, ByVal pls_iptmode As Short, ByVal pls_logic As Short) As Short
	Declare Function B_8158_set_feedback_src Lib "8158.dll"  Alias "_8158_set_feedback_src"(ByVal AxisNo As Short, ByVal Src As Short) As Short
	'
	' Velocity mode motion Section 6.5
	Declare Function B_8158_tv_move Lib "8158.dll"  Alias "_8158_tv_move"(ByVal AxisNo As Short, ByVal StrVel As Double, ByVal MaxVel As Double, ByVal Tacc As Double) As Short
	Declare Function B_8158_sv_move Lib "8158.dll"  Alias "_8158_sv_move"(ByVal AxisNo As Short, ByVal StrVel As Double, ByVal MaxVel As Double, ByVal Tacc As Double, ByVal SVacc As Double) As Short
	Declare Function B_8158_sd_stop Lib "8158.dll"  Alias "_8158_sd_stop"(ByVal AxisNo As Short, ByVal Tdec As Double) As Short
	Declare Function B_8158_emg_stop Lib "8158.dll"  Alias "_8158_emg_stop"(ByVal AxisNo As Short) As Short
	Declare Function B_8158_get_current_speed Lib "8158.dll"  Alias "_8158_get_current_speed"(ByVal AxisNo As Short, ByRef speed As Double) As Short
	Declare Function B_8158_speed_override Lib "8158.dll"  Alias "_8158_speed_override"(ByVal CAxisNo As Short, ByVal NewVelPercent As Double, ByVal Time As Double) As Short
	Declare Function B_8158_set_max_override_speed Lib "8158.dll"  Alias "_8158_set_max_override_speed"(ByVal AxisNo As Short, ByVal OvrdSpeed As Double, ByVal enable As Short) As Short
	'
	' Single Axis Position Mode Section 6.6
	Declare Function B_8158_start_tr_move Lib "8158.dll"  Alias "_8158_start_tr_move"(ByVal AxisNo As Short, ByVal Dist As Double, ByVal StrVel As Double, ByVal MaxVel As Double, ByVal Tacc As Double, ByVal Tdec As Double) As Short
	Declare Function B_8158_start_ta_move Lib "8158.dll"  Alias "_8158_start_ta_move"(ByVal AxisNo As Short, ByVal Pos As Double, ByVal StrVel As Double, ByVal MaxVel As Double, ByVal Tacc As Double, ByVal Tdec As Double) As Short
	Declare Function B_8158_start_sr_move Lib "8158.dll"  Alias "_8158_start_sr_move"(ByVal AxisNo As Short, ByVal Dist As Double, ByVal StrVel As Double, ByVal MaxVel As Double, ByVal Tacc As Double, ByVal Tdec As Double, ByVal SVacc As Double, ByVal SVdec As Double) As Short
	Declare Function B_8158_start_sa_move Lib "8158.dll"  Alias "_8158_start_sa_move"(ByVal AxisNo As Short, ByVal Pos As Double, ByVal StrVel As Double, ByVal MaxVel As Double, ByVal Tacc As Double, ByVal Tdec As Double, ByVal SVacc As Double, ByVal SVdec As Double) As Short
	Declare Function B_8158_set_move_ratio Lib "8158.dll"  Alias "_8158_set_move_ratio"(ByVal AxisNo As Short, ByVal move_ratio As Double) As Short
	Declare Function B_8158_position_override Lib "8158.dll"  Alias "_8158_position_override"(ByVal AxisNo As Short, ByVal NewPos As Double) As Short
	'
	' Linear Interpolated Motion Section 6.7
	'  Two Axes Linear Interpolation function
	Declare Function B_8158_start_tr_move_xy Lib "8158.dll"  Alias "_8158_start_tr_move_xy"(ByVal CardId As Short, ByVal DistX As Double, ByVal DistY As Double, ByVal StrVel As Double, ByVal MaxVel As Double, ByVal Tacc As Double, ByVal Tdec As Double) As Short
	Declare Function B_8158_start_tr_move_zu Lib "8158.dll"  Alias "_8158_start_tr_move_zu"(ByVal CardId As Short, ByVal DistX As Double, ByVal DistY As Double, ByVal StrVel As Double, ByVal MaxVel As Double, ByVal Tacc As Double, ByVal Tdec As Double) As Short
	'
	Declare Function B_8158_start_ta_move_xy Lib "8158.dll"  Alias "_8158_start_ta_move_xy"(ByVal CardId As Short, ByVal PosX As Double, ByVal PosY As Double, ByVal StrVel As Double, ByVal MaxVel As Double, ByVal Tacc As Double, ByVal Tdec As Double) As Short
	Declare Function B_8158_start_ta_move_zu Lib "8158.dll"  Alias "_8158_start_ta_move_zu"(ByVal CardId As Short, ByVal PosX As Double, ByVal PosY As Double, ByVal StrVel As Double, ByVal MaxVel As Double, ByVal Tacc As Double, ByVal Tdec As Double) As Short
	'
	Declare Function B_8158_start_sr_move_xy Lib "8158.dll"  Alias "_8158_start_sr_move_xy"(ByVal CardId As Short, ByVal DistX As Double, ByVal DistY As Double, ByVal StrVel As Double, ByVal MaxVel As Double, ByVal Tacc As Double, ByVal Tdec As Double, ByVal SVacc As Double, ByVal SVdec As Double) As Short
	Declare Function B_8158_start_sr_move_zu Lib "8158.dll"  Alias "_8158_start_sr_move_zu"(ByVal CardId As Short, ByVal DistX As Double, ByVal DistY As Double, ByVal StrVel As Double, ByVal MaxVel As Double, ByVal Tacc As Double, ByVal Tdec As Double, ByVal SVacc As Double, ByVal SVdec As Double) As Short
	'
	Declare Function B_8158_start_sa_move_xy Lib "8158.dll"  Alias "_8158_start_sa_move_xy"(ByVal CardId As Short, ByVal PosX As Double, ByVal PosY As Double, ByVal StrVel As Double, ByVal MaxVel As Double, ByVal Tacc As Double, ByVal Tdec As Double, ByVal SVacc As Double, ByVal SVdec As Double) As Short
	Declare Function B_8158_start_sa_move_zu Lib "8158.dll"  Alias "_8158_start_sa_move_zu"(ByVal CardId As Short, ByVal PosX As Double, ByVal PosY As Double, ByVal StrVel As Double, ByVal MaxVel As Double, ByVal Tacc As Double, ByVal Tdec As Double, ByVal SVacc As Double, ByVal SVdec As Double) As Short
	'
	' Any 2 of former or later 4 axes linear interpolation function
	Declare Function B_8158_start_tr_line2 Lib "8158.dll"  Alias "_8158_start_tr_line2"(ByRef AxisArray As Short, ByRef DistArray As Double, ByVal StrVel As Double, ByVal MaxVel As Double, ByVal Tacc As Double, ByVal Tdec As Double) As Short
	Declare Function B_8158_start_ta_line2 Lib "8158.dll"  Alias "_8158_start_ta_line2"(ByRef AxisArray As Short, ByRef PosArray As Double, ByVal StrVel As Double, ByVal MaxVel As Double, ByVal Tacc As Double, ByVal Tdec As Double) As Short
	Declare Function B_8158_start_sr_line2 Lib "8158.dll"  Alias "_8158_start_sr_line2"(ByRef AxisArray As Short, ByRef DistArray As Double, ByVal StrVel As Double, ByVal MaxVel As Double, ByVal Tacc As Double, ByVal Tdec As Double, ByVal SVacc As Double, ByVal SVdec As Double) As Short
	Declare Function B_8158_start_sa_line2 Lib "8158.dll"  Alias "_8158_start_sa_line2"(ByRef AxisArray As Short, ByRef PosArray As Double, ByVal StrVel As Double, ByVal MaxVel As Double, ByVal Tacc As Double, ByVal Tdec As Double, ByVal SVacc As Double, ByVal SVdec As Double) As Short
	'
	' Any 3 of former or later 4 axes linear interpolation function
	Declare Function B_8158_start_tr_line3 Lib "8158.dll"  Alias "_8158_start_tr_line3"(ByRef AxisArray As Short, ByRef DistArray As Double, ByVal StrVel As Double, ByVal MaxVel As Double, ByVal Tacc As Double, ByVal Tdec As Double) As Short
	Declare Function B_8158_start_ta_line3 Lib "8158.dll"  Alias "_8158_start_ta_line3"(ByRef AxisArray As Short, ByRef PosArray As Double, ByVal StrVel As Double, ByVal MaxVel As Double, ByVal Tacc As Double, ByVal Tdec As Double) As Short
	Declare Function B_8158_start_sr_line3 Lib "8158.dll"  Alias "_8158_start_sr_line3"(ByRef AxisArray As Short, ByRef DistArray As Double, ByVal StrVel As Double, ByVal MaxVel As Double, ByVal Tacc As Double, ByVal Tdec As Double, ByVal SVacc As Double, ByVal SVdec As Double) As Short
	Declare Function B_8158_start_sa_line3 Lib "8158.dll"  Alias "_8158_start_sa_line3"(ByRef AxisArray As Short, ByRef PosArray As Double, ByVal StrVel As Double, ByVal MaxVel As Double, ByVal Tacc As Double, ByVal Tdec As Double, ByVal SVacc As Double, ByVal SVdec As Double) As Short
	'
	' Former or later 4 Axes linear interpolation function
	Declare Function B_8158_start_tr_line4 Lib "8158.dll"  Alias "_8158_start_tr_line4"(ByRef AxisArray As Short, ByRef DistArray As Double, ByVal StrVel As Double, ByVal MaxVel As Double, ByVal Tacc As Double, ByVal Tdec As Double) As Short
	Declare Function B_8158_start_ta_line4 Lib "8158.dll"  Alias "_8158_start_ta_line4"(ByRef AxisArray As Short, ByRef PosArray As Double, ByVal StrVel As Double, ByVal MaxVel As Double, ByVal Tacc As Double, ByVal Tdec As Double) As Short
	Declare Function B_8158_start_sr_line4 Lib "8158.dll"  Alias "_8158_start_sr_line4"(ByRef AxisArray As Short, ByRef DistArray As Double, ByVal StrVel As Double, ByVal MaxVel As Double, ByVal Tacc As Double, ByVal Tdec As Double, ByVal SVacc As Double, ByVal SVdec As Double) As Short
	Declare Function B_8158_start_sa_line4 Lib "8158.dll"  Alias "_8158_start_sa_line4"(ByRef AxisArray As Short, ByRef PosArray As Double, ByVal StrVel As Double, ByVal MaxVel As Double, ByVal Tacc As Double, ByVal Tdec As Double, ByVal SVacc As Double, ByVal SVdec As Double) As Short
	
	'
	' Circular Interpolation Motion Section 6.8
	'  Two Axes Arc Interpolation function
	Declare Function B_8158_start_tr_arc_xy Lib "8158.dll"  Alias "_8158_start_tr_arc_xy"(ByVal CardId As Short, ByVal OffsetCx As Double, ByVal OffsetCy As Double, ByVal OffsetEx As Double, ByVal OffsetEy As Double, ByVal CW_CCW As Short, ByVal StrVel As Double, ByVal MaxVel As Double, ByVal Tacc As Double, ByVal Tdec As Double) As Short
	Declare Function B_8158_start_ta_arc_xy Lib "8158.dll"  Alias "_8158_start_ta_arc_xy"(ByVal CardId As Short, ByVal Cx As Double, ByVal Cy As Double, ByVal Ex As Double, ByVal Ey As Double, ByVal CW_CCW As Short, ByVal StrVel As Double, ByVal MaxVel As Double, ByVal Tacc As Double, ByVal Tdec As Double) As Short
	Declare Function B_8158_start_sr_arc_xy Lib "8158.dll"  Alias "_8158_start_sr_arc_xy"(ByVal CardId As Short, ByVal OffsetCx As Double, ByVal OffsetCy As Double, ByVal OffsetEx As Double, ByVal OffsetEy As Double, ByVal CW_CCW As Short, ByVal StrVel As Double, ByVal MaxVel As Double, ByVal Tacc As Double, ByVal Tdec As Double, ByVal SVacc As Double, ByVal SVdec As Double) As Short
	Declare Function B_8158_start_sa_arc_xy Lib "8158.dll"  Alias "_8158_start_sa_arc_xy"(ByVal CardId As Short, ByVal Cx As Double, ByVal Cy As Double, ByVal Ex As Double, ByVal Ey As Double, ByVal CW_CCW As Short, ByVal StrVel As Double, ByVal MaxVel As Double, ByVal Tacc As Double, ByVal Tdec As Double, ByVal SVacc As Double, ByVal SVdec As Double) As Short
	'
	Declare Function B_8158_start_tr_arc_zu Lib "8158.dll"  Alias "_8158_start_tr_arc_zu"(ByVal CardId As Short, ByVal OffsetCx As Double, ByVal OffsetCy As Double, ByVal OffsetEx As Double, ByVal OffsetEy As Double, ByVal CW_CCW As Short, ByVal StrVel As Double, ByVal MaxVel As Double, ByVal Tacc As Double, ByVal Tdec As Double) As Short
	Declare Function B_8158_start_ta_arc_zu Lib "8158.dll"  Alias "_8158_start_ta_arc_zu"(ByVal CardId As Short, ByVal Cx As Double, ByVal Cy As Double, ByVal Ex As Double, ByVal Ey As Double, ByVal CW_CCW As Short, ByVal StrVel As Double, ByVal MaxVel As Double, ByVal Tacc As Double, ByVal Tdec As Double) As Short
	Declare Function B_8158_start_sr_arc_zu Lib "8158.dll"  Alias "_8158_start_sr_arc_zu"(ByVal CardId As Short, ByVal OffsetCx As Double, ByVal OffsetCy As Double, ByVal OffsetEx As Double, ByVal OffsetEy As Double, ByVal CW_CCW As Short, ByVal StrVel As Double, ByVal MaxVel As Double, ByVal Tacc As Double, ByVal Tdec As Double, ByVal SVacc As Double, ByVal SVdec As Double) As Short
	Declare Function B_8158_start_sa_arc_zu Lib "8158.dll"  Alias "_8158_start_sa_arc_zu"(ByVal CardId As Short, ByVal Cx As Double, ByVal Cy As Double, ByVal Ex As Double, ByVal Ey As Double, ByVal CW_CCW As Short, ByVal StrVel As Double, ByVal MaxVel As Double, ByVal Tacc As Double, ByVal Tdec As Double, ByVal SVacc As Double, ByVal SVdec As Double) As Short
	'
	Declare Function B_8158_start_tr_arc2 Lib "8158.dll"  Alias "_8158_start_tr_arc2"(ByRef AxisArray As Short, ByRef OffsetCenter As Double, ByRef OffsetEnd As Double, ByVal CW_CCW As Short, ByVal StrVel As Double, ByVal MaxVel As Double, ByVal Tacc As Double, ByVal Tdec As Double) As Short
	Declare Function B_8158_start_ta_arc2 Lib "8158.dll"  Alias "_8158_start_ta_arc2"(ByRef AxisArray As Short, ByRef CenterPos As Double, ByRef EndPos As Double, ByVal CW_CCW As Short, ByVal StrVel As Double, ByVal MaxVel As Double, ByVal Tacc As Double, ByVal Tdec As Double) As Short
	Declare Function B_8158_start_sr_arc2 Lib "8158.dll"  Alias "_8158_start_sr_arc2"(ByRef AxisArray As Short, ByRef OffsetCenter As Double, ByRef OffsetEnd As Double, ByVal CW_CCW As Short, ByVal StrVel As Double, ByVal MaxVel As Double, ByVal Tacc As Double, ByVal Tdec As Double, ByVal SVacc As Double, ByVal SVdec As Double) As Short
	Declare Function B_8158_start_sa_arc2 Lib "8158.dll"  Alias "_8158_start_sa_arc2"(ByRef AxisArray As Short, ByRef CenterPos As Double, ByRef EndPos As Double, ByVal CW_CCW As Short, ByVal StrVel As Double, ByVal MaxVel As Double, ByVal Tacc As Double, ByVal Tdec As Double, ByVal SVacc As Double, ByVal SVdec As Double) As Short
	'
	' Helical Interpolation Motion Section 6.9
	Declare Function B_8158_start_tr_helical Lib "8158.dll"  Alias "_8158_start_tr_helical"(ByVal Card_ID As Short, ByVal OffsetCx As Double, ByVal OffsetCy As Double, ByVal OffsetEx As Double, ByVal OffsetEy As Double, ByVal PitchDist As Double, ByVal CW_CCW As Short, ByVal StrVel As Double, ByVal MaxVel As Double, ByVal Tacc As Double, ByVal Tdec As Double) As Short
	Declare Function B_8158_start_ta_helical Lib "8158.dll"  Alias "_8158_start_ta_helical"(ByVal Card_ID As Short, ByVal Cx As Double, ByVal Cy As Double, ByVal Ex As Double, ByVal Ey As Double, ByVal PitchPos As Double, ByVal CW_CCW As Short, ByVal StrVel As Double, ByVal MaxVel As Double, ByVal Tacc As Double, ByVal Tdec As Double) As Short
	Declare Function B_8158_start_sr_helical Lib "8158.dll"  Alias "_8158_start_sr_helical"(ByVal Card_ID As Short, ByVal OffsetCx As Double, ByVal OffsetCy As Double, ByVal OffsetEx As Double, ByVal OffsetEy As Double, ByVal PitchDist As Double, ByVal CW_CCW As Short, ByVal StrVel As Double, ByVal MaxVel As Double, ByVal Tacc As Double, ByVal Tdec As Double, ByVal SVacc As Double, ByVal SVdec As Double) As Short
	Declare Function B_8158_start_sa_helical Lib "8158.dll"  Alias "_8158_start_sa_helical"(ByVal Card_ID As Short, ByVal Cx As Double, ByVal Cy As Double, ByVal Ex As Double, ByVal Ey As Double, ByVal PitchPos As Double, ByVal CW_CCW As Short, ByVal StrVel As Double, ByVal MaxVel As Double, ByVal Tacc As Double, ByVal Tdec As Double, ByVal SVacc As Double, ByVal SVdec As Double) As Short
	'
	'
	' Home Return Mode Section 6.10
	Declare Function B_8158_set_home_config Lib "8158.dll"  Alias "_8158_set_home_config"(ByVal AxisNo As Short, ByVal home_mode As Short, ByVal org_logic As Short, ByVal ez_logic As Short, ByVal ez_count As Short, ByVal erc_out As Short) As Short
	Declare Function B_8158_home_move Lib "8158.dll"  Alias "_8158_home_move"(ByVal AxisNo As Short, ByVal StrVel As Double, ByVal MaxVel As Double, ByVal Tacc As Double) As Short
	Declare Function B_8158_home_search Lib "8158.dll"  Alias "_8158_home_search"(ByVal AxisNo As Short, ByVal StrVel As Double, ByVal MaxVel As Double, ByVal Tacc As Double, ByVal ORGOffset As Double) As Short
	'
	' Manual Pulser Motion Section 6.11
	Declare Function B_8158_set_pulser_iptmode Lib "8158.dll"  Alias "_8158_set_pulser_iptmode"(ByVal AxisNo As Short, ByVal InputMode As Short, ByVal Inverse As Short) As Short
	Declare Function B_8158_disable_pulser_input Lib "8158.dll"  Alias "_8158_disable_pulser_input"(ByVal AxisNo As Short, ByVal Disable As Short) As Short
	Declare Function B_8158_pulser_vmove Lib "8158.dll"  Alias "_8158_pulser_vmove"(ByVal AxisNo As Short, ByVal SpeedLimit As Double) As Short
	Declare Function B_8158_pulser_pmove Lib "8158.dll"  Alias "_8158_pulser_pmove"(ByVal AxisNo As Short, ByVal Dist As Double, ByVal SpeedLimit As Double) As Short
	Declare Function B_8158_set_pulser_ratio Lib "8158.dll"  Alias "_8158_set_pulser_ratio"(ByVal AxisNo As Short, ByVal DivF As Short, ByVal MultiF As Short) As Short
	'
	' Motion Status Section 6.12
	Declare Function B_8158_motion_done Lib "8158.dll"  Alias "_8158_motion_done"(ByVal AxisNo As Short) As Short
	'
	' Motion Interface I/O Section 6.13
	Declare Function B_8158_set_servo Lib "8158.dll"  Alias "_8158_set_servo"(ByVal AxisNo As Short, ByVal on_off As Short) As Short
	Declare Function B_8158_set_pcs_logic Lib "8158.dll"  Alias "_8158_set_pcs_logic"(ByVal AxisNo As Short, ByVal pcs_logic As Short) As Short
	Declare Function B_8158_set_pcs Lib "8158.dll"  Alias "_8158_set_pcs"(ByVal AxisNo As Short, ByVal enable As Short) As Short
	Declare Function B_8158_set_clr_mode Lib "8158.dll"  Alias "_8158_set_clr_mode"(ByVal AxisNo As Short, ByVal clr_mode As Short, ByVal targetCounterInBit As Short) As Short
	Declare Function B_8158_set_inp Lib "8158.dll"  Alias "_8158_set_inp"(ByVal AxisNo As Short, ByVal inp_enable As Short, ByVal inp_logic As Short) As Short
	Declare Function B_8158_set_alm Lib "8158.dll"  Alias "_8158_set_alm"(ByVal AxisNo As Short, ByVal alm_logic As Short, ByVal alm_mode As Short) As Short
	Declare Function B_8158_set_erc Lib "8158.dll"  Alias "_8158_set_erc"(ByVal AxisNo As Short, ByVal erc_logic As Short, ByVal erc_pulse_width As Short, ByVal erc_mode As Short) As Short
	Declare Function B_8158_set_erc_out Lib "8158.dll"  Alias "_8158_set_erc_out"(ByVal AxisNo As Short) As Short
	Declare Function B_8158_clr_erc Lib "8158.dll"  Alias "_8158_clr_erc"(ByVal AxisNo As Short) As Short
	Declare Function B_8158_set_sd Lib "8158.dll"  Alias "_8158_set_sd"(ByVal AxisNo As Short, ByVal sd_logic As Short, ByVal sd_latch As Short, ByVal sd_mode As Short) As Short
	Declare Function B_8158_enable_sd Lib "8158.dll"  Alias "_8158_enable_sd"(ByVal AxisNo As Short, ByVal enable As Short) As Short
	Declare Function B_8158_set_limit_logic Lib "8158.dll"  Alias "_8158_set_limit_logic"(ByVal AxisNo As Short, ByVal Logic As Short) As Short
	Declare Function B_8158_set_limit_mode Lib "8158.dll"  Alias "_8158_set_limit_mode"(ByVal AxisNo As Short, ByVal limit_mode As Short) As Short
	Declare Function B_8158_get_io_status Lib "8158.dll"  Alias "_8158_get_io_status"(ByVal AxisNo As Short, ByRef io_sts As Short) As Short
	'
	' Interrupt Control Section 6.14
	Declare Function B_8158_int_control Lib "8158.dll"  Alias "_8158_int_control"(ByVal CardId As Short, ByVal intFlag As Short) As Short
	Declare Function B_8158_wait_error_interrupt Lib "8158.dll"  Alias "_8158_wait_error_interrupt"(ByVal AxisNo As Short, ByVal TimeOut_ms As Integer) As Short
	Declare Function B_8158_wait_motion_interrupt Lib "8158.dll"  Alias "_8158_wait_motion_interrupt"(ByVal AxisNo As Short, ByVal IntFactorBitNo As Short, ByVal TimeOut_ms As Integer) As Short
	Declare Function B_8158_set_motion_int_factor Lib "8158.dll"  Alias "_8158_set_motion_int_factor"(ByVal AxisNo As Short, ByVal int_factor As Integer) As Short
	'
	' Position Control and Counters Section 6.15
	Declare Function B_8158_get_position Lib "8158.dll"  Alias "_8158_get_position"(ByVal AxisNo As Short, ByRef Pos As Double) As Short
	Declare Function B_8158_set_position Lib "8158.dll"  Alias "_8158_set_position"(ByVal AxisNo As Short, ByVal Pos As Double) As Short
	Declare Function B_8158_get_command Lib "8158.dll"  Alias "_8158_get_command"(ByVal AxisNo As Short, ByRef Cmd As Integer) As Short
	Declare Function B_8158_set_command Lib "8158.dll"  Alias "_8158_set_command"(ByVal AxisNo As Short, ByVal Cmd As Integer) As Short
	Declare Function B_8158_get_error_counter Lib "8158.dll"  Alias "_8158_get_error_counter"(ByVal AxisNo As Short, ByRef error_Renamed As Short) As Short
	Declare Function B_8158_reset_error_counter Lib "8158.dll"  Alias "_8158_reset_error_counter"(ByVal AxisNo As Short) As Short
	Declare Function B_8158_set_general_counter Lib "8158.dll"  Alias "_8158_set_general_counter"(ByVal AxisNo As Short, ByVal CntSrc As Short, ByVal CntValue As Double) As Short
	Declare Function B_8158_get_general_counter Lib "8158.dll"  Alias "_8158_get_general_counter"(ByVal AxisNo As Short, ByRef CntValue As Double) As Short
	Declare Function B_8158_reset_target_pos Lib "8158.dll"  Alias "_8158_reset_target_pos"(ByVal AxisNo As Short, ByVal TargetPos As Double) As Short
	Declare Function B_8158_get_target_pos Lib "8158.dll"  Alias "_8158_get_target_pos"(ByVal AxisNo As Short, ByRef TargetPos As Double) As Short
	Declare Function B_8158_set_res_distance Lib "8158.dll"  Alias "_8158_set_res_distance"(ByVal AxisNo As Short, ByVal ResDistance As Double) As Short
	Declare Function B_8158_get_res_distance Lib "8158.dll"  Alias "_8158_get_res_distance"(ByVal AxisNo As Short, ByRef ResDistance As Double) As Short
	'
	' Position Compare and Latch Section 6.16
	Declare Function B_8158_set_do_cmp_output_selection Lib "8158.dll"  Alias "_8158_set_do_cmp_output_selection"(ByVal CardId As Short, ByVal Channel As Short, ByVal DoCmpOutputSelection As Short) As Short
	Declare Function B_8158_set_trigger_logic Lib "8158.dll"  Alias "_8158_set_trigger_logic"(ByVal AxisNo As Short, ByVal Logic As Short) As Short
	Declare Function B_8158_set_error_comparator Lib "8158.dll"  Alias "_8158_set_error_comparator"(ByVal AxisNo As Short, ByVal CmpMethod As Short, ByVal CmpAction As Short, ByVal Data As Integer) As Short
	Declare Function B_8158_set_general_comparator Lib "8158.dll"  Alias "_8158_set_general_comparator"(ByVal AxisNo As Short, ByVal CmpSrc As Short, ByVal CmpMethod As Short, ByVal CmpAction As Short, ByVal Data As Integer) As Short
	Declare Function B_8158_set_trigger_comparator Lib "8158.dll"  Alias "_8158_set_trigger_comparator"(ByVal AxisNo As Short, ByVal CmpSrc As Short, ByVal CmpMethod As Short, ByVal Data As Integer) As Short
	Declare Function B_8158_set_latch_source Lib "8158.dll"  Alias "_8158_set_latch_source"(ByVal AxisNo As Short, ByVal LtcSrc As Short) As Short
	Declare Function B_8158_set_ltc_logic Lib "8158.dll"  Alias "_8158_set_ltc_logic"(ByVal AxisNo As Short, ByVal LtcLogic As Short) As Short
	Declare Function B_8158_get_latch_data Lib "8158.dll"  Alias "_8158_get_latch_data"(ByVal AxisNo As Short, ByVal CounterNo As Short, ByRef Pos As Double) As Short
	'
	' Continuous Motion Section 6.17
	Declare Function B_8158_set_continuous_move Lib "8158.dll"  Alias "_8158_set_continuous_move"(ByVal AxisNo As Short, ByVal enable As Short) As Short
	Declare Function B_8158_check_continuous_buffer Lib "8158.dll"  Alias "_8158_check_continuous_buffer"(ByVal AxisNo As Short) As Short
	Declare Function B_8158_dwell_move Lib "8158.dll"  Alias "_8158_dwell_move"(ByVal AxisNo As Short, ByVal milliSecond As Double) As Short
	'
	' Multiple Axes Simultaneous Operation Section 6.18
	Declare Function B_8158_set_tr_move_all Lib "8158.dll"  Alias "_8158_set_tr_move_all"(ByVal TotalAxes As Short, ByRef AxisArray As Short, ByRef DistA As Double, ByRef StrVelA As Double, ByRef MaxVelA As Double, ByRef TaccA As Double, ByRef TdecA As Double) As Short
	Declare Function B_8158_set_sa_move_all Lib "8158.dll"  Alias "_8158_set_sa_move_all"(ByVal TotalAx As Short, ByRef AxisArray As Short, ByRef PosA As Double, ByRef StrVelA As Double, ByRef MaxVelA As Double, ByRef TaccA As Double, ByRef TdecA As Double, ByRef SVaccA As Double, ByRef SVdecA As Double) As Short
	Declare Function B_8158_set_ta_move_all Lib "8158.dll"  Alias "_8158_set_ta_move_all"(ByVal TotalAx As Short, ByRef AxisArray As Short, ByRef PosA As Double, ByRef StrVelA As Double, ByRef MaxVelA As Double, ByRef TaccA As Double, ByRef TdecA As Double) As Short
	Declare Function B_8158_set_sr_move_all Lib "8158.dll"  Alias "_8158_set_sr_move_all"(ByVal TotalAx As Short, ByRef AxisArray As Short, ByRef DistA As Double, ByRef StrVelA As Double, ByRef MaxVelA As Double, ByRef TaccA As Double, ByRef TdecA As Double, ByRef SVaccA As Double, ByRef SVdecA As Double) As Short
	Declare Function B_8158_start_move_all Lib "8158.dll"  Alias "_8158_start_move_all"(ByVal FirstAxisNo As Short) As Short
	Declare Function B_8158_stop_move_all Lib "8158.dll"  Alias "_8158_stop_move_all"(ByVal FirstAxisNo As Short) As Short
	'
	' General-purposed Input/Output Section 6.19
	Declare Function B_8158_set_gpio_output Lib "8158.dll"  Alias "_8158_set_gpio_output"(ByVal CardId As Short, ByVal DoValue As Short) As Short
	Declare Function B_8158_get_gpio_output Lib "8158.dll"  Alias "_8158_get_gpio_output"(ByVal CardId As Short, ByRef DoValue As Short) As Short
	Declare Function B_8158_get_gpio_input Lib "8158.dll"  Alias "_8158_get_gpio_input"(ByVal CardId As Short, ByRef DiValue As Short) As Short
	Declare Function B_8158_set_gpio_input_function Lib "8158.dll"  Alias "_8158_set_gpio_input_function"(ByVal CardId As Short, ByVal Channel As Short, ByVal SelectNo As Short, ByVal Logic As Short) As Short
	'
	' Soft Limit 6.20
	Declare Function B_8158_disable_soft_limit Lib "8158.dll"  Alias "_8158_disable_soft_limit"(ByVal AxisNo As Short) As Short
	Declare Function B_8158_enable_soft_limit Lib "8158.dll"  Alias "_8158_enable_soft_limit"(ByVal AxisNo As Short, ByVal Action As Short) As Short
	Declare Function B_8158_set_soft_limit Lib "8158.dll"  Alias "_8158_set_soft_limit"(ByVal AxisNo As Short, ByVal PlusLimit As Integer, ByVal MinusLimit As Integer) As Short
	'
	' Backlas Compensation / Vibration Suppression 6.21
	Declare Function B_8158_backlash_comp Lib "8158.dll"  Alias "_8158_backlash_comp"(ByVal AxisNo As Short, ByVal CompPulse As Short, ByVal Mode As Short) As Short
	Declare Function B_8158_suppress_vibration Lib "8158.dll"  Alias "_8158_suppress_vibration"(ByVal AxisNo As Short, ByVal ReverseTime As Short, ByVal ForwardTime As Short) As Short
	Declare Function B_8158_set_fa_speed Lib "8158.dll"  Alias "_8158_set_fa_speed"(ByVal AxisNo As Short, ByVal FA_Speed As Double) As Short
	'
	' Speed Profile Calculation 6.22
	Declare Function B_8158_get_tr_move_profile Lib "8158.dll"  Alias "_8158_get_tr_move_profile"(ByVal AxisNo As Short, ByVal Dist As Double, ByVal StrVel As Double, ByVal MaxVel As Double, ByVal Tacc As Double, ByVal Tdec As Double, ByRef pStrVel As Double, ByRef pMaxVel As Double, ByRef pTacc As Double, ByRef pTdec As Double, ByRef pTconst As Double) As Short
	Declare Function B_8158_get_ta_move_profile Lib "8158.dll"  Alias "_8158_get_ta_move_profile"(ByVal AxisNo As Short, ByVal Pos As Double, ByVal StrVel As Double, ByVal MaxVel As Double, ByVal Tacc As Double, ByVal Tdec As Double, ByRef pStrVel As Double, ByRef pMaxVel As Double, ByRef pTacc As Double, ByRef pTdec As Double, ByRef pTconst As Double) As Short
	Declare Function B_8158_get_sr_move_profile Lib "8158.dll"  Alias "_8158_get_sr_move_profile"(ByVal AxisNo As Short, ByVal Dist As Double, ByVal StrVel As Double, ByVal MaxVel As Double, ByVal Tacc As Double, ByVal Tdec As Double, ByVal SVacc As Double, ByVal SVdec As Double, ByRef pStrVel As Double, ByRef pMaxVel As Double, ByRef pTacc As Double, ByRef pTdec As Double, ByRef pSVacc As Double, ByRef pSVdec As Double, ByRef pTconst As Double) As Short
	Declare Function B_8158_get_sa_move_profile Lib "8158.dll"  Alias "_8158_get_sa_move_profile"(ByVal AxisNo As Short, ByVal Pos As Double, ByVal StrVel As Double, ByVal MaxVel As Double, ByVal Tacc As Double, ByVal Tdec As Double, ByVal SVacc As Double, ByVal SVdec As Double, ByRef pStrVel As Double, ByRef pMaxVel As Double, ByRef pTacc As Double, ByRef pTdec As Double, ByRef pSVacc As Double, ByRef pSVdec As Double, ByRef pTconst As Double) As Short
	'
	' DB-8152
	'  System Section x.1
	Declare Function B_8158_db52_initial Lib "8158.dll"  Alias "_8158_db52_initial"(ByVal CardId As Short) As Short
	Declare Function B_8158_db52_close Lib "8158.dll"  Alias "_8158_db52_close"(ByVal CardId As Short) As Short
	Declare Function B_8158_db52_emg_stop Lib "8158.dll"  Alias "_8158_db52_emg_stop"(ByVal CardId As Short) As Short
	'
	' Pulse Input/Output Configuration Section x.2
	Declare Function B_8158_db52_set_master_pls_iptmode Lib "8158.dll"  Alias "_8158_db52_set_master_pls_iptmode"(ByVal CardId As Short, ByVal pls_InputMode As Short) As Short
	Declare Function B_8158_db52_set_slave_pls_iptmode Lib "8158.dll"  Alias "_8158_db52_set_slave_pls_iptmode"(ByVal CardId As Short, ByVal pls_InputMode As Short) As Short
	Declare Function B_8158_db52_set_slave_pls_outmode Lib "8158.dll"  Alias "_8158_db52_set_slave_pls_outmode"(ByVal CardId As Short, ByVal pls_outmode As Short) As Short
	'
	' ecam mode motion Section x.3
	Declare Function B_8158_db52_get_start_position Lib "8158.dll"  Alias "_8158_db52_get_start_position"(ByVal CardId As Short, ByRef Master_Position As Integer) As Short
	Declare Function B_8158_db52_set_start_position Lib "8158.dll"  Alias "_8158_db52_set_start_position"(ByVal CardId As Short, ByVal Master_Position As Integer) As Short
	Declare Function B_8158_db52_start_ecam Lib "8158.dll"  Alias "_8158_db52_start_ecam"(ByVal CardId As Short, ByVal ecam_Type As Short) As Short
	Declare Function B_8158_db52_stop_ecam Lib "8158.dll"  Alias "_8158_db52_stop_ecam"(ByVal CardId As Short, ByVal ecam_Type As Short) As Short
	Declare Function B_8158_db52_build_ecam_table Lib "8158.dll"  Alias "_8158_db52_build_ecam_table"(ByVal CardId As Short, ByRef table_angle As Integer, ByRef table_position As Integer, ByVal table_size As Short) As Short
	'
	' slave Motion Section x.4
	Declare Function B_8158_db52_slave_v_move Lib "8158.dll"  Alias "_8158_db52_slave_v_move"(ByVal CardId As Short, ByVal Vel As Integer) As Short
	Declare Function B_8158_db52_slave_r_move Lib "8158.dll"  Alias "_8158_db52_slave_r_move"(ByVal CardId As Short, ByVal Dist As Integer, ByVal Vel As Integer) As Short
	Declare Function B_8158_db52_slave_home_move Lib "8158.dll"  Alias "_8158_db52_slave_home_move"(ByVal CardId As Short, ByVal Vel As Integer) As Short
	Declare Function B_8158_db52_slave_stop Lib "8158.dll"  Alias "_8158_db52_slave_stop"(ByVal CardId As Short) As Short
	'
	' Motion Interface I/O Section x.5
	Declare Function B_8158_db52_set_EMG_logic Lib "8158.dll"  Alias "_8158_db52_set_EMG_logic"(ByVal CardId As Short, ByVal Logic As Short) As Short
	Declare Function B_8158_db52_get_EMG_logic Lib "8158.dll"  Alias "_8158_db52_get_EMG_logic"(ByVal CardId As Short, ByRef Logic As Short) As Short
	Declare Function B_8158_db52_set_ELL_logic Lib "8158.dll"  Alias "_8158_db52_set_ELL_logic"(ByVal CardId As Short, ByVal Logic As Short) As Short
	Declare Function B_8158_db52_get_ELL_logic Lib "8158.dll"  Alias "_8158_db52_get_ELL_logic"(ByVal CardId As Short, ByRef Logic As Short) As Short
	Declare Function B_8158_db52_set_ORG_logic Lib "8158.dll"  Alias "_8158_db52_set_ORG_logic"(ByVal CardId As Short, ByVal Logic As Short) As Short
	Declare Function B_8158_db52_get_ORG_logic Lib "8158.dll"  Alias "_8158_db52_get_ORG_logic"(ByVal CardId As Short, ByRef Logic As Short) As Short
	Declare Function B_8158_db52_set_ALM_logic Lib "8158.dll"  Alias "_8158_db52_set_ALM_logic"(ByVal CardId As Short, ByVal Logic As Short) As Short
	Declare Function B_8158_db52_get_ALM_logic Lib "8158.dll"  Alias "_8158_db52_get_ALM_logic"(ByVal CardId As Short, ByRef Logic As Short) As Short
	Declare Function B_8158_db52_set_INP_logic Lib "8158.dll"  Alias "_8158_db52_set_INP_logic"(ByVal CardId As Short, ByVal Logic As Short) As Short
	Declare Function B_8158_db52_get_INP_logic Lib "8158.dll"  Alias "_8158_db52_get_INP_logic"(ByVal CardId As Short, ByRef Logic As Short) As Short
	Declare Function B_8158_db52_set_EZ_logic Lib "8158.dll"  Alias "_8158_db52_set_EZ_logic"(ByVal CardId As Short, ByVal Logic As Short) As Short
	Declare Function B_8158_db52_get_EZ_logic Lib "8158.dll"  Alias "_8158_db52_get_EZ_logic"(ByVal CardId As Short, ByRef Logic As Short) As Short
	Declare Function B_8158_db52_set_ERC_logic Lib "8158.dll"  Alias "_8158_db52_set_ERC_logic"(ByVal CardId As Short, ByVal Logic As Short) As Short
	Declare Function B_8158_db52_get_ERC_logic Lib "8158.dll"  Alias "_8158_db52_get_ERC_logic"(ByVal CardId As Short, ByRef Logic As Short) As Short
	Declare Function B_8158_db52_set_erc Lib "8158.dll"  Alias "_8158_db52_set_erc"(ByVal CardId As Short, ByVal Logic As Short) As Short
	Declare Function B_8158_db52_get_io_status Lib "8158.dll"  Alias "_8158_db52_get_io_status"(ByVal CardId As Short, ByRef io_sts As Short) As Short
	'
	' Interrupt Control Section x.6
	Declare Function B_8158_db52_int_control Lib "8158.dll"  Alias "_8158_db52_int_control"(ByVal CardId As Short, ByVal intFlag As Short) As Short
	Declare Function B_8158_db52_wait_error_interrupt Lib "8158.dll"  Alias "_8158_db52_wait_error_interrupt"(ByVal CardId As Short, ByVal TimeOut_ms As Integer) As Short
	Declare Function B_8158_db52_wait_ecam_interrupt Lib "8158.dll"  Alias "_8158_db52_wait_ecam_interrupt"(ByVal CardId As Short, ByVal IntFactorBitNo As Short, ByVal TimeOut_ms As Integer) As Short
	Declare Function B_8158_db52_set_ecam_int_factor Lib "8158.dll"  Alias "_8158_db52_set_ecam_int_factor"(ByVal CardId As Short, ByVal int_factor As Short) As Short
	'
	' Position Control and Counters Section x.7
	Declare Function B_8158_db52_get_master_position Lib "8158.dll"  Alias "_8158_db52_get_master_position"(ByVal CardId As Short, ByRef Position As Integer) As Short
	Declare Function B_8158_db52_set_master_position Lib "8158.dll"  Alias "_8158_db52_set_master_position"(ByVal CardId As Short, ByVal Position As Integer) As Short
	Declare Function B_8158_db52_get_slave_position Lib "8158.dll"  Alias "_8158_db52_get_slave_position"(ByVal CardId As Short, ByRef Position As Integer) As Short
	Declare Function B_8158_db52_set_slave_position Lib "8158.dll"  Alias "_8158_db52_set_slave_position"(ByVal CardId As Short, ByVal Position As Integer) As Short
	Declare Function B_8158_db52_get_command Lib "8158.dll"  Alias "_8158_db52_get_command"(ByVal CardId As Short, ByRef Command_Renamed As Integer) As Short
	Declare Function B_8158_db52_set_command Lib "8158.dll"  Alias "_8158_db52_set_command"(ByVal CardId As Short, ByVal Command_Renamed As Integer) As Short
	Declare Function B_8158_db52_get_res_command Lib "8158.dll"  Alias "_8158_db52_get_res_command"(ByVal CardId As Short, ByRef Command_Renamed As Integer) As Short
	Declare Function B_8158_db52_set_res_command Lib "8158.dll"  Alias "_8158_db52_set_res_command"(ByVal CardId As Short, ByVal Command_Renamed As Integer) As Short
	'
	' Position Compare and Latch Section x.8
	Declare Function B_8158_db52_get_EZ_latch_data Lib "8158.dll"  Alias "_8158_db52_get_EZ_latch_data"(ByVal CardId As Short, ByRef Latch_Position As Integer) As Short
	Declare Function B_8158_db52_get_comparator_data Lib "8158.dll"  Alias "_8158_db52_get_comparator_data"(ByVal CardId As Short, ByVal CompNo As Short, ByVal Comp_A_B As Short, ByRef Comp_Data As Integer) As Short
	Declare Function B_8158_db52_set_comparator_data Lib "8158.dll"  Alias "_8158_db52_set_comparator_data"(ByVal CardId As Short, ByVal CompNo As Short, ByVal Comp_A_B As Short, ByVal Comp_Data As Integer) As Short
	Declare Function B_8158_db52_set_comparator_mode Lib "8158.dll"  Alias "_8158_db52_set_comparator_mode"(ByVal CardId As Short, ByVal CompNo As Short, ByVal Comp_A_B As Short, ByVal Comp_Mode As Short) As Short
	Declare Function B_8158_db52_set_comparator_do Lib "8158.dll"  Alias "_8158_db52_set_comparator_do"(ByVal CardId As Short, ByVal CompNo As Short, ByVal Logic As Short) As Short
	'
	' DB-8151
	' /****************************************************************************/
	' /*      Function  Declerations                                              */
	' /****************************************************************************/
	'  Initialization and System Information Section
	' _8158_db51_
	Declare Function B_8158_db51_HSL_initial Lib "8158.dll"  Alias "_8158_db51_HSL_initial"(ByVal Card_ID As Short) As Short
	Declare Function B_8158_db51_HSL_close Lib "8158.dll"  Alias "_8158_db51_HSL_close"(ByVal Card_ID As Short) As Short
	Declare Function B_8158_db51_HSL_auto_start Lib "8158.dll"  Alias "_8158_db51_HSL_auto_start"(ByVal Card_ID As Short) As Short
	Declare Function B_8158_db51_HSL_start Lib "8158.dll"  Alias "_8158_db51_HSL_start"(ByVal Card_ID As Short, ByVal max_slave_No As Short) As Short
	Declare Function B_8158_db51_HSL_stop Lib "8158.dll"  Alias "_8158_db51_HSL_stop"(ByVal Card_ID As Short) As Short
	Declare Function B_8158_db51_HSL_connect_status Lib "8158.dll"  Alias "_8158_db51_HSL_connect_status"(ByVal Card_ID As Short, ByVal Slave_No As Short, ByRef sts_data As Short) As Short
	Declare Function B_8158_db51_HSL_slave_live Lib "8158.dll"  Alias "_8158_db51_HSL_slave_live"(ByVal Card_ID As Short, ByVal Slave_No As Short, ByRef live_data As Short) As Short
	Declare Function B_8158_db51_HSL_get_slave_type Lib "8158.dll"  Alias "_8158_db51_HSL_get_slave_type"(ByVal Card_ID As Short, ByVal Slave_No As Short, ByRef type_data As Short) As Short
	Declare Function B_8158_db51_HSL_set_scan_condition Lib "8158.dll"  Alias "_8158_db51_HSL_set_scan_condition"(ByVal Card_ID As Short, ByVal transfer_rate As Short, ByVal hub_number As Short) As Short
	Declare Function B_8158_db51_HSL_get_scan_condition Lib "8158.dll"  Alias "_8158_db51_HSL_get_scan_condition"(ByVal Card_ID As Short, ByRef transfer_rate As Short, ByRef hub_number As Short) As Short
	Declare Function B_8158_db51_HSL_get_version Lib "8158.dll"  Alias "_8158_db51_HSL_get_version"(ByVal Card_ID As Short, ByRef Firmware_Version As Integer, ByRef Driver_Version As Integer, ByRef Software_Version As Integer) As Short
	'
	'  DIO
	Declare Function B_8158_db51_HSL_D_write_output Lib "8158.dll"  Alias "_8158_db51_HSL_D_write_output"(ByVal Card_ID As Short, ByVal Slave_No As Short, ByVal out_data As Integer) As Short
	Declare Function B_8158_db51_HSL_D_write_channel_output Lib "8158.dll"  Alias "_8158_db51_HSL_D_write_channel_output"(ByVal Card_ID As Short, ByVal Slave_No As Short, ByVal Channel As Short, ByVal out_data As Short) As Short
	Declare Function B_8158_db51_HSL_D_read_input Lib "8158.dll"  Alias "_8158_db51_HSL_D_read_input"(ByVal Card_ID As Short, ByVal Slave_No As Short, ByRef in_data As Integer) As Short
	Declare Function B_8158_db51_HSL_D_read_channel_input Lib "8158.dll"  Alias "_8158_db51_HSL_D_read_channel_input"(ByVal Card_ID As Short, ByVal Slave_No As Short, ByVal Channel As Short, ByRef in_data As Short) As Short
	Declare Function B_8158_db51_HSL_D_read_output Lib "8158.dll"  Alias "_8158_db51_HSL_D_read_output"(ByVal Card_ID As Short, ByVal Slave_No As Short, ByRef out_data_in_ram As Integer) As Short
	Declare Function B_8158_db51_HSL_D_read_all_slave_input Lib "8158.dll"  Alias "_8158_db51_HSL_D_read_all_slave_input"(ByVal Card_ID As Short, ByRef in_data As Short) As Short
	Declare Function B_8158_db51_HSL_D_write_all_slave_output Lib "8158.dll"  Alias "_8158_db51_HSL_D_write_all_slave_output"(ByVal Card_ID As Short, ByRef out_data As Short) As Short
	Declare Function B_8158_db51_HSL_D_set_input_logic Lib "8158.dll"  Alias "_8158_db51_HSL_D_set_input_logic"(ByVal Card_ID As Short, ByVal Slave_No As Short, ByVal Input_Logic As Short) As Short
	Declare Function B_8158_db51_HSL_D_set_output_logic Lib "8158.dll"  Alias "_8158_db51_HSL_D_set_output_logic"(ByVal Card_ID As Short, ByVal Slave_No As Short, ByVal Output_Logic As Short) As Short
	Declare Function B_8158_db51_HSL_D_write_slave_output Lib "8158.dll"  Alias "_8158_db51_HSL_D_write_slave_output"(ByVal Card_ID As Short, ByVal Slave_No As Short, ByVal out_data As Short) As Short
	Declare Function B_8158_db51_HSL_D_read_slave_output Lib "8158.dll"  Alias "_8158_db51_HSL_D_read_slave_output"(ByVal Card_ID As Short, ByVal Slave_No As Short, ByRef data_out As Short) As Short
	Declare Function B_8158_db51_HSL_D_read_slave_input Lib "8158.dll"  Alias "_8158_db51_HSL_D_read_slave_input"(ByVal Card_ID As Short, ByVal Slave_No As Short, ByRef data_in As Short) As Short
	'
	' DI INTERRUPT (ONLY FOR 7853/54)
	Declare Function B_8158_db51_HSL_D_set_int_renewal_type Lib "8158.dll"  Alias "_8158_db51_HSL_D_set_int_renewal_type"(ByVal Card_ID As Short, ByVal renewal_type As Short) As Short
	Declare Function B_8158_db51_HSL_D_set_int_renewal_bit Lib "8158.dll"  Alias "_8158_db51_HSL_D_set_int_renewal_bit"(ByVal Card_ID As Short, ByVal Slave_No As Short, ByVal bitsOfCheck As Short) As Short
	Declare Function B_8158_db51_HSL_D_set_int_control Lib "8158.dll"  Alias "_8158_db51_HSL_D_set_int_control"(ByVal Card_ID As Short, ByVal enable As Short) As Short
	Declare Function B_8158_db51_HSL_D_wait_di_interrupt Lib "8158.dll"  Alias "_8158_db51_HSL_D_wait_di_interrupt"(ByVal Card_ID As Short, ByVal time_out_ms As Integer) As Short
	'
	'  FOR DI16-UL
	Declare Function B_8158_db51_HSL_D_set_di_latch_function Lib "8158.dll"  Alias "_8158_db51_HSL_D_set_di_latch_function"(ByVal Card_ID As Short, ByVal Slave_No As Short, ByVal Channel As Short, ByVal active_mode As Short, ByVal duration As Short) As Short
	Declare Function B_8158_db51_HSL_D_set_di_latch_functionA Lib "8158.dll"  Alias "_8158_db51_HSL_D_set_di_latch_functionA"(ByVal Card_ID As Short, ByVal Slave_No As Short, ByVal edge As Short, ByVal duration As Short) As Short
	Declare Function B_8158_db51_HSL_D_get_di_latch_function Lib "8158.dll"  Alias "_8158_db51_HSL_D_get_di_latch_function"(ByVal Card_ID As Short, ByVal Slave_No As Short, ByVal Channel As Short, ByRef active_mode As Short, ByRef duration As Short) As Short
	'
	'  Timer Control Section
	Declare Function B_8158_db51_HSL_set_timer Lib "8158.dll"  Alias "_8158_db51_HSL_set_timer"(ByVal Card_ID As Short, ByVal c1 As Short, ByVal c2 As Short) As Short
	Declare Function B_8158_db51_HSL_enable_timer_interrupt Lib "8158.dll"  Alias "_8158_db51_HSL_enable_timer_interrupt"(ByVal Card_ID As Short, ByRef phEvent As Integer) As Short
	Declare Function B_8158_db51_HSL_disable_timer_interrupt Lib "8158.dll"  Alias "_8158_db51_HSL_disable_timer_interrupt"(ByVal Card_ID As Short) As Short
	Declare Function B_8158_db51_W_HSL_Timer_Set Lib "8158.dll"  Alias "_8158_db51_W_HSL_Timer_Set"(ByVal Card_ID As Short, ByVal c1 As Short, ByVal c2 As Short) As Short
	Declare Function B_8158_db51_W_HSL_TMRINT_Enable Lib "8158.dll"  Alias "_8158_db51_W_HSL_TMRINT_Enable"(ByVal Card_ID As Short, ByRef phEvent As Integer) As Short
	Declare Function B_8158_db51_W_HSL_TMRINT_Disable Lib "8158.dll"  Alias "_8158_db51_W_HSL_TMRINT_Disable"(ByVal Card_ID As Short) As Short
	'
	'  AIO
	Declare Function B_8158_db51_HSL_A_start_read Lib "8158.dll"  Alias "_8158_db51_HSL_A_start_read"(ByVal Card_ID As Short) As Short
	Declare Function B_8158_db51_HSL_A_stop_read Lib "8158.dll"  Alias "_8158_db51_HSL_A_stop_read"(ByVal Card_ID As Short) As Short
	Declare Function B_8158_db51_HSL_A_set_signal_range Lib "8158.dll"  Alias "_8158_db51_HSL_A_set_signal_range"(ByVal Card_ID As Short, ByVal Slave_No As Short, ByVal signal_range As Short) As Short
	Declare Function B_8158_db51_HSL_A_get_signal_range Lib "8158.dll"  Alias "_8158_db51_HSL_A_get_signal_range"(ByVal Card_ID As Short, ByVal Slave_No As Short, ByRef signal_range As Short) As Short
	Declare Function B_8158_db51_HSL_A_get_input_mode Lib "8158.dll"  Alias "_8158_db51_HSL_A_get_input_mode"(ByVal Card_ID As Short, ByVal Slave_No As Short, ByRef Mode As Short) As Short
	Declare Function B_8158_db51_HSL_A_set_last_channel Lib "8158.dll"  Alias "_8158_db51_HSL_A_set_last_channel"(ByVal Card_ID As Short, ByVal Slave_No As Short, ByVal Last_Channel As Short) As Short
	Declare Function B_8158_db51_HSL_A_get_last_channel Lib "8158.dll"  Alias "_8158_db51_HSL_A_get_last_channel"(ByVal Card_ID As Short, ByVal Slave_No As Short, ByRef Last_Channel As Short) As Short
	Declare Function B_8158_db51_HSL_A_read_input Lib "8158.dll"  Alias "_8158_db51_HSL_A_read_input"(ByVal Card_ID As Short, ByVal Slave_No As Short, ByVal ai_channel As Short, ByRef AI_data As Double) As Short
	Declare Function B_8158_db51_HSL_A_write_output Lib "8158.dll"  Alias "_8158_db51_HSL_A_write_output"(ByVal Card_ID As Short, ByVal Slave_No As Short, ByVal ao_channel As Short, ByVal AO_data As Double) As Short
	Declare Function B_8158_db51_HSL_A_read_output Lib "8158.dll"  Alias "_8158_db51_HSL_A_read_output"(ByVal Card_ID As Short, ByVal Slave_No As Short, ByVal ao_channel As Short, ByRef AO_data As Double) As Short
	Declare Function B_8158_db51_HSL_A_sync_rw Lib "8158.dll"  Alias "_8158_db51_HSL_A_sync_rw"(ByVal Card_ID As Short, ByVal Slave_No As Short, ByVal ai_channel As Short, ByRef AI_data As Double, ByVal ao_channel As Short, ByVal AO_data As Double) As Short
	Declare Function B_8158_db51_HSL_A_get_version Lib "8158.dll"  Alias "_8158_db51_HSL_A_get_version"(ByVal Card_ID As Short, ByVal Slave_No As Short, ByRef Ver As Short) As Short
	'  AO4
	Declare Function B_8158_db51_HSL_A_save_calibration Lib "8158.dll"  Alias "_8158_db51_HSL_A_save_calibration"(ByVal Card_ID As Short, ByVal Slave_No As Short, ByVal AoChannelId As Short) As Short
	Declare Function B_8158_db51_HSL_A_output_gain_calib Lib "8158.dll"  Alias "_8158_db51_HSL_A_output_gain_calib"(ByVal Card_ID As Short, ByVal Slave_No As Short, ByVal AoChannelId As Short, ByVal GainDifference As Short) As Short
	Declare Function B_8158_db51_HSL_A_output_offset_calib Lib "8158.dll"  Alias "_8158_db51_HSL_A_output_offset_calib"(ByVal Card_ID As Short, ByVal Slave_No As Short, ByVal AoChannelId As Short, ByVal OffsetDifference As Short) As Short
	'
	' /****************************************************************************/
	'  The following function declarations are old                                                          */
	' /****************************************************************************/
	Declare Function B_8158_db51_W_HSL_Initial Lib "8158.dll"  Alias "_8158_db51_W_HSL_Initial"(ByVal Card_ID As Short) As Short
	Declare Function B_8158_db51_W_HSL_Close Lib "8158.dll"  Alias "_8158_db51_W_HSL_Close"(ByVal Card_ID As Short) As Short
	Declare Function B_8158_db51_W_HSL_Auto_Start Lib "8158.dll"  Alias "_8158_db51_W_HSL_Auto_Start"(ByVal Card_ID As Short) As Short
	Declare Function B_8158_db51_W_HSL_Start Lib "8158.dll"  Alias "_8158_db51_W_HSL_Start"(ByVal Card_ID As Short, ByVal max_slave_No As Short) As Short
	Declare Function B_8158_db51_W_HSL_Stop Lib "8158.dll"  Alias "_8158_db51_W_HSL_Stop"(ByVal Card_ID As Short) As Short
	Declare Function B_8158_db51_W_HSL_Connect_Status Lib "8158.dll"  Alias "_8158_db51_W_HSL_Connect_Status"(ByVal Card_ID As Short, ByVal Slave_No As Short, ByRef sts_data As Byte) As Short
	Declare Function B_8158_db51_W_HSL_Slave_Live Lib "8158.dll"  Alias "_8158_db51_W_HSL_Slave_Live"(ByVal Card_ID As Short, ByVal Slave_No As Short, ByRef live_data As Byte) As Short
	'
	Declare Function B_8158_db51_W_HSL_DIO_In Lib "8158.dll"  Alias "_8158_db51_W_HSL_DIO_In"(ByVal Card_ID As Short, ByVal Slave_No As Short, ByRef in_data As Integer) As Short
	Declare Function B_8158_db51_W_HSL_DIO_Channel_In Lib "8158.dll"  Alias "_8158_db51_W_HSL_DIO_Channel_In"(ByVal Card_ID As Short, ByVal Slave_No As Short, ByVal Channel As Short, ByRef in_data As Short) As Short
	Declare Function B_8158_db51_W_HSL_DIO_Out Lib "8158.dll"  Alias "_8158_db51_W_HSL_DIO_Out"(ByVal Card_ID As Short, ByVal Slave_No As Short, ByVal out_data As Integer) As Short
	Declare Function B_8158_db51_W_HSL_DIO_Channel_Out Lib "8158.dll"  Alias "_8158_db51_W_HSL_DIO_Channel_Out"(ByVal Card_ID As Short, ByVal Slave_No As Short, ByVal Channel As Short, ByVal out_data As Short) As Short
	Declare Function B_8158_db51_W_HSL_DI8DO8_DIO_In Lib "8158.dll"  Alias "_8158_db51_W_HSL_DI8DO8_DIO_In"(ByVal Card_ID As Short, ByVal Slave_No As Short, ByRef in_data As Short) As Short
	Declare Function B_8158_db51_W_HSL_DI8DO8_DIO_Channel_In Lib "8158.dll"  Alias "_8158_db51_W_HSL_DI8DO8_DIO_Channel_In"(ByVal Card_ID As Short, ByVal Slave_No As Short, ByVal Channel As Short, ByRef in_data As Short) As Short
	Declare Function B_8158_db51_W_HSL_DI8DO8_DIO_Out Lib "8158.dll"  Alias "_8158_db51_W_HSL_DI8DO8_DIO_Out"(ByVal Card_ID As Short, ByVal Slave_No As Short, ByVal out_data As Short) As Short
	Declare Function B_8158_db51_W_HSL_DI8DO8_DIO_Channel_Out Lib "8158.dll"  Alias "_8158_db51_W_HSL_DI8DO8_DIO_Channel_Out"(ByVal Card_ID As Short, ByVal Slave_No As Short, ByVal Channel As Short, ByVal out_data As Short) As Short
	Declare Function B_8158_db51_W_HSL_Read_DIO_Out Lib "8158.dll"  Alias "_8158_db51_W_HSL_Read_DIO_Out"(ByVal Card_ID As Short, ByVal Slave_No As Short, ByRef out_data_in_ram As Integer) As Short
	Declare Function B_8158_db51_W_HSL_Read_DIO_Channel_Out Lib "8158.dll"  Alias "_8158_db51_W_HSL_Read_DIO_Channel_Out"(ByVal Card_ID As Short, ByVal Slave_No As Short, ByVal Channel As Short, ByRef out_channel_data_in_ram As Short) As Short
	Declare Function B_8158_db51_W_HSL_Read_DI8DO8_Out Lib "8158.dll"  Alias "_8158_db51_W_HSL_Read_DI8DO8_Out"(ByVal Card_ID As Short, ByVal Slave_No As Short, ByRef out_data_in_ram As Short) As Short
	Declare Function B_8158_db51_W_HSL_Read_DI8DO8_Channel_Out Lib "8158.dll"  Alias "_8158_db51_W_HSL_Read_DI8DO8_Channel_Out"(ByVal Card_ID As Short, ByVal Slave_No As Short, ByVal Channel As Short, ByRef out_channel_data_in_ram As Short) As Short
	Declare Function B_8158_db51_W_HSL_Set_In_Out_Logic Lib "8158.dll"  Alias "_8158_db51_W_HSL_Set_In_Out_Logic"(ByVal Card_ID As Short, ByVal Slave_No As Short, ByVal Input_Logic As Short, ByVal Output_Logic As Short) As Short
	'
	Declare Function B_8158_db51_W_HSL_AI_Start_Read Lib "8158.dll"  Alias "_8158_db51_W_HSL_AI_Start_Read"(ByVal Card_ID As Short) As Short
	Declare Function B_8158_db51_W_HSL_AI_Stop_Read Lib "8158.dll"  Alias "_8158_db51_W_HSL_AI_Stop_Read"(ByVal Card_ID As Short) As Short
	Declare Function B_8158_db51_W_HSL_AI_Channel_In Lib "8158.dll"  Alias "_8158_db51_W_HSL_AI_Channel_In"(ByVal Card_ID As Short, ByVal Slave_No As Short, ByVal Channel As Short, ByRef AI_data As Double) As Short
	Declare Function B_8158_db51_W_HSL_AI_SetConfig Lib "8158.dll"  Alias "_8158_db51_W_HSL_AI_SetConfig"(ByVal Card_ID As Short, ByVal Slave_No As Short, ByVal signal_range As Short, ByVal signal_type As Short, ByVal cjc_status As Short) As Short
	Declare Function B_8158_db51_W_HSL_AI_GetConfig Lib "8158.dll"  Alias "_8158_db51_W_HSL_AI_GetConfig"(ByVal Card_ID As Short, ByVal Slave_No As Short, ByRef signal_range As Short, ByRef signal_type As Short, ByRef cjc_status As Short) As Short
	Declare Function B_8158_db51_W_HSL_AI_OffsetCalib Lib "8158.dll"  Alias "_8158_db51_W_HSL_AI_OffsetCalib"(ByVal Card_ID As Short, ByVal Slave_No As Short) As Short
	Declare Function B_8158_db51_W_HSL_AI_SpanCalib Lib "8158.dll"  Alias "_8158_db51_W_HSL_AI_SpanCalib"(ByVal Card_ID As Short, ByVal Slave_No As Short) As Short
	Declare Function B_8158_db51_W_HSL_AI_WriteDefault Lib "8158.dll"  Alias "_8158_db51_W_HSL_AI_WriteDefault"(ByVal Card_ID As Short, ByVal Slave_No As Short) As Short
	Declare Function B_8158_db51_W_HSL_AI_SetCJCOffset Lib "8158.dll"  Alias "_8158_db51_W_HSL_AI_SetCJCOffset"(ByVal Card_ID As Short, ByVal Slave_No As Short, ByVal CJC_data2 As Double) As Short
	Declare Function B_8158_db51_W_HSL_AI_GetCJCOffset Lib "8158.dll"  Alias "_8158_db51_W_HSL_AI_GetCJCOffset"(ByVal Card_ID As Short, ByVal Slave_No As Short, ByRef CJC_data As Double) As Short
	Declare Function B_8158_db51_W_HSL_AI_SetChannelStatus Lib "8158.dll"  Alias "_8158_db51_W_HSL_AI_SetChannelStatus"(ByVal Card_ID As Short, ByVal Slave_No As Short, ByVal enable_chans As Integer) As Short
	Declare Function B_8158_db51_W_HSL_AI_GetChannelStatus Lib "8158.dll"  Alias "_8158_db51_W_HSL_AI_GetChannelStatus"(ByVal Card_ID As Short, ByVal Slave_No As Short, ByRef enable_chans As Integer) As Short
	'
	Declare Function B_8158_db51_W_HSL_DIO_Memory_In Lib "8158.dll"  Alias "_8158_db51_W_HSL_DIO_Memory_In"(ByVal Card_ID As Short, ByRef data_in As Short) As Short
	Declare Function B_8158_db51_W_HSL_DIO_Memory_Out Lib "8158.dll"  Alias "_8158_db51_W_HSL_DIO_Memory_Out"(ByVal Card_ID As Short, ByRef data_out As Short) As Short
	'
	'  AI16AO2 Module Use
	Declare Function B_8158_db51_W_HSL_AI_Set_Last_Channel Lib "8158.dll"  Alias "_8158_db51_W_HSL_AI_Set_Last_Channel"(ByVal Card_ID As Short, ByVal Slave_No As Short, ByVal Last_Channel As Short) As Short
	Declare Function B_8158_db51_W_HSL_AI_Get_Last_Channel Lib "8158.dll"  Alias "_8158_db51_W_HSL_AI_Get_Last_Channel"(ByVal Card_ID As Short, ByVal Slave_No As Short, ByRef Last_Channel As Short) As Short
	Declare Function B_8158_db51_W_HSL_AI_Get_Version Lib "8158.dll"  Alias "_8158_db51_W_HSL_AI_Get_Version"(ByVal Card_ID As Short, ByVal Slave_No As Short, ByRef Ver As Byte) As Short
	Declare Function B_8158_db51_W_HSL_AIO_LoadConfig Lib "8158.dll"  Alias "_8158_db51_W_HSL_AIO_LoadConfig"(ByVal Card_ID As Short, ByVal Slave_No As Short) As Short
	Declare Function B_8158_db51_W_HSL_AIO_SaveConfig Lib "8158.dll"  Alias "_8158_db51_W_HSL_AIO_SaveConfig"(ByVal Card_ID As Short, ByVal Slave_No As Short) As Short
	Declare Function B_8158_db51_W_HSL_AO_Channel_Out Lib "8158.dll"  Alias "_8158_db51_W_HSL_AO_Channel_Out"(ByVal Card_ID As Short, ByVal Slave_No As Short, ByVal AO_Ch_No As Short, ByVal AO_data As Double) As Short
	Declare Function B_8158_db51_W_HSL_AIO_Channel_InOut Lib "8158.dll"  Alias "_8158_db51_W_HSL_AIO_Channel_InOut"(ByVal Card_ID As Short, ByVal Slave_No As Short, ByVal AI_CH_No As Short, ByRef AI_data As Double, ByVal AO_Ch_No As Short, ByVal AO_data As Double) As Short
	Declare Function B_8158_db51_W_HSL_AO_Channel_In Lib "8158.dll"  Alias "_8158_db51_W_HSL_AO_Channel_In"(ByVal Card_ID As Short, ByVal Slave_No As Short, ByVal AO_Ch_No As Short, ByRef AO_data As Short) As Short
	Declare Function B_8158_db51_W_HSL_AO_OffsetCalib Lib "8158.dll"  Alias "_8158_db51_W_HSL_AO_OffsetCalib"(ByVal Card_ID As Short, ByVal Slave_No As Short, ByVal DA_CH As Short) As Short
	Declare Function B_8158_db51_W_HSL_AO_GainCalib Lib "8158.dll"  Alias "_8158_db51_W_HSL_AO_GainCalib"(ByVal Card_ID As Short, ByVal Slave_No As Short, ByVal DA_CH As Short) As Short
	'
	'  TC08 Use
	Declare Function B_8158_db51_W_HSL_TC08_Offset_Calib Lib "8158.dll"  Alias "_8158_db51_W_HSL_TC08_Offset_Calib"(ByVal Card_ID As Short, ByVal Slave_No As Short, ByVal Channel As Short) As Short
	Declare Function B_8158_db51_W_HSL_TC08_Span_Calib Lib "8158.dll"  Alias "_8158_db51_W_HSL_TC08_Span_Calib"(ByVal Card_ID As Short, ByVal Slave_No As Short, ByVal Channel As Short) As Short
	Declare Function B_8158_db51_W_HSL_TC08_Get_Temperature Lib "8158.dll"  Alias "_8158_db51_W_HSL_TC08_Get_Temperature"(ByVal Card_ID As Short, ByVal Slave_No As Short, ByVal Channel As Short, ByVal TC_type As Short, ByRef Temperature As Double) As Short
	'
	'
	' /****************************************************************************/
	' /* HSL Motion Function Declerations                                        */
	' /****************************************************************************/
	Declare Function B_8158_db51_HSL_M_get_version Lib "8158.dll"  Alias "_8158_db51_HSL_M_get_version"(ByVal Card_ID As Short, ByVal M_No As Short, ByRef CPLD_Ver As Byte, ByRef Kernel_Ver As Integer, ByRef Software_Ver As Integer) As Short
	'
	'  Pulse I/O Configuration
	Declare Function B_8158_db51_HSL_M_set_pls_outmode Lib "8158.dll"  Alias "_8158_db51_HSL_M_set_pls_outmode"(ByVal Card_ID As Short, ByVal AxisNo As Short, ByVal pls_outmode As Short) As Short
	Declare Function B_8158_db51_HSL_M_set_pls_iptmode Lib "8158.dll"  Alias "_8158_db51_HSL_M_set_pls_iptmode"(ByVal Card_ID As Short, ByVal AxisNo As Short, ByVal pls_iptmode As Short, ByVal pls_logic As Short) As Short
	Declare Function B_8158_db51_HSL_M_set_feedback_src Lib "8158.dll"  Alias "_8158_db51_HSL_M_set_feedback_src"(ByVal Card_ID As Short, ByVal AxisNo As Short, ByVal Src As Short) As Short
	'
	'  Velocity Mode motion
	Declare Function B_8158_db51_HSL_M_tv_move Lib "8158.dll"  Alias "_8158_db51_HSL_M_tv_move"(ByVal Card_ID As Short, ByVal AxisNo As Short, ByVal StrVel As Double, ByVal MaxVel As Double, ByVal Tacc As Double) As Short
	Declare Function B_8158_db51_HSL_M_sv_move Lib "8158.dll"  Alias "_8158_db51_HSL_M_sv_move"(ByVal Card_ID As Short, ByVal AxisNo As Short, ByVal StrVel As Double, ByVal MaxVel As Double, ByVal Tacc As Double, ByVal SVacc As Double) As Short
	Declare Function B_8158_db51_HSL_M_v_change Lib "8158.dll"  Alias "_8158_db51_HSL_M_v_change"(ByVal Card_ID As Short, ByVal AxisNo As Short, ByVal NewVel As Double, ByVal Tacc As Double) As Short
	Declare Function B_8158_db51_HSL_M_sd_stop Lib "8158.dll"  Alias "_8158_db51_HSL_M_sd_stop"(ByVal Card_ID As Short, ByVal AxisNo As Short, ByVal Tdec As Double) As Short
	Declare Function B_8158_db51_HSL_M_emg_stop Lib "8158.dll"  Alias "_8158_db51_HSL_M_emg_stop"(ByVal Card_ID As Short, ByVal AxisNo As Short) As Short
	Declare Function B_8158_db51_HSL_M_fix_speed_range Lib "8158.dll"  Alias "_8158_db51_HSL_M_fix_speed_range"(ByVal Card_ID As Short, ByVal AxisNo As Short, ByVal MaxVel As Double) As Short
	Declare Function B_8158_db51_HSL_M_unfix_speed_range Lib "8158.dll"  Alias "_8158_db51_HSL_M_unfix_speed_range"(ByVal Card_ID As Short, ByVal AxisNo As Short) As Short
	Declare Function B_8158_db51_HSL_M_get_current_speed Lib "8158.dll"  Alias "_8158_db51_HSL_M_get_current_speed"(ByVal Card_ID As Short, ByVal AxisNo As Short, ByRef speed As Double) As Short
	Declare Function B_8158_db51_HSL_M_verify_speed Lib "8158.dll"  Alias "_8158_db51_HSL_M_verify_speed"(ByVal Card_ID As Short, ByVal M_No As Short, ByVal StrVel As Double, ByVal MaxVel As Double, ByRef minAccTime As Double, ByRef maxAccT As Double, ByVal MaxSpeed As Double) As Short
	'
	'  Single Axis Motion
	Declare Function B_8158_db51_HSL_M_start_tr_move Lib "8158.dll"  Alias "_8158_db51_HSL_M_start_tr_move"(ByVal Card_ID As Short, ByVal AxisNo As Short, ByVal Dist As Double, ByVal StrVel As Double, ByVal MaxVel As Double, ByVal Tacc As Double, ByVal Tdec As Double) As Short
	Declare Function B_8158_db51_HSL_M_start_ta_move Lib "8158.dll"  Alias "_8158_db51_HSL_M_start_ta_move"(ByVal Card_ID As Short, ByVal AxisNo As Short, ByVal Pos As Double, ByVal StrVel As Double, ByVal MaxVel As Double, ByVal Tacc As Double, ByVal Tdec As Double) As Short
	Declare Function B_8158_db51_HSL_M_start_sr_move Lib "8158.dll"  Alias "_8158_db51_HSL_M_start_sr_move"(ByVal Card_ID As Short, ByVal AxisNo As Short, ByVal Dist As Double, ByVal StrVel As Double, ByVal MaxVel As Double, ByVal Tacc As Double, ByVal Tdec As Double, ByVal SVacc As Double, ByVal SVdec As Double) As Short
	Declare Function B_8158_db51_HSL_M_start_sa_move Lib "8158.dll"  Alias "_8158_db51_HSL_M_start_sa_move"(ByVal Card_ID As Short, ByVal AxisNo As Short, ByVal Pos As Double, ByVal StrVel As Double, ByVal MaxVel As Double, ByVal Tacc As Double, ByVal Tdec As Double, ByVal SVacc As Double, ByVal SVdec As Double) As Short
	Declare Function B_8158_db51_HSL_M_set_move_ratio Lib "8158.dll"  Alias "_8158_db51_HSL_M_set_move_ratio"(ByVal Card_ID As Short, ByVal AxisNo As Short, ByVal move_ratio As Double) As Short
	Declare Function B_8158_db51_HSL_M_p_change Lib "8158.dll"  Alias "_8158_db51_HSL_M_p_change"(ByVal Card_ID As Short, ByVal AxisNo As Short, ByVal NewPos As Double) As Short
	Declare Function B_8158_db51_HSL_M_backlash_comp Lib "8158.dll"  Alias "_8158_db51_HSL_M_backlash_comp"(ByVal Card_ID As Short, ByVal AxisNo As Short, ByVal BCompPulse As Short, ByVal Mode As Short) As Short
	Declare Function B_8158_db51_HSL_M_suppress_vibration Lib "8158.dll"  Alias "_8158_db51_HSL_M_suppress_vibration"(ByVal Card_ID As Short, ByVal AxisNo As Short, ByVal T1 As Short, ByVal T2 As Short) As Short
	Declare Function B_8158_db51_HSL_M_set_idle_pulse Lib "8158.dll"  Alias "_8158_db51_HSL_M_set_idle_pulse"(ByVal Card_ID As Short, ByVal AxisNo As Short, ByVal idl_pulse As Short) As Short
	Declare Function B_8158_db51_HSL_M_set_fa_speed Lib "8158.dll"  Alias "_8158_db51_HSL_M_set_fa_speed"(ByVal Card_ID As Short, ByVal AxisNo As Short, ByVal FA_Speed As Double) As Short
	'
	'  Point Table
	Declare Function B_8158_db51_HSL_M_set_point_data Lib "8158.dll"  Alias "_8158_db51_HSL_M_set_point_data"(ByVal Card_ID As Short, ByVal Dimension As Short, ByRef AxisArray As Short, ByVal point_index As Short, ByVal cmd_func As Short, ByRef DistArray As Double, ByVal MaxVel As Double) As Short
	Declare Function B_8158_db51_HSL_M_set_arc_data Lib "8158.dll"  Alias "_8158_db51_HSL_M_set_arc_data"(ByVal Card_ID As Short, ByRef AxisArray As Short, ByVal point_index As Short, ByVal cmd_func As Short, ByRef CenterArray As Double, ByRef EndArray As Double, ByVal DIR_Renamed As Short, ByVal MaxVel As Double) As Short
	Declare Function B_8158_db51_HSL_M_move_point_range Lib "8158.dll"  Alias "_8158_db51_HSL_M_move_point_range"(ByVal Card_ID As Short, ByVal Dimension As Short, ByRef AxisArray As Short, ByVal start_index As Short, ByVal last_index As Short) As Short
	Declare Function B_8158_db51_HSL_M_move_point_table Lib "8158.dll"  Alias "_8158_db51_HSL_M_move_point_table"(ByVal Card_ID As Short, ByVal Dimension As Short, ByRef AxisArray As Short, ByRef PointArray As Short, ByVal total_points As Short) As Short
	'
	'  Linear Interpolated Motion
	Declare Function B_8158_db51_HSL_M_start_tr_move_xy Lib "8158.dll"  Alias "_8158_db51_HSL_M_start_tr_move_xy"(ByVal Card_ID As Short, ByVal M_No As Short, ByVal DistX As Double, ByVal DistY As Double, ByVal StrVel As Double, ByVal MaxVel As Double, ByVal Tacc As Double, ByVal Tdec As Double) As Short
	Declare Function B_8158_db51_HSL_M_start_ta_move_xy Lib "8158.dll"  Alias "_8158_db51_HSL_M_start_ta_move_xy"(ByVal Card_ID As Short, ByVal M_No As Short, ByVal PosX As Double, ByVal PosY As Double, ByVal StrVel As Double, ByVal MaxVel As Double, ByVal Tacc As Double, ByVal Tdec As Double) As Short
	Declare Function B_8158_db51_HSL_M_start_sr_move_xy Lib "8158.dll"  Alias "_8158_db51_HSL_M_start_sr_move_xy"(ByVal Card_ID As Short, ByVal M_No As Short, ByVal DistX As Double, ByVal DistY As Double, ByVal StrVel As Double, ByVal MaxVel As Double, ByVal Tacc As Double, ByVal Tdec As Double, ByVal SVacc As Double, ByVal SVdec As Double) As Short
	Declare Function B_8158_db51_HSL_M_start_sa_move_xy Lib "8158.dll"  Alias "_8158_db51_HSL_M_start_sa_move_xy"(ByVal Card_ID As Short, ByVal M_No As Short, ByVal PosX As Double, ByVal PosY As Double, ByVal StrVel As Double, ByVal MaxVel As Double, ByVal Tacc As Double, ByVal Tdec As Double, ByVal SVacc As Double, ByVal SVdec As Double) As Short
	Declare Function B_8158_db51_HSL_M_start_tr_move_zu Lib "8158.dll"  Alias "_8158_db51_HSL_M_start_tr_move_zu"(ByVal Card_ID As Short, ByVal M_No As Short, ByVal DistX As Double, ByVal DistY As Double, ByVal StrVel As Double, ByVal MaxVel As Double, ByVal Tacc As Double, ByVal Tdec As Double) As Short
	Declare Function B_8158_db51_HSL_M_start_ta_move_zu Lib "8158.dll"  Alias "_8158_db51_HSL_M_start_ta_move_zu"(ByVal Card_ID As Short, ByVal M_No As Short, ByVal PosX As Double, ByVal PosY As Double, ByVal StrVel As Double, ByVal MaxVel As Double, ByVal Tacc As Double, ByVal Tdec As Double) As Short
	Declare Function B_8158_db51_HSL_M_start_sr_move_zu Lib "8158.dll"  Alias "_8158_db51_HSL_M_start_sr_move_zu"(ByVal Card_ID As Short, ByVal M_No As Short, ByVal DistX As Double, ByVal DistY As Double, ByVal StrVel As Double, ByVal MaxVel As Double, ByVal Tacc As Double, ByVal Tdec As Double, ByVal SVacc As Double, ByVal SVdec As Double) As Short
	Declare Function B_8158_db51_HSL_M_start_sa_move_zu Lib "8158.dll"  Alias "_8158_db51_HSL_M_start_sa_move_zu"(ByVal Card_ID As Short, ByVal M_No As Short, ByVal PosX As Double, ByVal PosY As Double, ByVal StrVel As Double, ByVal MaxVel As Double, ByVal Tacc As Double, ByVal Tdec As Double, ByVal SVacc As Double, ByVal SVdec As Double) As Short
	Declare Function B_8158_db51_HSL_M_start_tr_line2 Lib "8158.dll"  Alias "_8158_db51_HSL_M_start_tr_line2"(ByVal Card_ID As Short, ByRef AxisArray As Short, ByVal DistX As Double, ByVal DistY As Double, ByVal StrVel As Double, ByVal MaxVel As Double, ByVal Tacc As Double, ByVal Tdec As Double) As Short
	Declare Function B_8158_db51_HSL_M_start_ta_line2 Lib "8158.dll"  Alias "_8158_db51_HSL_M_start_ta_line2"(ByVal Card_ID As Short, ByRef AxisArray As Short, ByVal PosX As Double, ByVal PosY As Double, ByVal StrVel As Double, ByVal MaxVel As Double, ByVal Tacc As Double, ByVal Tdec As Double) As Short
	Declare Function B_8158_db51_HSL_M_start_sr_line2 Lib "8158.dll"  Alias "_8158_db51_HSL_M_start_sr_line2"(ByVal Card_ID As Short, ByRef AxisArray As Short, ByVal DistX As Double, ByVal DistY As Double, ByVal StrVel As Double, ByVal MaxVel As Double, ByVal Tacc As Double, ByVal Tdec As Double, ByVal SVacc As Double, ByVal SVdec As Double) As Short
	Declare Function B_8158_db51_HSL_M_start_sa_line2 Lib "8158.dll"  Alias "_8158_db51_HSL_M_start_sa_line2"(ByVal Card_ID As Short, ByRef AxisArray As Short, ByVal PosX As Double, ByVal PosY As Double, ByVal StrVel As Double, ByVal MaxVel As Double, ByVal Tacc As Double, ByVal Tdec As Double, ByVal SVacc As Double, ByVal SVdec As Double) As Short
	Declare Function B_8158_db51_HSL_M_start_tr_line3 Lib "8158.dll"  Alias "_8158_db51_HSL_M_start_tr_line3"(ByVal Card_ID As Short, ByRef AxisArray As Short, ByVal DistX As Double, ByVal DistY As Double, ByVal DistZ As Double, ByVal StrVel As Double, ByVal MaxVel As Double, ByVal Tacc As Double, ByVal Tdec As Double) As Short
	Declare Function B_8158_db51_HSL_M_start_ta_line3 Lib "8158.dll"  Alias "_8158_db51_HSL_M_start_ta_line3"(ByVal Card_ID As Short, ByRef AxisArray As Short, ByVal PosX As Double, ByVal PosY As Double, ByVal PosZ As Double, ByVal StrVel As Double, ByVal MaxVel As Double, ByVal Tacc As Double, ByVal Tdec As Double) As Short
	Declare Function B_8158_db51_HSL_M_start_sr_line3 Lib "8158.dll"  Alias "_8158_db51_HSL_M_start_sr_line3"(ByVal Card_ID As Short, ByRef AxisArray As Short, ByVal DistX As Double, ByVal DistY As Double, ByVal DistZ As Double, ByVal StrVel As Double, ByVal MaxVel As Double, ByVal Tacc As Double, ByVal Tdec As Double, ByVal SVacc As Double, ByVal SVdec As Double) As Short
	Declare Function B_8158_db51_HSL_M_start_sa_line3 Lib "8158.dll"  Alias "_8158_db51_HSL_M_start_sa_line3"(ByVal Card_ID As Short, ByRef AxisArray As Short, ByVal PosX As Double, ByVal PosY As Double, ByVal PosZ As Double, ByVal StrVel As Double, ByVal MaxVel As Double, ByVal Tacc As Double, ByVal Tdec As Double, ByVal SVacc As Double, ByVal SVdec As Double) As Short
	Declare Function B_8158_db51_HSL_M_start_tr_line4 Lib "8158.dll"  Alias "_8158_db51_HSL_M_start_tr_line4"(ByVal Card_ID As Short, ByVal M_No As Short, ByVal DistX As Double, ByVal DistY As Double, ByVal DistZ As Double, ByVal DistU As Double, ByVal StrVel As Double, ByVal MaxVel As Double, ByVal Tacc As Double, ByVal Tdec As Double) As Short
	Declare Function B_8158_db51_HSL_M_start_ta_line4 Lib "8158.dll"  Alias "_8158_db51_HSL_M_start_ta_line4"(ByVal Card_ID As Short, ByVal M_No As Short, ByVal PosX As Double, ByVal PosY As Double, ByVal PosZ As Double, ByVal PosU As Double, ByVal StrVel As Double, ByVal MaxVel As Double, ByVal Tacc As Double, ByVal Tdec As Double) As Short
	Declare Function B_8158_db51_HSL_M_start_sr_line4 Lib "8158.dll"  Alias "_8158_db51_HSL_M_start_sr_line4"(ByVal Card_ID As Short, ByVal M_No As Short, ByVal DistX As Double, ByVal DistY As Double, ByVal DistZ As Double, ByVal DistU As Double, ByVal StrVel As Double, ByVal MaxVel As Double, ByVal Tacc As Double, ByVal Tdec As Double, ByVal SVacc As Double, ByVal SVdec As Double) As Short
	Declare Function B_8158_db51_HSL_M_start_sa_line4 Lib "8158.dll"  Alias "_8158_db51_HSL_M_start_sa_line4"(ByVal Card_ID As Short, ByVal M_No As Short, ByVal PosX As Double, ByVal PosY As Double, ByVal PosZ As Double, ByVal PosU As Double, ByVal StrVel As Double, ByVal MaxVel As Double, ByVal Tacc As Double, ByVal Tdec As Double, ByVal SVacc As Double, ByVal SVdec As Double) As Short
	'
	'  Circular Interpolation Motion
	Declare Function B_8158_db51_HSL_M_start_r_arc_xy Lib "8158.dll"  Alias "_8158_db51_HSL_M_start_r_arc_xy"(ByVal Card_ID As Short, ByVal M_No As Short, ByVal OffsetCx As Double, ByVal OffsetCy As Double, ByVal OffsetEx As Double, ByVal OffsetEy As Double, ByVal DIR_Renamed As Short, ByVal MaxVel As Double) As Short
	Declare Function B_8158_db51_HSL_M_start_a_arc_xy Lib "8158.dll"  Alias "_8158_db51_HSL_M_start_a_arc_xy"(ByVal Card_ID As Short, ByVal M_No As Short, ByVal Cx As Double, ByVal Cy As Double, ByVal Ex As Double, ByVal Ey As Double, ByVal DIR_Renamed As Short, ByVal MaxVel As Double) As Short
	Declare Function B_8158_db51_HSL_M_start_r_arc_zu Lib "8158.dll"  Alias "_8158_db51_HSL_M_start_r_arc_zu"(ByVal Card_ID As Short, ByVal M_No As Short, ByVal OffsetCx As Double, ByVal OffsetCy As Double, ByVal OffsetEx As Double, ByVal OffsetEy As Double, ByVal DIR_Renamed As Short, ByVal MaxVel As Double) As Short
	Declare Function B_8158_db51_HSL_M_start_a_arc_zu Lib "8158.dll"  Alias "_8158_db51_HSL_M_start_a_arc_zu"(ByVal Card_ID As Short, ByVal M_No As Short, ByVal Cx As Double, ByVal Cy As Double, ByVal Ex As Double, ByVal Ey As Double, ByVal DIR_Renamed As Short, ByVal MaxVel As Double) As Short
	Declare Function B_8158_db51_HSL_M_start_r_arc2 Lib "8158.dll"  Alias "_8158_db51_HSL_M_start_r_arc2"(ByVal Card_ID As Short, ByRef AxisArray As Short, ByVal OffsetCx As Double, ByVal OffsetCy As Double, ByVal OffsetEx As Double, ByVal OffsetEy As Double, ByVal DIR_Renamed As Short, ByVal MaxVel As Double) As Short
	Declare Function B_8158_db51_HSL_M_start_a_arc2 Lib "8158.dll"  Alias "_8158_db51_HSL_M_start_a_arc2"(ByVal Card_ID As Short, ByRef AxisArray As Short, ByVal Cx As Double, ByVal Cy As Double, ByVal Ex As Double, ByVal Ey As Double, ByVal DIR_Renamed As Short, ByVal MaxVel As Double) As Short
	Declare Function B_8158_db51_HSL_M_start_tr_arc_xy Lib "8158.dll"  Alias "_8158_db51_HSL_M_start_tr_arc_xy"(ByVal Card_ID As Short, ByVal M_No As Short, ByVal OffsetCx As Double, ByVal OffsetCy As Double, ByVal OffsetEx As Double, ByVal OffsetEy As Double, ByVal DIR_Renamed As Short, ByVal StrVel As Double, ByVal MaxVel As Double, ByVal Tacc As Double, ByVal Tdec As Double) As Short
	Declare Function B_8158_db51_HSL_M_start_ta_arc_xy Lib "8158.dll"  Alias "_8158_db51_HSL_M_start_ta_arc_xy"(ByVal Card_ID As Short, ByVal M_No As Short, ByVal Cx As Double, ByVal Cy As Double, ByVal Ex As Double, ByVal Ey As Double, ByVal DIR_Renamed As Short, ByVal StrVel As Double, ByVal MaxVel As Double, ByVal Tacc As Double, ByVal Tdec As Double) As Short
	Declare Function B_8158_db51_HSL_M_start_sr_arc_xy Lib "8158.dll"  Alias "_8158_db51_HSL_M_start_sr_arc_xy"(ByVal Card_ID As Short, ByVal M_No As Short, ByVal OffsetCx As Double, ByVal OffsetCy As Double, ByVal OffsetEx As Double, ByVal OffsetEy As Double, ByVal DIR_Renamed As Short, ByVal StrVel As Double, ByVal MaxVel As Double, ByVal Tacc As Double, ByVal Tdec As Double, ByVal SVacc As Double, ByVal SVdec As Double) As Short
	Declare Function B_8158_db51_HSL_M_start_sa_arc_xy Lib "8158.dll"  Alias "_8158_db51_HSL_M_start_sa_arc_xy"(ByVal Card_ID As Short, ByVal M_No As Short, ByVal Cx As Double, ByVal Cy As Double, ByVal Ex As Double, ByVal Ey As Double, ByVal DIR_Renamed As Short, ByVal StrVel As Double, ByVal MaxVel As Double, ByVal Tacc As Double, ByVal Tdec As Double, ByVal SVacc As Double, ByVal SVdec As Double) As Short
	Declare Function B_8158_db51_HSL_M_start_tr_arc_zu Lib "8158.dll"  Alias "_8158_db51_HSL_M_start_tr_arc_zu"(ByVal Card_ID As Short, ByVal M_No As Short, ByVal OffsetCx As Double, ByVal OffsetCy As Double, ByVal OffsetEx As Double, ByVal OffsetEy As Double, ByVal DIR_Renamed As Short, ByVal StrVel As Double, ByVal MaxVel As Double, ByVal Tacc As Double, ByVal Tdec As Double) As Short
	Declare Function B_8158_db51_HSL_M_start_ta_arc_zu Lib "8158.dll"  Alias "_8158_db51_HSL_M_start_ta_arc_zu"(ByVal Card_ID As Short, ByVal M_No As Short, ByVal Cx As Double, ByVal Cy As Double, ByVal Ex As Double, ByVal Ey As Double, ByVal DIR_Renamed As Short, ByVal StrVel As Double, ByVal MaxVel As Double, ByVal Tacc As Double, ByVal Tdec As Double) As Short
	Declare Function B_8158_db51_HSL_M_start_sr_arc_zu Lib "8158.dll"  Alias "_8158_db51_HSL_M_start_sr_arc_zu"(ByVal Card_ID As Short, ByVal M_No As Short, ByVal OffsetCx As Double, ByVal OffsetCy As Double, ByVal OffsetEx As Double, ByVal OffsetEy As Double, ByVal DIR_Renamed As Short, ByVal StrVel As Double, ByVal MaxVel As Double, ByVal Tacc As Double, ByVal Tdec As Double, ByVal SVacc As Double, ByVal SVdec As Double) As Short
	Declare Function B_8158_db51_HSL_M_start_sa_arc_zu Lib "8158.dll"  Alias "_8158_db51_HSL_M_start_sa_arc_zu"(ByVal Card_ID As Short, ByVal M_No As Short, ByVal Cx As Double, ByVal Cy As Double, ByVal Ex As Double, ByVal Ey As Double, ByVal DIR_Renamed As Short, ByVal StrVel As Double, ByVal MaxVel As Double, ByVal Tacc As Double, ByVal Tdec As Double, ByVal SVacc As Double, ByVal SVdec As Double) As Short
	Declare Function B_8158_db51_HSL_M_start_tr_arc2 Lib "8158.dll"  Alias "_8158_db51_HSL_M_start_tr_arc2"(ByVal Card_ID As Short, ByRef AxisArray As Short, ByVal OffsetCx As Double, ByVal OffsetCy As Double, ByVal OffsetEx As Double, ByVal OffsetEy As Double, ByVal DIR_Renamed As Short, ByVal StrVel As Double, ByVal MaxVel As Double, ByVal Tacc As Double, ByVal Tdec As Double) As Short
	Declare Function B_8158_db51_HSL_M_start_ta_arc2 Lib "8158.dll"  Alias "_8158_db51_HSL_M_start_ta_arc2"(ByVal Card_ID As Short, ByRef AxisArray As Short, ByVal Cx As Double, ByVal Cy As Double, ByVal Ex As Double, ByVal Ey As Double, ByVal DIR_Renamed As Short, ByVal StrVel As Double, ByVal MaxVel As Double, ByVal Tacc As Double, ByVal Tdec As Double) As Short
	Declare Function B_8158_db51_HSL_M_start_sr_arc2 Lib "8158.dll"  Alias "_8158_db51_HSL_M_start_sr_arc2"(ByVal Card_ID As Short, ByRef AxisArray As Short, ByVal OffsetCx As Double, ByVal OffsetCy As Double, ByVal OffsetEx As Double, ByVal OffsetEy As Double, ByVal DIR_Renamed As Short, ByVal StrVel As Double, ByVal MaxVel As Double, ByVal Tacc As Double, ByVal Tdec As Double, ByVal SVacc As Double, ByVal SVdec As Double) As Short
	Declare Function B_8158_db51_HSL_M_start_sa_arc2 Lib "8158.dll"  Alias "_8158_db51_HSL_M_start_sa_arc2"(ByVal Card_ID As Short, ByRef AxisArray As Short, ByVal Cx As Double, ByVal Cy As Double, ByVal Ex As Double, ByVal Ey As Double, ByVal DIR_Renamed As Short, ByVal StrVel As Double, ByVal MaxVel As Double, ByVal Tacc As Double, ByVal Tdec As Double, ByVal SVacc As Double, ByVal SVdec As Double) As Short
	'
	'  Home Return Mode
	Declare Function B_8158_db51_HSL_M_set_home_config Lib "8158.dll"  Alias "_8158_db51_HSL_M_set_home_config"(ByVal Card_ID As Short, ByVal AxisNo As Short, ByVal home_mode As Short, ByVal org_logic As Short, ByVal ez_logic As Short, ByVal ez_count As Short, ByVal erc_out As Short) As Short
	Declare Function B_8158_db51_HSL_M_set_org_offset Lib "8158.dll"  Alias "_8158_db51_HSL_M_set_org_offset"(ByVal Card_ID As Short, ByVal AxisNo As Short, ByVal ORG_ESC_Offset As Double) As Short
	Declare Function B_8158_db51_HSL_M_home_move Lib "8158.dll"  Alias "_8158_db51_HSL_M_home_move"(ByVal Card_ID As Short, ByVal AxisNo As Short, ByVal StrVel As Double, ByVal MaxVel As Double, ByVal Tacc As Double) As Short
	Declare Function B_8158_db51_HSL_M_escape_home Lib "8158.dll"  Alias "_8158_db51_HSL_M_escape_home"(ByVal Card_ID As Short, ByVal AxisNo As Short, ByVal StrVel As Double, ByVal MaxVel As Double, ByVal Tacc As Double) As Short
	Declare Function B_8158_db51_HSL_M_home_search Lib "8158.dll"  Alias "_8158_db51_HSL_M_home_search"(ByVal Card_ID As Short, ByVal AxisNo As Short, ByVal StrVel As Double, ByVal MaxVel As Double, ByVal Tacc As Double, ByVal ORGOffset As Double) As Short
	'
	'  Motion Status
	Declare Function B_8158_db51_HSL_M_motion_done Lib "8158.dll"  Alias "_8158_db51_HSL_M_motion_done"(ByVal Card_ID As Short, ByVal AxisNo As Short) As Short
	Declare Function B_8158_db51_HSL_M_get_abnormal_stop_status Lib "8158.dll"  Alias "_8158_db51_HSL_M_get_abnormal_stop_status"(ByVal Card_ID As Short, ByVal AxisNo As Short, ByRef status As Integer) As Short
	'
	'  Motion Interface I/O
	Declare Function B_8158_db51_HSL_M_set_alm Lib "8158.dll"  Alias "_8158_db51_HSL_M_set_alm"(ByVal Card_ID As Short, ByVal AxisNo As Short, ByVal alm_logic As Short, ByVal alm_mode As Short) As Short
	Declare Function B_8158_db51_HSL_M_set_el Lib "8158.dll"  Alias "_8158_db51_HSL_M_set_el"(ByVal Card_ID As Short, ByVal AxisNo As Short, ByVal el_mode As Short) As Short
	Declare Function B_8158_db51_HSL_M_set_el_logic Lib "8158.dll"  Alias "_8158_db51_HSL_M_set_el_logic"(ByVal Card_ID As Short, ByVal AxisNo As Short, ByVal el_logic As Short) As Short
	Declare Function B_8158_db51_HSL_M_set_inp Lib "8158.dll"  Alias "_8158_db51_HSL_M_set_inp"(ByVal Card_ID As Short, ByVal AxisNo As Short, ByVal inp_enable As Short, ByVal inp_logic As Short) As Short
	Declare Function B_8158_db51_HSL_M_set_erc Lib "8158.dll"  Alias "_8158_db51_HSL_M_set_erc"(ByVal Card_ID As Short, ByVal AxisNo As Short, ByVal erc_logic As Short, ByVal erc_on_time As Short) As Short
	Declare Function B_8158_db51_HSL_M_set_servo Lib "8158.dll"  Alias "_8158_db51_HSL_M_set_servo"(ByVal Card_ID As Short, ByVal AxisNo As Short, ByVal on_off As Short) As Short
	Declare Function B_8158_db51_HSL_M_set_sd Lib "8158.dll"  Alias "_8158_db51_HSL_M_set_sd"(ByVal Card_ID As Short, ByVal AxisNo As Short, ByVal enable As Short, ByVal sd_logic As Short, ByVal sd_latch As Short, ByVal sd_mode As Short) As Short
	'
	'  Motion I/O Monitoring
	Declare Function B_8158_db51_HSL_M_get_io_status Lib "8158.dll"  Alias "_8158_db51_HSL_M_get_io_status"(ByVal Card_ID As Short, ByVal AxisNo As Short, ByRef io_sts As Short) As Short
	'
	'  Position Control and Counters
	Declare Function B_8158_db51_HSL_M_get_position Lib "8158.dll"  Alias "_8158_db51_HSL_M_get_position"(ByVal Card_ID As Short, ByVal AxisNo As Short, ByRef Pos As Double) As Short
	Declare Function B_8158_db51_HSL_M_set_position Lib "8158.dll"  Alias "_8158_db51_HSL_M_set_position"(ByVal Card_ID As Short, ByVal AxisNo As Short, ByVal Pos As Double) As Short
	Declare Function B_8158_db51_HSL_M_get_command Lib "8158.dll"  Alias "_8158_db51_HSL_M_get_command"(ByVal Card_ID As Short, ByVal AxisNo As Short, ByRef Cmd As Integer) As Short
	Declare Function B_8158_db51_HSL_M_set_command Lib "8158.dll"  Alias "_8158_db51_HSL_M_set_command"(ByVal Card_ID As Short, ByVal AxisNo As Short, ByVal Cmd As Integer) As Short
	Declare Function B_8158_db51_HSL_M_get_error_counter Lib "8158.dll"  Alias "_8158_db51_HSL_M_get_error_counter"(ByVal Card_ID As Short, ByVal AxisNo As Short, ByRef error_counter As Short) As Short
	Declare Function B_8158_db51_HSL_M_reset_error_counter Lib "8158.dll"  Alias "_8158_db51_HSL_M_reset_error_counter"(ByVal Card_ID As Short, ByVal AxisNo As Short) As Short
	Declare Function B_8158_db51_HSL_M_get_general_counter Lib "8158.dll"  Alias "_8158_db51_HSL_M_get_general_counter"(ByVal Card_ID As Short, ByVal AxisNo As Short, ByRef CntValue As Double) As Short
	Declare Function B_8158_db51_HSL_M_set_general_counter Lib "8158.dll"  Alias "_8158_db51_HSL_M_set_general_counter"(ByVal Card_ID As Short, ByVal AxisNo As Short, ByVal CntSrc As Short, ByVal CntValue As Double) As Short
	Declare Function B_8158_db51_HSL_M_get_target_pos Lib "8158.dll"  Alias "_8158_db51_HSL_M_get_target_pos"(ByVal Card_ID As Short, ByVal AxisNo As Short, ByRef Pos As Double) As Short
	Declare Function B_8158_db51_HSL_M_reset_target_pos Lib "8158.dll"  Alias "_8158_db51_HSL_M_reset_target_pos"(ByVal Card_ID As Short, ByVal AxisNo As Short, ByVal Pos As Double) As Short
	Declare Function B_8158_db51_HSL_M_get_rest_command Lib "8158.dll"  Alias "_8158_db51_HSL_M_get_rest_command"(ByVal Card_ID As Short, ByVal AxisNo As Short, ByRef rest_command As Integer) As Short
	Declare Function B_8158_db51_HSL_M_check_rdp Lib "8158.dll"  Alias "_8158_db51_HSL_M_check_rdp"(ByVal Card_ID As Short, ByVal AxisNo As Short, ByRef rdp_command As Integer) As Short
	'
	'  Position Compare and Latch
	Declare Function B_8158_db51_HSL_M_set_ltc_logic Lib "8158.dll"  Alias "_8158_db51_HSL_M_set_ltc_logic"(ByVal Card_ID As Short, ByVal AxisNo As Short, ByVal ltc_logic As Short) As Short
	Declare Function B_8158_db51_HSL_M_get_latch_data Lib "8158.dll"  Alias "_8158_db51_HSL_M_get_latch_data"(ByVal Card_ID As Short, ByVal AxisNo As Short, ByVal LatchNo As Short, ByRef Pos As Double) As Short
	Declare Function B_8158_db51_HSL_M_set_soft_limit Lib "8158.dll"  Alias "_8158_db51_HSL_M_set_soft_limit"(ByVal Card_ID As Short, ByVal AxisNo As Short, ByVal PLimit As Integer, ByVal NLimit As Integer) As Short
	Declare Function B_8158_db51_HSL_M_enable_soft_limit Lib "8158.dll"  Alias "_8158_db51_HSL_M_enable_soft_limit"(ByVal Card_ID As Short, ByVal AxisNo As Short, ByVal Action As Short) As Short
	Declare Function B_8158_db51_HSL_M_disable_soft_limit Lib "8158.dll"  Alias "_8158_db51_HSL_M_disable_soft_limit"(ByVal Card_ID As Short, ByVal AxisNo As Short) As Short
	Declare Function B_8158_db51_HSL_M_set_error_counter_check Lib "8158.dll"  Alias "_8158_db51_HSL_M_set_error_counter_check"(ByVal Card_ID As Short, ByVal AxisNo As Short, ByVal Tolerance As Short, ByVal on_off As Short) As Short
	Declare Function B_8158_db51_HSL_M_set_general_comparator Lib "8158.dll"  Alias "_8158_db51_HSL_M_set_general_comparator"(ByVal Card_ID As Short, ByVal AxisNo As Short, ByVal CmpSrc As Short, ByVal CmpMethod As Short, ByVal CmpAction As Short, ByVal Data As Double) As Short
	Declare Function B_8158_db51_HSL_M_set_trigger_comparator Lib "8158.dll"  Alias "_8158_db51_HSL_M_set_trigger_comparator"(ByVal Card_ID As Short, ByVal AxisNo As Short, ByVal CmpSrc As Short, ByVal CmpMethod As Short, ByVal Data As Double) As Short
	Declare Function B_8158_db51_HSL_M_check_compare_data Lib "8158.dll"  Alias "_8158_db51_HSL_M_check_compare_data"(ByVal Card_ID As Short, ByVal AxisNo As Short, ByVal CompType As Short, ByRef Pos As Double) As Short
	Declare Function B_8158_db51_HSL_M_check_compare_status Lib "8158.dll"  Alias "_8158_db51_HSL_M_check_compare_status"(ByVal Card_ID As Short, ByVal AxisNo As Short, ByRef cmp_sts As Short) As Short
	Declare Function B_8158_db51_HSL_M_build_compare_table Lib "8158.dll"  Alias "_8158_db51_HSL_M_build_compare_table"(ByVal Card_ID As Short, ByVal AxisNo As Short, ByRef TableArray As Double, ByVal ArraySize As Short) As Short
	Declare Function B_8158_db51_HSL_M_build_compare_function Lib "8158.dll"  Alias "_8158_db51_HSL_M_build_compare_function"(ByVal Card_ID As Short, ByVal AxisNo As Short, ByVal Startpoint As Double, ByVal Endpoint As Double, ByVal Interval As Double) As Short
	Declare Function B_8158_db51_HSL_M_set_auto_compare Lib "8158.dll"  Alias "_8158_db51_HSL_M_set_auto_compare"(ByVal Card_ID As Short, ByVal AxisNo As Short, ByVal enable As Short) As Short
	Declare Function B_8158_db51_HSL_M_set_compare_dir Lib "8158.dll"  Alias "_8158_db51_HSL_M_set_compare_dir"(ByVal Card_ID As Short, ByVal AxisNo As Short, ByVal Inverse As Short) As Short
	' I16 FNTYPE _8158_db51_HSL_M_set_compare_output_type(I16 card_ID, I16 AxisNo, I16 Normal_High_or_Low);
	'
	'  Multiple Axes Simultaneous Operation
	Declare Function B_8158_db51_HSL_M_set_tr_move_all Lib "8158.dll"  Alias "_8158_db51_HSL_M_set_tr_move_all"(ByVal Card_ID As Short, ByVal TotalAxes As Short, ByRef AxisArray As Short, ByRef DistA As Double, ByRef StrVelA As Double, ByRef MaxVelA As Double, ByRef TaccA As Double, ByRef TdecA As Double) As Short
	Declare Function B_8158_db51_HSL_M_set_ta_move_all Lib "8158.dll"  Alias "_8158_db51_HSL_M_set_ta_move_all"(ByVal Card_ID As Short, ByVal TotalAxes As Short, ByRef AxisArray As Short, ByRef PosA As Double, ByRef StrVelA As Double, ByRef MaxVelA As Double, ByRef TaccA As Double, ByRef TdecA As Double) As Short
	Declare Function B_8158_db51_HSL_M_set_sa_move_all Lib "8158.dll"  Alias "_8158_db51_HSL_M_set_sa_move_all"(ByVal Card_ID As Short, ByVal TotalAxes As Short, ByRef AxisArray As Short, ByRef PosA As Double, ByRef StrVelA As Double, ByRef MaxVelA As Double, ByRef TaccA As Double, ByRef TdecA As Double, ByRef SVaccA As Double, ByRef SVdecA As Double) As Short
	Declare Function B_8158_db51_HSL_M_set_sr_move_all Lib "8158.dll"  Alias "_8158_db51_HSL_M_set_sr_move_all"(ByVal Card_ID As Short, ByVal TotalAxes As Short, ByRef AxisArray As Short, ByRef DistA As Double, ByRef StrVelA As Double, ByRef MaxVelA As Double, ByRef TaccA As Double, ByRef TdecA As Double, ByRef SVaccA As Double, ByRef SVdecA As Double) As Short
	Declare Function B_8158_db51_HSL_M_start_move_all Lib "8158.dll"  Alias "_8158_db51_HSL_M_start_move_all"(ByVal Card_ID As Short, ByVal FirstAxisNo As Short) As Short
	Declare Function B_8158_db51_HSL_M_stop_move_all Lib "8158.dll"  Alias "_8158_db51_HSL_M_stop_move_all"(ByVal Card_ID As Short, ByVal FirstAxisNo As Short) As Short
	Declare Function B_8158_db51_HSL_M_set_sync_option Lib "8158.dll"  Alias "_8158_db51_HSL_M_set_sync_option"(ByVal Card_ID As Short, ByVal AxisNo As Short, ByVal sync_stop_on As Short, ByVal cstop_output_on As Short, ByVal sync_option1 As Short, ByVal sync_option2 As Short) As Short
	Declare Function B_8158_db51_HSL_M_set_sync_stop_mode Lib "8158.dll"  Alias "_8158_db51_HSL_M_set_sync_stop_mode"(ByVal Card_ID As Short, ByVal AxisNo As Short, ByVal stop_mode As Short) As Short
	'
	'  General-purposed DIO
	Declare Function B_8158_db51_HSL_M_write_do Lib "8158.dll"  Alias "_8158_db51_HSL_M_write_do"(ByVal Card_ID As Short, ByVal AxisNo As Short, ByVal value As Short) As Short
	Declare Function B_8158_db51_HSL_M_read_di Lib "8158.dll"  Alias "_8158_db51_HSL_M_read_di"(ByVal Card_ID As Short, ByVal AxisNo As Short) As Short
	'
	'  G code based function
	' I16 FNTYPE _8158_db51_HSL_M_load_G_code(I16 card_ID, I16 M_No, char *filename);
	Declare Function B_8158_db51_HSL_M_run_G_code Lib "8158.dll"  Alias "_8158_db51_HSL_M_run_G_code"(ByVal Card_ID As Short, ByVal M_No As Short, ByVal start_line_num As Short) As Short
	Declare Function B_8158_db51_HSL_M_stop_G_code Lib "8158.dll"  Alias "_8158_db51_HSL_M_stop_G_code "(ByVal Card_ID As Short, ByVal M_No As Short) As Short
	Declare Function B_8158_db51_HSL_M_pause_G_code Lib "8158.dll"  Alias "_8158_db51_HSL_M_pause_G_code "(ByVal Card_ID As Short, ByVal M_No As Short, ByVal pause_line_num As Short) As Short
	Declare Function B_8158_db51_HSL_M_resume_G_code Lib "8158.dll"  Alias "_8158_db51_HSL_M_resume_G_code "(ByVal Card_ID As Short, ByVal M_No As Short) As Short
	Declare Function B_8158_db51_HSL_M_get_current_G_line Lib "8158.dll"  Alias "_8158_db51_HSL_M_get_current_G_line "(ByVal Card_ID As Short, ByVal M_No As Short, ByRef current_line As Short) As Short
	Declare Function B_8158_db51_HSL_M_map_G_code Lib "8158.dll"  Alias "_8158_db51_HSL_M_map_G_code"(ByVal Card_ID As Short, ByVal M_No As Short, ByVal G_Function As Short, ByRef AxisArray As Short, ByVal Motion_Function As Short) As Short
	'
	' /****************************************************************************/
	' /*      Simplified Function  for HSL communication                          */
	' /****************************************************************************/
	'
	'  Parameter Setting
	Declare Function B_8158_db51_HSL_M_set_str_velocity Lib "8158.dll"  Alias "_8158_db51_HSL_M_set_str_velocity"(ByVal Card_ID As Short, ByVal AxisNo As Short, ByVal StrVel As Double) As Short
	Declare Function B_8158_db51_HSL_M_set_max_velocity Lib "8158.dll"  Alias "_8158_db51_HSL_M_set_max_velocity"(ByVal Card_ID As Short, ByVal AxisNo As Short, ByVal MaxVel As Double) As Short
	Declare Function B_8158_db51_HSL_M_set_arc_velocity Lib "8158.dll"  Alias "_8158_db51_HSL_M_set_arc_velocity"(ByVal Card_ID As Short, ByVal AxisNo As Short, ByVal Arc_MaxVel As Double) As Short
	Declare Function B_8158_db51_HSL_M_set_Tacc Lib "8158.dll"  Alias "_8158_db51_HSL_M_set_Tacc"(ByVal Card_ID As Short, ByVal AxisNo As Short, ByVal Tacc As Double) As Short
	Declare Function B_8158_db51_HSL_M_set_Tdec Lib "8158.dll"  Alias "_8158_db51_HSL_M_set_Tdec"(ByVal Card_ID As Short, ByVal AxisNo As Short, ByVal Tdec As Double) As Short
	Declare Function B_8158_db51_HSL_M_set_SVacc Lib "8158.dll"  Alias "_8158_db51_HSL_M_set_SVacc"(ByVal Card_ID As Short, ByVal AxisNo As Short, ByVal SVacc As Double) As Short
	Declare Function B_8158_db51_HSL_M_set_SVdec Lib "8158.dll"  Alias "_8158_db51_HSL_M_set_SVdec"(ByVal Card_ID As Short, ByVal AxisNo As Short, ByVal SVdec As Double) As Short
	'
	'  Single Axis Motion
	Declare Function B_8158_db51_HSL_M_move_t_distance Lib "8158.dll"  Alias "_8158_db51_HSL_M_move_t_distance"(ByVal Card_ID As Short, ByVal AxisNo As Short, ByVal Dist As Double) As Short
	Declare Function B_8158_db51_HSL_M_move_t_position Lib "8158.dll"  Alias "_8158_db51_HSL_M_move_t_position"(ByVal Card_ID As Short, ByVal AxisNo As Short, ByVal Pos As Double) As Short
	Declare Function B_8158_db51_HSL_M_move_s_distance Lib "8158.dll"  Alias "_8158_db51_HSL_M_move_s_distance"(ByVal Card_ID As Short, ByVal AxisNo As Short, ByVal Dist As Double) As Short
	Declare Function B_8158_db51_HSL_M_move_s_position Lib "8158.dll"  Alias "_8158_db51_HSL_M_move_s_position"(ByVal Card_ID As Short, ByVal AxisNo As Short, ByVal Pos As Double) As Short
	'
	'  Linear Interpolated Motion
	Declare Function B_8158_db51_HSL_M_move_t_distance2 Lib "8158.dll"  Alias "_8158_db51_HSL_M_move_t_distance2"(ByVal Card_ID As Short, ByRef AxisArray As Short, ByVal DistX As Double, ByVal DistY As Double) As Short
	Declare Function B_8158_db51_HSL_M_move_t_position2 Lib "8158.dll"  Alias "_8158_db51_HSL_M_move_t_position2"(ByVal Card_ID As Short, ByRef AxisArray As Short, ByVal PosX As Double, ByVal PosY As Double) As Short
	Declare Function B_8158_db51_HSL_M_move_s_distance2 Lib "8158.dll"  Alias "_8158_db51_HSL_M_move_s_distance2"(ByVal Card_ID As Short, ByRef AxisArray As Short, ByVal DistX As Double, ByVal DistY As Double) As Short
	Declare Function B_8158_db51_HSL_M_move_s_position2 Lib "8158.dll"  Alias "_8158_db51_HSL_M_move_s_position2"(ByVal Card_ID As Short, ByRef AxisArray As Short, ByVal PosX As Double, ByVal PosY As Double) As Short
	'
	'  Circular Interpolation Motion
	Declare Function B_8158_db51_HSL_M_move_t_arc2_distance Lib "8158.dll"  Alias "_8158_db51_HSL_M_move_t_arc2_distance"(ByVal Card_ID As Short, ByRef AxisArray As Short, ByVal OffsetCx As Double, ByVal OffsetCy As Double, ByVal OffsetEx As Double, ByVal OffsetEy As Double, ByVal DIR_Renamed As Short) As Short
	Declare Function B_8158_db51_HSL_M_move_t_arc2_position Lib "8158.dll"  Alias "_8158_db51_HSL_M_move_t_arc2_position"(ByVal Card_ID As Short, ByRef AxisArray As Short, ByVal Cx As Double, ByVal Cy As Double, ByVal Ex As Double, ByVal Ey As Double, ByVal DIR_Renamed As Short) As Short
	Declare Function B_8158_db51_HSL_M_move_s_arc2_distance Lib "8158.dll"  Alias "_8158_db51_HSL_M_move_s_arc2_distance"(ByVal Card_ID As Short, ByRef AxisArray As Short, ByVal OffsetCx As Double, ByVal OffsetCy As Double, ByVal OffsetEx As Double, ByVal OffsetEy As Double, ByVal DIR_Renamed As Short) As Short
	Declare Function B_8158_db51_HSL_M_move_s_arc2_position Lib "8158.dll"  Alias "_8158_db51_HSL_M_move_s_arc2_position"(ByVal Card_ID As Short, ByRef AxisArray As Short, ByVal Cx As Double, ByVal Cy As Double, ByVal Ex As Double, ByVal Ey As Double, ByVal DIR_Renamed As Short) As Short
	
	' #ifdef __cplusplus
	' }
	' #endif
	'
	' #endif
End Module