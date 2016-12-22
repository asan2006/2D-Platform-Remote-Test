<!DOCTYPE HTML>
<head>
	<META CHARSET="UTF-8">
	<title>2D Platform Remote Test</title>
	<style type="text/css">
		
	</style>
</head>

<body>
	<div id="PCI8158">
		
		<div id="LinearMotion">
			<form>
				<fieldset style="width:400px">
					<legend>LinearMotion</legend>
					<table border="0">
						<tr>
							<th colspan="2"><input type="checkbox" name="chkLinearMotion">LinearMotion</th>
						</tr>
						
						<tr>
							<td>Delay Time(s):</td>
							<td><input type="text" name="delayTime" value="1"/></td>
						</tr>
						<tr>
							<td>Acc Time(s):</td>
							<td><input name="accTime"  value="0.1"/></td>
						</tr>
						<tr>
							<td>Dec Time(s):</td>
							<td><input name="decTime"  value="0.2"/></td>
						</tr>
						<tr>
							<td>Max Speed(mm/s):</td>
							<td><input name="maxSpeed"  value="60"/></td>
						</tr>
						<tr>
							<td>Unif Time(s):</td>
							<td><input name="unifTime"  value="0.2"/></td>
						</tr>
						<tr>
							<td>Current Speed(mm/s):</td>
							<td><input name="curSpeed" placeholder="ADLINK feedback"/></td>
						</tr>
					</table>
				</fieldset>
			</form>
			
		</div>
		
		
		<div id="RotationMotion">
			<form>
				<fieldset style="width:400px">
					<legend>RotationMotion</legend>
					<table border="0">
						<tr>
							<th colspan="2"><input type="checkbox" name="chkRotMotion">RotationMotion</th>
						</tr>
						
						<tr>
							<td>Delay Time(s):</td>
							<td><input type="text" name="delayTime" value="0"/></td>
						</tr>
						<tr>
							<td>Acc Time(s):</td>
							<td><input name="accTime" value="0.1"/></td>
						</tr>
						<tr>
							<td>Dec Time(s):</td>
							<td><input name="decTime" value="0.1"/></td>
						</tr>
						<tr>
							<td>Max Speed(deg/s):</td>
							<td><input name="maxSpeed" value="60"/></td>
						</tr>
						<tr>
							<td>Distance(deg):</td>
							<td><input name="unifTime" value="60"/></td>
						</tr>
						<tr>
							<td>Current Speed(deg/s):</td>
							<td><input name="curSpeed" placeholder="ADLINK feedback"/></td>
						</tr>
					</table>
				</fieldset>
			</form>
		</div>
	</div>
	<div id="DAQ2005">
		<form>
				<fieldset style="width:400px">
					<legend>LinearMotion</legend>
					<table border="0">
						<tr>
							<th colspan="2"><input type="checkbox" name="chkDAQ2005">DAQ2005 Enable</th>
						</tr>
						
						<tr>
							<td>Scan Intervals:</td>
							<td><input type="text" name="delayTime" value="200"/></td>
						</tr>	
						<tr>
							<td>Data Size:</td>
							<td><input name="accTime" value="100000"/></td>
						</tr>
						<tr>
							<td>Num of Ave::</td>
							<td><input name="decTime" value="100"/></td>
						</tr>
						<tr>
							<td>Exp conditions:</td>
							<td><textarea rows="4" cols="21" placeholder="Enperimental conditions content will paste in excel file at cell ('W1')" ></textarea></td>
						</tr>
						<tr>
							<td>File to Save:</td>
							<td><input name="unifTime" value="ADLINKDaq"/></td>
						</tr>
					</table>
				</fieldset>
			</form>
	</div>
	
</body>														