<?php
	//保留表单数据
	$L_delayTime=isset($_POST['L_delayTime']) ? $_POST['L_delayTime'] : "1";
	$L_accTime=isset($_POST['L_accTime']) ? $_POST['L_accTime'] : "0.1";
	$L_decTime=isset($_POST['L_decTime']) ? $_POST['L_decTime'] : "0.2";
	$L_maxSpeed=isset($_POST['L_maxSpeed']) ? $_POST['L_maxSpeed'] : "60";
	$L_unifTime=isset($_POST['L_unifTime']) ? $_POST['L_unifTime'] : "0.2";
	$R_delayTime=isset($_POST['R_delayTime']) ? $_POST['R_delayTime'] : "0";
	$R_accTime=isset($_POST['R_accTime']) ? $_POST['R_accTime'] : "0.1";
	$R_decTime=isset($_POST['R_decTime']) ? $_POST['R_decTime'] : "0.1";
	$R_maxSpeed=isset($_POST['R_maxSpeed']) ? $_POST['R_maxSpeed'] : "60";
	$R_dist=isset($_POST['R_dist']) ? $_POST['R_dist'] : "60";
	$sanIntervals=isset($_POST['sanIntervals']) ? $_POST['sanIntervals'] : "200";
	$dataSize=isset($_POST['dataSize']) ? $_POST['dataSize'] : "100000";
	$numOfAve=isset($_POST['numOfAve']) ? $_POST['numOfAve'] : "100";
	$expConditions=isset($_POST['expConditions']) ? $_POST['expConditions'] : "";	
	$fileToSave = isset($_POST['fileToSave']) ? $_POST['fileToSave'] : "ADLINKDaq";
	
	$host = '58.210.119.62';
	$port = '5112';
	$message = 'Hello~~~';
	
	if ($_POST['btn']=="Start")
	{
		$ret = send_tcp_message($host, $port, $message);
		start();
	}
	
	if ($_POST['btn']=="Stop")
	{
		stop();
	}
	
	function start()
	{
		echo isset($_POST['expConditions']);
	}
	function stop() {echo "stop";}
	
	function send_tcp_message($host, $port, $message)
	{
		$socket = socket_create(AF_INET, SOCK_STREAM, SOL_TCP);
		@socket_connect($socket, $host, $port);
		
		$num = 0;
		$length = strlen($message);
		do
		{
			$buffer = substr($message, $num);
			$ret = @socket_write($socket, $buffer);
			$num += $ret;
		} while ($num < $length);
		
		$ret = '';
		do
		{
			$buffer = @socket_read($socket, 1024, PHP_BINARY_READ);
			$ret .= $buffer;
		} while (strlen($buffer) == 1024);
		
		socket_close($socket);
		
		return $ret;
	}	
	
	
?>

<!DOCTYPE HTML>
<html>
	<head>
		<META CHARSET="UTF-8">
		<title>2D Platform Remote Test</title>
		<style type="text/css">
			
		</style>
	</head>
	
	<body>
		<form method="post" autocomplete="on">
			<div id="PCI8158">
				
				<div id="LinearMotion">
					
					<fieldset style="width:400px">
						<legend>LinearMotion</legend>
						<table border="0">
							<tr>
								<th colspan="2"><input type="checkbox" name="chkLinearMotion" />LinearMotion</th>
							</tr>
							
							<tr>
								<td>Delay Time(s):</td>
								<td><input type="text" name="L_delayTime" value="<?php echo $L_delayTime;?>"/></td>
							</tr>
							<tr>
								<td>Acc Time(s):</td>
								<td><input name="L_accTime"  value="<?php echo $L_accTime;?>"/></td>
							</tr>
							<tr>
								<td>Dec Time(s):</td>
								<td><input name="L_decTime"  value="<?php echo $L_decTime;?>"/></td>
							</tr>
							<tr>
								<td>Max Speed(mm/s):</td>
								<td><input name="L_maxSpeed"  value="<?php echo $L_maxSpeed;?>"/></td>
							</tr>
							<tr>
								<td>Unif Time(s):</td>
								<td><input name="L_unifTime"  value="<?php echo $L_unifTime;?>"/></td>
							</tr>
							<tr>
								<td>Current Speed(mm/s):</td>
								<td><input name="L_curSpeed" placeholder="ADLINK feedback"/></td>
							</tr>
						</table>
					</fieldset>
					
					
				</div>
				
				
				<div id="RotationMotion">
					
					<fieldset style="width:400px">
						<legend>RotationMotion</legend>
						<table border="0">
							<tr>
								<th colspan="2"><input type="checkbox" name="chkRotMotion">RotationMotion</th>
							</tr>
							
							<tr>
								<td>Delay Time(s):</td>
								<td><input type="text" name="R_delayTime" value="<?php echo $R_delayTime;?>"/></td>
							</tr>
							<tr>
								<td>Acc Time(s):</td>
								<td><input name="R_accTime" value="<?php echo $R_accTime;?>"/></td>
							</tr>
							<tr>
								<td>Dec Time(s):</td>
								<td><input name="R_decTime" value="<?php echo $R_decTime;?>"/></td>
							</tr>
							<tr>
								<td>Max Speed(deg/s):</td>
								<td><input name="R_maxSpeed" value="<?php echo $R_maxSpeed;?>"/></td>
							</tr>
							<tr>
								<td>Distance(deg):</td>
								<td><input name="R_dist" value="<?php echo $R_dist;?>"/></td>
							</tr>
							<tr>
								<td>Current Speed(deg/s):</td>
								<td><input name="R_curSpeed" placeholder="ADLINK feedback"/></td>
							</tr>
						</table>
					</fieldset>
					
				</div>
			</div>
			<div id="DAQ2005">
				
				<fieldset style="width:400px">
					<legend>LinearMotion</legend>
					<table border="0">
						<tr>
							<th colspan="2"><input type="checkbox" name="chkDAQ2005">DAQ2005 Enable</th>
						</tr>
						
						<tr>
							<td>Scan Intervals:</td>
							<td><input type="text" name="sanIntervals" value="<?php echo $sanIntervals;?>"/></td>
						</tr>	
						<tr>
							<td>Data Size:</td>
							<td><input name="dataSize" value="<?php echo $dataSize;?>"/></td>
						</tr>
						<tr>
							<td>Num of Ave::</td>
							<td><input name="numOfAve" value="<?php echo $numOfAve;?>"/></td>
						</tr>
						<tr>
							<td>Exp conditions:</td>
							<td><textarea name="expConditions" value="<?php echo $expConditions;?> rows="4" cols="21" placeholder="Enperimental conditions content will paste in excel file at cell ('W1')" ></textarea></td>
						</tr>
						<tr>
							<td>File to Save:</td>
							<td><input name="fileToSave" value="<?php echo $fileToSave;?>" /></td>
						</tr>
					</table>
				</fieldset>
				
			</div>
			
			<div id="button">
				
				<input type="submit" name="btn" value="Start">
				<input type="submit" name="btn" value="Stop">
				
				
			</div>
		</form>
	</body>		
</html>


