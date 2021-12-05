<?php
$conn = mysqli_connect("127.0.0.1", "root", "");
mysqli_select_db($conn,"segundoparcialmultimedial");
$flujo=$_GET["flujo"];
$proceso=$_GET["proceso"];
$formulario=$_GET["formulario"];
$ntramite=$_GET["tramite"];
$usuarant=$_GET["usant"];
//include $formulario.".mot.inc.php";
if (isset($_GET["Siguiente"]))
{
	$sql="select * from flujoproceso where flujo='".$flujo."' and proceso='".$proceso."'";
	$resultado=mysqli_query($conn, $sql);
	$fila=mysqli_fetch_array($resultado);
	$procesosiguiente=$fila["procesosiguiente"];
	$sql2="select * from flujoproceso where flujo='".$flujo."' and proceso='".$procesosiguiente."'";
	$resultado2=mysqli_query($conn, $sql2);
	$fila2=mysqli_fetch_array($resultado2);

	$mandara = $fila2[3];
	session_start();
	$roldesession= $_SESSION["tipo"];
	/* echo "session de </br>";
	echo $roldesession;
	echo "mandar a ";
	echo $mandara; */
	echo $ntramite;
	if ($roldesession == $mandara) {
		$sql4="UPDATE seguimiento SET fecha_fin='".date('d/M/Y')."' WHERE numerotram='".$ntramite."' and fecha_fin=''";
		$sql5="insert into seguimiento values('".$ntramite."','".$_SESSION['usuario']."','".$procesosiguiente."','".date('d/M/Y'). "','')";
		$conn->query($sql4);
		$conn->query($sql5);
		header("Location: desflujo.php?flujo=".$flujo."&proceso=".$procesosiguiente);
	} else {
		$sql4="UPDATE seguimiento SET fecha_fin='".date('d/M/Y')."' WHERE numerotram='".$ntramite."' and fecha_fin=''";
		$sql5="insert into seguimiento values('".$ntramite."','".$usuarant."','".$procesosiguiente."','".date('d/M/Y'). "','','".$_SESSION['usuario']."')";
		$conn->query($sql4);
		$conn->query($sql5);
		echo $conn->error;
		header("Location: bandeja.php");

	}
	
	


	//header("Location: desflujo.php?flujo=".$flujo."&proceso=".$procesosiguiente);
}
else if (isset($_GET["Anterior"]))
{
	$sql="select * from flujocondicionante where si='".$proceso."' or no='".$proceso."'";
	$resultado=mysqli_query($conn, $sql);
	$fila=mysqli_fetch_row($resultado);
	print_r ($fila);
	if (count($fila)!=0) {
		$proceso=$fila[0];
		header("Location: desflujo.php?flujo=".$flujo."&proceso=".$proceso);
	}else{
	$sql="select * from flujoproceso where flujo='".$flujo."' and procesosiguiente='".$proceso."'";
	$resultado=mysqli_query($conn, $sql);
	$fila=mysqli_fetch_array($resultado);
	$proceso=$fila["proceso"];
	header("Location: desflujo.php?flujo=".$flujo."&proceso=".$proceso);
	}
}else if (isset($_GET["Aceptado"]))
{
	
	$sql="select * from flujocondicionante where proceso='".$proceso."'";
	$resultado=mysqli_query($conn, $sql);
	$fila=mysqli_fetch_all($resultado);
	$proceso=$fila[0][1];
	print_r($proceso);

	$sql2="select * from flujoproceso where flujo='".$flujo."' and proceso='".$proceso."'";
	$resultado2=mysqli_query($conn, $sql2);
	$fila2=mysqli_fetch_array($resultado2);
	$mandara = $fila2[3];
	session_start();
	$roldesession= $_SESSION["tipo"];

	if ($roldesession == $mandara) {
		$sql4="UPDATE seguimiento SET fecha_fin='".date('d/M/Y')."' WHERE numerotram='".$ntramite."' and fecha_fin=''";
		$sql5="insert into seguimiento values('".$ntramite."','".$_SESSION['usuario']."','".$proceso."','".date('d/M/Y'). "','')";
		$conn->query($sql5);	
		$conn->query($sql4);
		header("Location: desflujo.php?flujo=".$flujo."&proceso=".$proceso);
	}else{
		$sql4="UPDATE seguimiento SET fecha_fin='".date('d/M/Y')."' WHERE numerotram='".$ntramite."' and fecha_fin=''";
		$sql5="insert into seguimiento values('".$ntramite."','".$usuarant."','".$proceso."','".date('d/M/Y'). "','','".$_SESSION['usuario']."')";
		$conn->query($sql4);
		$conn->query($sql5);
		echo $conn->error;
		header("Location: bandeja.php");
	}

//header("Location: desflujo.php?flujo=".$flujo."&proceso=".$proceso);

}else if (isset($_GET["Denegado"]))
{
	$sql="select * from flujocondicionante where proceso='".$proceso."'";
	$resultado=mysqli_query($conn, $sql);
	$fila=mysqli_fetch_all($resultado);
	$proceso=$fila[0][2];
	print_r($proceso);
	header("Location: desflujo.php?flujo=".$flujo."&proceso=".$proceso);

	$sql2="select * from flujoproceso where flujo='".$flujo."' and proceso='".$proceso."'";
	$resultado2=mysqli_query($conn, $sql2);
	$fila2=mysqli_fetch_array($resultado2);
	$mandara = $fila2[3];
	session_start();
	$roldesession= $_SESSION["tipo"];

	if ($roldesession == $mandara) {
		$sql4="UPDATE seguimiento SET fecha_fin='".date('d/M/Y')."' WHERE numerotram='".$ntramite."' and fecha_fin=''";
		$sql5="insert into seguimiento values('".$ntramite."','".$_SESSION['usuario']."','".$proceso."','".date('d/M/Y'). "','')";
		$conn->query($sql5);	
		$conn->query($sql4);
		header("Location: desflujo.php?flujo=".$flujo."&proceso=".$proceso);
	}else{
		$sql4="UPDATE seguimiento SET fecha_fin='".date('d/M/Y')."' WHERE numerotram='".$ntramite."' and fecha_fin=''";
		$sql5="insert into seguimiento values('".$ntramite."','".$usuarant."','".$proceso."','".date('d/M/Y'). "','','".$_SESSION['usuario']."')";
		$conn->query($sql4);
		$conn->query($sql5);
		echo $conn->error;
		header("Location: bandeja.php");
	}
}

?>
