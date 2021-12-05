<html>
	<head>
		<title>Tabla BD</title>
	</head>
<body>
	<?php
	$conn = mysqli_connect("127.0.0.1", "root", "");
	mysqli_select_db($conn,"segundoparcialmultimedial");
	$flujo=$_GET["flujo"];
	$proceso=$_GET["proceso"];
	$ntramite=$_GET["tramite"];
	$usant=$_GET["usuarante"];
	$sql="select * from flujoproceso where flujo='".$flujo."' and proceso='".$proceso."'";
	$resultado=mysqli_query($conn, $sql);
	$fila=mysqli_fetch_array($resultado);
	//include $fila['formulario'].'.cab.inc.php';
	//print_r($fila);
	//echo $flujo;
	//echo $proceso;
	session_start();
	?>
	<h1><?php echo "sesion de:  ".$_SESSION["usuario"] ?></h1>
	<form action="motflujo.php" method="GET">
		
		<?php include $fila['formulario'].'.inc.php';?>
		<br>
		<input type="hidden" value="<?php echo $fila['formulario'];?>" name="formulario"/>
		<input type="hidden" value="<?php echo $flujo?>" name="flujo"/>
		<input type="hidden" value="<?php echo $proceso?>" name="proceso"/>
		<input type="hidden" value="<?php echo $ntramite?>" name="tramite"/>
		<input type="hidden" value="<?php echo $usant?>" name="usant"/>
		<?php 
			if ($fila['tipo']=="C") {
				
				echo "<input type='submit' value='Aceptado' name='Aceptado'/>";
				echo "<input type='submit' value='Denegado' name='Denegado'/>";
				/* echo "<input type='submit' value='Anterior' name='Anterior'/>"; */
			}			
			else if ($fila['tipo']=="F") {
				# code...
			}else{
					/* echo "<input type='submit' value='Anterior' name='Anterior'/>"; */
					echo "<input type='submit' value='Siguiente' name='Siguiente'/>";
			}
		
		
		
		?>
		
		
	</form>
</body>
</html>